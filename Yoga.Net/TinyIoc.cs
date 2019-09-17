//===============================================================================
// TinyIoC
//
// An easy to use, hassle free, Inversion of Control Container for small projects
// and beginners alike.
//
// https://github.com/grumpydev/TinyIoC
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
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;

namespace Yoga.Net
{
    public class SafeDictionary<TKey, TValue> : IDisposable
    {
        readonly Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();
        readonly ReaderWriterLockSlim _padlock = new ReaderWriterLockSlim();

        public TValue this[TKey key]
        {
            set
            {
                _padlock.EnterWriteLock();

                try
                {
                    if (_dictionary.TryGetValue(key, out var current))
                    {
                        if (current is IDisposable disposable)
                            disposable.Dispose();
                    }

                    _dictionary[key] = value;
                }
                finally
                {
                    _padlock.ExitWriteLock();
                }
            }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                _padlock.EnterReadLock();
                try
                {
                    return new List<TKey>(_dictionary.Keys);
                }
                finally
                {
                    _padlock.ExitReadLock();
                }
            }
        }

        public void Dispose()
        {
            _padlock.EnterWriteLock();

            try
            {
                var disposableItems = from item in _dictionary.Values
                    where item is IDisposable
                    select item as IDisposable;

                foreach (var item in disposableItems)
                {
                    item.Dispose();
                }
            }
            finally
            {
                _padlock.ExitWriteLock();
            }

            GC.SuppressFinalize(this);
        }

        public void Clear()
        {
            _padlock.EnterWriteLock();
            try
            {
                _dictionary.Clear();
            }
            finally
            {
                _padlock.ExitWriteLock();
            }
        }

        public bool Remove(TKey key)
        {
            _padlock.EnterWriteLock();
            try
            {
                return _dictionary.Remove(key);
            }
            finally
            {
                _padlock.ExitWriteLock();
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            _padlock.EnterReadLock();
            try
            {
                return _dictionary.TryGetValue(key, out value);
            }
            finally
            {
                _padlock.ExitReadLock();
            }
        }
    }

    public static class AssemblyExtensions
    {
        public static Type[] SafeGetTypes(this Assembly assembly)
        {
            Type[] assemblies;

            try
            {
                assemblies = assembly.GetTypes();
            }
            catch (FileNotFoundException)
            {
                assemblies = new Type[] { };
            }
            catch (NotSupportedException)
            {
                assemblies = new Type[] { };
            }
            catch (ReflectionTypeLoadException e)
            {
                assemblies = e.Types.Where(t => t != null).ToArray();
            }

            return assemblies;
        }
    }

    public static class TypeExtensions
    {
        static readonly SafeDictionary<GenericMethodCacheKey, MethodInfo> _genericMethodCache;

        static TypeExtensions()
        {
            _genericMethodCache = new SafeDictionary<GenericMethodCacheKey, MethodInfo>();
        }


        /// <summary>
        ///     Gets a generic method from a type given the method name, binding flags, generic types and parameter types
        /// </summary>
        /// <param name="sourceType">Source type</param>
        /// <param name="bindingFlags">Binding flags</param>
        /// <param name="methodName">Name of the method</param>
        /// <param name="genericTypes">Generic types to use to make the method generic</param>
        /// <param name="parameterTypes">Method parameters</param>
        /// <returns>MethodInfo or null if no matches found</returns>
        /// <exception cref="System.Reflection.AmbiguousMatchException" />
        /// <exception cref="System.ArgumentException" />
        public static MethodInfo GetGenericMethod(this Type sourceType, BindingFlags bindingFlags, string methodName, Type[] genericTypes, Type[] parameterTypes)
        {
            var cacheKey = new GenericMethodCacheKey(sourceType, methodName, genericTypes, parameterTypes);

            // Shouldn't need any additional locking
            // we don't care if we do the method info generation
            // more than once before it gets cached.
            if (!_genericMethodCache.TryGetValue(cacheKey, out var method))
            {
                method                        = GetMethod(sourceType, bindingFlags, methodName, genericTypes, parameterTypes);
                _genericMethodCache[cacheKey] = method;
            }

            return method;
        }

        static MethodInfo GetMethod(Type sourceType, BindingFlags bindingFlags, string methodName, Type[] genericTypes, Type[] parameterTypes)
        {
            var methods =
                sourceType.GetMethods(bindingFlags).Where(
                    mi => string.Equals(methodName, mi.Name, StringComparison.Ordinal)).Where(
                    mi => mi.ContainsGenericParameters).Where(mi => mi.GetGenericArguments().Length == genericTypes.Length).Where(mi => mi.GetParameters().Length == parameterTypes.Length).Select(
                    mi => mi.MakeGenericMethod(genericTypes)).Where(
                    mi => mi.GetParameters().Select(pi => pi.ParameterType).SequenceEqual(parameterTypes)).ToList();

            if (methods.Count > 1)
            {
                throw new AmbiguousMatchException();
            }

            return methods.FirstOrDefault();
        }

        sealed class GenericMethodCacheKey
        {
            readonly Type[] _genericTypes;

            readonly int _hashCode;

            readonly string _methodName;

            readonly Type[] _parameterTypes;
            readonly Type _sourceType;

            public GenericMethodCacheKey(Type sourceType, string methodName, Type[] genericTypes, Type[] parameterTypes)
            {
                _sourceType     = sourceType;
                _methodName     = methodName;
                _genericTypes   = genericTypes;
                _parameterTypes = parameterTypes;
                _hashCode       = GenerateHashCode();
            }

            public override bool Equals(object obj)
            {
                var cacheKey = obj as GenericMethodCacheKey;
                if (cacheKey == null)
                    return false;

                if (_sourceType != cacheKey._sourceType)
                    return false;

                if (!string.Equals(_methodName, cacheKey._methodName, StringComparison.Ordinal))
                    return false;

                if (_genericTypes.Length != cacheKey._genericTypes.Length)
                    return false;

                if (_parameterTypes.Length != cacheKey._parameterTypes.Length)
                    return false;

                for (var i = 0; i < _genericTypes.Length; ++i)
                {
                    if (_genericTypes[i] != cacheKey._genericTypes[i])
                        return false;
                }

                for (var i = 0; i < _parameterTypes.Length; ++i)
                {
                    if (_parameterTypes[i] != cacheKey._parameterTypes[i])
                        return false;
                }

                return true;
            }

            public override int GetHashCode()
            {
                return _hashCode;
            }

            int GenerateHashCode()
            {
                unchecked
                {
                    var result = _sourceType.GetHashCode();

                    result = (result * 397) ^ _methodName.GetHashCode();

                    for (var i = 0; i < _genericTypes.Length; ++i)
                    {
                        result = (result * 397) ^ _genericTypes[i].GetHashCode();
                    }

                    for (var i = 0; i < _parameterTypes.Length; ++i)
                    {
                        result = (result * 397) ^ _parameterTypes[i].GetHashCode();
                    }

                    return result;
                }
            }
        }
    }


    [Serializable]
    public
        class TinyIoCResolutionException : Exception
    {
        const string ERROR_TEXT = "Unable to resolve type: {0}";

        public TinyIoCResolutionException(Type type)
            : base(string.Format(ERROR_TEXT, type.FullName)) { }

        public TinyIoCResolutionException(Type type, Exception innerException)
            : base(string.Format(ERROR_TEXT, type.FullName), innerException) { }

        protected TinyIoCResolutionException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public
        class TinyIoCRegistrationTypeException : Exception
    {
        const string REGISTER_ERROR_TEXT = "Cannot register type {0} - abstract classes or interfaces are not valid implementation types for {1}.";

        public TinyIoCRegistrationTypeException(Type type, string factory)
            : base(string.Format(REGISTER_ERROR_TEXT, type.FullName, factory)) { }

        public TinyIoCRegistrationTypeException(Type type, string factory, Exception innerException)
            : base(string.Format(REGISTER_ERROR_TEXT, type.FullName, factory), innerException) { }

        protected TinyIoCRegistrationTypeException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public
        class TinyIoCRegistrationException : Exception
    {
        const string CONVERT_ERROR_TEXT = "Cannot convert current registration of {0} to {1}";
        const string GENERIC_CONSTRAINT_ERROR_TEXT = "Type {1} is not valid for a registration of type {0}";

        public TinyIoCRegistrationException(Type type, string method)
            : base(string.Format(CONVERT_ERROR_TEXT, type.FullName, method)) { }

        public TinyIoCRegistrationException(Type type, string method, Exception innerException)
            : base(string.Format(CONVERT_ERROR_TEXT, type.FullName, method), innerException) { }

        public TinyIoCRegistrationException(Type registerType, Type implementationType)
            : base(string.Format(GENERIC_CONSTRAINT_ERROR_TEXT, registerType.FullName, implementationType.FullName)) { }

        public TinyIoCRegistrationException(Type registerType, Type implementationType, Exception innerException)
            : base(string.Format(GENERIC_CONSTRAINT_ERROR_TEXT, registerType.FullName, implementationType.FullName), innerException) { }

        protected TinyIoCRegistrationException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public
        class TinyIoCWeakReferenceException : Exception
    {
        const string ERROR_TEXT = "Unable to instantiate {0} - referenced object has been reclaimed";

        public TinyIoCWeakReferenceException(Type type)
            : base(string.Format(ERROR_TEXT, type.FullName)) { }

        public TinyIoCWeakReferenceException(Type type, Exception innerException)
            : base(string.Format(ERROR_TEXT, type.FullName), innerException) { }

        protected TinyIoCWeakReferenceException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public
        class TinyIoCConstructorResolutionException : Exception
    {
        const string ERROR_TEXT = "Unable to resolve constructor for {0} using provided Expression.";

        public TinyIoCConstructorResolutionException(Type type)
            : base(string.Format(ERROR_TEXT, type.FullName)) { }

        public TinyIoCConstructorResolutionException(Type type, Exception innerException)
            : base(string.Format(ERROR_TEXT, type.FullName), innerException) { }

        public TinyIoCConstructorResolutionException(string message, Exception innerException)
            : base(message, innerException) { }

        public TinyIoCConstructorResolutionException(string message)
            : base(message) { }

        protected TinyIoCConstructorResolutionException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public
        class TinyIoCAutoRegistrationException : Exception
    {
        const string ERROR_TEXT = "Duplicate implementation of type {0} found ({1}).";

        public TinyIoCAutoRegistrationException(Type registerType, IEnumerable<Type> types)
            : base(string.Format(ERROR_TEXT, registerType, GetTypesString(types))) { }

        public TinyIoCAutoRegistrationException(Type registerType, IEnumerable<Type> types, Exception innerException)
            : base(string.Format(ERROR_TEXT, registerType, GetTypesString(types)), innerException) { }

        protected TinyIoCAutoRegistrationException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        static string GetTypesString(IEnumerable<Type> types)
        {
            var typeNames = from type in types
                select type.FullName;

            return string.Join(",", typeNames.ToArray());
        }
    }

    /// <summary>
    ///     Name/Value pairs for specifying "user" parameters when resolving
    /// </summary>
    public
        sealed class NamedParameterOverloads : Dictionary<string, object>
    {
        public NamedParameterOverloads() { }

        public NamedParameterOverloads(IDictionary<string, object> data)
            : base(data) { }

        public static NamedParameterOverloads Default { get; } = new NamedParameterOverloads();

        public static NamedParameterOverloads FromIDictionary(IDictionary<string, object> data)
        {
            return data as NamedParameterOverloads ?? new NamedParameterOverloads(data);
        }
    }

    public
        enum UnregisteredResolutionActions
    {
        /// <summary>
        ///     Attempt to resolve type, even if the type isn't registered.
        ///     Registered types/options will always take precedence.
        /// </summary>
        AttemptResolve,

        /// <summary>
        ///     Fail resolution if type not explicitly registered
        /// </summary>
        Fail,

        /// <summary>
        ///     Attempt to resolve unregistered type if requested type is generic
        ///     and no registration exists for the specific generic parameters used.
        ///     Registered types/options will always take precedence.
        /// </summary>
        GenericsOnly
    }

    public
        enum NamedResolutionFailureActions
    {
        AttemptUnnamedResolution,
        Fail
    }

    public
        enum DuplicateImplementationActions
    {
        RegisterSingle,
        RegisterMultiple,
        Fail
    }

    /// <summary>
    ///     Resolution settings
    /// </summary>
    public
        sealed class ResolveOptions
    {
        /// <summary>
        ///     Gets the default options (attempt resolution of unregistered types, fail on named resolution if name not found)
        /// </summary>
        public static ResolveOptions Default { get; } = new ResolveOptions();

        /// <summary>
        ///     Preconfigured option for attempting resolution of unregistered types and failing on named resolution if name not
        ///     found
        /// </summary>
        public static ResolveOptions FailNameNotFoundOnly { get; } = new ResolveOptions() {NamedResolutionFailureAction = NamedResolutionFailureActions.Fail, UnregisteredResolutionAction = UnregisteredResolutionActions.AttemptResolve};

        /// <summary>
        ///     Preconfigured option for failing on resolving unregistered types and on named resolution if name not found
        /// </summary>
        public static ResolveOptions FailUnregisteredAndNameNotFound { get; } = new ResolveOptions() {NamedResolutionFailureAction = NamedResolutionFailureActions.Fail, UnregisteredResolutionAction = UnregisteredResolutionActions.Fail};

        /// <summary>
        ///     Preconfigured option for failing on resolving unregistered types, but attempting unnamed resolution if name not
        ///     found
        /// </summary>
        public static ResolveOptions FailUnregisteredOnly { get; } = new ResolveOptions() {NamedResolutionFailureAction = NamedResolutionFailureActions.AttemptUnnamedResolution, UnregisteredResolutionAction = UnregisteredResolutionActions.Fail};

        public NamedResolutionFailureActions NamedResolutionFailureAction { get; set; } = NamedResolutionFailureActions.Fail;

        public UnregisteredResolutionActions UnregisteredResolutionAction { get; set; } = UnregisteredResolutionActions.AttemptResolve;
    }


    public sealed class TinyIoCContainer : IDisposable
    {
        static readonly SafeDictionary<ConstructorInfo, ObjectConstructor> _objectConstructorCache = new SafeDictionary<ConstructorInfo, ObjectConstructor>();

        readonly object _autoRegisterLock = new object();

        readonly TinyIoCContainer _parent;

        readonly SafeDictionary<TypeRegistration, ObjectFactoryBase> _registeredTypes;

        bool _disposed;

        static TinyIoCContainer() { }

        public TinyIoCContainer()
        {
            _registeredTypes = new SafeDictionary<TypeRegistration, ObjectFactoryBase>();

            RegisterDefaultTypes();
        }

        TinyIoCContainer(TinyIoCContainer parent)
            : this()
        {
            _parent = parent;
        }

        /// <summary>
        ///     Lazy created Singleton instance of the container for simple scenarios
        /// </summary>
        public static TinyIoCContainer Current { get; } = new TinyIoCContainer();

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;

                _registeredTypes.Dispose();

                GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        ///     Attempt to automatically register all non-generic classes and interfaces in the current app domain.
        ///     If more than one class implements an interface then only one implementation will be registered
        ///     although no error will be thrown.
        /// </summary>
        public void AutoRegister()
        {
            AutoRegisterInternal(AppDomain.CurrentDomain.GetAssemblies().Where(a => !IsIgnoredAssembly(a)), DuplicateImplementationActions.RegisterSingle, null);
        }

        /// <summary>
        ///     Attempt to automatically register all non-generic classes and interfaces in the current app domain.
        ///     Types will only be registered if they pass the supplied registration predicate.
        ///     If more than one class implements an interface then only one implementation will be registered
        ///     although no error will be thrown.
        /// </summary>
        /// <param name="registrationPredicate">Predicate to determine if a particular type should be registered</param>
        public void AutoRegister(Func<Type, bool> registrationPredicate)
        {
            AutoRegisterInternal(AppDomain.CurrentDomain.GetAssemblies().Where(a => !IsIgnoredAssembly(a)), DuplicateImplementationActions.RegisterSingle, registrationPredicate);
        }

        /// <summary>
        ///     Attempt to automatically register all non-generic classes and interfaces in the current app domain.
        /// </summary>
        /// <param name="duplicateAction">
        ///     What action to take when encountering duplicate implementations of an interface/base
        ///     class.
        /// </param>
        /// <exception cref="TinyIoCAutoRegistrationException" />
        public void AutoRegister(DuplicateImplementationActions duplicateAction)
        {
            AutoRegisterInternal(AppDomain.CurrentDomain.GetAssemblies().Where(a => !IsIgnoredAssembly(a)), duplicateAction, null);
        }

        /// <summary>
        ///     Attempt to automatically register all non-generic classes and interfaces in the current app domain.
        ///     Types will only be registered if they pass the supplied registration predicate.
        /// </summary>
        /// <param name="duplicateAction">
        ///     What action to take when encountering duplicate implementations of an interface/base
        ///     class.
        /// </param>
        /// <param name="registrationPredicate">Predicate to determine if a particular type should be registered</param>
        /// <exception cref="TinyIoCAutoRegistrationException" />
        public void AutoRegister(DuplicateImplementationActions duplicateAction, Func<Type, bool> registrationPredicate)
        {
            AutoRegisterInternal(AppDomain.CurrentDomain.GetAssemblies().Where(a => !IsIgnoredAssembly(a)), duplicateAction, registrationPredicate);
        }

        /// <summary>
        ///     Attempt to automatically register all non-generic classes and interfaces in the specified assemblies
        ///     If more than one class implements an interface then only one implementation will be registered
        ///     although no error will be thrown.
        /// </summary>
        /// <param name="assemblies">Assemblies to process</param>
        public void AutoRegister(IEnumerable<Assembly> assemblies)
        {
            AutoRegisterInternal(assemblies, DuplicateImplementationActions.RegisterSingle, null);
        }

        /// <summary>
        ///     Attempt to automatically register all non-generic classes and interfaces in the specified assemblies
        ///     Types will only be registered if they pass the supplied registration predicate.
        ///     If more than one class implements an interface then only one implementation will be registered
        ///     although no error will be thrown.
        /// </summary>
        /// <param name="assemblies">Assemblies to process</param>
        /// <param name="registrationPredicate">Predicate to determine if a particular type should be registered</param>
        public void AutoRegister(IEnumerable<Assembly> assemblies, Func<Type, bool> registrationPredicate)
        {
            AutoRegisterInternal(assemblies, DuplicateImplementationActions.RegisterSingle, registrationPredicate);
        }

        /// <summary>
        ///     Attempt to automatically register all non-generic classes and interfaces in the specified assemblies
        /// </summary>
        /// <param name="assemblies">Assemblies to process</param>
        /// <param name="duplicateAction">
        ///     What action to take when encountering duplicate implementations of an interface/base
        ///     class.
        /// </param>
        /// <exception cref="TinyIoCAutoRegistrationException" />
        public void AutoRegister(IEnumerable<Assembly> assemblies, DuplicateImplementationActions duplicateAction)
        {
            AutoRegisterInternal(assemblies, duplicateAction, null);
        }

        /// <summary>
        ///     Attempt to automatically register all non-generic classes and interfaces in the specified assemblies
        ///     Types will only be registered if they pass the supplied registration predicate.
        /// </summary>
        /// <param name="assemblies">Assemblies to process</param>
        /// <param name="duplicateAction">
        ///     What action to take when encountering duplicate implementations of an interface/base
        ///     class.
        /// </param>
        /// <param name="registrationPredicate">Predicate to determine if a particular type should be registered</param>
        /// <exception cref="TinyIoCAutoRegistrationException" />
        public void AutoRegister(IEnumerable<Assembly> assemblies, DuplicateImplementationActions duplicateAction, Func<Type, bool> registrationPredicate)
        {
            AutoRegisterInternal(assemblies, duplicateAction, registrationPredicate);
        }

        /// <summary>
        ///     Attempts to resolve all public property dependencies on the given object.
        /// </summary>
        /// <param name="input">Object to "build up"</param>
        public void BuildUp(object input)
        {
            BuildUpInternal(input, ResolveOptions.Default);
        }

        /// <summary>
        ///     Attempts to resolve all public property dependencies on the given object using the given resolve options.
        /// </summary>
        /// <param name="input">Object to "build up"</param>
        /// <param name="resolveOptions">Resolve options to use</param>
        public void BuildUp(object input, ResolveOptions resolveOptions)
        {
            BuildUpInternal(input, resolveOptions);
        }

        /// <summary>
        ///     Attempts to predict whether a given type can be resolved with default options.
        ///     Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve(Type resolveType)
        {
            return CanResolveInternal(new TypeRegistration(resolveType), NamedParameterOverloads.Default, ResolveOptions.Default);
        }

        /// <summary>
        ///     Attempts to predict whether a given type can be resolved with the specified options.
        ///     Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="options">Resolution options</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve(Type resolveType, ResolveOptions options)
        {
            return CanResolveInternal(new TypeRegistration(resolveType), NamedParameterOverloads.Default, options);
        }

        /// <summary>
        ///     Attempts to predict whether a given named type can be resolved with the specified options.
        ///     Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="name">Name of registration</param>
        /// <param name="options">Resolution options</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve(Type resolveType, string name, ResolveOptions options)
        {
            return CanResolveInternal(new TypeRegistration(resolveType, name), NamedParameterOverloads.Default, options);
        }

        /// <summary>
        ///     Attempts to predict whether a given type can be resolved with the supplied constructor parameters and default
        ///     options.
        ///     Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one
        ///     exists).
        ///     All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will
        ///     fail.
        ///     Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="parameters">User supplied named parameter overloads</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve(Type resolveType, NamedParameterOverloads parameters)
        {
            return CanResolveInternal(new TypeRegistration(resolveType), parameters, ResolveOptions.Default);
        }

        /// <summary>
        ///     Attempts to predict whether a given named type can be resolved with the supplied constructor parameters and default
        ///     options.
        ///     Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one
        ///     exists).
        ///     All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will
        ///     fail.
        ///     Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="name">Name of registration</param>
        /// <param name="parameters">User supplied named parameter overloads</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve(Type resolveType, string name, NamedParameterOverloads parameters)
        {
            return CanResolveInternal(new TypeRegistration(resolveType, name), parameters, ResolveOptions.Default);
        }

        /// <summary>
        ///     Attempts to predict whether a given type can be resolved with the supplied constructor parameters options.
        ///     Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one
        ///     exists).
        ///     All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will
        ///     fail.
        ///     Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="parameters">User supplied named parameter overloads</param>
        /// <param name="options">Resolution options</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve(Type resolveType, NamedParameterOverloads parameters, ResolveOptions options)
        {
            return CanResolveInternal(new TypeRegistration(resolveType), parameters, options);
        }

        /// <summary>
        ///     Attempts to predict whether a given named type can be resolved with the supplied constructor parameters options.
        ///     Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one
        ///     exists).
        ///     All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will
        ///     fail.
        ///     Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="name">Name of registration</param>
        /// <param name="parameters">User supplied named parameter overloads</param>
        /// <param name="options">Resolution options</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve(Type resolveType, string name, NamedParameterOverloads parameters, ResolveOptions options)
        {
            return CanResolveInternal(new TypeRegistration(resolveType, name), parameters, options);
        }

        /// <summary>
        ///     Attempts to predict whether a given type can be resolved with default options.
        ///     Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve<TResolveType>()
            where TResolveType : class
        {
            return CanResolve(typeof(TResolveType));
        }

        /// <summary>
        ///     Attempts to predict whether a given named type can be resolved with default options.
        ///     Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve<TResolveType>(string name)
            where TResolveType : class
        {
            return CanResolve(typeof(TResolveType), name);
        }

        /// <summary>
        ///     Attempts to predict whether a given type can be resolved with the specified options.
        ///     Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="options">Resolution options</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve<TResolveType>(ResolveOptions options)
            where TResolveType : class
        {
            return CanResolve(typeof(TResolveType), options);
        }

        /// <summary>
        ///     Attempts to predict whether a given named type can be resolved with the specified options.
        ///     Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="name">Name of registration</param>
        /// <param name="options">Resolution options</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve<TResolveType>(string name, ResolveOptions options)
            where TResolveType : class
        {
            return CanResolve(typeof(TResolveType), name, options);
        }

        /// <summary>
        ///     Attempts to predict whether a given type can be resolved with the supplied constructor parameters and default
        ///     options.
        ///     Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one
        ///     exists).
        ///     All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will
        ///     fail.
        ///     Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="parameters">User supplied named parameter overloads</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve<TResolveType>(NamedParameterOverloads parameters)
            where TResolveType : class
        {
            return CanResolve(typeof(TResolveType), parameters);
        }

        /// <summary>
        ///     Attempts to predict whether a given named type can be resolved with the supplied constructor parameters and default
        ///     options.
        ///     Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one
        ///     exists).
        ///     All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will
        ///     fail.
        ///     Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="name">Name of registration</param>
        /// <param name="parameters">User supplied named parameter overloads</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve<TResolveType>(string name, NamedParameterOverloads parameters)
            where TResolveType : class
        {
            return CanResolve(typeof(TResolveType), name, parameters);
        }

        /// <summary>
        ///     Attempts to predict whether a given type can be resolved with the supplied constructor parameters options.
        ///     Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one
        ///     exists).
        ///     All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will
        ///     fail.
        ///     Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="parameters">User supplied named parameter overloads</param>
        /// <param name="options">Resolution options</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve<TResolveType>(NamedParameterOverloads parameters, ResolveOptions options)
            where TResolveType : class
        {
            return CanResolve(typeof(TResolveType), parameters, options);
        }

        /// <summary>
        ///     Attempts to predict whether a given named type can be resolved with the supplied constructor parameters options.
        ///     Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one
        ///     exists).
        ///     All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will
        ///     fail.
        ///     Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="name">Name of registration</param>
        /// <param name="parameters">User supplied named parameter overloads</param>
        /// <param name="options">Resolution options</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        public bool CanResolve<TResolveType>(string name, NamedParameterOverloads parameters, ResolveOptions options)
            where TResolveType : class
        {
            return CanResolve(typeof(TResolveType), name, parameters, options);
        }

        public TinyIoCContainer GetChildContainer()
        {
            return new TinyIoCContainer(this);
        }

        /// <summary>
        ///     Creates/replaces a container class registration with default options.
        /// </summary>
        /// <param name="registerType">Type to register</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register(Type registerType)
        {
            return RegisterInternal(registerType, string.Empty, GetDefaultObjectFactory(registerType, registerType));
        }

        /// <summary>
        ///     Creates/replaces a named container class registration with default options.
        /// </summary>
        /// <param name="registerType">Type to register</param>
        /// <param name="name">Name of registration</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register(Type registerType, string name)
        {
            return RegisterInternal(registerType, name, GetDefaultObjectFactory(registerType, registerType));
        }

        /// <summary>
        ///     Creates/replaces a container class registration with a given implementation and default options.
        /// </summary>
        /// <param name="registerType">Type to register</param>
        /// <param name="registerImplementation">Type to instantiate that implements RegisterType</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register(Type registerType, Type registerImplementation)
        {
            return RegisterInternal(registerType, string.Empty, GetDefaultObjectFactory(registerType, registerImplementation));
        }

        /// <summary>
        ///     Creates/replaces a named container class registration with a given implementation and default options.
        /// </summary>
        /// <param name="registerType">Type to register</param>
        /// <param name="registerImplementation">Type to instantiate that implements RegisterType</param>
        /// <param name="name">Name of registration</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register(Type registerType, Type registerImplementation, string name)
        {
            return RegisterInternal(registerType, name, GetDefaultObjectFactory(registerType, registerImplementation));
        }

        /// <summary>
        ///     Creates/replaces a container class registration with a specific, strong referenced, instance.
        /// </summary>
        /// <param name="registerType">Type to register</param>
        /// <param name="instance">Instance of RegisterType to register</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register(Type registerType, object instance)
        {
            return RegisterInternal(registerType, string.Empty, new InstanceFactory(registerType, registerType, instance));
        }

        /// <summary>
        ///     Creates/replaces a named container class registration with a specific, strong referenced, instance.
        /// </summary>
        /// <param name="registerType">Type to register</param>
        /// <param name="instance">Instance of RegisterType to register</param>
        /// <param name="name">Name of registration</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register(Type registerType, object instance, string name)
        {
            return RegisterInternal(registerType, name, new InstanceFactory(registerType, registerType, instance));
        }

        /// <summary>
        ///     Creates/replaces a container class registration with a specific, strong referenced, instance.
        /// </summary>
        /// <param name="registerType">Type to register</param>
        /// <param name="registerImplementation">Type of instance to register that implements RegisterType</param>
        /// <param name="instance">Instance of RegisterImplementation to register</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register(Type registerType, Type registerImplementation, object instance)
        {
            return RegisterInternal(registerType, string.Empty, new InstanceFactory(registerType, registerImplementation, instance));
        }

        /// <summary>
        ///     Creates/replaces a named container class registration with a specific, strong referenced, instance.
        /// </summary>
        /// <param name="registerType">Type to register</param>
        /// <param name="registerImplementation">Type of instance to register that implements RegisterType</param>
        /// <param name="instance">Instance of RegisterImplementation to register</param>
        /// <param name="name">Name of registration</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register(Type registerType, Type registerImplementation, object instance, string name)
        {
            return RegisterInternal(registerType, name, new InstanceFactory(registerType, registerImplementation, instance));
        }

        /// <summary>
        ///     Creates/replaces a container class registration with a user specified factory
        /// </summary>
        /// <param name="registerType">Type to register</param>
        /// <param name="factory">Factory/lambda that returns an instance of RegisterType</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register(Type registerType, Func<TinyIoCContainer, NamedParameterOverloads, object> factory)
        {
            return RegisterInternal(registerType, string.Empty, new DelegateFactory(registerType, factory));
        }

        /// <summary>
        ///     Creates/replaces a container class registration with a user specified factory
        /// </summary>
        /// <param name="registerType">Type to register</param>
        /// <param name="factory">Factory/lambda that returns an instance of RegisterType</param>
        /// <param name="name">Name of registration</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register(Type registerType, Func<TinyIoCContainer, NamedParameterOverloads, object> factory, string name)
        {
            return RegisterInternal(registerType, name, new DelegateFactory(registerType, factory));
        }

        /// <summary>
        ///     Creates/replaces a container class registration with default options.
        /// </summary>
        /// <typeparam name="TRegisterType">Type to register</typeparam>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register<TRegisterType>()
            where TRegisterType : class
        {
            return Register(typeof(TRegisterType));
        }

        /// <summary>
        ///     Creates/replaces a named container class registration with default options.
        /// </summary>
        /// <typeparam name="TRegisterType">Type to register</typeparam>
        /// <param name="name">Name of registration</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register<TRegisterType>(string name)
            where TRegisterType : class
        {
            return Register(typeof(TRegisterType), name);
        }

        /// <summary>
        ///     Creates/replaces a container class registration with a given implementation and default options.
        /// </summary>
        /// <typeparam name="TRegisterType">Type to register</typeparam>
        /// <typeparam name="TRegisterImplementation">Type to instantiate that implements RegisterType</typeparam>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register<TRegisterType, TRegisterImplementation>()
            where TRegisterType : class
            where TRegisterImplementation : class, TRegisterType
        {
            return Register(typeof(TRegisterType), typeof(TRegisterImplementation));
        }

        /// <summary>
        ///     Creates/replaces a named container class registration with a given implementation and default options.
        /// </summary>
        /// <typeparam name="TRegisterType">Type to register</typeparam>
        /// <typeparam name="TRegisterImplementation">Type to instantiate that implements RegisterType</typeparam>
        /// <param name="name">Name of registration</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register<TRegisterType, TRegisterImplementation>(string name)
            where TRegisterType : class
            where TRegisterImplementation : class, TRegisterType
        {
            return Register(typeof(TRegisterType), typeof(TRegisterImplementation), name);
        }

        /// <summary>
        ///     Creates/replaces a container class registration with a specific, strong referenced, instance.
        /// </summary>
        /// <typeparam name="TRegisterType">Type to register</typeparam>
        /// <param name="instance">Instance of RegisterType to register</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register<TRegisterType>(TRegisterType instance)
            where TRegisterType : class
        {
            return Register(typeof(TRegisterType), instance);
        }

        /// <summary>
        ///     Creates/replaces a named container class registration with a specific, strong referenced, instance.
        /// </summary>
        /// <typeparam name="TRegisterType">Type to register</typeparam>
        /// <param name="instance">Instance of RegisterType to register</param>
        /// <param name="name">Name of registration</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register<TRegisterType>(TRegisterType instance, string name)
            where TRegisterType : class
        {
            return Register(typeof(TRegisterType), instance, name);
        }

        /// <summary>
        ///     Creates/replaces a container class registration with a specific, strong referenced, instance.
        /// </summary>
        /// <typeparam name="TRegisterType">Type to register</typeparam>
        /// <typeparam name="TRegisterImplementation">Type of instance to register that implements RegisterType</typeparam>
        /// <param name="instance">Instance of RegisterImplementation to register</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register<TRegisterType, TRegisterImplementation>(TRegisterImplementation instance)
            where TRegisterType : class
            where TRegisterImplementation : class, TRegisterType
        {
            return Register(typeof(TRegisterType), typeof(TRegisterImplementation), instance);
        }

        /// <summary>
        ///     Creates/replaces a named container class registration with a specific, strong referenced, instance.
        /// </summary>
        /// <typeparam name="TRegisterType">Type to register</typeparam>
        /// <typeparam name="TRegisterImplementation">Type of instance to register that implements RegisterType</typeparam>
        /// <param name="instance">Instance of RegisterImplementation to register</param>
        /// <param name="name">Name of registration</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register<TRegisterType, TRegisterImplementation>(TRegisterImplementation instance, string name)
            where TRegisterType : class
            where TRegisterImplementation : class, TRegisterType
        {
            return Register(typeof(TRegisterType), typeof(TRegisterImplementation), instance, name);
        }

        /// <summary>
        ///     Creates/replaces a container class registration with a user specified factory
        /// </summary>
        /// <typeparam name="TRegisterType">Type to register</typeparam>
        /// <param name="factory">Factory/lambda that returns an instance of RegisterType</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register<TRegisterType>(Func<TinyIoCContainer, NamedParameterOverloads, TRegisterType> factory)
            where TRegisterType : class
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            return Register(typeof(TRegisterType), (c, o) => factory(c, o));
        }

        /// <summary>
        ///     Creates/replaces a named container class registration with a user specified factory
        /// </summary>
        /// <typeparam name="TRegisterType">Type to register</typeparam>
        /// <param name="factory">Factory/lambda that returns an instance of RegisterType</param>
        /// <param name="name">Name of registration</param>
        /// <returns>RegisterOptions for fluent API</returns>
        public RegisterOptions Register<TRegisterType>(Func<TinyIoCContainer, NamedParameterOverloads, TRegisterType> factory, string name)
            where TRegisterType : class
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            return Register(typeof(TRegisterType), (c, o) => factory(c, o), name);
        }

        /// <summary>
        ///     Register multiple implementations of a type.
        ///     Internally this registers each implementation using the full name of the class as its registration name.
        /// </summary>
        /// <typeparam name="TRegisterType">Type that each implementation implements</typeparam>
        /// <param name="implementationTypes">Types that implement RegisterType</param>
        /// <returns>MultiRegisterOptions for the fluent API</returns>
        public MultiRegisterOptions RegisterMultiple<TRegisterType>(IEnumerable<Type> implementationTypes)
        {
            return RegisterMultiple(typeof(TRegisterType), implementationTypes);
        }

        /// <summary>
        ///     Register multiple implementations of a type.
        ///     Internally this registers each implementation using the full name of the class as its registration name.
        /// </summary>
        /// <param name="registrationType">Type that each implementation implements</param>
        /// <param name="implementationTypes">Types that implement RegisterType</param>
        /// <returns>MultiRegisterOptions for the fluent API</returns>
        public MultiRegisterOptions RegisterMultiple(Type registrationType, IEnumerable<Type> implementationTypes)
        {
            if (implementationTypes == null)
                throw new ArgumentNullException(nameof(implementationTypes), "types is null.");

            var implementationTypeList = implementationTypes.ToList();

            foreach (var type in implementationTypeList)
                if (!registrationType.IsAssignableFrom(type))
                    throw new ArgumentException($"types: The type {registrationType.FullName} is not assignable from {type.FullName}");

            if (implementationTypeList.Count != implementationTypeList.Distinct().Count())
            {
                var queryForDuplicatedTypes = from i in implementationTypeList
                    group i by i
                    into j
                    where j.Count() > 1
                    select j.Key.FullName;

                var fullNamesOfDuplicatedTypes = string.Join(",\n", queryForDuplicatedTypes.ToArray());
                var multipleRegMessage = string.Format("types: The same implementation type cannot be specified multiple times for {0}\n\n{1}", registrationType.FullName, fullNamesOfDuplicatedTypes);
                throw new ArgumentException(multipleRegMessage);
            }

            var registerOptions = new List<RegisterOptions>();

            foreach (var type in implementationTypeList)
            {
                registerOptions.Add(Register(registrationType, type, type.FullName));
            }

            return new MultiRegisterOptions(registerOptions);
        }

        /// <summary>
        ///     Attempts to resolve a type using default options.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public object Resolve(Type resolveType)
        {
            return ResolveInternal(new TypeRegistration(resolveType), NamedParameterOverloads.Default, ResolveOptions.Default);
        }

        /// <summary>
        ///     Attempts to resolve a type using specified options.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="options">Resolution options</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public object Resolve(Type resolveType, ResolveOptions options)
        {
            return ResolveInternal(new TypeRegistration(resolveType), NamedParameterOverloads.Default, options);
        }

        /// <summary>
        ///     Attempts to resolve a type using default options and the supplied name.
        ///     Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one
        ///     exists).
        ///     All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will
        ///     fail.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="name">Name of registration</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public object Resolve(Type resolveType, string name)
        {
            return ResolveInternal(new TypeRegistration(resolveType, name), NamedParameterOverloads.Default, ResolveOptions.Default);
        }

        /// <summary>
        ///     Attempts to resolve a type using supplied options and  name.
        ///     Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one
        ///     exists).
        ///     All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will
        ///     fail.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="name">Name of registration</param>
        /// <param name="options">Resolution options</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public object Resolve(Type resolveType, string name, ResolveOptions options)
        {
            return ResolveInternal(new TypeRegistration(resolveType, name), NamedParameterOverloads.Default, options);
        }

        /// <summary>
        ///     Attempts to resolve a type using default options and the supplied constructor parameters.
        ///     Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one
        ///     exists).
        ///     All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will
        ///     fail.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public object Resolve(Type resolveType, NamedParameterOverloads parameters)
        {
            return ResolveInternal(new TypeRegistration(resolveType), parameters, ResolveOptions.Default);
        }

        /// <summary>
        ///     Attempts to resolve a type using specified options and the supplied constructor parameters.
        ///     Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one
        ///     exists).
        ///     All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will
        ///     fail.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <param name="options">Resolution options</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public object Resolve(Type resolveType, NamedParameterOverloads parameters, ResolveOptions options)
        {
            return ResolveInternal(new TypeRegistration(resolveType), parameters, options);
        }

        /// <summary>
        ///     Attempts to resolve a type using default options and the supplied constructor parameters and name.
        ///     Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one
        ///     exists).
        ///     All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will
        ///     fail.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <param name="name">Name of registration</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public object Resolve(Type resolveType, string name, NamedParameterOverloads parameters)
        {
            return ResolveInternal(new TypeRegistration(resolveType, name), parameters, ResolveOptions.Default);
        }

        /// <summary>
        ///     Attempts to resolve a named type using specified options and the supplied constructor parameters.
        ///     Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one
        ///     exists).
        ///     All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will
        ///     fail.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="name">Name of registration</param>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <param name="options">Resolution options</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public object Resolve(Type resolveType, string name, NamedParameterOverloads parameters, ResolveOptions options)
        {
            return ResolveInternal(new TypeRegistration(resolveType, name), parameters, options);
        }

        /// <summary>
        ///     Attempts to resolve a type using default options.
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public TResolveType Resolve<TResolveType>()
            where TResolveType : class
        {
            return (TResolveType)Resolve(typeof(TResolveType));
        }

        /// <summary>
        ///     Attempts to resolve a type using specified options.
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="options">Resolution options</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public TResolveType Resolve<TResolveType>(ResolveOptions options)
            where TResolveType : class
        {
            return (TResolveType)Resolve(typeof(TResolveType), options);
        }

        /// <summary>
        ///     Attempts to resolve a type using default options and the supplied name.
        ///     Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one
        ///     exists).
        ///     All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will
        ///     fail.
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="name">Name of registration</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public TResolveType Resolve<TResolveType>(string name)
            where TResolveType : class
        {
            return (TResolveType)Resolve(typeof(TResolveType), name);
        }

        /// <summary>
        ///     Attempts to resolve a type using supplied options and  name.
        ///     Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one
        ///     exists).
        ///     All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will
        ///     fail.
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="name">Name of registration</param>
        /// <param name="options">Resolution options</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public TResolveType Resolve<TResolveType>(string name, ResolveOptions options)
            where TResolveType : class
        {
            return (TResolveType)Resolve(typeof(TResolveType), name, options);
        }

        /// <summary>
        ///     Attempts to resolve a type using default options and the supplied constructor parameters.
        ///     Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one
        ///     exists).
        ///     All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will
        ///     fail.
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public TResolveType Resolve<TResolveType>(NamedParameterOverloads parameters)
            where TResolveType : class
        {
            return (TResolveType)Resolve(typeof(TResolveType), parameters);
        }

        /// <summary>
        ///     Attempts to resolve a type using specified options and the supplied constructor parameters.
        ///     Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one
        ///     exists).
        ///     All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will
        ///     fail.
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <param name="options">Resolution options</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public TResolveType Resolve<TResolveType>(NamedParameterOverloads parameters, ResolveOptions options)
            where TResolveType : class
        {
            return (TResolveType)Resolve(typeof(TResolveType), parameters, options);
        }

        /// <summary>
        ///     Attempts to resolve a type using default options and the supplied constructor parameters and name.
        ///     Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one
        ///     exists).
        ///     All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will
        ///     fail.
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <param name="name">Name of registration</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public TResolveType Resolve<TResolveType>(string name, NamedParameterOverloads parameters)
            where TResolveType : class
        {
            return (TResolveType)Resolve(typeof(TResolveType), name, parameters);
        }

        /// <summary>
        ///     Attempts to resolve a named type using specified options and the supplied constructor parameters.
        ///     Parameters are used in conjunction with normal container resolution to find the most suitable constructor (if one
        ///     exists).
        ///     All user supplied parameters must exist in at least one resolvable constructor of RegisterType or resolution will
        ///     fail.
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="name">Name of registration</param>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <param name="options">Resolution options</param>
        /// <returns>Instance of type</returns>
        /// <exception cref="TinyIoCResolutionException">Unable to resolve the type.</exception>
        public TResolveType Resolve<TResolveType>(string name, NamedParameterOverloads parameters, ResolveOptions options)
            where TResolveType : class
        {
            return (TResolveType)Resolve(typeof(TResolveType), name, parameters, options);
        }

        /// <summary>
        ///     Returns all registrations of a type
        /// </summary>
        /// <param name="resolveType">Type to resolveAll</param>
        /// <param name="includeUnnamed">Whether to include un-named (default) registrations</param>
        /// <returns>IEnumerable</returns>
        public IEnumerable<object> ResolveAll(Type resolveType, bool includeUnnamed)
        {
            return ResolveAllInternal(resolveType, includeUnnamed);
        }

        /// <summary>
        ///     Returns all registrations of a type, both named and unnamed
        /// </summary>
        /// <param name="resolveType">Type to resolveAll</param>
        /// <returns>IEnumerable</returns>
        public IEnumerable<object> ResolveAll(Type resolveType)
        {
            return ResolveAll(resolveType, true);
        }

        /// <summary>
        ///     Returns all registrations of a type
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolveAll</typeparam>
        /// <param name="includeUnnamed">Whether to include un-named (default) registrations</param>
        /// <returns>IEnumerable</returns>
        public IEnumerable<TResolveType> ResolveAll<TResolveType>(bool includeUnnamed)
            where TResolveType : class
        {
            return ResolveAll(typeof(TResolveType), includeUnnamed).Cast<TResolveType>();
        }

        /// <summary>
        ///     Returns all registrations of a type, both named and unnamed
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolveAll</typeparam>
        /// <returns>IEnumerable</returns>
        public IEnumerable<TResolveType> ResolveAll<TResolveType>()
            where TResolveType : class
        {
            return ResolveAll<TResolveType>(true);
        }

        /// <summary>
        ///     Attempts to resolve a type using the default options
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve(Type resolveType, out object resolvedType)
        {
            try
            {
                resolvedType = Resolve(resolveType);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = null;
                return false;
            }
        }

        /// <summary>
        ///     Attempts to resolve a type using the given options
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="options">Resolution options</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve(Type resolveType, ResolveOptions options, out object resolvedType)
        {
            try
            {
                resolvedType = Resolve(resolveType, options);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = null;
                return false;
            }
        }

        /// <summary>
        ///     Attempts to resolve a type using the default options and given name
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="name">Name of registration</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve(Type resolveType, string name, out object resolvedType)
        {
            try
            {
                resolvedType = Resolve(resolveType, name);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = null;
                return false;
            }
        }

        /// <summary>
        ///     Attempts to resolve a type using the given options and name
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="name">Name of registration</param>
        /// <param name="options">Resolution options</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve(Type resolveType, string name, ResolveOptions options, out object resolvedType)
        {
            try
            {
                resolvedType = Resolve(resolveType, name, options);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = null;
                return false;
            }
        }

        /// <summary>
        ///     Attempts to resolve a type using the default options and supplied constructor parameters
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve(Type resolveType, NamedParameterOverloads parameters, out object resolvedType)
        {
            try
            {
                resolvedType = Resolve(resolveType, parameters);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = null;
                return false;
            }
        }

        /// <summary>
        ///     Attempts to resolve a type using the default options and supplied name and constructor parameters
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="name">Name of registration</param>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve(Type resolveType, string name, NamedParameterOverloads parameters, out object resolvedType)
        {
            try
            {
                resolvedType = Resolve(resolveType, name, parameters);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = null;
                return false;
            }
        }

        /// <summary>
        ///     Attempts to resolve a type using the supplied options and constructor parameters
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <param name="options">Resolution options</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve(Type resolveType, NamedParameterOverloads parameters, ResolveOptions options, out object resolvedType)
        {
            try
            {
                resolvedType = Resolve(resolveType, parameters, options);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = null;
                return false;
            }
        }

        /// <summary>
        ///     Attempts to resolve a type using the supplied name, options and constructor parameters
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="name">Name of registration</param>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <param name="options">Resolution options</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve(Type resolveType, string name, NamedParameterOverloads parameters, ResolveOptions options, out object resolvedType)
        {
            try
            {
                resolvedType = Resolve(resolveType, name, parameters, options);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = null;
                return false;
            }
        }

        /// <summary>
        ///     Attempts to resolve a type using the default options
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve<TResolveType>(out TResolveType resolvedType)
            where TResolveType : class
        {
            try
            {
                resolvedType = Resolve<TResolveType>();
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = default(TResolveType);
                return false;
            }
        }

        /// <summary>
        ///     Attempts to resolve a type using the given options
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="options">Resolution options</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve<TResolveType>(ResolveOptions options, out TResolveType resolvedType)
            where TResolveType : class
        {
            try
            {
                resolvedType = Resolve<TResolveType>(options);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = default(TResolveType);
                return false;
            }
        }

        /// <summary>
        ///     Attempts to resolve a type using the default options and given name
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="name">Name of registration</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve<TResolveType>(string name, out TResolveType resolvedType)
            where TResolveType : class
        {
            try
            {
                resolvedType = Resolve<TResolveType>(name);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = default(TResolveType);
                return false;
            }
        }

        /// <summary>
        ///     Attempts to resolve a type using the given options and name
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="name">Name of registration</param>
        /// <param name="options">Resolution options</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve<TResolveType>(string name, ResolveOptions options, out TResolveType resolvedType)
            where TResolveType : class
        {
            try
            {
                resolvedType = Resolve<TResolveType>(name, options);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = default(TResolveType);
                return false;
            }
        }

        /// <summary>
        ///     Attempts to resolve a type using the default options and supplied constructor parameters
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve<TResolveType>(NamedParameterOverloads parameters, out TResolveType resolvedType)
            where TResolveType : class
        {
            try
            {
                resolvedType = Resolve<TResolveType>(parameters);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = default(TResolveType);
                return false;
            }
        }

        /// <summary>
        ///     Attempts to resolve a type using the default options and supplied name and constructor parameters
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="name">Name of registration</param>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve<TResolveType>(string name, NamedParameterOverloads parameters, out TResolveType resolvedType)
            where TResolveType : class
        {
            try
            {
                resolvedType = Resolve<TResolveType>(name, parameters);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = default(TResolveType);
                return false;
            }
        }

        /// <summary>
        ///     Attempts to resolve a type using the supplied options and constructor parameters
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <param name="options">Resolution options</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve<TResolveType>(NamedParameterOverloads parameters, ResolveOptions options, out TResolveType resolvedType)
            where TResolveType : class
        {
            try
            {
                resolvedType = Resolve<TResolveType>(parameters, options);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = default(TResolveType);
                return false;
            }
        }

        /// <summary>
        ///     Attempts to resolve a type using the supplied name, options and constructor parameters
        /// </summary>
        /// <typeparam name="TResolveType">Type to resolve</typeparam>
        /// <param name="name">Name of registration</param>
        /// <param name="parameters">User specified constructor parameters</param>
        /// <param name="options">Resolution options</param>
        /// <param name="resolvedType">Resolved type or default if resolve fails</param>
        /// <returns>True if resolved successfully, false otherwise</returns>
        public bool TryResolve<TResolveType>(string name, NamedParameterOverloads parameters, ResolveOptions options, out TResolveType resolvedType)
            where TResolveType : class
        {
            try
            {
                resolvedType = Resolve<TResolveType>(name, parameters, options);
                return true;
            }
            catch (TinyIoCResolutionException)
            {
                resolvedType = default(TResolveType);
                return false;
            }
        }


        /// <summary>
        ///     Remove a container class registration.
        /// </summary>
        /// <typeparam name="TRegisterType">Type to unregister</typeparam>
        /// <returns>true if the registration is successfully found and removed; otherwise, false.</returns>
        public bool Unregister<TRegisterType>()
        {
            return Unregister(typeof(TRegisterType), string.Empty);
        }

        /// <summary>
        ///     Remove a named container class registration.
        /// </summary>
        /// <typeparam name="TRegisterType">Type to unregister</typeparam>
        /// <param name="name">Name of registration</param>
        /// <returns>true if the registration is successfully found and removed; otherwise, false.</returns>
        public bool Unregister<TRegisterType>(string name)
        {
            return Unregister(typeof(TRegisterType), name);
        }

        /// <summary>
        ///     Remove a container class registration.
        /// </summary>
        /// <param name="registerType">Type to unregister</param>
        /// <returns>true if the registration is successfully found and removed; otherwise, false.</returns>
        public bool Unregister(Type registerType)
        {
            return Unregister(registerType, string.Empty);
        }

        /// <summary>
        ///     Remove a named container class registration.
        /// </summary>
        /// <param name="registerType">Type to unregister</param>
        /// <param name="name">Name of registration</param>
        /// <returns>true if the registration is successfully found and removed; otherwise, false.</returns>
        public bool Unregister(Type registerType, string name)
        {
            var typeRegistration = new TypeRegistration(registerType, name);

            return RemoveRegistration(typeRegistration);
        }

        RegisterOptions AddUpdateRegistration(TypeRegistration typeRegistration, ObjectFactoryBase factory)
        {
            _registeredTypes[typeRegistration] = factory;

            return new RegisterOptions(this, typeRegistration);
        }

        void AutoRegisterInternal(IEnumerable<Assembly> assemblies, DuplicateImplementationActions duplicateAction, Func<Type, bool> registrationPredicate)
        {
            lock (_autoRegisterLock)
            {
                var types = assemblies.SelectMany(a => a.SafeGetTypes()).Where(t => !IsIgnoredType(t, registrationPredicate)).ToList();

                var concreteTypes = types
                                   .Where(type => type.IsClass() && type.IsAbstract() == false && type != GetType() && type.DeclaringType != GetType() && !type.IsGenericTypeDefinition())
                                   .ToList();

                foreach (var type in concreteTypes)
                {
                    try
                    {
                        RegisterInternal(type, string.Empty, GetDefaultObjectFactory(type, type));
                    }
                    catch (MethodAccessException)
                    {
                        // Ignore methods we can't access - added for Silverlight
                    }
                }

                var abstractInterfaceTypes = from type in types
                    where (type.IsInterface() || type.IsAbstract()) && type.DeclaringType != GetType() && !type.IsGenericTypeDefinition()
                    select type;

                foreach (var type in abstractInterfaceTypes)
                {
                    var localType = type;
                    var implementations = (from implementationType in concreteTypes
                        where localType.IsAssignableFrom(implementationType)
                        select implementationType).ToList();

                    if (implementations.Skip(1).Any())
                    {
                        if (duplicateAction == DuplicateImplementationActions.Fail)
                            throw new TinyIoCAutoRegistrationException(type, implementations);

                        if (duplicateAction == DuplicateImplementationActions.RegisterMultiple)
                        {
                            RegisterMultiple(type, implementations);
                        }
                    }

                    var firstImplementation = implementations.FirstOrDefault();
                    if (firstImplementation != null)
                    {
                        try
                        {
                            RegisterInternal(type, string.Empty, GetDefaultObjectFactory(type, firstImplementation));
                        }
                        catch (MethodAccessException)
                        {
                            // Ignore methods we can't access - added for Silverlight
                        }
                    }
                }
            }
        }

        void BuildUpInternal(object input, ResolveOptions resolveOptions)
        {
            var properties = from property in input.GetType().GetProperties()
                where property.GetGetMethod() != null && property.GetSetMethod() != null && !property.PropertyType.IsValueType()
                select property;

            foreach (var property in properties)
            {
                if (property.GetValue(input, null) == null)
                {
                    try
                    {
                        property.SetValue(input, ResolveInternal(new TypeRegistration(property.PropertyType), NamedParameterOverloads.Default, resolveOptions), null);
                    }
                    catch (TinyIoCResolutionException)
                    {
                        // Catch any resolution errors and ignore them
                    }
                }
            }
        }

        bool CanConstruct(ConstructorInfo ctor, NamedParameterOverloads parameters, ResolveOptions options)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            foreach (var parameter in ctor.GetParameters())
            {
                if (string.IsNullOrEmpty(parameter.Name))
                    return false;

                var isParameterOverload = parameters.ContainsKey(parameter.Name);

                if (parameter.ParameterType.IsPrimitive() && !isParameterOverload)
                    return false;

                if (!isParameterOverload && !CanResolveInternal(new TypeRegistration(parameter.ParameterType), NamedParameterOverloads.Default, options))
                    return false;
            }

            return true;
        }

        /// <summary>
        ///     Attempts to predict whether a given named type can be resolved with default options.
        ///     Note: Resolution may still fail if user defined factory registrations fail to construct objects when called.
        /// </summary>
        /// <param name="resolveType">Type to resolve</param>
        /// <param name="name">Name of registration</param>
        /// <returns>Bool indicating whether the type can be resolved</returns>
        bool CanResolve(Type resolveType, string name)
        {
            return CanResolveInternal(new TypeRegistration(resolveType, name), NamedParameterOverloads.Default, ResolveOptions.Default);
        }

        bool CanResolveInternal(TypeRegistration registration, NamedParameterOverloads parameters, ResolveOptions options)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            var checkType = registration.Type;
            var name = registration.Name;

            ObjectFactoryBase factory;
            if (_registeredTypes.TryGetValue(new TypeRegistration(checkType, name), out factory))
            {
                if (factory.AssumeConstruction)
                    return true;

                if (factory.Constructor == null)
                    return GetBestConstructor(factory.CreatesType, parameters, options) != null;
                return CanConstruct(factory.Constructor, parameters, options);
            }

            if (checkType.IsInterface() && checkType.IsGenericType())
            {
                // if the type is registered as an open generic, then see if the open generic is registered
                if (_registeredTypes.TryGetValue(new TypeRegistration(checkType.GetGenericTypeDefinition(), name), out factory))
                {
                    if (factory.AssumeConstruction)
                        return true;

                    if (factory.Constructor == null)
                        return GetBestConstructor(factory.CreatesType, parameters, options) != null;
                    return CanConstruct(factory.Constructor, parameters, options);
                }
            }

            // Fail if requesting named resolution and settings set to fail if unresolved
            // Or bubble up if we have a parent
            if (!string.IsNullOrEmpty(name) && options.NamedResolutionFailureAction == NamedResolutionFailureActions.Fail)
                return _parent?.CanResolveInternal(registration, parameters, options) ?? false;

            // Attempted unnamed fallback container resolution if relevant and requested
            if (!string.IsNullOrEmpty(name) && options.NamedResolutionFailureAction == NamedResolutionFailureActions.AttemptUnnamedResolution)
            {
                if (_registeredTypes.TryGetValue(new TypeRegistration(checkType), out factory))
                {
                    if (factory.AssumeConstruction)
                        return true;

                    return GetBestConstructor(factory.CreatesType, parameters, options) != null;
                }
            }

            // Check if type is an automatic lazy factory request
            if (IsAutomaticLazyFactoryRequest(checkType))
                return true;

            // Check if type is an IEnumerable<ResolveType>
            if (IsIEnumerableRequest(registration.Type))
                return true;

            // Attempt unregistered construction if possible and requested
            // If we cant', bubble if we have a parent
            if (options.UnregisteredResolutionAction == UnregisteredResolutionActions.AttemptResolve || checkType.IsGenericType() && options.UnregisteredResolutionAction == UnregisteredResolutionActions.GenericsOnly)
                return GetBestConstructor(checkType, parameters, options) != null || (_parent?.CanResolveInternal(registration, parameters, options) ?? false);

            // Bubble resolution up the container tree if we have a parent
            if (_parent != null)
                return _parent.CanResolveInternal(registration, parameters, options);

            return false;
        }

        object ConstructType(Type requestedType, Type implementationType, ConstructorInfo constructor, ResolveOptions options)
        {
            return ConstructType(requestedType, implementationType, constructor, NamedParameterOverloads.Default, options);
        }

        object ConstructType(Type requestedType, Type implementationType, NamedParameterOverloads parameters, ResolveOptions options)
        {
            return ConstructType(requestedType, implementationType, null, parameters, options);
        }

        object ConstructType(Type requestedType, Type implementationType, ConstructorInfo constructor, NamedParameterOverloads parameters, ResolveOptions options)
        {
            var typeToConstruct = implementationType;

            if (implementationType.IsGenericTypeDefinition())
            {
                if (requestedType == null || !requestedType.IsGenericType() || !requestedType.GetGenericArguments().Any())
                    throw new TinyIoCResolutionException(typeToConstruct);

                typeToConstruct = typeToConstruct.MakeGenericType(requestedType.GetGenericArguments());
            }

            if (constructor == null)
            {
                // Try and get the best constructor that we can construct
                // if we can't construct any then get the constructor
                // with the least number of parameters so we can throw a meaningful
                // resolve exception
                constructor = GetBestConstructor(typeToConstruct, parameters, options) ?? GetTypeConstructors(typeToConstruct).LastOrDefault();
            }

            if (constructor == null)
                throw new TinyIoCResolutionException(typeToConstruct);

            var ctorParams = constructor.GetParameters();
            var args = new object[ctorParams.Length];

            for (var parameterIndex = 0; parameterIndex < ctorParams.Length; parameterIndex++)
            {
                var currentParam = ctorParams[parameterIndex];

                try
                {
                    args[parameterIndex] = parameters.ContainsKey(currentParam.Name)
                        ? parameters[currentParam.Name]
                        : ResolveInternal(
                            new TypeRegistration(currentParam.ParameterType),
                            NamedParameterOverloads.Default,
                            options);
                }
                catch (TinyIoCResolutionException ex)
                {
                    // If a constructor parameter can't be resolved
                    // it will throw, so wrap it and throw that this can't
                    // be resolved.
                    throw new TinyIoCResolutionException(typeToConstruct, ex);
                }
                catch (Exception ex)
                {
                    throw new TinyIoCResolutionException(typeToConstruct, ex);
                }
            }

            try
            {
                var constructionDelegate = CreateObjectConstructionDelegateWithCache(constructor);
                return constructionDelegate.Invoke(args);
            }
            catch (Exception ex)
            {
                throw new TinyIoCResolutionException(typeToConstruct, ex);
            }
        }

        static ObjectConstructor CreateObjectConstructionDelegateWithCache(ConstructorInfo constructor)
        {
            ObjectConstructor objectConstructor;
            if (_objectConstructorCache.TryGetValue(constructor, out objectConstructor))
                return objectConstructor;

            // We could lock the cache here, but there's no real side
            // effect to two threads creating the same ObjectConstructor
            // at the same time, compared to the cost of a lock for 
            // every creation.
            var constructorParams = constructor.GetParameters();
            var lambdaParams = Expression.Parameter(typeof(object[]), "parameters");
            var newParams = new Expression[constructorParams.Length];

            for (var i = 0; i < constructorParams.Length; i++)
            {
                var paramsParameter = Expression.ArrayIndex(lambdaParams, Expression.Constant(i));

                newParams[i] = Expression.Convert(paramsParameter, constructorParams[i].ParameterType);
            }

            var newExpression = Expression.New(constructor, newParams);

            var constructionLambda = Expression.Lambda(typeof(ObjectConstructor), newExpression, lambdaParams);

            objectConstructor = (ObjectConstructor)constructionLambda.Compile();

            _objectConstructorCache[constructor] = objectConstructor;
            return objectConstructor;
        }

        ConstructorInfo GetBestConstructor(Type type, NamedParameterOverloads parameters, ResolveOptions options)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            if (type.IsValueType())
                return null;

            // Get constructors in reverse order based on the number of parameters
            // i.e. be as "greedy" as possible so we satify the most amount of dependencies possible
            var ctors = GetTypeConstructors(type);

            foreach (var ctor in ctors)
            {
                if (CanConstruct(ctor, parameters, options))
                    return ctor;
            }

            return null;
        }

        ObjectFactoryBase GetCurrentFactory(TypeRegistration registration)
        {
            _registeredTypes.TryGetValue(registration, out var current);

            return current;
        }

        ObjectFactoryBase GetDefaultObjectFactory(Type registerType, Type registerImplementation)
        {
            if (registerType.IsInterface() || registerType.IsAbstract())
                return new SingletonFactory(registerType, registerImplementation);

            return new MultiInstanceFactory(registerType, registerImplementation);
        }

        object GetIEnumerableRequest(Type type)
        {
            var genericResolveAllMethod = GetType().GetGenericMethod(BindingFlags.Public | BindingFlags.Instance, "ResolveAll", type.GetGenericArguments(), new[] {typeof(bool)});

            return genericResolveAllMethod.Invoke(this, new object[] {false});
        }

        object GetLazyAutomaticFactoryRequest(Type type)
        {
            if (!type.IsGenericType())
                return null;

            var genericType = type.GetGenericTypeDefinition();
            var genericArguments = type.GetGenericArguments();

            // Just a func
            if (genericType == typeof(Func<>))
            {
                var returnType = genericArguments[0];

                var resolveMethod = typeof(TinyIoCContainer).GetMethod("Resolve", new Type[] { });
                if (resolveMethod != null)
                {
                    resolveMethod = resolveMethod.MakeGenericMethod(returnType);

                    var resolveCall = Expression.Call(Expression.Constant(this), resolveMethod);

                    var resolveLambda = Expression.Lambda(resolveCall).Compile();

                    return resolveLambda;
                }
            }

            // 2 parameter func with string as first parameter (name)
            if (genericType == typeof(Func<,>) && genericArguments[0] == typeof(string))
            {
                var returnType = genericArguments[1];

                var resolveMethod = typeof(TinyIoCContainer).GetMethod("Resolve", new[] {typeof(string)});
                if (resolveMethod != null)
                {
                    resolveMethod = resolveMethod.MakeGenericMethod(returnType);

                    var resolveParameters = new[] {Expression.Parameter(typeof(string), "name")};
                    var resolveCall = Expression.Call(Expression.Constant(this), resolveMethod, resolveParameters);

                    var resolveLambda = Expression.Lambda(resolveCall, resolveParameters).Compile();

                    return resolveLambda;
                }
            }

            // 3 parameter func with string as first parameter (name) and IDictionary<string, object> as second (parameters)
            if (genericType == typeof(Func<,,>) && type.GetGenericArguments()[0] == typeof(string) && type.GetGenericArguments()[1] == typeof(IDictionary<string, object>))
            {
                var returnType = genericArguments[2];

                var name = Expression.Parameter(typeof(string), "name");
                var parameters = Expression.Parameter(typeof(IDictionary<string, object>), "parameters");

                var resolveMethod = typeof(TinyIoCContainer).GetMethod("Resolve", new[] {typeof(string), typeof(NamedParameterOverloads)});
                if (resolveMethod != null)
                {
                    resolveMethod = resolveMethod.MakeGenericMethod(returnType);

                    var resolveCall = Expression.Call(Expression.Constant(this), resolveMethod, name, Expression.Call(typeof(NamedParameterOverloads), "FromIDictionary", null, parameters));

                    var resolveLambda = Expression.Lambda(resolveCall, name, parameters).Compile();

                    return resolveLambda;
                }
            }

            throw new TinyIoCResolutionException(type);
        }

        ObjectFactoryBase GetParentObjectFactory(TypeRegistration registration)
        {
            if (_parent == null)
                return null;

            ObjectFactoryBase factory;

            if (registration.Type.IsGenericType())
            {
                var openTypeRegistration = new TypeRegistration(
                    registration.Type,
                    registration.Name);

                if (_parent._registeredTypes.TryGetValue(openTypeRegistration, out factory))
                {
                    return factory.GetFactoryForChildContainer(openTypeRegistration.Type, _parent, this);
                }

                return _parent.GetParentObjectFactory(registration);
            }

            if (_parent._registeredTypes.TryGetValue(registration, out factory))
            {
                return factory.GetFactoryForChildContainer(registration.Type, _parent, this);
            }

            return _parent.GetParentObjectFactory(registration);
        }

        IEnumerable<TypeRegistration> GetParentRegistrationsForType(Type resolveType)
        {
            if (_parent == null)
                return new TypeRegistration[] { };

            var registrations = _parent._registeredTypes.Keys.Where(tr => tr.Type == resolveType);

            return registrations.Concat(_parent.GetParentRegistrationsForType(resolveType));
        }

        IEnumerable<ConstructorInfo> GetTypeConstructors(Type type)
        {
            var candidateCtors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                     .Where(x => !x.IsPrivate) // Includes internal constructors but not private constructors
                                     .ToList();

            var attributeCtors = candidateCtors.Where(x => x.GetCustomAttributes(typeof(TinyIoCConstructorAttribute), false).Any())
                                               .ToList();

            if (attributeCtors.Any())
                candidateCtors = attributeCtors;

            return candidateCtors.OrderByDescending(ctor => ctor.GetParameters().Length);
        }

        bool IsAutomaticLazyFactoryRequest(Type type)
        {
            if (!type.IsGenericType())
                return false;

            var genericType = type.GetGenericTypeDefinition();

            // Just a func
            if (genericType == typeof(Func<>))
                return true;

            // 2 parameter func with string as first parameter (name)
            if (genericType == typeof(Func<,>) && type.GetGenericArguments()[0] == typeof(string))
                return true;

            // 3 parameter func with string as first parameter (name) and IDictionary<string, object> as second (parameters)
            if (genericType == typeof(Func<,,>) && type.GetGenericArguments()[0] == typeof(string) && type.GetGenericArguments()[1] == typeof(IDictionary<string, object>))
                return true;

            return false;
        }

        bool IsIEnumerableRequest(Type type)
        {
            if (!type.IsGenericType())
                return false;

            var genericType = type.GetGenericTypeDefinition();

            if (genericType == typeof(IEnumerable<>))
                return true;

            return false;
        }

        bool IsIgnoredAssembly(Assembly assembly)
        {
            // TODO - find a better way to remove "system" assemblies from the auto registration
            var ignoreChecks = new List<Func<Assembly, bool>>()
            {
                asm => asm.FullName.StartsWith("Microsoft.", StringComparison.Ordinal),
                asm => asm.FullName.StartsWith("System.", StringComparison.Ordinal),
                asm => asm.FullName.StartsWith("System,", StringComparison.Ordinal),
                asm => asm.FullName.StartsWith("CR_ExtUnitTest", StringComparison.Ordinal),
                asm => asm.FullName.StartsWith("mscorlib,", StringComparison.Ordinal),
                asm => asm.FullName.StartsWith("CR_VSTest", StringComparison.Ordinal),
                asm => asm.FullName.StartsWith("DevExpress.CodeRush", StringComparison.Ordinal),
                asm => asm.FullName.StartsWith("xunit.", StringComparison.Ordinal),
            };

            foreach (var check in ignoreChecks)
            {
                if (check(assembly))
                    return true;
            }

            return false;
        }

        bool IsIgnoredType(Type type, Func<Type, bool> registrationPredicate)
        {
            // TODO - find a better way to remove "system" types from the auto registration
            var ignoreChecks = new List<Func<Type, bool>>
            {
                t => t.FullName.StartsWith("System.", StringComparison.Ordinal),
                t => t.FullName.StartsWith("Microsoft.", StringComparison.Ordinal),
                t => t.IsPrimitive(),
                t => t.GetConstructors(BindingFlags.Instance | BindingFlags.Public).Length == 0 && !(t.IsInterface() || t.IsAbstract()),
            };

            if (registrationPredicate != null)
            {
                ignoreChecks.Add(t => !registrationPredicate(t));
            }

            foreach (var check in ignoreChecks)
            {
                if (check(type))
                    return true;
            }

            return false;
        }

        static bool IsValidAssignment(Type registerType, Type registerImplementation)
        {
            if (!registerType.IsGenericTypeDefinition())
            {
                if (!registerType.IsAssignableFrom(registerImplementation))
                    return false;
            }
            else
            {
                if (registerType.IsInterface())
                {
                    if (!registerImplementation.FindInterfaces((t, o) => t.Name == registerType.Name, null).Any())
                        return false;
                }
                else if (registerType.IsAbstract() && registerImplementation.BaseType() != registerType)
                {
                    return false;
                }
            }

            return true;
        }

        void RegisterDefaultTypes()
        {
            Register(this);

            // Only register the TinyMessenger singleton if we are the root container
            if (_parent == null)
                Register<ITinyMessengerHub, TinyMessengerHub>();
        }

        RegisterOptions RegisterInternal(Type registerType, string name, ObjectFactoryBase factory)
        {
            var typeRegistration = new TypeRegistration(registerType, name);

            return AddUpdateRegistration(typeRegistration, factory);
        }

        bool RemoveRegistration(TypeRegistration typeRegistration)
        {
            return _registeredTypes.Remove(typeRegistration);
        }

        IEnumerable<object> ResolveAllInternal(Type resolveType, bool includeUnnamed)
        {
            var registrations = _registeredTypes.Keys.Where(tr => tr.Type == resolveType).Concat(GetParentRegistrationsForType(resolveType)).Distinct();

            if (!includeUnnamed)
                registrations = registrations.Where(tr => tr.Name != string.Empty);

            return registrations.Select(registration => ResolveInternal(registration, NamedParameterOverloads.Default, ResolveOptions.Default));
        }

        object ResolveInternal(TypeRegistration registration, NamedParameterOverloads parameters, ResolveOptions options)
        {
            ObjectFactoryBase factory;

            // Attempt container resolution
            if (_registeredTypes.TryGetValue(registration, out factory))
            {
                try
                {
                    return factory.GetObject(registration.Type, this, parameters, options);
                }
                catch (TinyIoCResolutionException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw new TinyIoCResolutionException(registration.Type, ex);
                }
            }

            // Attempt container resolution of open generic
            if (registration.Type.IsGenericType())
            {
                var openTypeRegistration = new TypeRegistration(
                    registration.Type.GetGenericTypeDefinition(),
                    registration.Name);

                if (_registeredTypes.TryGetValue(openTypeRegistration, out factory))
                {
                    try
                    {
                        return factory.GetObject(registration.Type, this, parameters, options);
                    }
                    catch (TinyIoCResolutionException)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        throw new TinyIoCResolutionException(registration.Type, ex);
                    }
                }
            }

            // Attempt to get a factory from parent if we can
            var bubbledObjectFactory = GetParentObjectFactory(registration);
            if (bubbledObjectFactory != null)
            {
                try
                {
                    return bubbledObjectFactory.GetObject(registration.Type, this, parameters, options);
                }
                catch (TinyIoCResolutionException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw new TinyIoCResolutionException(registration.Type, ex);
                }
            }

            // Fail if requesting named resolution and settings set to fail if unresolved
            if (!string.IsNullOrEmpty(registration.Name) && options.NamedResolutionFailureAction == NamedResolutionFailureActions.Fail)
                throw new TinyIoCResolutionException(registration.Type);

            // Attempted unnamed fallback container resolution if relevant and requested
            if (!string.IsNullOrEmpty(registration.Name) && options.NamedResolutionFailureAction == NamedResolutionFailureActions.AttemptUnnamedResolution)
            {
                if (_registeredTypes.TryGetValue(new TypeRegistration(registration.Type, string.Empty), out factory))
                {
                    try
                    {
                        return factory.GetObject(registration.Type, this, parameters, options);
                    }
                    catch (TinyIoCResolutionException)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        throw new TinyIoCResolutionException(registration.Type, ex);
                    }
                }
            }

            // Attempt to construct an automatic lazy factory if possible
            if (IsAutomaticLazyFactoryRequest(registration.Type))
                return GetLazyAutomaticFactoryRequest(registration.Type);

            if (IsIEnumerableRequest(registration.Type))
                return GetIEnumerableRequest(registration.Type);

            // Attempt unregistered construction if possible and requested
            if (options.UnregisteredResolutionAction == UnregisteredResolutionActions.AttemptResolve || registration.Type.IsGenericType() && options.UnregisteredResolutionAction == UnregisteredResolutionActions.GenericsOnly)
            {
                if (!registration.Type.IsAbstract() && !registration.Type.IsInterface())
                    return ConstructType(null, registration.Type, parameters, options);
            }

            // Unable to resolve - throw
            throw new TinyIoCResolutionException(registration.Type);
        }

        /// <summary>
        ///     Registration options for "fluent" API
        /// </summary>
        public sealed class RegisterOptions
        {
            readonly TinyIoCContainer _container;
            readonly TypeRegistration _registration;

            public RegisterOptions(TinyIoCContainer container, TypeRegistration registration)
            {
                _container    = container;
                _registration = registration;
            }

            /// <summary>
            ///     Make registration multi-instance if possible
            /// </summary>
            /// <returns>RegisterOptions</returns>
            /// <exception cref="TinyIoCRegistrationException"></exception>
            public RegisterOptions AsMultiInstance()
            {
                var currentFactory = _container.GetCurrentFactory(_registration);

                if (currentFactory == null)
                    throw new TinyIoCRegistrationException(_registration.Type, "multi-instance");

                return _container.AddUpdateRegistration(_registration, currentFactory.MultiInstanceVariant);
            }

            /// <summary>
            ///     Make registration a singleton (single instance) if possible
            /// </summary>
            /// <returns>RegisterOptions</returns>
            /// <exception cref="TinyIoCRegistrationException"></exception>
            public RegisterOptions AsSingleton()
            {
                var currentFactory = _container.GetCurrentFactory(_registration);

                if (currentFactory == null)
                    throw new TinyIoCRegistrationException(_registration.Type, "singleton");

                return _container.AddUpdateRegistration(_registration, currentFactory.SingletonVariant);
            }

            /// <summary>
            ///     Switches to a custom lifetime manager factory if possible.
            ///     Usually used for RegisterOptions "To*" extension methods such as the ASP.Net per-request one.
            /// </summary>
            /// <param name="instance">RegisterOptions instance</param>
            /// <param name="lifetimeProvider">Custom lifetime manager</param>
            /// <param name="errorString">Error string to display if switch fails</param>
            /// <returns>RegisterOptions</returns>
            public static RegisterOptions ToCustomLifetimeManager(RegisterOptions instance, ITinyIoCObjectLifetimeProvider lifetimeProvider, string errorString)
            {
                if (instance == null)
                    throw new ArgumentNullException(nameof(instance), "instance is null.");

                if (lifetimeProvider == null)
                    throw new ArgumentNullException(nameof(lifetimeProvider), "lifetimeProvider is null.");

                if (string.IsNullOrEmpty(errorString))
                    throw new ArgumentException("errorString is null or empty.", nameof(errorString));

                var currentFactory = instance._container.GetCurrentFactory(instance._registration);

                if (currentFactory == null)
                    throw new TinyIoCRegistrationException(instance._registration.Type, errorString);

                return instance._container.AddUpdateRegistration(instance._registration, currentFactory.GetCustomObjectLifetimeVariant(lifetimeProvider, errorString));
            }

            public RegisterOptions UsingConstructor<TRegisterType>(Expression<Func<TRegisterType>> constructor)
            {
                if (!IsValidAssignment(_registration.Type, typeof(TRegisterType)))
                    throw new TinyIoCConstructorResolutionException(typeof(TRegisterType));

                var lambda = constructor as LambdaExpression;
                if (lambda == null)
                    throw new TinyIoCConstructorResolutionException(typeof(TRegisterType));

                var newExpression = lambda.Body as NewExpression;
                if (newExpression == null)
                    throw new TinyIoCConstructorResolutionException(typeof(TRegisterType));

                var constructorInfo = newExpression.Constructor;
                if (constructorInfo == null)
                    throw new TinyIoCConstructorResolutionException(typeof(TRegisterType));

                var currentFactory = _container.GetCurrentFactory(_registration);
                if (currentFactory == null)
                    throw new TinyIoCConstructorResolutionException(typeof(TRegisterType));

                currentFactory.SetConstructor(constructorInfo);

                return this;
            }

            /// <summary>
            ///     Make registration hold a strong reference if possible
            /// </summary>
            /// <returns>RegisterOptions</returns>
            /// <exception cref="TinyIoCRegistrationException"></exception>
            public RegisterOptions WithStrongReference()
            {
                var currentFactory = _container.GetCurrentFactory(_registration);

                if (currentFactory == null)
                    throw new TinyIoCRegistrationException(_registration.Type, "strong reference");

                return _container.AddUpdateRegistration(_registration, currentFactory.StrongReferenceVariant);
            }

            /// <summary>
            ///     Make registration hold a weak reference if possible
            /// </summary>
            /// <returns>RegisterOptions</returns>
            /// <exception cref="TinyIoCRegistrationException"></exception>
            public RegisterOptions WithWeakReference()
            {
                var currentFactory = _container.GetCurrentFactory(_registration);

                if (currentFactory == null)
                    throw new TinyIoCRegistrationException(_registration.Type, "weak reference");

                return _container.AddUpdateRegistration(_registration, currentFactory.WeakReferenceVariant);
            }
        }

        /// <summary>
        ///     Registration options for "fluent" API when registering multiple implementations
        /// </summary>
        public sealed class MultiRegisterOptions
        {
            IEnumerable<RegisterOptions> _registerOptions;

            /// <summary>
            ///     Initializes a new instance of the MultiRegisterOptions class.
            /// </summary>
            /// <param name="registerOptions">Registration options</param>
            public MultiRegisterOptions(IEnumerable<RegisterOptions> registerOptions)
            {
                _registerOptions = registerOptions;
            }

            /// <summary>
            ///     Make registration multi-instance if possible
            /// </summary>
            /// <returns>MultiRegisterOptions</returns>
            /// <exception cref="TinyIoCRegistrationException"></exception>
            public MultiRegisterOptions AsMultiInstance()
            {
                _registerOptions = ExecuteOnAllRegisterOptions(ro => ro.AsMultiInstance());
                return this;
            }

            /// <summary>
            ///     Make registration a singleton (single instance) if possible
            /// </summary>
            /// <returns>RegisterOptions</returns>
            /// <exception cref="TinyIoCRegistrationException"></exception>
            public MultiRegisterOptions AsSingleton()
            {
                _registerOptions = ExecuteOnAllRegisterOptions(ro => ro.AsSingleton());
                return this;
            }

            /// <summary>
            ///     Switches to a custom lifetime manager factory if possible.
            ///     Usually used for RegisterOptions "To*" extension methods such as the ASP.Net per-request one.
            /// </summary>
            /// <param name="instance">MultiRegisterOptions instance</param>
            /// <param name="lifetimeProvider">Custom lifetime manager</param>
            /// <param name="errorString">Error string to display if switch fails</param>
            /// <returns>MultiRegisterOptions</returns>
            public static MultiRegisterOptions ToCustomLifetimeManager(
                MultiRegisterOptions instance,
                ITinyIoCObjectLifetimeProvider lifetimeProvider,
                string errorString)
            {
                if (instance == null)
                    throw new ArgumentNullException(nameof(instance), "instance is null.");

                if (lifetimeProvider == null)
                    throw new ArgumentNullException(nameof(lifetimeProvider), "lifetimeProvider is null.");

                if (string.IsNullOrEmpty(errorString))
                    throw new ArgumentException("errorString is null or empty.", nameof(errorString));

                instance._registerOptions = instance.ExecuteOnAllRegisterOptions(ro => RegisterOptions.ToCustomLifetimeManager(ro, lifetimeProvider, errorString));

                return instance;
            }

            IEnumerable<RegisterOptions> ExecuteOnAllRegisterOptions(Func<RegisterOptions, RegisterOptions> action)
            {
                var newRegisterOptions = new List<RegisterOptions>();

                foreach (var registerOption in _registerOptions)
                {
                    newRegisterOptions.Add(action(registerOption));
                }

                return newRegisterOptions;
            }
        }

        /// <summary>
        ///     Provides custom lifetime management for ASP.Net per-request lifetimes etc.
        /// </summary>
        public interface ITinyIoCObjectLifetimeProvider
        {
            /// <summary>
            ///     Gets the stored object if it exists, or null if not
            /// </summary>
            /// <returns>Object instance or null</returns>
            object GetObject();

            /// <summary>
            ///     Release the object
            /// </summary>
            void ReleaseObject();

            /// <summary>
            ///     Store the object
            /// </summary>
            /// <param name="value">Object to store</param>
            void SetObject(object value);
        }

        abstract class ObjectFactoryBase
        {
            /// <summary>
            ///     Whether to assume this factory successfully constructs its objects
            ///     Generally set to true for delegate style factories as CanResolve cannot delve
            ///     into the delegates they contain.
            /// </summary>
            public virtual bool AssumeConstruction => false;

            /// <summary>
            ///     Constructor to use, if specified
            /// </summary>
            public ConstructorInfo Constructor { get; protected set; }

            /// <summary>
            ///     The type the factory instantiates
            /// </summary>
            public abstract Type CreatesType { get; }

            public virtual ObjectFactoryBase MultiInstanceVariant => throw new TinyIoCRegistrationException(GetType(), "multi-instance");

            public virtual ObjectFactoryBase SingletonVariant => throw new TinyIoCRegistrationException(GetType(), "singleton");

            public virtual ObjectFactoryBase StrongReferenceVariant => throw new TinyIoCRegistrationException(GetType(), "strong reference");

            public virtual ObjectFactoryBase WeakReferenceVariant => throw new TinyIoCRegistrationException(GetType(), "weak reference");

            public virtual ObjectFactoryBase GetCustomObjectLifetimeVariant(ITinyIoCObjectLifetimeProvider lifetimeProvider, string errorString)
            {
                throw new TinyIoCRegistrationException(GetType(), errorString);
            }

            public virtual ObjectFactoryBase GetFactoryForChildContainer(Type type, TinyIoCContainer parent, TinyIoCContainer child)
            {
                return this;
            }

            /// <summary>
            ///     Create the type
            /// </summary>
            /// <param name="requestedType">Type user requested to be resolved</param>
            /// <param name="container">Container that requested the creation</param>
            /// <param name="parameters">Any user parameters passed</param>
            /// <param name="options"></param>
            /// <returns></returns>
            public abstract object GetObject(Type requestedType, TinyIoCContainer container, NamedParameterOverloads parameters, ResolveOptions options);

            public virtual void SetConstructor(ConstructorInfo constructor)
            {
                Constructor = constructor;
            }
        }

        /// <summary>
        ///     IObjectFactory that creates new instances of types for each resolution
        /// </summary>
        class MultiInstanceFactory : ObjectFactoryBase
        {
            readonly Type _registerImplementation;
            readonly Type _registerType;

            public MultiInstanceFactory(Type registerType, Type registerImplementation)
            {
                if (registerImplementation.IsAbstract() || registerImplementation.IsInterface())
                    throw new TinyIoCRegistrationTypeException(registerImplementation, "MultiInstanceFactory");
                if (!IsValidAssignment(registerType, registerImplementation))
                    throw new TinyIoCRegistrationTypeException(registerImplementation, "MultiInstanceFactory");

                _registerType           = registerType;
                _registerImplementation = registerImplementation;
            }

            public override Type CreatesType => _registerImplementation;

            public override ObjectFactoryBase MultiInstanceVariant => this;

            public override ObjectFactoryBase SingletonVariant => new SingletonFactory(_registerType, _registerImplementation);

            public override ObjectFactoryBase GetCustomObjectLifetimeVariant(ITinyIoCObjectLifetimeProvider lifetimeProvider, string errorString)
            {
                return new CustomObjectLifetimeFactory(_registerType, _registerImplementation, lifetimeProvider, errorString);
            }

            public override object GetObject(Type requestedType, TinyIoCContainer container, NamedParameterOverloads parameters, ResolveOptions options)
            {
                try
                {
                    return container.ConstructType(requestedType, _registerImplementation, Constructor, parameters, options);
                }
                catch (TinyIoCResolutionException ex)
                {
                    throw new TinyIoCResolutionException(_registerType, ex);
                }
            }
        }

        /// <summary>
        ///     IObjectFactory that invokes a specified delegate to construct the object
        /// </summary>
        class DelegateFactory : ObjectFactoryBase
        {
            readonly Func<TinyIoCContainer, NamedParameterOverloads, object> _factory;
            readonly Type _registerType;

            public DelegateFactory(Type registerType, Func<TinyIoCContainer, NamedParameterOverloads, object> factory)
            {
                if (factory == null)
                    throw new ArgumentNullException(nameof(factory));

                _factory = factory;

                _registerType = registerType;
            }

            public override bool AssumeConstruction => true;

            public override Type CreatesType => _registerType;

            public override ObjectFactoryBase StrongReferenceVariant => this;

            public override ObjectFactoryBase WeakReferenceVariant => new WeakDelegateFactory(_registerType, _factory);

            public override object GetObject(Type requestedType, TinyIoCContainer container, NamedParameterOverloads parameters, ResolveOptions options)
            {
                try
                {
                    return _factory.Invoke(container, parameters);
                }
                catch (Exception ex)
                {
                    throw new TinyIoCResolutionException(_registerType, ex);
                }
            }

            public override void SetConstructor(ConstructorInfo constructor)
            {
                throw new TinyIoCConstructorResolutionException("Constructor selection is not possible for delegate factory registrations");
            }
        }

        /// <summary>
        ///     IObjectFactory that invokes a specified delegate to construct the object
        ///     Holds the delegate using a weak reference
        /// </summary>
        class WeakDelegateFactory : ObjectFactoryBase
        {
            readonly WeakReference _factory;
            readonly Type _registerType;

            public WeakDelegateFactory(Type registerType, Func<TinyIoCContainer, NamedParameterOverloads, object> factory)
            {
                if (factory == null)
                    throw new ArgumentNullException(nameof(factory));

                _factory = new WeakReference(factory);

                _registerType = registerType;
            }

            public override bool AssumeConstruction => true;

            public override Type CreatesType => _registerType;

            public override ObjectFactoryBase StrongReferenceVariant
            {
                get
                {
                    var factory = _factory.Target as Func<TinyIoCContainer, NamedParameterOverloads, object>;

                    if (factory == null)
                        throw new TinyIoCWeakReferenceException(_registerType);

                    return new DelegateFactory(_registerType, factory);
                }
            }

            public override ObjectFactoryBase WeakReferenceVariant => this;

            public override object GetObject(Type requestedType, TinyIoCContainer container, NamedParameterOverloads parameters, ResolveOptions options)
            {
                var factory = _factory.Target as Func<TinyIoCContainer, NamedParameterOverloads, object>;

                if (factory == null)
                    throw new TinyIoCWeakReferenceException(_registerType);

                try
                {
                    return factory.Invoke(container, parameters);
                }
                catch (Exception ex)
                {
                    throw new TinyIoCResolutionException(_registerType, ex);
                }
            }

            public override void SetConstructor(ConstructorInfo constructor)
            {
                throw new TinyIoCConstructorResolutionException("Constructor selection is not possible for delegate factory registrations");
            }
        }

        /// <summary>
        ///     Stores an particular instance to return for a type
        /// </summary>
        class InstanceFactory : ObjectFactoryBase, IDisposable
        {
            readonly object _instance;
            readonly Type _registerImplementation;
            readonly Type _registerType;

            public InstanceFactory(Type registerType, Type registerImplementation, object instance)
            {
                if (!IsValidAssignment(registerType, registerImplementation))
                    throw new TinyIoCRegistrationTypeException(registerImplementation, "InstanceFactory");

                _registerType           = registerType;
                _registerImplementation = registerImplementation;
                _instance               = instance;
            }

            public override bool AssumeConstruction => true;

            public override Type CreatesType => _registerImplementation;

            public override ObjectFactoryBase MultiInstanceVariant => new MultiInstanceFactory(_registerType, _registerImplementation);

            public override ObjectFactoryBase StrongReferenceVariant => this;

            public override ObjectFactoryBase WeakReferenceVariant => new WeakInstanceFactory(_registerType, _registerImplementation, _instance);

            public void Dispose()
            {
                var disposable = _instance as IDisposable;

                if (disposable != null)
                    disposable.Dispose();
            }

            public override object GetObject(Type requestedType, TinyIoCContainer container, NamedParameterOverloads parameters, ResolveOptions options)
            {
                return _instance;
            }

            public override void SetConstructor(ConstructorInfo constructor)
            {
                throw new TinyIoCConstructorResolutionException("Constructor selection is not possible for instance factory registrations");
            }
        }

        /// <summary>
        ///     Stores an particular instance to return for a type
        ///     Stores the instance with a weak reference
        /// </summary>
        class WeakInstanceFactory : ObjectFactoryBase, IDisposable
        {
            readonly WeakReference _instance;
            readonly Type _registerImplementation;
            readonly Type _registerType;

            public WeakInstanceFactory(Type registerType, Type registerImplementation, object instance)
            {
                if (!IsValidAssignment(registerType, registerImplementation))
                    throw new TinyIoCRegistrationTypeException(registerImplementation, "WeakInstanceFactory");

                _registerType           = registerType;
                _registerImplementation = registerImplementation;
                _instance               = new WeakReference(instance);
            }

            public override Type CreatesType => _registerImplementation;

            public override ObjectFactoryBase MultiInstanceVariant => new MultiInstanceFactory(_registerType, _registerImplementation);

            public override ObjectFactoryBase StrongReferenceVariant
            {
                get
                {
                    var instance = _instance.Target;

                    if (instance == null)
                        throw new TinyIoCWeakReferenceException(_registerType);

                    return new InstanceFactory(_registerType, _registerImplementation, instance);
                }
            }

            public override ObjectFactoryBase WeakReferenceVariant => this;

            public void Dispose()
            {
                var disposable = _instance.Target as IDisposable;

                if (disposable != null)
                    disposable.Dispose();
            }

            public override object GetObject(Type requestedType, TinyIoCContainer container, NamedParameterOverloads parameters, ResolveOptions options)
            {
                var instance = _instance.Target;

                if (instance == null)
                    throw new TinyIoCWeakReferenceException(_registerType);

                return instance;
            }

            public override void SetConstructor(ConstructorInfo constructor)
            {
                throw new TinyIoCConstructorResolutionException("Constructor selection is not possible for instance factory registrations");
            }
        }

        /// <summary>
        ///     A factory that lazy instantiates a type and always returns the same instance
        /// </summary>
        class SingletonFactory : ObjectFactoryBase, IDisposable
        {
            object _current;
            readonly Type _registerImplementation;
            readonly Type _registerType;
            readonly object _singletonLock = new object();

            public SingletonFactory(Type registerType, Type registerImplementation)
            {
                if (registerImplementation.IsAbstract() || registerImplementation.IsInterface())
                    throw new TinyIoCRegistrationTypeException(registerImplementation, "SingletonFactory");

                if (!IsValidAssignment(registerType, registerImplementation))
                    throw new TinyIoCRegistrationTypeException(registerImplementation, "SingletonFactory");

                _registerType           = registerType;
                _registerImplementation = registerImplementation;
            }

            public override Type CreatesType => _registerImplementation;

            public override ObjectFactoryBase MultiInstanceVariant => new MultiInstanceFactory(_registerType, _registerImplementation);

            public override ObjectFactoryBase SingletonVariant => this;

            public void Dispose()
            {
                if (_current == null)
                    return;

                var disposable = _current as IDisposable;

                if (disposable != null)
                    disposable.Dispose();
            }

            public override ObjectFactoryBase GetCustomObjectLifetimeVariant(ITinyIoCObjectLifetimeProvider lifetimeProvider, string errorString)
            {
                return new CustomObjectLifetimeFactory(_registerType, _registerImplementation, lifetimeProvider, errorString);
            }

            public override ObjectFactoryBase GetFactoryForChildContainer(Type type, TinyIoCContainer parent, TinyIoCContainer child)
            {
                // We make sure that the singleton is constructed before the child container takes the factory.
                // Otherwise the results would vary depending on whether or not the parent container had resolved
                // the type before the child container does.
                GetObject(type, parent, NamedParameterOverloads.Default, ResolveOptions.Default);
                return this;
            }

            public override object GetObject(Type requestedType, TinyIoCContainer container, NamedParameterOverloads parameters, ResolveOptions options)
            {
                if (parameters.Count != 0)
                    throw new ArgumentException("Cannot specify parameters for singleton types");

                lock (_singletonLock)
                {
                    if (_current == null)
                        _current = container.ConstructType(requestedType, _registerImplementation, Constructor, options);
                }

                return _current;
            }
        }

        /// <summary>
        ///     A factory that offloads lifetime to an external lifetime provider
        /// </summary>
        class CustomObjectLifetimeFactory : ObjectFactoryBase, IDisposable
        {
            readonly ITinyIoCObjectLifetimeProvider _lifetimeProvider;
            readonly Type _registerImplementation;
            readonly Type _registerType;
            readonly object _singletonLock = new object();

            public CustomObjectLifetimeFactory(Type registerType, Type registerImplementation, ITinyIoCObjectLifetimeProvider lifetimeProvider, string errorMessage)
            {
                if (lifetimeProvider == null)
                    throw new ArgumentNullException(nameof(lifetimeProvider), "lifetimeProvider is null.");

                if (!IsValidAssignment(registerType, registerImplementation))
                    throw new TinyIoCRegistrationTypeException(registerImplementation, "SingletonFactory");

                if (registerImplementation.IsAbstract() || registerImplementation.IsInterface())
                    throw new TinyIoCRegistrationTypeException(registerImplementation, errorMessage);

                _registerType           = registerType;
                _registerImplementation = registerImplementation;
                _lifetimeProvider       = lifetimeProvider;
            }

            public override Type CreatesType => _registerImplementation;

            public override ObjectFactoryBase MultiInstanceVariant
            {
                get
                {
                    _lifetimeProvider.ReleaseObject();
                    return new MultiInstanceFactory(_registerType, _registerImplementation);
                }
            }

            public override ObjectFactoryBase SingletonVariant
            {
                get
                {
                    _lifetimeProvider.ReleaseObject();
                    return new SingletonFactory(_registerType, _registerImplementation);
                }
            }

            public void Dispose()
            {
                _lifetimeProvider.ReleaseObject();
            }

            public override ObjectFactoryBase GetCustomObjectLifetimeVariant(ITinyIoCObjectLifetimeProvider lifetimeProvider, string errorString)
            {
                _lifetimeProvider.ReleaseObject();
                return new CustomObjectLifetimeFactory(_registerType, _registerImplementation, lifetimeProvider, errorString);
            }

            public override ObjectFactoryBase GetFactoryForChildContainer(Type type, TinyIoCContainer parent, TinyIoCContainer child)
            {
                // We make sure that the singleton is constructed before the child container takes the factory.
                // Otherwise the results would vary depending on whether or not the parent container had resolved
                // the type before the child container does.
                GetObject(type, parent, NamedParameterOverloads.Default, ResolveOptions.Default);
                return this;
            }

            public override object GetObject(Type requestedType, TinyIoCContainer container, NamedParameterOverloads parameters, ResolveOptions options)
            {
                object current;

                lock (_singletonLock)
                {
                    current = _lifetimeProvider.GetObject();
                    if (current == null)
                    {
                        current = container.ConstructType(requestedType, _registerImplementation, Constructor, options);
                        _lifetimeProvider.SetObject(current);
                    }
                }

                return current;
            }
        }

        public sealed class TypeRegistration
        {
            readonly int _hashCode;

            public TypeRegistration(Type type)
                : this(type, string.Empty) { }

            public TypeRegistration(Type type, string name)
            {
                Type = type;
                Name = name;

                _hashCode = string.Concat(Type.FullName, "|", Name).GetHashCode();
            }

            public string Name { get; }

            public Type Type { get; }

            public override bool Equals(object obj)
            {
                var typeRegistration = obj as TypeRegistration;

                if (typeRegistration == null)
                    return false;

                if (Type != typeRegistration.Type)
                    return false;

                if (string.Compare(Name, typeRegistration.Name, StringComparison.Ordinal) != 0)
                    return false;

                return true;
            }

            public override int GetHashCode()
            {
                return _hashCode;
            }
        }

        delegate object ObjectConstructor(params object[] parameters);
    }


    // reverse shim for WinRT SR changes...
    internal static class ReverseTypeExtender
    {
        public static Assembly Assembly(this Type type)
        {
            return type.Assembly;
        }

        public static Type BaseType(this Type type)
        {
            return type.BaseType;
        }

        public static bool IsAbstract(this Type type)
        {
            return type.IsAbstract;
        }

        public static bool IsClass(this Type type)
        {
            return type.IsClass;
        }

        public static bool IsGenericParameter(this Type type)
        {
            return type.IsGenericParameter;
        }

        public static bool IsGenericType(this Type type)
        {
            return type.IsGenericType;
        }

        public static bool IsGenericTypeDefinition(this Type type)
        {
            return type.IsGenericTypeDefinition;
        }

        public static bool IsInterface(this Type type)
        {
            return type.IsInterface;
        }

        public static bool IsPrimitive(this Type type)
        {
            return type.IsPrimitive;
        }

        public static bool IsValueType(this Type type)
        {
            return type.IsValueType;
        }
    }

    [AttributeUsage(AttributeTargets.Constructor, Inherited = false, AllowMultiple = false)]
    public
        sealed class TinyIoCConstructorAttribute : Attribute { }
}
