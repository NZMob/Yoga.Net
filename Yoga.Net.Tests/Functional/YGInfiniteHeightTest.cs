using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGInfiniteHeightTest
    {
        // This test isn't correct from the Flexbox standard standpoint,
        // because percentages are calculated with parent constraints.
        // However, we need to make sure we fail gracefully in this case, not returning NaN
        [Test]
        public void percent_absolute_position_infinite_height()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 300);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 300);
            YGNodeStyleSetHeight(rootChild0, 300);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(rootChild1, PositionType.Absolute);
            YGNodeStyleSetPositionPercent(rootChild1, Edge.Left, 20);
            YGNodeStyleSetPositionPercent(rootChild1, Edge.Top, 20);
            YGNodeStyleSetWidthPercent(rootChild1, 20);
            YGNodeStyleSetHeightPercent(rootChild1, 20);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(300, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(300, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(300, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(300, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild1));
        }
    }
}
