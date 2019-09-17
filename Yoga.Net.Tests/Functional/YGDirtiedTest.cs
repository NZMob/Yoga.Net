using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGDirtiedTest
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
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

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
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 20);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 20);
            YGNodeInsertChild(root, rootChild1, 1);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

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
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 20);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 20);
            YGNodeInsertChild(root, rootChild1, 1);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

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
