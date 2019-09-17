using NUnit.Framework;

using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaInfiniteHeightTest
    {
        // This test isn't correct from the Flexbox standard standpoint,
        // because percentages are calculated with parent constraints.
        // However, we need to make sure we fail gracefully in this case, not returning NaN
        [Test]
        public void percent_absolute_position_infinite_height()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 300)
                           .Add(rootChild0 = Node(width:300, height:300))
                           .Add(rootChild1 = Node(positionType:PositionType.Absolute, left:20.Percent(), top:20.Percent(), width:20.Percent(), height:20.Percent()));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(300, root.Layout.Width);
            Assert.AreEqual(300, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(300, rootChild0.Layout.Width);
            Assert.AreEqual(300, rootChild0.Layout.Height);

            Assert.AreEqual(60, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(60, rootChild1.Layout.Width);
            Assert.AreEqual(0, rootChild1.Layout.Height);
        }
    }
}
