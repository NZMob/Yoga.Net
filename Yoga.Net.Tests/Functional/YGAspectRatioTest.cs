using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGAspectRatioTest
    {
        static MeasureFunc _measure = (
            YogaNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode, object context) =>
        {
            return new YogaSize(
                widthMode == MeasureMode.Exactly ? width : 50,
                heightMode == MeasureMode.Exactly ? height : 50);
        };

        [Test]
        public void aspect_ratio_cross_defined()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_main_defined()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_both_dimensions_defined_row()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild0, 100);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_both_dimensions_defined_column()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild0, 100);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_align_stretch()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_flex_grow()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_flex_shrink()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetHeight(rootChild0, 150);
            YGNodeStyleSetFlexShrink(rootChild0, 1);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_flex_shrink_2()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetHeightPercent(rootChild0, 100);
            YGNodeStyleSetFlexShrink(rootChild0, 1);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNew();
            YGNodeStyleSetHeightPercent(rootChild1, 100);
            YGNodeStyleSetFlexShrink(rootChild1, 1);
            YGNodeStyleSetAspectRatio(rootChild1, 1);
            YGNodeInsertChild(root, rootChild1, 1);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void aspect_ratio_basis()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetFlexBasis(rootChild0, 50);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_absolute_layout_width_defined()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetPosition(rootChild0, Edge.Left, 0);
            YGNodeStyleSetPosition(rootChild0, Edge.Top, 0);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_absolute_layout_height_defined()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetPosition(rootChild0, Edge.Left, 0);
            YGNodeStyleSetPosition(rootChild0, Edge.Top, 0);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_with_max_cross_defined()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeStyleSetMaxWidth(rootChild0, 40);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_with_max_main_defined()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetMaxHeight(rootChild0, 40);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_with_min_cross_defined()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetHeight(rootChild0, 30);
            YGNodeStyleSetMinWidth(rootChild0, 40);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_with_min_main_defined()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild0, 30);
            YGNodeStyleSetMinHeight(rootChild0, 40);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_double_cross()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeStyleSetAspectRatio(rootChild0, 2);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_half_cross()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetHeight(rootChild0, 100);
            YGNodeStyleSetAspectRatio(rootChild0, 0.5f);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_double_main()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetAspectRatio(rootChild0, 0.5f);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_half_main()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild0, 100);
            YGNodeStyleSetAspectRatio(rootChild0, 2);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_with_measure_func()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeSetMeasureFunc(rootChild0, _measure);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_width_height_flex_grow_row()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 200);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_width_height_flex_grow_column()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_height_as_flex_basis()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNew();
            YGNodeStyleSetHeight(rootChild1, 100);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeStyleSetAspectRatio(rootChild1, 1);
            YGNodeInsertChild(root, rootChild1, 1);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(75, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(75, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(75, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(125, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(125, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void aspect_ratio_width_as_flex_basis()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild1, 100);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeStyleSetAspectRatio(rootChild1, 1);
            YGNodeInsertChild(root, rootChild1, 1);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(75, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(75, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(75, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(125, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(125, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void aspect_ratio_overrides_flex_grow_row()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetAspectRatio(rootChild0, 0.5f);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_overrides_flex_grow_column()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetAspectRatio(rootChild0, 2);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_left_right_absolute()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetPosition(rootChild0, Edge.Left, 10);
            YGNodeStyleSetPosition(rootChild0, Edge.Top, 10);
            YGNodeStyleSetPosition(rootChild0, Edge.Right, 10);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_top_bottom_absolute()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetPositionType(rootChild0, PositionType.Absolute);
            YGNodeStyleSetPosition(rootChild0, Edge.Left, 10);
            YGNodeStyleSetPosition(rootChild0, Edge.Top, 10);
            YGNodeStyleSetPosition(rootChild0, Edge.Bottom, 10);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_width_overrides_align_stretch_row()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_height_overrides_align_stretch_column()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_allow_child_overflow_parent_size()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeStyleSetAspectRatio(rootChild0, 4);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(200, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_defined_main_with_margin()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeStyleSetMargin(rootChild0, Edge.Left, 10);
            YGNodeStyleSetMargin(rootChild0, Edge.Right, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_defined_cross_with_margin()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeStyleSetMargin(rootChild0, Edge.Left, 10);
            YGNodeStyleSetMargin(rootChild0, Edge.Right, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void aspect_ratio_defined_cross_with_main_margin()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetAspectRatio(rootChild0, 1);
            YGNodeStyleSetMargin(rootChild0, Edge.Top, 10);
            YGNodeStyleSetMargin(rootChild0, Edge.Bottom, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));
        }

        /*
        [Test] public void aspect_ratio_should_prefer_explicit_height() {
            YGConfig config = YGConfigNew();
            YGConfigSetUseWebDefaults(config, true);

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Column);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Column);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0_child0, FlexDirection.Column);
            YGNodeStyleSetHeight(root_child0_child0, 100);
            YGNodeStyleSetAspectRatio(root_child0_child0, 2);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YGNodeCalculateLayout(root, 100, 200, Direction.LTR);

            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0_child0));

            
        }
        */

        /*
        [Test] public void aspect_ratio_should_prefer_explicit_width() {
            YGConfig config = YGConfigNew();
            YGConfigSetUseWebDefaults(config, true);

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0_child0, FlexDirection.Row);
            YGNodeStyleSetWidth(root_child0_child0, 100);
            YGNodeStyleSetAspectRatio(root_child0_child0, 0.5f);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YGNodeCalculateLayout(root, 200, 100, Direction.LTR);

            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root_child0_child0));

            
        }
        */

        /*
        [Test] public void aspect_ratio_should_prefer_flexed_dimension() {
            YGConfig config = YGConfigNew();
            YGConfigSetUseWebDefaults(config, true);

            YogaNode root = YGNodeNewWithConfig(config);

            YogaNode root_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Column);
            YGNodeStyleSetAspectRatio(root_child0, 2);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAspectRatio(root_child0_child0, 4);
            YGNodeStyleSetFlexGrow(root_child0_child0, 1);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YGNodeCalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetWidth(root_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0));

            Assert.AreEqual(200, YGNodeLayoutGetWidth(root_child0_child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root_child0_child0));

            
        }
        */
    }
}
