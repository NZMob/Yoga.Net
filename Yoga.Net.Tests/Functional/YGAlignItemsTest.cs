using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGAlignItemsTest
    {
        [Test]
        public void align_items_stretch()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void align_items_center()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
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
        public void align_items_flex_start()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
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
        public void align_items_flex_end()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexEnd);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
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
        public void align_baseline()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 20);
            YGNodeInsertChild(root, rootChild1, 1);
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
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

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
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void align_baseline_child()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
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

        [Test]
        public void align_baseline_child_multiline()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 60);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(rootChild1, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(rootChild1, Wrap.Wrap);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 25);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild1Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1Child0, 25);
            YGNodeStyleSetHeight(rootChild1Child0, 20);
            YGNodeInsertChild(rootChild1, rootChild1Child0, 0);

            YogaNode rootChild1Child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1Child1, 25);
            YGNodeStyleSetHeight(rootChild1Child1, 10);
            YGNodeInsertChild(rootChild1, rootChild1Child1, 1);

            YogaNode rootChild1Child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1Child2, 25);
            YGNodeStyleSetHeight(rootChild1Child2, 20);
            YGNodeInsertChild(rootChild1, rootChild1Child2, 2);

            YogaNode rootChild1Child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1Child3, 25);
            YGNodeStyleSetHeight(rootChild1Child3, 10);
            YGNodeInsertChild(rootChild1, rootChild1Child3, 3);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1Child0));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild1Child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child1));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild1Child2));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child2));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1Child2));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild1Child3));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild1Child3));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child3));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child1));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child1));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild1Child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild1Child2));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child2));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1Child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child3));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild1Child3));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child3));
        }

        [Test]
        public void align_baseline_child_multiline_override()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 60);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(rootChild1, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(rootChild1, Wrap.Wrap);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 25);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild1Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1Child0, 25);
            YGNodeStyleSetHeight(rootChild1Child0, 20);
            YGNodeInsertChild(rootChild1, rootChild1Child0, 0);

            YogaNode rootChild1Child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignSelf(rootChild1Child1, YogaAlign.Baseline);
            YGNodeStyleSetWidth(rootChild1Child1, 25);
            YGNodeStyleSetHeight(rootChild1Child1, 10);
            YGNodeInsertChild(rootChild1, rootChild1Child1, 1);

            YogaNode rootChild1Child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1Child2, 25);
            YGNodeStyleSetHeight(rootChild1Child2, 20);
            YGNodeInsertChild(rootChild1, rootChild1Child2, 2);

            YogaNode rootChild1Child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignSelf(rootChild1Child3, YogaAlign.Baseline);
            YGNodeStyleSetWidth(rootChild1Child3, 25);
            YGNodeStyleSetHeight(rootChild1Child3, 10);
            YGNodeInsertChild(rootChild1, rootChild1Child3, 3);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1Child0));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild1Child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child1));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild1Child2));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child2));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1Child2));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild1Child3));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild1Child3));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child3));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child1));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child1));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild1Child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild1Child2));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child2));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1Child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child3));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild1Child3));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child3));
        }

        [Test]
        public void align_baseline_child_multiline_no_override_on_second_line()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 60);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(rootChild1, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(rootChild1, Wrap.Wrap);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 25);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild1Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1Child0, 25);
            YGNodeStyleSetHeight(rootChild1Child0, 20);
            YGNodeInsertChild(rootChild1, rootChild1Child0, 0);

            YogaNode rootChild1Child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1Child1, 25);
            YGNodeStyleSetHeight(rootChild1Child1, 10);
            YGNodeInsertChild(rootChild1, rootChild1Child1, 1);

            YogaNode rootChild1Child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1Child2, 25);
            YGNodeStyleSetHeight(rootChild1Child2, 20);
            YGNodeInsertChild(rootChild1, rootChild1Child2, 2);

            YogaNode rootChild1Child3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignSelf(rootChild1Child3, YogaAlign.Baseline);
            YGNodeStyleSetWidth(rootChild1Child3, 25);
            YGNodeStyleSetHeight(rootChild1Child3, 10);
            YGNodeInsertChild(rootChild1, rootChild1Child3, 3);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1Child0));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild1Child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child1));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild1Child2));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child2));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1Child2));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild1Child3));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild1Child3));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child3));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child1));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child1));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild1Child2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild1Child2));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child2));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1Child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child3));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild1Child3));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1Child3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child3));
        }

        [Test]
        public void align_baseline_child_top()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPosition(rootChild0, Edge.Top, 10);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
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
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild0));
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
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild0));
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

        [Test]
        public void align_baseline_child_top2()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPosition(rootChild1, Edge.Top, 5);
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
            Assert.AreEqual(45, YGNodeLayoutGetTop(rootChild1));
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
            Assert.AreEqual(45, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child0));
        }

        [Test]
        public void align_baseline_double_nested_child()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child0, 50);
            YGNodeStyleSetHeight(rootChild0Child0, 20);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 20);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild1Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1Child0, 50);
            YGNodeStyleSetHeight(rootChild1Child0, 15);
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

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(5, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(15, YGNodeLayoutGetHeight(rootChild1Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(5, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(15, YGNodeLayoutGetHeight(rootChild1Child0));
        }

        [Test]
        public void align_baseline_column()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 20);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void align_baseline_child_margin()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(rootChild0, Edge.Left, 5);
            YGNodeStyleSetMargin(rootChild0, Edge.Top, 5);
            YGNodeStyleSetMargin(rootChild0, Edge.Right, 5);
            YGNodeStyleSetMargin(rootChild0, Edge.Bottom, 5);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 20);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild1Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(rootChild1Child0, Edge.Left, 1);
            YGNodeStyleSetMargin(rootChild1Child0, Edge.Top, 1);
            YGNodeStyleSetMargin(rootChild1Child0, Edge.Right, 1);
            YGNodeStyleSetMargin(rootChild1Child0, Edge.Bottom, 1);
            YGNodeStyleSetWidth(rootChild1Child0, 50);
            YGNodeStyleSetHeight(rootChild1Child0, 10);
            YGNodeInsertChild(rootChild1, rootChild1Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(5, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(5, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(44, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(1, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(1, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(5, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(-10, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(44, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(-1, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(1, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child0));
        }

        [Test]
        public void align_baseline_child_padding()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetPadding(root, Edge.Left, 5);
            YGNodeStyleSetPadding(root, Edge.Top, 5);
            YGNodeStyleSetPadding(root, Edge.Right, 5);
            YGNodeStyleSetPadding(root, Edge.Bottom, 5);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPadding(rootChild1, Edge.Left, 5);
            YGNodeStyleSetPadding(rootChild1, Edge.Top, 5);
            YGNodeStyleSetPadding(rootChild1, Edge.Right, 5);
            YGNodeStyleSetPadding(rootChild1, Edge.Bottom, 5);
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

            Assert.AreEqual(5, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(5, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(55, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(5, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(5, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(5, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(-5, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(-5, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(5, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child0));
        }

        [Test]
        public void align_baseline_multiline()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 20);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild1Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1Child0, 50);
            YGNodeStyleSetHeight(rootChild1Child0, 10);
            YGNodeInsertChild(rootChild1, rootChild1Child0, 0);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 50);
            YGNodeStyleSetHeight(rootChild2, 20);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild2Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2Child0, 50);
            YGNodeStyleSetHeight(rootChild2Child0, 10);
            YGNodeInsertChild(rootChild2, rootChild2Child0, 0);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeStyleSetHeight(rootChild3, 50);
            YGNodeInsertChild(root, rootChild3, 3);
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

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2Child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(60, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild3));

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

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(60, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild3));
        }

        [Test]
        public void align_baseline_multiline_column()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 30);
            YGNodeStyleSetHeight(rootChild1, 50);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild1Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1Child0, 20);
            YGNodeStyleSetHeight(rootChild1Child0, 20);
            YGNodeInsertChild(rootChild1, rootChild1Child0, 0);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 40);
            YGNodeStyleSetHeight(rootChild2, 70);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild2Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2Child0, 10);
            YGNodeStyleSetHeight(rootChild2Child0, 10);
            YGNodeInsertChild(rootChild2, rootChild2Child0, 0);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeStyleSetHeight(rootChild3, 20);
            YGNodeInsertChild(root, rootChild3, 3);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1Child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(70, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2Child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2Child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(70, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild3));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1Child0));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(70, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild2Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2Child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(70, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild3));
        }

        [Test]
        public void align_baseline_multiline_column2()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 30);
            YGNodeStyleSetHeight(rootChild1, 50);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild1Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1Child0, 20);
            YGNodeStyleSetHeight(rootChild1Child0, 20);
            YGNodeInsertChild(rootChild1, rootChild1Child0, 0);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 40);
            YGNodeStyleSetHeight(rootChild2, 70);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild2Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2Child0, 10);
            YGNodeStyleSetHeight(rootChild2Child0, 10);
            YGNodeInsertChild(rootChild2, rootChild2Child0, 0);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeStyleSetHeight(rootChild3, 20);
            YGNodeInsertChild(root, rootChild3, 3);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1Child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(70, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2Child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2Child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(70, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild3));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1Child0));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(70, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild2Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2Child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(70, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild3));
        }

        [Test]
        public void align_baseline_multiline_row_and_column()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 50);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild1Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1Child0, 50);
            YGNodeStyleSetHeight(rootChild1Child0, 10);
            YGNodeInsertChild(rootChild1, rootChild1Child0, 0);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 50);
            YGNodeStyleSetHeight(rootChild2, 20);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild2Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2Child0, 50);
            YGNodeStyleSetHeight(rootChild2Child0, 10);
            YGNodeInsertChild(rootChild2, rootChild2Child0, 0);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeStyleSetHeight(rootChild3, 20);
            YGNodeInsertChild(root, rootChild3, 3);
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
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2Child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(90, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild3));

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
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(90, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild3));
        }

        [Test]
        public void align_items_center_child_with_margin_bigger_than_parent()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 52);
            YGNodeStyleSetHeight(root, 52);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(rootChild0, YogaAlign.Center);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(rootChild0Child0, Edge.Left, 10);
            YGNodeStyleSetMargin(rootChild0Child0, Edge.Right, 10);
            YGNodeStyleSetWidth(rootChild0Child0, 52);
            YGNodeStyleSetHeight(rootChild0Child0, 52);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(52, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(52, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(-10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(72, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(52, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(52, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(52, YGNodeLayoutGetHeight(rootChild0Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(52, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(52, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(-10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(72, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(52, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(52, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(52, YGNodeLayoutGetHeight(rootChild0Child0));
        }

        [Test]
        public void align_items_flex_end_child_with_margin_bigger_than_parent()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 52);
            YGNodeStyleSetHeight(root, 52);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(rootChild0, YogaAlign.FlexEnd);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(rootChild0Child0, Edge.Left, 10);
            YGNodeStyleSetMargin(rootChild0Child0, Edge.Right, 10);
            YGNodeStyleSetWidth(rootChild0Child0, 52);
            YGNodeStyleSetHeight(rootChild0Child0, 52);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(52, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(52, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(-10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(72, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(52, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(52, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(52, YGNodeLayoutGetHeight(rootChild0Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(52, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(52, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(-10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(72, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(52, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(52, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(52, YGNodeLayoutGetHeight(rootChild0Child0));
        }

        [Test]
        public void align_items_center_child_without_margin_bigger_than_parent()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 52);
            YGNodeStyleSetHeight(root, 52);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(rootChild0, YogaAlign.Center);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child0, 72);
            YGNodeStyleSetHeight(rootChild0Child0, 72);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(52, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(52, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(-10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(-10, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(72, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(72, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(72, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(72, YGNodeLayoutGetHeight(rootChild0Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(52, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(52, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(-10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(-10, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(72, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(72, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(72, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(72, YGNodeLayoutGetHeight(rootChild0Child0));
        }

        [Test]
        public void align_items_flex_end_child_without_margin_bigger_than_parent()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 52);
            YGNodeStyleSetHeight(root, 52);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(rootChild0, YogaAlign.FlexEnd);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child0, 72);
            YGNodeStyleSetHeight(rootChild0Child0, 72);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(52, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(52, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(-10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(-10, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(72, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(72, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(72, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(72, YGNodeLayoutGetHeight(rootChild0Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(52, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(52, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(-10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(-10, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(72, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(72, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(72, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(72, YGNodeLayoutGetHeight(rootChild0Child0));
        }

        [Test]
        public void align_center_should_size_based_on_content()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetMargin(root, Edge.Top, 20);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(rootChild0, Justify.Center);
            YGNodeStyleSetFlexShrink(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0Child0, 1);
            YGNodeStyleSetFlexShrink(rootChild0Child0, 1);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild0Child0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child0Child0, 20);
            YGNodeStyleSetHeight(rootChild0Child0Child0, 20);
            YGNodeInsertChild(rootChild0Child0, rootChild0Child0Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0Child0Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0Child0Child0));
        }

        [Test]
        public void align_strech_should_size_based_on_parent()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(root, Edge.Top, 20);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(rootChild0, Justify.Center);
            YGNodeStyleSetFlexShrink(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0Child0, 1);
            YGNodeStyleSetFlexShrink(rootChild0Child0, 1);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild0Child0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child0Child0, 20);
            YGNodeStyleSetHeight(rootChild0Child0Child0, 20);
            YGNodeInsertChild(rootChild0Child0, rootChild0Child0Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0Child0Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0Child0Child0));
        }

        [Test]
        public void align_flex_start_with_shrinking_children()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 500);
            YGNodeStyleSetHeight(root, 500);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(rootChild0, YogaAlign.FlexStart);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0Child0, 1);
            YGNodeStyleSetFlexShrink(rootChild0Child0, 1);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild0Child0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0Child0Child0, 1);
            YGNodeStyleSetFlexShrink(rootChild0Child0Child0, 1);
            YGNodeInsertChild(rootChild0Child0, rootChild0Child0Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0Child0Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(500, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0Child0Child0));
        }

        [Test]
        public void align_flex_start_with_stretching_children()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 500);
            YGNodeStyleSetHeight(root, 500);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0Child0, 1);
            YGNodeStyleSetFlexShrink(rootChild0Child0, 1);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild0Child0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0Child0Child0, 1);
            YGNodeStyleSetFlexShrink(rootChild0Child0Child0, 1);
            YGNodeInsertChild(rootChild0Child0, rootChild0Child0Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0Child0Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0Child0Child0));
        }

        [Test]
        public void align_flex_start_with_shrinking_children_with_stretch()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 500);
            YGNodeStyleSetHeight(root, 500);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(rootChild0, YogaAlign.FlexStart);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0Child0, 1);
            YGNodeStyleSetFlexShrink(rootChild0Child0, 1);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild0Child0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0Child0Child0, 1);
            YGNodeStyleSetFlexShrink(rootChild0Child0Child0, 1);
            YGNodeInsertChild(rootChild0Child0, rootChild0Child0Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0Child0Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(500, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0Child0Child0));
        }
    }
}
