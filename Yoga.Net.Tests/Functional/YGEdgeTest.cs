using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGEdgeTest
    {
        [Test]
        public void start_overrides()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetMargin(rootChild0, Edge.Start, 10);
            YGNodeStyleSetMargin(rootChild0, Edge.Left, 20);
            YGNodeStyleSetMargin(rootChild0, Edge.Right, 20);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetRight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);
            Assert.AreEqual(20, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetRight(rootChild0));
        }

        [Test]
        public void end_overrides()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetMargin(rootChild0, Edge.End, 10);
            YGNodeStyleSetMargin(rootChild0, Edge.Left, 20);
            YGNodeStyleSetMargin(rootChild0, Edge.Right, 20);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(20, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetRight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);
            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetRight(rootChild0));
        }

        [Test]
        public void horizontal_overridden()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetMargin(rootChild0, Edge.Horizontal, 10);
            YGNodeStyleSetMargin(rootChild0, Edge.Left, 20);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(20, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetRight(rootChild0));
        }

        [Test]
        public void vertical_overridden()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Column);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetMargin(rootChild0, Edge.Vertical, 10);
            YGNodeStyleSetMargin(rootChild0, Edge.Top, 20);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetBottom(rootChild0));
        }

        [Test]
        public void horizontal_overrides_all()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Column);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetMargin(rootChild0, Edge.Horizontal, 10);
            YGNodeStyleSetMargin(rootChild0, Edge.All, 20);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetRight(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetBottom(rootChild0));
        }

        [Test]
        public void vertical_overrides_all()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Column);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetMargin(rootChild0, Edge.Vertical, 10);
            YGNodeStyleSetMargin(rootChild0, Edge.All, 20);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(20, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetRight(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetBottom(rootChild0));
        }

        [Test]
        public void all_overridden()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Column);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetMargin(rootChild0, Edge.Left, 10);
            YGNodeStyleSetMargin(rootChild0, Edge.Top, 10);
            YGNodeStyleSetMargin(rootChild0, Edge.Right, 10);
            YGNodeStyleSetMargin(rootChild0, Edge.Bottom, 10);
            YGNodeStyleSetMargin(rootChild0, Edge.All, 20);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetRight(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetBottom(rootChild0));
        }
    }
}
