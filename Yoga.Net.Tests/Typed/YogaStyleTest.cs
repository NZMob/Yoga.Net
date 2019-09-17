using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaStyleTest
    {
        [Test]
        public void copy_style_same()
        {
            YogaNode node0 = Node();
            YogaNode node1 = Node();
            Assert.IsFalse(node0.IsDirty);

            node0.CopyStyle(node1);
            Assert.IsFalse(node0.IsDirty);
        }

        [Test]
        public void copy_style_modified()
        {
            YogaNode node0 = Node();
            Assert.IsFalse(node0.IsDirty);
            Assert.AreEqual(FlexDirection.Column, node0.Style.FlexDirection);
            Assert.IsFalse( node0.Style.MaxHeight.Unit != YogaUnit.Undefined);

            YogaNode node1 = Node();
            node1.Style.FlexDirection = FlexDirection.Row;
            node1.Style.MaxHeight = 10;

            node0.CopyStyle(node1);
            Assert.IsTrue(node0.IsDirty);
            Assert.AreEqual(FlexDirection.Row, node0.Style.FlexDirection);
            Assert.AreEqual(10, node0.Style.MaxHeight.Value);
        }

        [Test]
        public void copy_style_modified_same()
        {
            YogaNode node0 = Node(flexDirection: FlexDirection.Row, maxHeight: 10);

            YogaArrange.CalculateLayout(node0, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.IsFalse(node0.IsDirty);

            YogaNode node1 = Node(flexDirection: FlexDirection.Row, maxHeight: 10);

            node0.CopyStyle(node1);
            Assert.IsFalse(node0.IsDirty);
        }

        [Test]
        public void initialise_flexShrink_flexGrow()
        {
            YogaNode node0 = Node(flexShrink: 1);
            Assert.AreEqual(1f, node0.Style.FlexShrink);

            node0.Style.FlexShrink = YogaValue.YGUndefined;
            node0.Style.FlexGrow = 3;
            Assert.AreEqual(0, node0.Style.FlexShrink); // Default value is Zero, if flex shrink is not defined
            Assert.AreEqual(3, node0.Style.FlexGrow);

            node0.Style.FlexGrow = YogaValue.YGUndefined;
            node0.Style.FlexShrink = 3;
            Assert.AreEqual(0, node0.Style.FlexGrow); // Default value is Zero, if flex grow is not defined
            Assert.AreEqual(3, node0.Style.FlexShrink);
        }
    }
}
