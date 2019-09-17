//===============================================================================
// TinyIoC - TinyMessenger
//
// A simple messenger/event aggregator.
//
// http://hg.grumpydev.com/tinyioc
//===============================================================================
// Copyright © Steven Robbins.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
// BrainOffline: Adjusted and simplified for my own use
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;

namespace Yoga.Net
{
    /// <summary>
    ///     Base class for messages that provides weak reference storage of the sender
    /// </summary>
    public abstract class TinyMessageBase
    {
        /// <summary>
        ///     Store a WeakReference to the sender just in case anyone is daft enough to
        ///     keep the message around and prevent the sender from being collected.
        /// </summary>
        readonly WeakReference _sender;

        /// <summary>
        ///     Initializes a new instance of the MessageBase class.
        /// </summary>
        /// <param name="sender">Message sender (usually "this")</param>
        protected TinyMessageBase(object sender)
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(sender));

            _sender = new WeakReference(sender);
        }

        public object Sender => _sender?.Target;
    }

    /// <summary>
    ///     Generic message with user specified content
    /// </summary>
    /// <typeparam name="TContent">Content type to store</typeparam>
    public class GenericTinyMessage<TContent> : TinyMessageBase
    {
        /// <summary>
        ///     Create a new instance of the GenericTinyMessage class.
        /// </summary>
        /// <param name="sender">Message sender (usually "this")</param>
        /// <param name="content">Contents of the message</param>
        public GenericTinyMessage(object sender, TContent content)
            : base(sender)
        {
            Content = content;
        }

        /// <summary>
        ///     Contents of the message
        /// </summary>
        public TContent Content { get; }
    }

    /// <summary>
    ///     Basic "cancellable" generic message
    /// </summary>
    /// <typeparam name="TContent">Content type to store</typeparam>
    public class CancellableGenericTinyMessage<TContent> : TinyMessageBase
    {
        /// <summary>
        ///     Create a new instance of the CancellableGenericTinyMessage class.
        /// </summary>
        /// <param name="sender">Message sender (usually "this")</param>
        /// <param name="content">Contents of the message</param>
        /// <param name="cancelAction">Action to call for cancellation</param>
        public CancellableGenericTinyMessage(object sender, TContent content, Action cancelAction)
            : base(sender)
        {
            Cancel  = cancelAction ?? throw new ArgumentNullException(nameof(cancelAction));
            Content = content;
        }

        /// <summary>
        ///     Cancel action
        /// </summary>
        public Action Cancel { get; }

        /// <summary>
        ///     Contents of the message
        /// </summary>
        public TContent Content { get; }
    }

    /// <summary>
    ///     Represents an active subscription to a message
    /// </summary>
    public sealed class TinyMessageSubscriptionToken : IDisposable
    {
        readonly WeakReference _hub;
        readonly Type _messageType;

        /// <summary>
        ///     Initializes a new instance of the TinyMessageSubscriptionToken class.
        /// </summary>
        public TinyMessageSubscriptionToken(ITinyMessengerHub hub, Type messageType)
        {
            if (hub == null)
                throw new ArgumentNullException(nameof(hub));

            _hub         = new WeakReference(hub);
            _messageType = messageType;
        }

        public void Dispose()
        {
            if (_hub.IsAlive)
            {
                if (_hub.Target is ITinyMessengerHub hub)
                {
                    var unsubscribeMethod = typeof(ITinyMessengerHub).GetMethod("Unsubscribe", new[] {typeof(TinyMessageSubscriptionToken)});
                    if (unsubscribeMethod != null)
                    {
                        unsubscribeMethod = unsubscribeMethod.MakeGenericMethod(_messageType);
                        unsubscribeMethod.Invoke(hub, new object[] {this});
                    }
                }
            }

            GC.SuppressFinalize(this);
        }
    }

    /// <summary>
    ///     Represents a message subscription
    /// </summary>
    public interface ITinyMessageSubscription
    {
        /// <summary>
        ///     Token returned to the subscribed to reference this subscription
        /// </summary>
        TinyMessageSubscriptionToken SubscriptionToken { get; }

        /// <summary>
        ///     Deliver the message
        /// </summary>
        void Deliver(object message);

        /// <summary>
        ///     Whether delivery should be attempted.
        /// </summary>
        bool ShouldAttemptDelivery(object message);
    }

    /// <summary>
    ///     Message proxy definition.
    ///     A message proxy can be used to intercept/alter messages and/or
    ///     marshall delivery actions onto a particular thread.
    /// </summary>
    public interface ITinyMessageProxy
    {
        void Deliver(object message, ITinyMessageSubscription subscription);
    }

    /// <summary>
    ///     Default "pass through" proxy.
    ///     Does nothing other than deliver the message.
    /// </summary>
    public sealed class DefaultTinyMessageProxy : ITinyMessageProxy
    {
        static DefaultTinyMessageProxy() { }

        DefaultTinyMessageProxy() { }

        /// <summary>
        ///     Singleton instance of the proxy.
        /// </summary>
        public static DefaultTinyMessageProxy Instance { get; } = new DefaultTinyMessageProxy();

        public void Deliver(object message, ITinyMessageSubscription subscription)
        {
            subscription.Deliver(message);
        }
    }

    /// <summary>
    ///     Thrown when an exceptions occurs while subscribing to a message type
    /// </summary>
    public class TinyMessengerSubscriptionException : Exception
    {
        const string ERROR_TEXT = "Unable to add subscription for {0} : {1}";

        public TinyMessengerSubscriptionException(Type messageType, string reason)
            : base(string.Format(ERROR_TEXT, messageType, reason)) { }

        public TinyMessengerSubscriptionException(Type messageType, string reason, Exception innerException)
            : base(string.Format(ERROR_TEXT, messageType, reason), innerException) { }
    }

    /// <summary>
    ///     Messenger hub responsible for taking subscriptions/publications and delivering of messages.
    /// </summary>
    public interface ITinyMessengerHub
    {
        /// <summary>
        ///     Publish a message to any subscribers
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="message">Message to deliver</param>
        void Publish<TMessage>(TMessage message) where TMessage : class;

        /// <summary>
        ///     Publish a message to any subscribers asynchronously
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="message">Message to deliver</param>
        void PublishAsync<TMessage>(TMessage message) where TMessage : class;

        /// <summary>
        ///     Publish a message to any subscribers asynchronously
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="message">Message to deliver</param>
        /// <param name="callback">AsyncCallback called on completion</param>
        void PublishAsync<TMessage>(TMessage message, AsyncCallback callback) where TMessage : class;

        /// <summary>
        ///     Subscribe to a message type with the given destination and delivery action.
        ///     All references are held with WeakReferences
        ///     All messages of this type will be delivered.
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="deliveryAction">Action to invoke when message is delivered</param>
        /// <returns>TinyMessageSubscription used to unsubscribing</returns>
        TinyMessageSubscriptionToken Subscribe<TMessage>(Action<TMessage> deliveryAction) where TMessage : class;

        /// <summary>
        ///     Subscribe to a message type with the given destination and delivery action.
        ///     Messages will be delivered via the specified proxy.
        ///     All references (apart from the proxy) are held with WeakReferences
        ///     All messages of this type will be delivered.
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="deliveryAction">Action to invoke when message is delivered</param>
        /// <param name="proxy">Proxy to use when delivering the messages</param>
        /// <returns>TinyMessageSubscription used to unsubscribing</returns>
        TinyMessageSubscriptionToken Subscribe<TMessage>(Action<TMessage> deliveryAction, ITinyMessageProxy proxy) where TMessage : class;

        /// <summary>
        ///     Subscribe to a message type with the given destination and delivery action.
        ///     All messages of this type will be delivered.
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="deliveryAction">Action to invoke when message is delivered</param>
        /// <param name="useStrongReferences">Use strong references to destination and deliveryAction </param>
        /// <returns>TinyMessageSubscription used to unsubscribing</returns>
        TinyMessageSubscriptionToken Subscribe<TMessage>(Action<TMessage> deliveryAction, bool useStrongReferences) where TMessage : class;

        /// <summary>
        ///     Subscribe to a message type with the given destination and delivery action.
        ///     Messages will be delivered via the specified proxy.
        ///     All messages of this type will be delivered.
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="deliveryAction">Action to invoke when message is delivered</param>
        /// <param name="useStrongReferences">Use strong references to destination and deliveryAction </param>
        /// <param name="proxy">Proxy to use when delivering the messages</param>
        /// <returns>TinyMessageSubscription used to unsubscribing</returns>
        TinyMessageSubscriptionToken Subscribe<TMessage>(Action<TMessage> deliveryAction, bool useStrongReferences, ITinyMessageProxy proxy) where TMessage : class;

        /// <summary>
        ///     Subscribe to a message type with the given destination and delivery action with the given filter.
        ///     All references are held with WeakReferences
        ///     Only messages that "pass" the filter will be delivered.
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="deliveryAction">Action to invoke when message is delivered</param>
        /// <param name="messageFilter">Message filter predicate</param>
        /// <returns>TinyMessageSubscription used to unsubscribing</returns>
        TinyMessageSubscriptionToken Subscribe<TMessage>(Action<TMessage> deliveryAction, Func<TMessage, bool> messageFilter) where TMessage : class;

        /// <summary>
        ///     Subscribe to a message type with the given destination and delivery action with the given filter.
        ///     Messages will be delivered via the specified proxy.
        ///     All references (apart from the proxy) are held with WeakReferences
        ///     Only messages that "pass" the filter will be delivered.
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="deliveryAction">Action to invoke when message is delivered</param>
        /// <param name="messageFilter">Message filter predicate</param>
        /// <param name="proxy">Proxy to use when delivering the messages</param>
        /// <returns>TinyMessageSubscription used to unsubscribing</returns>
        TinyMessageSubscriptionToken Subscribe<TMessage>(Action<TMessage> deliveryAction, Func<TMessage, bool> messageFilter, ITinyMessageProxy proxy) where TMessage : class;

        /// <summary>
        ///     Subscribe to a message type with the given destination and delivery action with the given filter.
        ///     All references are held with WeakReferences
        ///     Only messages that "pass" the filter will be delivered.
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="deliveryAction">Action to invoke when message is delivered</param>
        /// <param name="messageFilter">Message filter predicate</param>
        /// <param name="useStrongReferences">Use strong references to destination and deliveryAction </param>
        /// <returns>TinyMessageSubscription used to unsubscribing</returns>
        TinyMessageSubscriptionToken Subscribe<TMessage>(Action<TMessage> deliveryAction, Func<TMessage, bool> messageFilter, bool useStrongReferences) where TMessage : class;

        /// <summary>
        ///     Subscribe to a message type with the given destination and delivery action with the given filter.
        ///     Messages will be delivered via the specified proxy.
        ///     All references are held with WeakReferences
        ///     Only messages that "pass" the filter will be delivered.
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="deliveryAction">Action to invoke when message is delivered</param>
        /// <param name="messageFilter">Message filter predicate</param>
        /// <param name="useStrongReferences">Use strong references to destination and deliveryAction </param>
        /// <param name="proxy">Proxy to use when delivering the messages</param>
        /// <returns>TinyMessageSubscription used to unsubscribing</returns>
        TinyMessageSubscriptionToken Subscribe<TMessage>(Action<TMessage> deliveryAction, Func<TMessage, bool> messageFilter, bool useStrongReferences, ITinyMessageProxy proxy) where TMessage : class;

        /// <summary>
        ///     Unsubscribe from a particular message type.
        ///     Does not throw an exception if the subscription is not found.
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="subscriptionToken">Subscription token received from Subscribe</param>
        void Unsubscribe<TMessage>(TinyMessageSubscriptionToken subscriptionToken) where TMessage : class;
    }

    /// <summary>
    ///     Messenger hub responsible for taking subscriptions/publications and delivering of messages.
    /// </summary>
    public sealed class TinyMessengerHub : ITinyMessengerHub
    {
        readonly Dictionary<Type, List<SubscriptionItem>> _subscriptions = new Dictionary<Type, List<SubscriptionItem>>();

        readonly object _subscriptionsPadlock = new object();

        /// <summary>
        ///     Subscribe to a message type with the given destination and delivery action.
        ///     All references are held with strong references
        ///     All messages of this type will be delivered.
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="deliveryAction">Action to invoke when message is delivered</param>
        /// <returns>TinyMessageSubscription used to unsubscribing</returns>
        public TinyMessageSubscriptionToken Subscribe<TMessage>(Action<TMessage> deliveryAction) where TMessage : class
        {
            return AddSubscriptionInternal(deliveryAction, (m) => true, true, DefaultTinyMessageProxy.Instance);
        }

        /// <summary>
        ///     Subscribe to a message type with the given destination and delivery action.
        ///     Messages will be delivered via the specified proxy.
        ///     All references (apart from the proxy) are held with strong references
        ///     All messages of this type will be delivered.
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="deliveryAction">Action to invoke when message is delivered</param>
        /// <param name="proxy">Proxy to use when delivering the messages</param>
        /// <returns>TinyMessageSubscription used to unsubscribing</returns>
        public TinyMessageSubscriptionToken Subscribe<TMessage>(Action<TMessage> deliveryAction, ITinyMessageProxy proxy) where TMessage : class
        {
            return AddSubscriptionInternal(deliveryAction, (m) => true, true, proxy);
        }

        /// <summary>
        ///     Subscribe to a message type with the given destination and delivery action.
        ///     All messages of this type will be delivered.
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="deliveryAction">Action to invoke when message is delivered</param>
        /// <param name="useStrongReferences">Use strong references to destination and deliveryAction </param>
        /// <returns>TinyMessageSubscription used to unsubscribing</returns>
        public TinyMessageSubscriptionToken Subscribe<TMessage>(Action<TMessage> deliveryAction, bool useStrongReferences) where TMessage : class
        {
            return AddSubscriptionInternal(deliveryAction, (m) => true, useStrongReferences, DefaultTinyMessageProxy.Instance);
        }

        /// <summary>
        ///     Subscribe to a message type with the given destination and delivery action.
        ///     Messages will be delivered via the specified proxy.
        ///     All messages of this type will be delivered.
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="deliveryAction">Action to invoke when message is delivered</param>
        /// <param name="useStrongReferences">Use strong references to destination and deliveryAction </param>
        /// <param name="proxy">Proxy to use when delivering the messages</param>
        /// <returns>TinyMessageSubscription used to unsubscribing</returns>
        public TinyMessageSubscriptionToken Subscribe<TMessage>(Action<TMessage> deliveryAction, bool useStrongReferences, ITinyMessageProxy proxy) where TMessage : class
        {
            return AddSubscriptionInternal(deliveryAction, (m) => true, useStrongReferences, proxy);
        }

        /// <summary>
        ///     Subscribe to a message type with the given destination and delivery action with the given filter.
        ///     All references are held with WeakReferences
        ///     Only messages that "pass" the filter will be delivered.
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="deliveryAction">Action to invoke when message is delivered</param>
        /// <param name="messageFilter">Message filter predicate</param>
        /// <returns>TinyMessageSubscription used to unsubscribing</returns>
        public TinyMessageSubscriptionToken Subscribe<TMessage>(Action<TMessage> deliveryAction, Func<TMessage, bool> messageFilter) where TMessage : class
        {
            return AddSubscriptionInternal(deliveryAction, messageFilter, true, DefaultTinyMessageProxy.Instance);
        }

        /// <summary>
        ///     Subscribe to a message type with the given destination and delivery action with the given filter.
        ///     Messages will be delivered via the specified proxy.
        ///     All references (apart from the proxy) are held with WeakReferences
        ///     Only messages that "pass" the filter will be delivered.
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="deliveryAction">Action to invoke when message is delivered</param>
        /// <param name="messageFilter">Message filter predicate</param>
        /// <param name="proxy">Proxy to use when delivering the messages</param>
        /// <returns>TinyMessageSubscription used to unsubscribing</returns>
        public TinyMessageSubscriptionToken Subscribe<TMessage>(Action<TMessage> deliveryAction, Func<TMessage, bool> messageFilter, ITinyMessageProxy proxy) where TMessage : class
        {
            return AddSubscriptionInternal(deliveryAction, messageFilter, true, proxy);
        }

        /// <summary>
        ///     Subscribe to a message type with the given destination and delivery action with the given filter.
        ///     All references are held with WeakReferences
        ///     Only messages that "pass" the filter will be delivered.
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="deliveryAction">Action to invoke when message is delivered</param>
        /// <param name="messageFilter">Message filter predicate</param>
        /// <param name="useStrongReferences">Use strong references to destination and deliveryAction </param>
        /// <returns>TinyMessageSubscription used to unsubscribing</returns>
        public TinyMessageSubscriptionToken Subscribe<TMessage>(Action<TMessage> deliveryAction, Func<TMessage, bool> messageFilter, bool useStrongReferences) where TMessage : class
        {
            return AddSubscriptionInternal(deliveryAction, messageFilter, useStrongReferences, DefaultTinyMessageProxy.Instance);
        }

        /// <summary>
        ///     Subscribe to a message type with the given destination and delivery action with the given filter.
        ///     Messages will be delivered via the specified proxy.
        ///     All references are held with WeakReferences
        ///     Only messages that "pass" the filter will be delivered.
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="deliveryAction">Action to invoke when message is delivered</param>
        /// <param name="messageFilter">Message filter predicate</param>
        /// <param name="useStrongReferences">Use strong references to destination and deliveryAction </param>
        /// <param name="proxy">Proxy to use when delivering the messages</param>
        /// <returns>TinyMessageSubscription used to unsubscribing</returns>
        public TinyMessageSubscriptionToken Subscribe<TMessage>(Action<TMessage> deliveryAction, Func<TMessage, bool> messageFilter, bool useStrongReferences, ITinyMessageProxy proxy) where TMessage : class
        {
            return AddSubscriptionInternal(deliveryAction, messageFilter, useStrongReferences, proxy);
        }

        /// <summary>
        ///     Unsubscribe from a particular message type.
        ///     Does not throw an exception if the subscription is not found.
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="subscriptionToken">Subscription token received from Subscribe</param>
        public void Unsubscribe<TMessage>(TinyMessageSubscriptionToken subscriptionToken) where TMessage : class
        {
            RemoveSubscriptionInternal<TMessage>(subscriptionToken);
        }

        /// <summary>
        ///     Publish a message to any subscribers
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="message">Message to deliver</param>
        public void Publish<TMessage>(TMessage message) where TMessage : class
        {
            PublishInternal(message);
        }

        /// <summary>
        ///     Publish a message to any subscribers asynchronously
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="message">Message to deliver</param>
        public void PublishAsync<TMessage>(TMessage message) where TMessage : class
        {
            PublishAsyncInternal(message, null);
        }

        /// <summary>
        ///     Publish a message to any subscribers asynchronously
        /// </summary>
        /// <typeparam name="TMessage">Type of message</typeparam>
        /// <param name="message">Message to deliver</param>
        /// <param name="callback">AsyncCallback called on completion</param>
        public void PublishAsync<TMessage>(TMessage message, AsyncCallback callback) where TMessage : class
        {
            PublishAsyncInternal(message, callback);
        }

        TinyMessageSubscriptionToken AddSubscriptionInternal<TMessage>(Action<TMessage> deliveryAction, Func<TMessage, bool> messageFilter, bool strongReference, ITinyMessageProxy proxy)
            where TMessage : class
        {
            if (deliveryAction == null)
                throw new ArgumentNullException(nameof(deliveryAction));

            if (messageFilter == null)
                throw new ArgumentNullException(nameof(messageFilter));

            if (proxy == null)
                throw new ArgumentNullException(nameof(proxy));

            lock (_subscriptionsPadlock)
            {
                if (!_subscriptions.TryGetValue(typeof(TMessage), out var currentSubscriptions))
                {
                    currentSubscriptions             = new List<SubscriptionItem>();
                    _subscriptions[typeof(TMessage)] = currentSubscriptions;
                }

                var subscriptionToken = new TinyMessageSubscriptionToken(this, typeof(TMessage));

                ITinyMessageSubscription subscription;
                if (strongReference)
                    subscription = new StrongTinyMessageSubscription<TMessage>(subscriptionToken, deliveryAction, messageFilter);
                else
                    subscription = new WeakTinyMessageSubscription<TMessage>(subscriptionToken, deliveryAction, messageFilter);

                currentSubscriptions.Add(new SubscriptionItem(proxy, subscription));

                return subscriptionToken;
            }
        }

        void PublishAsyncInternal<TMessage>(TMessage message, AsyncCallback callback) where TMessage : class
        {
            Action publishAction = () => { PublishInternal(message); };

            publishAction.BeginInvoke(callback, null);
        }

        void PublishInternal<TMessage>(TMessage message)
            where TMessage : class
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            List<SubscriptionItem> currentlySubscribed;
            lock (_subscriptionsPadlock)
            {
                if (!_subscriptions.TryGetValue(typeof(TMessage), out var currentSubscriptions))
                    return;

                currentlySubscribed = (from sub in currentSubscriptions
                    where sub.Subscription.ShouldAttemptDelivery(message)
                    select sub).ToList();
            }

            currentlySubscribed.ForEach(
                sub =>
                {
                    try
                    {
                        sub.Proxy.Deliver(message, sub.Subscription);
                    }
                    catch (Exception)
                    {
                        // Ignore any errors and carry on
                        // TODO - add to a list of erroring subs and remove them?
                    }
                });
        }

        void RemoveSubscriptionInternal<TMessage>(TinyMessageSubscriptionToken subscriptionToken)
            where TMessage : class
        {
            if (subscriptionToken == null)
                throw new ArgumentNullException(nameof(subscriptionToken));

            lock (_subscriptionsPadlock)
            {
                if (!_subscriptions.TryGetValue(typeof(TMessage), out var currentSubscriptions))
                    return;

                var currentlySubscribed = (from sub in currentSubscriptions
                    where ReferenceEquals(sub.Subscription.SubscriptionToken, subscriptionToken)
                    select sub).ToList();

                currentlySubscribed.ForEach(sub => currentSubscriptions.Remove(sub));
            }
        }

        class WeakTinyMessageSubscription<TMessage> : ITinyMessageSubscription
            where TMessage : class
        {
            readonly WeakReference _deliveryAction;
            readonly WeakReference _messageFilter;

            /// <summary>
            ///     Initializes a new instance of the WeakTinyMessageSubscription class.
            /// </summary>
            /// <param name="subscriptionToken">Destination object</param>
            /// <param name="deliveryAction">Delivery action</param>
            /// <param name="messageFilter">Filter function</param>
            public WeakTinyMessageSubscription(TinyMessageSubscriptionToken subscriptionToken, Action<TMessage> deliveryAction, Func<TMessage, bool> messageFilter)
            {
                if (deliveryAction == null)
                    throw new ArgumentNullException(nameof(deliveryAction));

                if (messageFilter == null)
                    throw new ArgumentNullException(nameof(messageFilter));

                SubscriptionToken = subscriptionToken ?? throw new ArgumentNullException(nameof(subscriptionToken));
                _deliveryAction   = new WeakReference(deliveryAction);
                _messageFilter    = new WeakReference(messageFilter);
            }

            public TinyMessageSubscriptionToken SubscriptionToken { get; }

            public bool ShouldAttemptDelivery(object message)
            {
                if (!(message is TMessage))
                    return false;

                if (!_deliveryAction.IsAlive)
                    return false;

                if (!_messageFilter.IsAlive)
                    return false;

                return ((Func<TMessage, bool>)_messageFilter.Target).Invoke((TMessage)message);
            }

            public void Deliver(object message)
            {
                if (!(message is TMessage))
                    throw new ArgumentException("Message is not the correct type");

                if (!_deliveryAction.IsAlive)
                    return;

                ((Action<TMessage>)_deliveryAction.Target).Invoke((TMessage)message);
            }
        }

        class StrongTinyMessageSubscription<TMessage> : ITinyMessageSubscription
            where TMessage : class
        {
            readonly Action<TMessage> _deliveryAction;
            readonly Func<TMessage, bool> _messageFilter;

            /// <summary>
            ///     Initializes a new instance of the TinyMessageSubscription class.
            /// </summary>
            /// <param name="subscriptionToken">Destination object</param>
            /// <param name="deliveryAction">Delivery action</param>
            /// <param name="messageFilter">Filter function</param>
            public StrongTinyMessageSubscription(TinyMessageSubscriptionToken subscriptionToken, Action<TMessage> deliveryAction, Func<TMessage, bool> messageFilter)
            {
                SubscriptionToken = subscriptionToken ?? throw new ArgumentNullException(nameof(subscriptionToken));
                _deliveryAction   = deliveryAction ?? throw new ArgumentNullException(nameof(deliveryAction));
                _messageFilter    = messageFilter ?? throw new ArgumentNullException(nameof(messageFilter));
            }

            public TinyMessageSubscriptionToken SubscriptionToken { get; }

            public bool ShouldAttemptDelivery(object message)
            {
                if (!(message is TMessage))
                    return false;

                return _messageFilter.Invoke((TMessage)message);
            }

            public void Deliver(object message)
            {
                if (!(message is TMessage))
                    throw new ArgumentException("Message is not the correct type");

                _deliveryAction.Invoke((TMessage)message);
            }
        }

        class SubscriptionItem
        {
            public SubscriptionItem(ITinyMessageProxy proxy, ITinyMessageSubscription subscription)
            {
                Proxy        = proxy;
                Subscription = subscription;
            }

            public ITinyMessageProxy Proxy { get; }
            public ITinyMessageSubscription Subscription { get; }
        }
    }
}
