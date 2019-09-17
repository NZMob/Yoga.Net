using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGMeasureTest
    {
        static MeasureFunc _measure = (
            YogaNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode, object context) =>
        {
            var nodeContext = node.Context;

            int measureCount = nodeContext == null ? 0 : (int)nodeContext;
            measureCount++;
            node.Context = measureCount;

            return new YogaSize(10, 10);
        };

        static MeasureFunc _simulateWrappingText = (
            YogaNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode, object context) =>
        {
            if (widthMode == MeasureMode.Undefined || width >= 68)
            {
                return new YogaSize(68, 16);
            }

            return new YogaSize(50, 32);
        };

        static MeasureFunc _measureAssertNegative = (
            YogaNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode,
            object context) =>
        {
            Assert.GreaterOrEqual(width, 0);
            Assert.GreaterOrEqual(height, 0);

            return new YogaSize(0, 0);
        };

        [Test]
        public void do_not_measure_single_grow_shrink_child()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            rootChild0.Context = 0;
            YGNodeSetMeasureFunc(rootChild0, _measure);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetFlexShrink(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, (int)rootChild0.Context);
        }

        [Test]
        public void measure_absolute_child_with_no_constraints()
        {
            YogaNode root = YGNodeNew();

            YogaNode rootChild0 = YGNodeNew();
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNew();
            YGNodeStyleSetPositionType(rootChild0Child0, PositionType.Absolute);
            rootChild0Child0.Context = 0;
            YGNodeSetMeasureFunc(rootChild0Child0, _measure);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, (int)rootChild0Child0.Context);
        }

        [Test]
        public void do_not_measure_when_min_equals_max()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            rootChild0.Context = 0;
            YGNodeSetMeasureFunc(rootChild0, _measure);
            YGNodeStyleSetMinWidth(rootChild0, 10);
            YGNodeStyleSetMaxWidth(rootChild0, 10);
            YGNodeStyleSetMinHeight(rootChild0, 10);
            YGNodeStyleSetMaxHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, (int)rootChild0.Context);
            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void do_not_measure_when_min_equals_max_percentages()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            rootChild0.Context = 0;
            YGNodeSetMeasureFunc(rootChild0, _measure);
            YGNodeStyleSetMinWidthPercent(rootChild0, 10);
            YGNodeStyleSetMaxWidthPercent(rootChild0, 10);
            YGNodeStyleSetMinHeightPercent(rootChild0, 10);
            YGNodeStyleSetMaxHeightPercent(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, (int)rootChild0.Context);
            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));
        }


        [Test]
        public void measure_nodes_with_margin_auto_and_stretch()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 500);
            YGNodeStyleSetHeight(root, 500);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeSetMeasureFunc(rootChild0, _measure);
            YGNodeStyleSetMarginAuto(rootChild0, Edge.Left);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(490, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void do_not_measure_when_min_equals_max_mixed_width_percent()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            rootChild0.Context = 0;
            YGNodeSetMeasureFunc(rootChild0, _measure);
            YGNodeStyleSetMinWidthPercent(rootChild0, 10);
            YGNodeStyleSetMaxWidthPercent(rootChild0, 10);
            YGNodeStyleSetMinHeight(rootChild0, 10);
            YGNodeStyleSetMaxHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, (int)rootChild0.Context);
            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void do_not_measure_when_min_equals_max_mixed_height_percent()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            rootChild0.Context = 0;
            YGNodeSetMeasureFunc(rootChild0, _measure);
            YGNodeStyleSetMinWidth(rootChild0, 10);
            YGNodeStyleSetMaxWidth(rootChild0, 10);
            YGNodeStyleSetMinHeightPercent(rootChild0, 10);
            YGNodeStyleSetMaxHeightPercent(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, (int)rootChild0.Context);
            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void measure_enough_size_should_be_in_single_line()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetAlignSelf(rootChild0, YogaAlign.FlexStart);
            YGNodeSetMeasureFunc(rootChild0, _simulateWrappingText);

            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(68, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(16, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void measure_not_enough_size_should_wrap()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 55);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetAlignSelf(rootChild0, YogaAlign.FlexStart);
            //  YGNodeSetMeasureFunc(root_child0, _simulate_wrapping_text);
            YGNodeSetMeasureFunc(rootChild0, _simulateWrappingText);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(32, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void measure_zero_space_should_grow()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetHeight(root, 200);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Column);
            YGNodeStyleSetFlexGrow(root, 0);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetFlexDirection(rootChild0, FlexDirection.Column);
            YGNodeStyleSetPadding(rootChild0, Edge.All, 100);
            rootChild0.Context = 0;
            YGNodeSetMeasureFunc(rootChild0, _measure);

            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, 282, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(282, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
        }

        [Test]
        public void measure_flex_direction_row_and_padding()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetPadding(root, Edge.Left, 25);
            YGNodeStyleSetPadding(root, Edge.Top, 25);
            YGNodeStyleSetPadding(root, Edge.Right, 25);
            YGNodeStyleSetPadding(root, Edge.Bottom, 25);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeSetMeasureFunc(rootChild0, _simulateWrappingText);
            //  YGNodeSetMeasureFunc(root_child0, _simulate_wrapping_text);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 5);
            YGNodeStyleSetHeight(rootChild1, 5);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(25, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(75, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(25, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(5, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(5, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void measure_flex_direction_column_and_padding()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(root, Edge.Top, 20);
            YGNodeStyleSetPadding(root, Edge.All, 25);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeSetMeasureFunc(rootChild0, _simulateWrappingText);
            //  YGNodeSetMeasureFunc(root_child0, _simulate_wrapping_text);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 5);
            YGNodeStyleSetHeight(rootChild1, 5);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(25, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(32, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(57, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(5, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(5, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void measure_flex_direction_row_no_padding()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetMargin(root, Edge.Top, 20);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            //  YGNodeSetMeasureFunc(root_child0, _simulate_wrapping_text);
            YGNodeSetMeasureFunc(rootChild0, _simulateWrappingText);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 5);
            YGNodeStyleSetHeight(rootChild1, 5);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(5, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(5, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void measure_flex_direction_row_no_padding_align_items_flexstart()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetMargin(root, Edge.Top, 20);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeSetMeasureFunc(rootChild0, _simulateWrappingText);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 5);
            YGNodeStyleSetHeight(rootChild1, 5);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(32, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(5, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(5, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void measure_with_fixed_size()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(root, Edge.Top, 20);
            YGNodeStyleSetPadding(root, Edge.All, 25);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeSetMeasureFunc(rootChild0, _simulateWrappingText);
            YGNodeStyleSetWidth(rootChild0, 10);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 5);
            YGNodeStyleSetHeight(rootChild1, 5);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(25, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(35, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(5, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(5, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void measure_with_flex_shrink()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(root, Edge.Top, 20);
            YGNodeStyleSetPadding(root, Edge.All, 25);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeSetMeasureFunc(rootChild0, _simulateWrappingText);
            YGNodeStyleSetFlexShrink(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 5);
            YGNodeStyleSetHeight(rootChild1, 5);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(25, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(25, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(5, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(5, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void measure_no_padding()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(root, Edge.Top, 20);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 50);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeSetMeasureFunc(rootChild0, _simulateWrappingText);
            YGNodeStyleSetFlexShrink(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 5);
            YGNodeStyleSetHeight(rootChild1, 5);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(20, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(32, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(32, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(5, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(5, YGNodeLayoutGetHeight(rootChild1));
        }

#if GTEST_HAS_DEATH_TEST
TEST(YogaDeathTest, cannot_add_child_to_node_with_measure_func() {
  YogaNode root = YGNodeNew();
  root.setMeasureFunc(_measure);

  YogaNode root_child0 = YGNodeNew();
  ASSERT_DEATH(YGNodeInsertChild(root, root_child0, 0), "Cannot add child.*");
  YGNodeFree(root_child0);
  
}

TEST(YogaDeathTest, cannot_add_nonnull_measure_func_to_non_leaf_node() {
  YogaNode root = YGNodeNew();
  YogaNode root_child0 = YGNodeNew();
  YGNodeInsertChild(root, root_child0, 0);
  ASSERT_DEATH(root.setMeasureFunc(_measure), "Cannot set measure function.*");
  
}

#endif

        [Test]
        public void can_nullify_measure_func_on_any_node()
        {
            YogaNode root = YGNodeNew();
            YGNodeInsertChild(root, YGNodeNew(), 0);
            YGNodeSetMeasureFunc(root, null);
            Assert.IsTrue(root.MeasureFunc == null);
        }

        [Test]
        public void cant_call_negative_measure()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Column);
            YGNodeStyleSetWidth(root, 50);
            YGNodeStyleSetHeight(root, 10);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeSetMeasureFunc(rootChild0, _measureAssertNegative);
            YGNodeStyleSetMargin(rootChild0, Edge.Top, 20);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
        }

        [Test]
        public void cant_call_negative_measure_horizontal()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 10);
            YGNodeStyleSetHeight(root, 20);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeSetMeasureFunc(rootChild0, _measureAssertNegative);
            YGNodeStyleSetMargin(rootChild0, Edge.Start, 20);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
        }

        static MeasureFunc _measure9010 = (
            YogaNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode,
            object context) =>
        {
            return new YogaSize(90, 10);
        };

        [Test]
        public void percent_with_text_node()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.SpaceBetween);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 80);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeSetMeasureFunc(rootChild1, _measure9010);
            YGNodeStyleSetMaxWidthPercent(rootChild1, 50);
            YGNodeStyleSetPaddingPercent(rootChild1, Edge.Top, 50);
            YGNodeInsertChild(root, rootChild1, 1);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(15, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));
        }
    }
}
