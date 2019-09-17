using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGDefaultValuesTest
    {
        [Test]
        public void assert_default_values()
        {
            YogaNode root = YGNodeNew();

            Assert.AreEqual(0, YGNodeGetChildCount(root));

            Assert.AreEqual(Direction.Inherit, YGNodeStyleGetDirection(root));
            Assert.AreEqual(FlexDirection.Column, YGNodeStyleGetFlexDirection(root));
            Assert.AreEqual(Justify.FlexStart, YGNodeStyleGetJustifyContent(root));
            Assert.AreEqual(YogaAlign.FlexStart, YGNodeStyleGetAlignContent(root));
            Assert.AreEqual(YogaAlign.Stretch, YGNodeStyleGetAlignItems(root));
            Assert.AreEqual(YogaAlign.Auto, YGNodeStyleGetAlignSelf(root));
            Assert.AreEqual(PositionType.Relative, YGNodeStyleGetPositionType(root));
            Assert.AreEqual(Wrap.NoWrap, YGNodeStyleGetFlexWrap(root));
            Assert.AreEqual(Overflow.Visible, YGNodeStyleGetOverflow(root));
            Assert.AreEqual(0f, YGNodeStyleGetFlexGrow(root));
            Assert.AreEqual(0f, YGNodeStyleGetFlexShrink(root));
            Assert.AreEqual(YogaUnit.Auto, YGNodeStyleGetFlexBasis(root).Unit);

            Assert.AreEqual(YGNodeStyleGetPosition(root, Edge.Left).Unit, YogaUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetPosition(root, Edge.Top).Unit, YogaUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetPosition(root, Edge.Right).Unit, YogaUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetPosition(root, Edge.Bottom).Unit, YogaUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetPosition(root, Edge.Start).Unit, YogaUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetPosition(root, Edge.End).Unit, YogaUnit.Undefined);

            Assert.AreEqual(YGNodeStyleGetMargin(root, Edge.Left).Unit, YogaUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetMargin(root, Edge.Top).Unit, YogaUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetMargin(root, Edge.Right).Unit, YogaUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetMargin(root, Edge.Bottom).Unit, YogaUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetMargin(root, Edge.Start).Unit, YogaUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetMargin(root, Edge.End).Unit, YogaUnit.Undefined);

            Assert.AreEqual(YGNodeStyleGetPadding(root, Edge.Left).Unit, YogaUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetPadding(root, Edge.Top).Unit, YogaUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetPadding(root, Edge.Right).Unit, YogaUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetPadding(root, Edge.Bottom).Unit, YogaUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetPadding(root, Edge.Start).Unit, YogaUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetPadding(root, Edge.End).Unit, YogaUnit.Undefined);

            Assert.IsTrue(YGNodeStyleGetBorder(root, Edge.Left).IsUndefined());
            Assert.IsTrue(YGNodeStyleGetBorder(root, Edge.Top).IsUndefined());
            Assert.IsTrue(YGNodeStyleGetBorder(root, Edge.Right).IsUndefined());
            Assert.IsTrue(YGNodeStyleGetBorder(root, Edge.Bottom).IsUndefined());
            Assert.IsTrue(YGNodeStyleGetBorder(root, Edge.Start).IsUndefined());
            Assert.IsTrue(YGNodeStyleGetBorder(root, Edge.End).IsUndefined());

            Assert.AreEqual(YGNodeStyleGetWidth(root).Unit, YogaUnit.Auto);
            Assert.AreEqual(YGNodeStyleGetHeight(root).Unit, YogaUnit.Auto);
            Assert.AreEqual(YGNodeStyleGetMinWidth(root).Unit, YogaUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetMinHeight(root).Unit, YogaUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetMaxWidth(root).Unit, YogaUnit.Undefined);
            Assert.AreEqual(YGNodeStyleGetMaxHeight(root).Unit, YogaUnit.Undefined);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(0, YGNodeLayoutGetRight(root));
            Assert.AreEqual(0, YGNodeLayoutGetBottom(root));

            Assert.AreEqual(0, YGNodeLayoutGetMargin(root, Edge.Left));
            Assert.AreEqual(0, YGNodeLayoutGetMargin(root, Edge.Top));
            Assert.AreEqual(0, YGNodeLayoutGetMargin(root, Edge.Right));
            Assert.AreEqual(0, YGNodeLayoutGetMargin(root, Edge.Bottom));

            Assert.AreEqual(0, YGNodeLayoutGetPadding(root, Edge.Left));
            Assert.AreEqual(0, YGNodeLayoutGetPadding(root, Edge.Top));
            Assert.AreEqual(0, YGNodeLayoutGetPadding(root, Edge.Right));
            Assert.AreEqual(0, YGNodeLayoutGetPadding(root, Edge.Bottom));

            Assert.AreEqual(0, YGNodeLayoutGetBorder(root, Edge.Left));
            Assert.AreEqual(0, YGNodeLayoutGetBorder(root, Edge.Top));
            Assert.AreEqual(0, YGNodeLayoutGetBorder(root, Edge.Right));
            Assert.AreEqual(0, YGNodeLayoutGetBorder(root, Edge.Bottom));

            Assert.IsTrue(YGNodeLayoutGetWidth(root).IsUndefined());
            Assert.IsTrue(YGNodeLayoutGetHeight(root).IsUndefined());
            Assert.AreEqual(Direction.Inherit, YGNodeLayoutGetDirection(root));
        }
    }
}
