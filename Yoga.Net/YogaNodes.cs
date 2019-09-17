using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;

namespace Yoga.Net
{
    public class YogaNodes : IList<YogaNode>
    {
        public YogaNode Owner { get; set; }
        List<YogaNode> _nodes;

        public YogaNodes()
        {
            _nodes = new List<YogaNode>();
        }
        public YogaNodes(int capacity)
        {
            _nodes = new List<YogaNode>(capacity);
        }
        public YogaNodes(IEnumerable<YogaNode> collection)
        {
            _nodes = new List<YogaNode>(collection);
        }

        /// <inheritdoc />
        public IEnumerator<YogaNode> GetEnumerator() => _nodes.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        public void Add(YogaNode item)
        {
            if (item == null)
                return;

            _nodes.Add(item);
            if (item.Owner == null)
                item.Owner = Owner;
        }

        public void AddRange(IEnumerable<YogaNode> collection)
        {
            foreach (var item in collection)
                Add(item);
        }
        
        /// <inheritdoc />
        public void Clear()
        {
            var childCount = _nodes.Count;
            if (childCount == 0)
                return;

            var firstChild = _nodes[0];
            if (firstChild.Owner == Owner)
            {
                // If the first child has this node as its owner, we assume that this child set is unique.
                for (var i = 0; i < childCount; i++)
                {
                    var oldChild = _nodes[i];
                    oldChild.Layout = new YogaNode().Layout; // layout is no longer valid
                    oldChild.Owner  = null;
                }
            }
            _nodes.Clear();
            Owner.MarkDirtyAndPropagate();
        }

        /// <inheritdoc />
        public bool Contains(YogaNode item) => _nodes.Contains(item);

        /// <inheritdoc />
        public void CopyTo(YogaNode[] array, int arrayIndex) => _nodes.CopyTo(array, arrayIndex);

        /// <inheritdoc />
        public bool Remove(YogaNode item)
        {
            if (_nodes.Count == 0 || item == null)
                return false;

            // Children may be shared between parents, which is indicated by not having an
            // owner. We only want to reset the child completely if it is owned exclusively by one node.
            var childOwner = item.Owner;
            if (_nodes.Contains(item) && _nodes.Remove(item))
            {
                if (Owner == childOwner)
                {
                    item.Layout = new YogaLayout(); // layout is no longer valid
                    item.Owner  = null;
                }

                Owner.MarkDirtyAndPropagate();
                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public int Count => _nodes.Count;

        /// <inheritdoc />
        public bool IsReadOnly => false;

        /// <inheritdoc />
        public int IndexOf(YogaNode item) => _nodes.IndexOf(item);

        /// <inheritdoc />
        public void Insert(int index, YogaNode item)
        {
            Debug.Assert( item.Owner == null, "Child already has a owner, it must be removed first.");
            Debug.Assert( Owner.MeasureFunc == null, "Cannot add child: Nodes with measure functions cannot have children.");

            _nodes.Insert(index, item);
            item.Owner = Owner;
            Owner.MarkDirtyAndPropagate();
        }

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            var item = _nodes[index];
            if (item == null)
                return;

            // Children may be shared between parents, which is indicated by not having an
            // owner. We only want to reset the child completely if it is owned exclusively by one node.
            _nodes.RemoveAt(index);
            if (Owner == item.Owner)
            {
                item.Layout = new YogaLayout(); // layout is no longer valid
                item.Owner  = null;
            }

            Owner.MarkDirtyAndPropagate();
        }

        /// <inheritdoc />
        public YogaNode this[int index]
        {
            get => _nodes[index];
            set => _nodes[index] = value;
        }
    }
}
