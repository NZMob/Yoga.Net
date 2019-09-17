using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGSizeOverflowTest
    {
        [Test]
        public void nested_overflowing_child()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child0, 200);
            YGNodeStyleSetHeight(rootChild0Child0, 200);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(rootChild0Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(-100, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(rootChild0Child0));
        }

        [Test]
        public void nested_overflowing_child_in_constraint_parent()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 100);
            YGNodeStyleSetHeight(rootChild0, 100);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child0, 200);
            YGNodeStyleSetHeight(rootChild0Child0, 200);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(rootChild0Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(-100, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(rootChild0Child0));
        }

        [Test]
        public void parent_wrap_child_size_overflowing_parent()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 100);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child0, 100);
            YGNodeStyleSetHeight(rootChild0Child0, 200);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(rootChild0Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(rootChild0Child0));
        }
    }
}
