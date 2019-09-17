using NUnit.Framework;
using System.Collections.Generic;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaMeasureModeTest
    {
        class MeasureConstraint
        {
            public float Width;
            public MeasureMode WidthMode;
            public float Height;
            public MeasureMode HeightMode;
        };

        class MeasureConstraintList : List<MeasureConstraint> { };

        static MeasureFunc _measure = (node, width, widthMode, height, heightMode, context) =>
        {
            var constraintList = (MeasureConstraintList)node.Context;

            constraintList.Add(
                new MeasureConstraint
                {
                    Width      = width,
                    WidthMode  = widthMode,
                    Height     = height,
                    HeightMode = heightMode
                });

            return new YogaSize(
                widthMode == MeasureMode.Undefined ? 10 : width,
                heightMode == MeasureMode.Undefined ? 10 : width);
        };

        [Test]
        public void exactly_measure_stretched_child_column()
        {
            var constraintList = new MeasureConstraintList();

            YogaNode rootChild0;
            YogaNode root = Node(width: 100, height: 100)
               .Add(rootChild0 = Node(measureFunc:_measure));
            rootChild0.Context = constraintList;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].Width);
            Assert.AreEqual(MeasureMode.Exactly, constraintList[0].WidthMode);
        }

        [Test]
        public void exactly_measure_stretched_child_row()
        {
            MeasureConstraintList constraintList = new MeasureConstraintList();

            YogaNode rootChild0;
            YogaNode root = Node(flexDirection:FlexDirection.Row, width: 100, height: 100)
               .Add(rootChild0 = Node(measureFunc:_measure));
            rootChild0.Context = constraintList;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].Height);
            Assert.AreEqual(MeasureMode.Exactly, constraintList[0].HeightMode);
        }

        [Test]
        public void at_most_main_axis_column()
        {
            var constraintList = new MeasureConstraintList();

            YogaNode rootChild0;
            YogaNode root = Node(width: 100, height: 100)
               .Add(rootChild0 = Node(measureFunc:_measure));
            rootChild0.Context = constraintList;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].Height);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].HeightMode);
        }

        [Test]
        public void at_most_cross_axis_column()
        {
            var constraintList = new MeasureConstraintList();

            YogaNode rootChild0;
            YogaNode root = Node(alignItems:YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(measureFunc:_measure));
            rootChild0.Context = constraintList;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].Width);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].WidthMode);
        }

        [Test]
        public void at_most_main_axis_row()
        {
            var constraintList = new MeasureConstraintList();

            YogaNode rootChild0;
            YogaNode root = Node(flexDirection:FlexDirection.Row, width: 100, height: 100)
               .Add(rootChild0 = Node(measureFunc:_measure));
            rootChild0.Context = constraintList;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].Width);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].WidthMode);
        }

        [Test]
        public void at_most_cross_axis_row()
        {
            var constraintList = new MeasureConstraintList();

            YogaNode rootChild0;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignItems:YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(measureFunc:_measure));
            rootChild0.Context = constraintList;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].Height);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].HeightMode);
        }

        [Test]
        public void flex_child()
        {
            var constraintList = new MeasureConstraintList();

            YogaNode rootChild0;
            YogaNode root = Node(height: 100)
               .Add(rootChild0 = Node(flexGrow:1, measureFunc:_measure));
            rootChild0.Context = constraintList;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(2, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].Height);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].HeightMode);

            Assert.AreEqual(100, constraintList[1].Height);
            Assert.AreEqual(MeasureMode.Exactly, constraintList[1].HeightMode);
        }

        [Test]
        public void flex_child_with_flex_basis()
        {
            var constraintList = new MeasureConstraintList();

            YogaNode rootChild0;
            YogaNode root = Node(height: 100)
               .Add(rootChild0 = Node(flexGrow:1, flexBasis:0, measureFunc:_measure));
            rootChild0.Context = constraintList;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].Height);
            Assert.AreEqual(MeasureMode.Exactly, constraintList[0].HeightMode);
        }

        [Test]
        public void overflow_scroll_column()
        {
            var constraintList = new MeasureConstraintList();

            YogaNode rootChild0;
            YogaNode root = Node(alignItems:YogaAlign.FlexStart, overflow:Overflow.Scroll, width: 100, height: 100)
               .Add(rootChild0 = Node(measureFunc:_measure));
            rootChild0.Context = constraintList;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].Width);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].WidthMode);

            Assert.IsTrue(constraintList[0].Height.IsUndefined());
            Assert.AreEqual(MeasureMode.Undefined, constraintList[0].HeightMode);
        }

        [Test]
        public void overflow_scroll_row()
        {
            var constraintList = new MeasureConstraintList();

            YogaNode rootChild0;
            YogaNode root = Node(alignItems:YogaAlign.FlexStart, flexDirection:FlexDirection.Row, overflow:Overflow.Scroll, width: 100, height: 100)
               .Add(rootChild0 = Node(measureFunc:_measure));
            rootChild0.Context = constraintList;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.IsTrue(constraintList[0].Width.IsUndefined());
            Assert.AreEqual(MeasureMode.Undefined, constraintList[0].WidthMode);

            Assert.AreEqual(100, constraintList[0].Height);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].HeightMode);
        }
    }
}
