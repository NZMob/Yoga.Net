using NUnit.Framework;
using static Yoga.Net.YogaGlobal;
using System.Collections.Generic;

namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGMeasureModeTest
    {
        class MeasureConstraint
        {
            public float Width;
            public MeasureMode WidthMode;
            public float Height;
            public MeasureMode HeightMode;
        };

        class MeasureConstraintList : List<MeasureConstraint> { };

        static MeasureFunc _measure = (
            YogaNode node,
            float width,
            MeasureMode widthMode,
            float height,
            MeasureMode heightMode,
            object context) =>
        {
            var constraintList = (MeasureConstraintList)node.Context;

            constraintList.Add(
                new YGMeasureModeTest.MeasureConstraint
                {
                    Width      = width,
                    WidthMode  = widthMode,
                    Height     = height,
                    HeightMode = heightMode
                });

            YogaSize x = new YogaSize(
                widthMode == MeasureMode.Undefined ? 10 : width,
                heightMode == MeasureMode.Undefined ? 10 : width);
            return new YogaSize(
                widthMode == MeasureMode.Undefined ? 10 : width,
                heightMode == MeasureMode.Undefined ? 10 : width);
        };

        [Test]
        public void exactly_measure_stretched_child_column()
        {
            var constraintList = new MeasureConstraintList();

            YogaNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            //  root_child0.Context = &constraintList);
            rootChild0.Context = constraintList;
            YGNodeSetMeasureFunc(rootChild0, _measure);
            //  root_child0.setMeasureFunc(_measure);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].Width);
            Assert.AreEqual(MeasureMode.Exactly, constraintList[0].WidthMode);

            //free(constraintList.constraints);
        }

        [Test]
        public void exactly_measure_stretched_child_row()
        {
            MeasureConstraintList constraintList = new MeasureConstraintList();

            YogaNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            //  root_child0.Context = &constraintList);
            rootChild0.Context = constraintList;
            YGNodeSetMeasureFunc(rootChild0, _measure);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].Height);
            Assert.AreEqual(MeasureMode.Exactly, constraintList[0].HeightMode);

            // free(constraintList.constraints);
        }

        [Test]
        public void at_most_main_axis_column()
        {
            var constraintList = new MeasureConstraintList();

            YogaNode root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            rootChild0.Context = constraintList;
            YGNodeSetMeasureFunc(rootChild0, _measure);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].Height);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].HeightMode);

            //free(constraintList.constraints);
        }

        [Test]
        public void at_most_cross_axis_column()
        {
            var constraintList = new MeasureConstraintList();

            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            rootChild0.Context = constraintList;
            YGNodeSetMeasureFunc(rootChild0, _measure);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].Width);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].WidthMode);

            // free(constraintList.constraints);
        }

        [Test]
        public void at_most_main_axis_row()
        {
            var constraintList = new MeasureConstraintList();

            YogaNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            rootChild0.Context = constraintList;
            YGNodeSetMeasureFunc(rootChild0, _measure);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].Width);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].WidthMode);

            // free(constraintList.constraints);
        }

        [Test]
        public void at_most_cross_axis_row()
        {
            var constraintList = new MeasureConstraintList();

            YogaNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            rootChild0.Context = constraintList;
            YGNodeSetMeasureFunc(rootChild0, _measure);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].Height);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].HeightMode);

            // free(constraintList.constraints);
        }

        [Test]
        public void flex_child()
        {
            var constraintList = new MeasureConstraintList();

            YogaNode root = YGNodeNew();
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            rootChild0.Context = constraintList;
            YGNodeSetMeasureFunc(rootChild0, _measure);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(2, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].Height);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].HeightMode);

            Assert.AreEqual(100, constraintList[1].Height);
            Assert.AreEqual(MeasureMode.Exactly, constraintList[1].HeightMode);

            // free(constraintList.constraints);
        }

        [Test]
        public void flex_child_with_flex_basis()
        {
            var constraintList = new MeasureConstraintList();

            YogaNode root = YGNodeNew();
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetFlexBasis(rootChild0, 0);
            rootChild0.Context = constraintList;
            YGNodeSetMeasureFunc(rootChild0, _measure);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].Height);
            Assert.AreEqual(MeasureMode.Exactly, constraintList[0].HeightMode);

            // free(constraintList.constraints);
        }

        [Test]
        public void overflow_scroll_column()
        {
            var constraintList = new MeasureConstraintList();

            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetOverflow(root, Overflow.Scroll);
            YGNodeStyleSetHeight(root, 100);
            YGNodeStyleSetWidth(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            rootChild0.Context = constraintList;
            YGNodeSetMeasureFunc(rootChild0, _measure);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.AreEqual(100, constraintList[0].Width);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].WidthMode);

            Assert.IsTrue(constraintList[0].Height.IsUndefined());
            Assert.AreEqual(MeasureMode.Undefined, constraintList[0].HeightMode);

            // free(constraintList.constraints);
        }

        [Test]
        public void overflow_scroll_row()
        {
            var constraintList = new MeasureConstraintList();

            YogaNode root = YGNodeNew();
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetOverflow(root, Overflow.Scroll);
            YGNodeStyleSetHeight(root, 100);
            YGNodeStyleSetWidth(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            rootChild0.Context = constraintList;
            YGNodeSetMeasureFunc(rootChild0, _measure);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(1, constraintList.Count);

            Assert.IsTrue(constraintList[0].Width.IsUndefined());
            Assert.AreEqual(MeasureMode.Undefined, constraintList[0].WidthMode);

            Assert.AreEqual(100, constraintList[0].Height);
            Assert.AreEqual(MeasureMode.AtMost, constraintList[0].HeightMode);

            // free(constraintList.constraints);
        }
    }
}
