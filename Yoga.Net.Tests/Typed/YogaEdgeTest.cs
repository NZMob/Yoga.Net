using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaEdgeTest
    {
        [Test]
        public void start_overrides()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 100, height: 100)
               .Add(rootChild0 = Node(flexGrow:1, margin:new Edges(start:10, left:20, right:20)));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(20, rootChild0.Layout.Right);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);
            Assert.AreEqual(20, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Right);
        }

        [Test]
        public void end_overrides()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 100, height: 100)
               .Add(rootChild0 = Node(flexGrow:1, margin:new Edges(end:10, left:20, right:20)));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(20, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Right);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);
            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(20, rootChild0.Layout.Right);
        }

        [Test]
        public void horizontal_overridden()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 100, height: 100)
               .Add(rootChild0 = Node(flexGrow:1, margin:new Edges(horizontal: 10, left:20)));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(20, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Right);
        }

        [Test]
        public void vertical_overridden()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexDirection: FlexDirection.Column, width: 100, height: 100)
               .Add(rootChild0 = Node(flexGrow:1, margin:new Edges(vertical: 10, top:20)));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(20, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Bottom);
        }

        [Test]
        public void horizontal_overrides_all()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexDirection: FlexDirection.Column, width: 100, height: 100)
               .Add(rootChild0 = Node(flexGrow:1, margin:new Edges(horizontal: 10, all:20)));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(20, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Right);
            Assert.AreEqual(20, rootChild0.Layout.Bottom);
        }

        [Test]
        public void vertical_overrides_all()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexDirection: FlexDirection.Column, width: 100, height: 100)
               .Add(rootChild0 = Node(flexGrow:1, margin:new Edges(vertical: 10, all:20)));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(20, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(20, rootChild0.Layout.Right);
            Assert.AreEqual(10, rootChild0.Layout.Bottom);
        }

        [Test]
        public void all_overridden()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexDirection: FlexDirection.Column, width: 100, height: 100)
               .Add(rootChild0 = Node(flexGrow:1, margin:new Edges(left: 10, top:10, right:10, bottom:10, all:20)));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Right);
            Assert.AreEqual(10, rootChild0.Layout.Bottom);
        }
    }
}
