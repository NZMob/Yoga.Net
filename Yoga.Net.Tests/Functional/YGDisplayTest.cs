using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGDisplayTest
    {
        [Test]
        public void display_none()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeStyleSetDisplay(rootChild1, Display.None);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void display_none_fixed_size()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 20);
            YGNodeStyleSetHeight(rootChild1, 20);
            YGNodeStyleSetDisplay(rootChild1, Display.None);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void display_none_with_margin()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(rootChild0, Edge.Left, 10);
            YGNodeStyleSetMargin(rootChild0, Edge.Top, 10);
            YGNodeStyleSetMargin(rootChild0, Edge.Right, 10);
            YGNodeStyleSetMargin(rootChild0, Edge.Bottom, 10);
            YGNodeStyleSetWidth(rootChild0, 20);
            YGNodeStyleSetHeight(rootChild0, 20);
            YGNodeStyleSetDisplay(rootChild0, Display.None);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void display_none_with_child()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetFlexShrink(rootChild0, 1);
            YGNodeStyleSetFlexBasisPercent(rootChild0, 0);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeStyleSetFlexShrink(rootChild1, 1);
            YGNodeStyleSetFlexBasisPercent(rootChild1, 0);
            YGNodeStyleSetDisplay(rootChild1, Display.None);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild1Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1Child0, 1);
            YGNodeStyleSetFlexShrink(rootChild1Child0, 1);
            YGNodeStyleSetFlexBasisPercent(rootChild1Child0, 0);
            YGNodeStyleSetWidth(rootChild1Child0, 20);
            YGNodeStyleSetMinWidth(rootChild1Child0, 0);
            YGNodeStyleSetMinHeight(rootChild1Child0, 0);
            YGNodeInsertChild(rootChild1, rootChild1Child0, 0);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild2, 1);
            YGNodeStyleSetFlexShrink(rootChild2, 1);
            YGNodeStyleSetFlexBasisPercent(rootChild2, 0);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild1Child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild1Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void display_none_with_position()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeStyleSetPosition(rootChild1, Edge.Top, 10);
            YGNodeStyleSetDisplay(rootChild1, Display.None);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild1));
        }
    }
}
