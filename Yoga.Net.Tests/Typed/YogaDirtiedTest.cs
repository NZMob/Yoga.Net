using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaDirtiedTest
    {
        static void _dirtied(YogaNode node)
        {
            int dirtiedCount = (int)node.Context;
            dirtiedCount++;
            node.Context = dirtiedCount;
        }

        [Test]
        public void Dirtied()
        {
            YogaNode root = Node(alignItems:YogaAlign.FlexStart, width:100, height:100);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            //int dirtiedCount = 0;
            root.Context = 0;
            root.DirtiedFunc = _dirtied;

            Assert.AreEqual(0, (int)root.Context);

            // `_dirtied` MUST be called in case of explicit dirtying.
            root.IsDirty = true;
            Assert.AreEqual(1, (int)root.Context);

            // `_dirtied` MUST be called ONCE.
            root.IsDirty = true;
            Assert.AreEqual(1, (int)root.Context);
        }

        [Test]
        public void dirtied_propagation()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
                           .Add(rootChild0 = Node(width:50, height:20))
                           .Add(Node(width:50, height:20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            root.Context = 0;
            root.DirtiedFunc = _dirtied;

            Assert.AreEqual(0, (int)root.Context);

            // `_dirtied` MUST be called for the first time.
            rootChild0.MarkDirtyAndPropagate();
            Assert.AreEqual(1, (int)root.Context);

            // `_dirtied` must NOT be called for the second time.
            rootChild0.MarkDirtyAndPropagate();
            Assert.AreEqual(1, (int)root.Context);
        }

        [Test]
        public void dirtied_hierarchy()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
                           .Add(rootChild0 = Node(width:50, height:20))
                           .Add(rootChild1 = Node(width:50, height:20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            rootChild0.Context = 0;
            rootChild0.DirtiedFunc = _dirtied;

            Assert.AreEqual(0, (int)rootChild0.Context);

            // `_dirtied` must NOT be called for descendants.
            root.MarkDirtyAndPropagate();
            Assert.AreEqual(0, (int)rootChild0.Context);

            // `_dirtied` must NOT be called for the sibling node.
            rootChild1.MarkDirtyAndPropagate();
            Assert.AreEqual(0, (int)rootChild0.Context);

            // `_dirtied` MUST be called in case of explicit dirtying.
            rootChild0.MarkDirtyAndPropagate();
            Assert.AreEqual(1, (int)rootChild0.Context);
        }
    }
}
