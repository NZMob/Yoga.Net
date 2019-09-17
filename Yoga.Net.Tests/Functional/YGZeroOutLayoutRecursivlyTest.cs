using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGZeroOutLayoutRecursivlyTest
    {
        [Test]
        public void zero_out_layout()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode child = YGNodeNew();
            YGNodeInsertChild(root, child, 0);
            YGNodeStyleSetWidth(child, 100);
            YGNodeStyleSetHeight(child, 100);
            YGNodeStyleSetMargin(child, Edge.Top, 10);
            YGNodeStyleSetPadding(child, Edge.Top, 10);

            YGNodeCalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(10, YGNodeLayoutGetMargin(child, Edge.Top));
            Assert.AreEqual(10, YGNodeLayoutGetPadding(child, Edge.Top));

            YGNodeStyleSetDisplay(child, Display.None);

            YGNodeCalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetMargin(child, Edge.Top));
            Assert.AreEqual(0, YGNodeLayoutGetPadding(child, Edge.Top));
        }
    }
}
