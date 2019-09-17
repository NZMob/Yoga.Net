using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaDefaultValuesTest
    {
        [Test]
        public void assert_default_values()
        {
            YogaNode root = Node();

            Assert.AreEqual(0, root.ChildCount);

            Assert.AreEqual(Direction.Inherit, root.Style.Direction);
            Assert.AreEqual(FlexDirection.Column, root.Style.FlexDirection);
            Assert.AreEqual(Justify.FlexStart, root.Style.JustifyContent);
            Assert.AreEqual(YogaAlign.FlexStart, root.Style.AlignContent);
            Assert.AreEqual(YogaAlign.Stretch, root.Style.AlignItems);
            Assert.AreEqual(YogaAlign.Auto, root.Style.AlignSelf);
            Assert.AreEqual(PositionType.Relative, root.Style.PositionType);
            Assert.AreEqual(Wrap.NoWrap, root.Style.FlexWrap);
            Assert.AreEqual(Overflow.Visible, root.Style.Overflow);
            Assert.AreEqual(0f, root.Style.FlexGrow);
            Assert.AreEqual(0f, root.Style.FlexShrink);
            Assert.AreEqual(YogaUnit.Auto, root.Style.FlexBasis.Unit);

            Assert.IsTrue(root.Style.Position.Left.IsUndefined);
            Assert.IsTrue(root.Style.Position.Top.IsUndefined);
            Assert.IsTrue(root.Style.Position.Right.IsUndefined);
            Assert.IsTrue(root.Style.Position.Bottom.IsUndefined);
            Assert.IsTrue(root.Style.Position.Start.IsUndefined);
            Assert.IsTrue(root.Style.Position.End.IsUndefined);

            Assert.IsTrue(root.Style.Margin.Left.IsUndefined);
            Assert.IsTrue(root.Style.Margin.Top.IsUndefined);
            Assert.IsTrue(root.Style.Margin.Right.IsUndefined);
            Assert.IsTrue(root.Style.Margin.Bottom.IsUndefined);
            Assert.IsTrue(root.Style.Margin.Start.IsUndefined);
            Assert.IsTrue(root.Style.Margin.End.IsUndefined);

            Assert.IsTrue(root.Style.Padding.Left.IsUndefined);
            Assert.IsTrue(root.Style.Padding.Top.IsUndefined);
            Assert.IsTrue(root.Style.Padding.Right.IsUndefined);
            Assert.IsTrue(root.Style.Padding.Bottom.IsUndefined);
            Assert.IsTrue(root.Style.Padding.Start.IsUndefined);
            Assert.IsTrue(root.Style.Padding.End.IsUndefined);

            Assert.IsTrue(root.Style.Border.Left.IsUndefined);
            Assert.IsTrue(root.Style.Border.Top.IsUndefined);
            Assert.IsTrue(root.Style.Border.Right.IsUndefined);
            Assert.IsTrue(root.Style.Border.Bottom.IsUndefined);
            Assert.IsTrue(root.Style.Border.Start.IsUndefined);
            Assert.IsTrue(root.Style.Border.End.IsUndefined);

            Assert.AreEqual( root.Style.Width.Unit, YogaUnit.Auto);
            Assert.AreEqual(root.Style.Height.Unit, YogaUnit.Auto);
            Assert.AreEqual(root.Style.MinWidth.Unit, YogaUnit.Undefined);
            Assert.AreEqual(root.Style.MinHeight.Unit, YogaUnit.Undefined);
            Assert.AreEqual(root.Style.MaxWidth.Unit, YogaUnit.Undefined);
            Assert.AreEqual(root.Style.MaxHeight.Unit, YogaUnit.Undefined);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Right);
            Assert.AreEqual(0, root.Layout.Bottom);

            Assert.AreEqual(0, root.Layout.Margin.Left);
            Assert.AreEqual(0, root.Layout.Margin.Top);
            Assert.AreEqual(0, root.Layout.Margin.Right);
            Assert.AreEqual(0, root.Layout.Margin.Bottom);

            Assert.AreEqual(0, root.Layout.Padding.Left);
            Assert.AreEqual(0, root.Layout.Padding.Top);
            Assert.AreEqual(0, root.Layout.Padding.Right);
            Assert.AreEqual(0, root.Layout.Padding.Bottom);

            Assert.AreEqual(0, root.Layout.Border.Left);
            Assert.AreEqual(0, root.Layout.Border.Top);
            Assert.AreEqual(0, root.Layout.Border.Right);
            Assert.AreEqual(0, root.Layout.Border.Bottom);

            Assert.IsTrue(root.Layout.Width.IsUndefined());
            Assert.IsTrue(root.Layout.Height.IsUndefined());
            Assert.AreEqual(Direction.Inherit, root.Layout.Direction);
        }
    }
}
