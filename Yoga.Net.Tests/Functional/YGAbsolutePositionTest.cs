using NUnit.Framework;
using static Yoga.Net.YogaGlobal;

namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGAbsolutePositionTest
    {
        [Test]
        public void absolute_layout_width_height_start_top()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetPosition(rootChild0, Edge.Start, 10);
            YGNodeStyleSetPosition(rootChild0, Edge.Top, 10);
            YGNodeStyleSetWidth(rootChild0, 10);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void absolute_layout_width_height_end_bottom()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetPosition(rootChild0, Edge.End, 10);
            YGNodeStyleSetPosition(rootChild0, Edge.Bottom, 10);
            YGNodeStyleSetWidth(rootChild0, 10);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void absolute_layout_start_top_end_bottom()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetPosition(rootChild0, Edge.Start, 10);
            YGNodeStyleSetPosition(rootChild0, Edge.Top, 10);
            YGNodeStyleSetPosition(rootChild0, Edge.End, 10);
            YGNodeStyleSetPosition(rootChild0, Edge.Bottom, 10);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void absolute_layout_width_height_start_top_end_bottom()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetPosition(rootChild0, Edge.Start, 10);
            YGNodeStyleSetPosition(rootChild0, Edge.Top, 10);
            YGNodeStyleSetPosition(rootChild0, Edge.End, 10);
            YGNodeStyleSetPosition(rootChild0, Edge.Bottom, 10);
            YGNodeStyleSetWidth(rootChild0, 10);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void do_not_clamp_height_of_absolute_node_to_height_of_its_overflow_hidden_parent()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetOverflow(root, Overflow.Hidden);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetPosition(rootChild0, Edge.Start, 0);
            YGNodeStyleSetPosition(rootChild0, Edge.Top, 0);
            YGNodeInsertChild(root, rootChild0, 0);

            var rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child0, 100);
            YGNodeStyleSetHeight(rootChild0Child0, 100);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

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
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(-50, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child0));
        }

        [Test]
        public void absolute_layout_within_border()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(root, Edge.Left, 10);
            YGNodeStyleSetMargin(root, Edge.Top, 10);
            YGNodeStyleSetMargin(root, Edge.Right, 10);
            YGNodeStyleSetMargin(root, Edge.Bottom, 10);
            YGNodeStyleSetPadding(root, Edge.Left, 10);
            YGNodeStyleSetPadding(root, Edge.Top, 10);
            YGNodeStyleSetPadding(root, Edge.Right, 10);
            YGNodeStyleSetPadding(root, Edge.Bottom, 10);
            YGNodeStyleSetBorder(root, Edge.Left, 10);
            YGNodeStyleSetBorder(root, Edge.Top, 10);
            YGNodeStyleSetBorder(root, Edge.Right, 10);
            YGNodeStyleSetBorder(root, Edge.Bottom, 10);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetPosition(rootChild0, Edge.Left, 0);
            YGNodeStyleSetPosition(rootChild0, Edge.Top, 0);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            var rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild1, PositionType.Absolute);
            YGNodeStyleSetPosition(rootChild1, Edge.Right, 0);
            YGNodeStyleSetPosition(rootChild1, Edge.Bottom, 0);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 50);
            YGNodeInsertChild(root, rootChild1, 1);

            var rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild2, PositionType.Absolute);
            YGNodeStyleSetPosition(rootChild2, Edge.Left, 0);
            YGNodeStyleSetPosition(rootChild2, Edge.Top, 0);
            YGNodeStyleSetMargin(rootChild2, Edge.Left, 10);
            YGNodeStyleSetMargin(rootChild2, Edge.Top, 10);
            YGNodeStyleSetMargin(rootChild2, Edge.Right, 10);
            YGNodeStyleSetMargin(rootChild2, Edge.Bottom, 10);
            YGNodeStyleSetWidth(rootChild2, 50);
            YGNodeStyleSetHeight(rootChild2, 50);
            YGNodeInsertChild(root, rootChild2, 2);

            var rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild3, PositionType.Absolute);
            YGNodeStyleSetPosition(rootChild3, Edge.Right, 0);
            YGNodeStyleSetPosition(rootChild3, Edge.Bottom, 0);
            YGNodeStyleSetMargin(rootChild3, Edge.Left, 10);
            YGNodeStyleSetMargin(rootChild3, Edge.Top, 10);
            YGNodeStyleSetMargin(rootChild3, Edge.Right, 10);
            YGNodeStyleSetMargin(rootChild3, Edge.Bottom, 10);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeStyleSetHeight(rootChild3, 50);
            YGNodeInsertChild(root, rootChild3, 3);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(20, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild3));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(10, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(10, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(20, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild3));
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_center()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetWidth(rootChild0, 60);
            YGNodeStyleSetHeight(rootChild0, 40);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_flex_end()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.FlexEnd);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexEnd);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetWidth(rootChild0, 60);
            YGNodeStyleSetHeight(rootChild0, 40);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void absolute_layout_justify_content_center()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetWidth(rootChild0, 60);
            YGNodeStyleSetHeight(rootChild0, 40);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void absolute_layout_align_items_center()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetWidth(rootChild0, 60);
            YGNodeStyleSetHeight(rootChild0, 40);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void absolute_layout_align_items_center_on_child_only()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignSelf(rootChild0, YogaAlign.Center);
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetWidth(rootChild0, 60);
            YGNodeStyleSetHeight(rootChild0, 40);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_center_and_top_position()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetPosition(rootChild0, Edge.Top, 10);
            YGNodeStyleSetWidth(rootChild0, 60);
            YGNodeStyleSetHeight(rootChild0, 40);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_center_and_bottom_position()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetPosition(rootChild0, Edge.Bottom, 10);
            YGNodeStyleSetWidth(rootChild0, 60);
            YGNodeStyleSetHeight(rootChild0, 40);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_center_and_left_position()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetPosition(rootChild0, Edge.Left, 5);
            YGNodeStyleSetWidth(rootChild0, 60);
            YGNodeStyleSetHeight(rootChild0, 40);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(5, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(5, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_center_and_right_position()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexGrow(root, 1);
            YGNodeStyleSetWidth(root, 110);
            YGNodeStyleSetHeight(root, 100);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetPosition(rootChild0, Edge.Right, 5);
            YGNodeStyleSetWidth(rootChild0, 60);
            YGNodeStyleSetHeight(rootChild0, 40);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(110, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void position_root_with_rtl_should_position_without_direction()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetPosition(root, Edge.Left, 72);
            YGNodeStyleSetWidth(root, 52);
            YGNodeStyleSetHeight(root, 52);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(72, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(52, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(52, YGNodeLayoutGetHeight(root));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(72, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(52, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(52, YGNodeLayoutGetHeight(root));
        }

        [Test]
        public void absolute_layout_percentage_bottom_based_on_parent_height()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 200);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetPositionPercent(rootChild0, Edge.Top, 50);
            YGNodeStyleSetWidth(rootChild0, 10);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            var rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild1, PositionType.Absolute);
            YGNodeStyleSetPositionPercent(rootChild1, Edge.Bottom, 50);
            YGNodeStyleSetWidth(rootChild1, 10);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            var rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild2, PositionType.Absolute);
            YGNodeStyleSetPositionPercent(rootChild2, Edge.Top, 10);
            YGNodeStyleSetPositionPercent(rootChild2, Edge.Bottom, 10);
            YGNodeStyleSetWidth(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(90, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(90, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void absolute_layout_in_wrap_reverse_column_container()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetWidth(rootChild0, 20);
            YGNodeStyleSetHeight(rootChild0, 20);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void absolute_layout_in_wrap_reverse_row_container()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetWidth(rootChild0, 20);
            YGNodeStyleSetHeight(rootChild0, 20);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void absolute_layout_in_wrap_reverse_column_container_flex_end()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignSelf(rootChild0, YogaAlign.FlexEnd);
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetWidth(rootChild0, 20);
            YGNodeStyleSetHeight(rootChild0, 20);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void absolute_layout_in_wrap_reverse_row_container_flex_end()
        {
            var config = YGConfigNew();

            var root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            var rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignSelf(rootChild0, YogaAlign.FlexEnd);
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetWidth(rootChild0, 20);
            YGNodeStyleSetHeight(rootChild0, 20);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));
        }
    }
}
