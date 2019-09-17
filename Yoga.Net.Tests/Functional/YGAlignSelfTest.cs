using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGAlignSelfTest
    {
        [Test]
        public void align_self_center()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignSelf(rootChild0, YogaAlign.Center);
            YGNodeStyleSetWidth(rootChild0, 10);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void align_self_flex_end()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignSelf(rootChild0, YogaAlign.FlexEnd);
            YGNodeStyleSetWidth(rootChild0, 10);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void align_self_flex_start()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignSelf(rootChild0, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(rootChild0, 10);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void align_self_flex_end_override_flex_start()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignSelf(rootChild0, YogaAlign.FlexEnd);
            YGNodeStyleSetWidth(rootChild0, 10);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void align_self_baseline()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignSelf(rootChild0, YogaAlign.Baseline);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignSelf(rootChild1, YogaAlign.Baseline);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 20);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild1Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1Child0, 50);
            YGNodeStyleSetHeight(rootChild1Child0, 10);
            YGNodeInsertChild(rootChild1, rootChild1Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child0));
        }
    }
}
