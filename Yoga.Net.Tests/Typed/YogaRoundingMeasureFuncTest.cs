using NUnit.Framework;

using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaRoundingMeasureFuncTest
    {
        static MeasureFunc _measureFloor = (node, width, widthMode, height, heightMode, context) => new YogaSize(10.2f, 10.2f);

        static MeasureFunc _measureCeil = (node, width, widthMode, height, heightMode, context) => new YogaSize(10.5f, 10.5f);

        static MeasureFunc _measureFractal = (node, width, widthMode, height, heightMode, context) => new YogaSize(0.5f, 0.5f);

        [Test]
        public void rounding_feature_with_custom_measure_func_floor()
        {
            YogaConfig config = new YogaConfig();
            YogaNode rootChild0;
            YogaNode root = Node(config)
               .Add(rootChild0 = Node(measureFunc: _measureFloor));

            config.PointScaleFactor = 0.0f;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(10.2f, rootChild0.Layout.Width);
            Assert.AreEqual(10.2f, rootChild0.Layout.Height);

            config.PointScaleFactor = 1.0f;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(11f, rootChild0.Layout.Width);
            Assert.AreEqual(11f, rootChild0.Layout.Height);

            config.PointScaleFactor = 2.0f;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(10.5f, rootChild0.Layout.Width);
            Assert.AreEqual(10.5f, rootChild0.Layout.Height);

            config.PointScaleFactor = 4.0f;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(10.25f, rootChild0.Layout.Width);
            Assert.AreEqual(10.25f, rootChild0.Layout.Height);

            config.PointScaleFactor = 1.0f / 3.0f;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(12.0f, rootChild0.Layout.Width);
            Assert.AreEqual(12.0f, rootChild0.Layout.Height);
        }

        [Test]
        public void rounding_feature_with_custom_measure_func_ceil()
        {
            YogaConfig config = new YogaConfig();
            YogaNode rootChild0;
            YogaNode root = Node(config)
               .Add(rootChild0 = Node(measureFunc: _measureCeil));

            config.PointScaleFactor = 1.0f;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(11, rootChild0.Layout.Width);
            Assert.AreEqual(11, rootChild0.Layout.Height);
        }

        [Test]
        public void rounding_feature_with_custom_measure_and_fractal_matching_scale()
        {
            YogaConfig config = new YogaConfig();
            YogaNode rootChild0;
            YogaNode root = Node(config)
               .Add(rootChild0 = Node(left: 73.625f, measureFunc:_measureFractal));

            config.PointScaleFactor = 2.0f;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0.5, rootChild0.Layout.Width);
            Assert.AreEqual(0.5, rootChild0.Layout.Height);
            Assert.AreEqual(73.5, rootChild0.Layout.Left);
        }
    }
}
