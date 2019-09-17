using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGMinMaxDimensionTest
    {
        [Test]
        public void max_width()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetMaxWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void max_height()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 10);
            YGNodeStyleSetMaxHeight(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void min_height()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetMinHeight(rootChild0, 60);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void min_width()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetMinWidth(rootChild0, 60);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(20, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void justify_content_min_max()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetMinHeight(root, 100);
            YGNodeStyleSetMaxHeight(root, 200);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 60);
            YGNodeStyleSetHeight(rootChild0, 60);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void align_items_min_max()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetMinWidth(root, 100);
            YGNodeStyleSetMaxWidth(root, 200);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 60);
            YGNodeStyleSetHeight(rootChild0, 60);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(20, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(20, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void justify_content_overflow_min_max()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetMinHeight(root, 100);
            YGNodeStyleSetMaxHeight(root, 110);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 50);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 50);
            YGNodeStyleSetHeight(rootChild2, 50);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(110, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(-20, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(110, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(-20, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void flex_grow_to_min()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetMinHeight(root, 100);
            YGNodeStyleSetMaxHeight(root, 500);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetFlexShrink(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild1, 50);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void flex_grow_in_at_most_container()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(rootChild0, FlexDirection.Row);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0Child0, 1);
            YGNodeStyleSetFlexBasis(rootChild0Child0, 0);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0Child0));
        }

        [Test]
        public void flex_grow_child()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetFlexBasis(rootChild0, 0);
            YGNodeStyleSetHeight(rootChild0, 100);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void flex_grow_within_constrained_min_max_column()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetMinHeight(root, 100);
            YGNodeStyleSetMaxHeight(root, 200);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild1, 50);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void flex_grow_within_max_width()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(rootChild0, FlexDirection.Row);
            YGNodeStyleSetMaxWidth(rootChild0, 100);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0Child0, 1);
            YGNodeStyleSetHeight(rootChild0Child0, 20);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0Child0));
        }

        [Test]
        public void flex_grow_within_constrained_max_width()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(rootChild0, FlexDirection.Row);
            YGNodeStyleSetMaxWidth(rootChild0, 300);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0Child0, 1);
            YGNodeStyleSetHeight(rootChild0Child0, 20);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0Child0));
        }

        [Test]
        public void flex_root_ignored()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetMinHeight(root, 100);
            YGNodeStyleSetMaxHeight(root, 500);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetFlexBasis(rootChild0, 200);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild1, 100);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(300, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(200, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(300, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(200, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void flex_grow_root_minimized()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetMinHeight(root, 100);
            YGNodeStyleSetMaxHeight(root, 500);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetMinHeight(rootChild0, 100);
            YGNodeStyleSetMaxHeight(rootChild0, 500);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0Child0, 1);
            YGNodeStyleSetFlexBasis(rootChild0Child0, 200);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild0Child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild0Child1, 100);
            YGNodeInsertChild(rootChild0, rootChild0Child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(300, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(300, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child1));
            Assert.AreEqual(200, YGNodeLayoutGetTop(rootChild0Child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(300, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(300, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child1));
            Assert.AreEqual(200, YGNodeLayoutGetTop(rootChild0Child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child1));
        }

        [Test]
        public void flex_grow_height_maximized()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 500);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetMinHeight(rootChild0, 100);
            YGNodeStyleSetMaxHeight(rootChild0, 500);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0Child0, 1);
            YGNodeStyleSetFlexBasis(rootChild0Child0, 200);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild0Child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild0Child1, 100);
            YGNodeInsertChild(rootChild0, rootChild0Child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(400, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child1));
            Assert.AreEqual(400, YGNodeLayoutGetTop(rootChild0Child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(400, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child1));
            Assert.AreEqual(400, YGNodeLayoutGetTop(rootChild0Child1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child1));
        }

        [Test]
        public void flex_grow_within_constrained_min_row()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetMinWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void flex_grow_within_constrained_min_column()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetMinHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild1, 50);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void flex_grow_within_constrained_max_row()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 200);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(rootChild0, FlexDirection.Row);
            YGNodeStyleSetMaxWidth(rootChild0, 100);
            YGNodeStyleSetHeight(rootChild0, 100);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexShrink(rootChild0Child0, 1);
            YGNodeStyleSetFlexBasis(rootChild0Child0, 100);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild0Child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child1, 50);
            YGNodeInsertChild(rootChild0, rootChild0Child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0Child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0Child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0Child1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child1));
        }

        [Test]
        public void flex_grow_within_constrained_max_column()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetMaxHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexShrink(rootChild0, 1);
            YGNodeStyleSetFlexBasis(rootChild0, 100);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild1, 50);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void child_min_max_width_flexing()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 120);
            YGNodeStyleSetHeight(root, 50);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetFlexBasis(rootChild0, 0);
            YGNodeStyleSetMinWidth(rootChild0, 60);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeStyleSetFlexBasisPercent(rootChild1, 50);
            YGNodeStyleSetMaxWidth(rootChild1, 20);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(120, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(120, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(20, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void min_width_overrides_width()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetMinWidth(root, 100);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root));
        }

        [Test]
        public void max_width_overrides_width()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetMaxWidth(root, 100);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(root));
        }

        [Test]
        public void min_height_overrides_height()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root, 50);
            YGNodeStyleSetMinHeight(root, 100);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));
        }

        [Test]
        public void max_height_overrides_height()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root, 200);
            YGNodeStyleSetMaxHeight(root, 100);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));
        }

        [Test]
        public void min_max_percent_no_width_height()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetMinWidthPercent(rootChild0, 10);
            YGNodeStyleSetMaxWidthPercent(rootChild0, 10);
            YGNodeStyleSetMinHeightPercent(rootChild0, 10);
            YGNodeStyleSetMaxHeightPercent(rootChild0, 10);
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
    }
}
