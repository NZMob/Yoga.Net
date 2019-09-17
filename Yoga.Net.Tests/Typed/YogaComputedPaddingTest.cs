using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaComputedPaddingTest
    {
        [Test]
        public void computed_layout_padding()
        {
            YogaNode root = Node(width:100, height:100, padding:new Edges(start:10));

            YogaArrange.CalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(10, root.Layout.Padding.Left);
            Assert.AreEqual(0, root.Layout.Padding.Right);

            YogaArrange.CalculateLayout(root, 100, 100, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Padding.Left);
            Assert.AreEqual(10, root.Layout.Padding.Right);
        }
    }
}
