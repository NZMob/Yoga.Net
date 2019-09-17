using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaZeroOutLayoutRecursivelyTest
    {
        [Test]
        public void zero_out_layout()
        {
            YogaNode child0;
            YogaNode root = Node(new YogaConfig {PrintTree = true}, width: 200, height: 200, flexDirection: FlexDirection.Row)
               .Add(child0 = Node(width:100, height:100, margin:new Edges(top:10), padding:new Edges(top:10)));

            YogaArrange.CalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(10, child0.LayoutMargin(Edge.Top));
            Assert.AreEqual(10, child0.LayoutPadding(Edge.Top));

            child0.Style.Display = Display.None;

            YogaArrange.CalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(0, child0.LayoutMargin(Edge.Top));
            Assert.AreEqual(0, child0.LayoutPadding(Edge.Top));
        }
    }
}
