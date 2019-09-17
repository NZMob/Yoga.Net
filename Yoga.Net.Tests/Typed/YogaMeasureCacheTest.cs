using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaMeasureCacheTest
    {
        static MeasureFunc _measureMax = (node, width, widthMode, height, heightMode, context) =>
        {
            int measureCount = (int)node.Context;
            measureCount++;
            node.Context = measureCount;

            return new YogaSize(
                widthMode == MeasureMode.Undefined ? 10 : width,
                heightMode == MeasureMode.Undefined ? 10 : height);
        };

        static MeasureFunc _measureMin = (node, width, widthMode, height, heightMode, context) =>
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

        static MeasureFunc _measure8449 = (node, width, widthMode, height, heightMode, context) =>
        {
            int measureCount = (int)node.Context;
            measureCount++;
            node.Context = measureCount;

            return new YogaSize(84f, 49f);
        };

        [Test]
        public void measure_once_single_flexible_child()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignItems:YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(measureFunc:_measureMax, flexGrow:1));
            rootChild0.Context = 0;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, (int)rootChild0.Context);
        }

        [Test]
        public void remeasure_with_same_exact_width_larger_than_needed_height()
        {
            YogaNode rootChild0;
            YogaNode root = Node(width: 100, height: 100)
               .Add(rootChild0 = Node(measureFunc:_measureMin));
            rootChild0.Context = 0;

            YogaArrange.CalculateLayout(root, 100, 100, Direction.LTR);
            YogaArrange.CalculateLayout(root, 100, 50, Direction.LTR);

            Assert.AreEqual(1, (int)rootChild0.Context);
        }

        [Test]
        public void remeasure_with_same_at_most_width_larger_than_needed_height()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems:YogaAlign.FlexStart)
               .Add(rootChild0 = Node(measureFunc:_measureMin));
            rootChild0.Context = 0;

            YogaArrange.CalculateLayout(root, 100, 100, Direction.LTR);
            YogaArrange.CalculateLayout(root, 100, 50, Direction.LTR);

            Assert.AreEqual(1, (int)rootChild0.Context);
        }

        [Test]
        public void remeasure_with_computed_width_larger_than_needed_height()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems:YogaAlign.FlexStart)
               .Add(rootChild0 = Node(measureFunc:_measureMin));
            rootChild0.Context = 0;

            YogaArrange.CalculateLayout(root, 100, 100, Direction.LTR);
            root.Style.AlignItems = YogaAlign.Stretch;

            YogaArrange.CalculateLayout(root, 10, 50, Direction.LTR);

            Assert.AreEqual(1, (int)rootChild0.Context);
        }

        [Test]
        public void remeasure_with_at_most_computed_width_undefined_height()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems:YogaAlign.FlexStart)
               .Add(rootChild0 = Node(measureFunc:_measureMin));
            rootChild0.Context = 0;

            YogaArrange.CalculateLayout(root, 100, YogaValue.YGUndefined, Direction.LTR);
            YogaArrange.CalculateLayout(root, 10, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, (int)rootChild0.Context);
        }

        [Test]
        public void remeasure_with_already_measured_value_smaller_but_still_float_equal()
        {
            YogaNode rootChild0Child0;
            YogaNode root = Node(width: 288, height: 288, flexDirection:FlexDirection.Row)
               .Add(Node(padding:new Edges(2.88f), flexDirection:FlexDirection.Row)
                   .Add(rootChild0Child0 = Node(measureFunc:_measure8449))
                );
            rootChild0Child0.Context = 0;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, (int)rootChild0Child0.Context);
        }
    }
}
