using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGMeasureCacheTest
    {
        static MeasureFunc _measureMax = (
            YogaNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode,
            object context) =>
        {
            int measureCount = (int)node.Context;
            measureCount++;
            node.Context = measureCount;

            return new YogaSize(
                widthMode == MeasureMode.Undefined ? 10 : width,
                heightMode == MeasureMode.Undefined ? 10 : height);
        };

        static MeasureFunc _measureMin = (
            YogaNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode, object context) =>
        {
            int measureCount = (int)node.Context;
            measureCount = measureCount + 1;
            node.Context = measureCount;
            return new YogaSize(
                widthMode == MeasureMode.Undefined || (widthMode == MeasureMode.AtMost && width > 10)
                    ? 10
                    : width,
                heightMode == MeasureMode.Undefined || (heightMode == MeasureMode.AtMost && height > 10)
                    ? 10
                    : height);
        };

        static MeasureFunc _measure8449 = (
            YogaNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode,
            object context) =>
        {
            int measureCount = (int)node.Context;
            measureCount++;
            node.Context = measureCount;

            return new YogaSize(84f, 49f);
        };

        [Test]
        public void measure_once_single_flexible_child()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            rootChild0.Context = 0;
            YGNodeSetMeasureFunc(rootChild0,_measureMax);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, (int)rootChild0.Context);
        }

        [Test]
        public void remeasure_with_same_exact_width_larger_than_needed_height()
        {
            YogaNode root = YGNodeNew();

            YogaNode rootChild0 = YGNodeNew();
            rootChild0.Context = 0;
            YGNodeSetMeasureFunc(rootChild0, _measureMin);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, 100, 100, Direction.LTR);
            YGNodeCalculateLayout(root, 100, 50, Direction.LTR);

            Assert.AreEqual(1, (int)rootChild0.Context);
        }

        [Test]
        public void remeasure_with_same_at_most_width_larger_than_needed_height()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);

            YogaNode rootChild0 = YGNodeNew();
            rootChild0.Context = 0;
            YGNodeSetMeasureFunc(rootChild0, _measureMin);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, 100, 100, Direction.LTR);
            YGNodeCalculateLayout(root, 100, 50, Direction.LTR);

            Assert.AreEqual(1, (int)rootChild0.Context);
        }

        [Test]
        public void remeasure_with_computed_width_larger_than_needed_height()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);

            YogaNode rootChild0 = YGNodeNew();
            rootChild0.Context = 0;
            YGNodeSetMeasureFunc(rootChild0, _measureMin);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, 100, 100, Direction.LTR);
            YGNodeStyleSetAlignItems(root, YogaAlign.Stretch);
            YGNodeCalculateLayout(root, 10, 50, Direction.LTR);

            Assert.AreEqual(1, (int)rootChild0.Context);
        }

        [Test]
        public void remeasure_with_at_most_computed_width_undefined_height()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);

            YogaNode rootChild0 = YGNodeNew();
            rootChild0.Context = 0;
            YGNodeSetMeasureFunc(rootChild0, _measureMin);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, 100, YogaValue.YGUndefined, Direction.LTR);
            YGNodeCalculateLayout(root, 10, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, (int)rootChild0.Context);
        }

        [Test]
        public void remeasure_with_already_measured_value_smaller_but_still_float_equal()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 288f);
            YGNodeStyleSetHeight(root, 288f);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetPadding(rootChild0, Edge.All, 2.88f);
            YGNodeStyleSetFlexDirection(rootChild0, FlexDirection.Row);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNew();
            rootChild0Child0.Context = 0;
            YGNodeSetMeasureFunc(rootChild0Child0, _measure8449);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);


            Assert.AreEqual(1, (int)rootChild0Child0.Context);
        }
    }
}
