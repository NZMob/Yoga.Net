using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaComputedMarginTest
    {
        [Test]
        public void computed_layout_margin()
        {
            YogaNode root = Node(width:100, height:100, margin:new Edges(start:10.Percent()));

            YogaArrange.CalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(10, root.Layout.Margin.Left);
            Assert.AreEqual(0, root.Layout.Margin.Right);

            YogaArrange.CalculateLayout(root, 100, 100, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Margin.Left);
            Assert.AreEqual(10, root.Layout.Margin.Right);
        }
    }
}
