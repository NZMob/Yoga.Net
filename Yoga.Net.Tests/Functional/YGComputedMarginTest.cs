using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGComputedMarginTest
    {
        [Test]
        public void computed_layout_margin()
        {
            var root = YGNodeNew();
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);
            YGNodeStyleSetMarginPercent(root, Edge.Start, 10);

            YGNodeCalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(10, YGNodeLayoutGetMargin(root, Edge.Left));
            Assert.AreEqual(0, YGNodeLayoutGetMargin(root, Edge.Right));

            YGNodeCalculateLayout(root, 100, 100, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetMargin(root, Edge.Left));
            Assert.AreEqual(10, YGNodeLayoutGetMargin(root, Edge.Right));
        }
    }
}
