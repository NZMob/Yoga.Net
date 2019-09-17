using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGDimensionTest
    {
        [Test]
        public void wrap_child()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 100);
            YGNodeStyleSetHeight(rootChild0, 100);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void wrap_grandchild()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, rootChild0, 0);

            var rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child0, 100);
            YGNodeStyleSetHeight(rootChild0Child0, 100);
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
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

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
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child0));
        }
    }
}
