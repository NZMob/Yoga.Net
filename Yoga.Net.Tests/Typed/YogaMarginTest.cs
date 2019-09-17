using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaMarginTest
    {
        [Test]
        public void margin_start()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 100, height: 100)
               .Add(rootChild0 = Node(margin:new Edges(start:10), width:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);
        }

        [Test]
        public void margin_top()
        {
            YogaNode rootChild0;
            YogaNode root = Node(width: 100, height: 100)
               .Add(rootChild0 = Node(margin:new Edges(top:10), height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);
        }

        [Test]
        public void margin_end()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, justifyContent:Justify.FlexEnd, width: 100, height: 100)
               .Add(rootChild0 = Node(margin:new Edges(end:10), width:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);
        }

        [Test]
        public void margin_bottom()
        {
            YogaNode rootChild0;
            YogaNode root = Node(justifyContent:Justify.FlexEnd, width: 100, height: 100)
               .Add(rootChild0 = Node(margin:new Edges(bottom:10), height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(80, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(80, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);
        }

        [Test]
        public void margin_and_flex_row()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 100, height: 100)
               .Add(rootChild0 = Node(flexGrow:1, margin:new Edges(start:10, end:10)));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(80, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(80, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);
        }

        [Test]
        public void margin_and_flex_column()
        {
            YogaNode rootChild0;
            YogaNode root = Node(width: 100, height: 100)
               .Add(rootChild0 = Node(flexGrow:1, margin:new Edges(top:10, bottom:10)));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(80, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(80, rootChild0.Layout.Height);
        }

        [Test]
        public void margin_and_stretch_row()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 100, height: 100)
               .Add(rootChild0 = Node(flexGrow:1, margin:new Edges(top:10, bottom:10)));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(80, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(80, rootChild0.Layout.Height);
        }

        [Test]
        public void margin_and_stretch_column()
        {
            YogaNode rootChild0;
            YogaNode root = Node(width: 100, height: 100)
               .Add(rootChild0 = Node(flexGrow:1, margin:new Edges(start:10, end:10)));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(80, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(80, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);
        }

        [Test]
        public void margin_with_sibling_row()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 100, height: 100)
                           .Add(rootChild0 = Node(flexGrow: 1, margin: new Edges(end: 10)))
                           .Add(rootChild1 = Node(flexGrow: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(45, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(55, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(45, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(55, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(45, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(45, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);
        }

        [Test]
        public void margin_with_sibling_column()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(width: 100, height: 100)
                           .Add(rootChild0 = Node(flexGrow: 1, margin: new Edges(bottom: 10)))
                           .Add(rootChild1 = Node(flexGrow: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(45, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(55, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(45, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(45, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(55, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(45, rootChild1.Layout.Height);
        }

        [Test]
        public void margin_auto_bottom()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(alignItems: YogaAlign.Center, width: 200, height: 200)
                           .Add(rootChild0 = Node(margin: new Edges(bottom: YogaValue.Auto), width: 50, height: 50))
                           .Add(rootChild1 = Node(width: 50, height: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(75, rootChild1.Layout.Left);
            Assert.AreEqual(150, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(75, rootChild1.Layout.Left);
            Assert.AreEqual(150, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void margin_auto_top()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(alignItems:YogaAlign.Center, width: 200, height: 200)
                           .Add(rootChild0 = Node(margin: new Edges(top: YogaValue.Auto), width:50, height:50))
                           .Add(rootChild1 = Node(width:50, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, rootChild0.Layout.Left);
            Assert.AreEqual(100, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(75, rootChild1.Layout.Left);
            Assert.AreEqual(150, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, rootChild0.Layout.Left);
            Assert.AreEqual(100, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(75, rootChild1.Layout.Left);
            Assert.AreEqual(150, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void margin_auto_bottom_and_top()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(alignItems:YogaAlign.Center, width: 200, height: 200)
                           .Add(rootChild0 = Node(margin: new Edges(top: YogaValue.Auto, bottom:YogaValue.Auto), width:50, height:50))
                           .Add(rootChild1 = Node(width:50, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, rootChild0.Layout.Left);
            Assert.AreEqual(50, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(75, rootChild1.Layout.Left);
            Assert.AreEqual(150, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, rootChild0.Layout.Left);
            Assert.AreEqual(50, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(75, rootChild1.Layout.Left);
            Assert.AreEqual(150, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void margin_auto_bottom_and_top_justify_center()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(justifyContent:Justify.Center, width: 200, height: 200)
                           .Add(rootChild0 = Node(margin: new Edges(top: YogaValue.Auto, bottom:YogaValue.Auto), width:50, height:50))
                           .Add(rootChild1 = Node(width:50, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(50, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(150, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(150, rootChild0.Layout.Left);
            Assert.AreEqual(50, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(150, rootChild1.Layout.Left);
            Assert.AreEqual(150, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void margin_auto_multiple_children_column()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(alignItems:YogaAlign.Center, width: 200, height: 200)
                           .Add(rootChild0 = Node(margin: new Edges(top: YogaValue.Auto), width:50, height:50))
                           .Add(rootChild1 = Node(margin: new Edges(top: YogaValue.Auto), width:50, height:50))
                           .Add(rootChild2 = Node(width:50, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, rootChild0.Layout.Left);
            Assert.AreEqual(25, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(75, rootChild1.Layout.Left);
            Assert.AreEqual(100, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            Assert.AreEqual(75, rootChild2.Layout.Left);
            Assert.AreEqual(150, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(50, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, rootChild0.Layout.Left);
            Assert.AreEqual(25, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(75, rootChild1.Layout.Left);
            Assert.AreEqual(100, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            Assert.AreEqual(75, rootChild2.Layout.Left);
            Assert.AreEqual(150, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(50, rootChild2.Layout.Height);
        }

        [Test]
        public void margin_auto_multiple_children_row()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignItems:YogaAlign.Center, width: 200, height: 200)
                           .Add(rootChild0 = Node(margin: new Edges(right: YogaValue.Auto), width:50, height:50))
                           .Add(rootChild1 = Node(margin: new Edges(right: YogaValue.Auto), width:50, height:50))
                           .Add(rootChild2 = Node(width:50, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(75, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(75, rootChild1.Layout.Left);
            Assert.AreEqual(75, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            Assert.AreEqual(150, rootChild2.Layout.Left);
            Assert.AreEqual(75, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(50, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(125, rootChild0.Layout.Left);
            Assert.AreEqual(75, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(75, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(75, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(50, rootChild2.Layout.Height);
        }

        [Test]
        public void margin_auto_left_and_right_column()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignItems:YogaAlign.Center, width: 200, height: 200)
                           .Add(rootChild0 = Node(margin: new Edges(left: YogaValue.Auto, right:YogaValue.Auto), width:50, height:50))
                           .Add(rootChild1 = Node(width:50, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(75, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(150, rootChild1.Layout.Left);
            Assert.AreEqual(75, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(100, rootChild0.Layout.Left);
            Assert.AreEqual(75, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(75, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void margin_auto_left_and_right()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(width: 200, height: 200)
                           .Add(rootChild0 = Node(margin: new Edges(left: YogaValue.Auto, right:YogaValue.Auto), width:50, height:50))
                           .Add(rootChild1 = Node(width:50, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(150, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void margin_auto_start_and_end_column()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignItems:YogaAlign.Center, width: 200, height: 200)
                           .Add(rootChild0 = Node(margin: new Edges(start: YogaValue.Auto, end:YogaValue.Auto), width:50, height:50))
                           .Add(rootChild1 = Node(width:50, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(75, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(150, rootChild1.Layout.Left);
            Assert.AreEqual(75, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(100, rootChild0.Layout.Left);
            Assert.AreEqual(75, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(75, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void margin_auto_start_and_end()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(width: 200, height: 200)
                           .Add(rootChild0 = Node(margin: new Edges(start: YogaValue.Auto, end:YogaValue.Auto), width:50, height:50))
                           .Add(rootChild1 = Node(width:50, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(150, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void margin_auto_left_and_right_column_and_center()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(alignItems:YogaAlign.Center, width: 200, height: 200)
                           .Add(rootChild0 = Node(margin: new Edges(left: YogaValue.Auto, right:YogaValue.Auto), width:50, height:50))
                           .Add(rootChild1 = Node(width:50, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(75, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(75, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void margin_auto_left()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(alignItems:YogaAlign.Center, width: 200, height: 200)
                           .Add(rootChild0 = Node(margin: new Edges(left: YogaValue.Auto), width:50, height:50))
                           .Add(rootChild1 = Node(width:50, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(150, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(75, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(150, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(75, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void margin_auto_right()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(alignItems:YogaAlign.Center, width: 200, height: 200)
                           .Add(rootChild0 = Node(margin: new Edges(right:YogaValue.Auto), width:50, height:50))
                           .Add(rootChild1 = Node(width:50, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(75, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(75, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void margin_auto_left_and_right_stretch()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(flexDirection:FlexDirection.Row, width: 200, height: 200)
                           .Add(rootChild0 = Node(margin: new Edges(left: YogaValue.Auto, right:YogaValue.Auto), width:50, height:50))
                           .Add(rootChild1 = Node(width:50, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(150, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(100, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void margin_auto_top_and_bottom_stretch()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(width: 200, height: 200)
                           .Add(rootChild0 = Node(margin: new Edges(top: YogaValue.Auto, bottom:YogaValue.Auto), width:50, height:50))
                           .Add(rootChild1 = Node(width:50, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(50, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(150, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(150, rootChild0.Layout.Left);
            Assert.AreEqual(50, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(150, rootChild1.Layout.Left);
            Assert.AreEqual(150, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void margin_should_not_be_part_of_max_height()
        {
            YogaNode rootChild0;
            YogaNode root = Node(width: 250, height: 250)
               .Add(rootChild0 = Node(margin: new Edges(top: 20), width: 100, height: 100, maxHeight:100));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(250, root.Layout.Width);
            Assert.AreEqual(250, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(20, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(250, root.Layout.Width);
            Assert.AreEqual(250, root.Layout.Height);

            Assert.AreEqual(150, rootChild0.Layout.Left);
            Assert.AreEqual(20, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);
        }

        [Test]
        public void margin_should_not_be_part_of_max_width()
        {
            YogaNode rootChild0;
            YogaNode root = Node(width: 250, height: 250)
               .Add(rootChild0 = Node(margin: new Edges(left: 20), width: 100, maxWidth:100, height: 100));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(250, root.Layout.Width);
            Assert.AreEqual(250, root.Layout.Height);

            Assert.AreEqual(20, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(250, root.Layout.Width);
            Assert.AreEqual(250, root.Layout.Height);

            Assert.AreEqual(150, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);
        }

        [Test]
        public void margin_auto_left_right_child_bigger_than_parent()
        {
            YogaNode rootChild0;
            YogaNode root = Node(justifyContent:Justify.Center, width: 52, height: 52)
               .Add(rootChild0 = Node(margin: new Edges(left: YogaValue.Auto, right:YogaValue.Auto), width: 72, height: 72));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(-10, rootChild0.Layout.Top);
            Assert.AreEqual(72, rootChild0.Layout.Width);
            Assert.AreEqual(72, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-20, rootChild0.Layout.Left);
            Assert.AreEqual(-10, rootChild0.Layout.Top);
            Assert.AreEqual(72, rootChild0.Layout.Width);
            Assert.AreEqual(72, rootChild0.Layout.Height);
        }

        [Test]
        public void margin_auto_left_child_bigger_than_parent()
        {
            YogaNode rootChild0;
            YogaNode root = Node(justifyContent:Justify.Center, width: 52, height: 52)
               .Add(rootChild0 = Node(margin: new Edges(left: YogaValue.Auto), width: 72, height: 72));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(-10, rootChild0.Layout.Top);
            Assert.AreEqual(72, rootChild0.Layout.Width);
            Assert.AreEqual(72, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-20, rootChild0.Layout.Left);
            Assert.AreEqual(-10, rootChild0.Layout.Top);
            Assert.AreEqual(72, rootChild0.Layout.Width);
            Assert.AreEqual(72, rootChild0.Layout.Height);
        }

        [Test]
        public void margin_fix_left_auto_right_child_bigger_than_parent()
        {
            YogaNode rootChild0;
            YogaNode root = Node(justifyContent:Justify.Center, width: 52, height: 52)
               .Add(rootChild0 = Node(margin: new Edges(left: 10, right:YogaValue.Auto), width: 72, height: 72));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(-10, rootChild0.Layout.Top);
            Assert.AreEqual(72, rootChild0.Layout.Width);
            Assert.AreEqual(72, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-20, rootChild0.Layout.Left);
            Assert.AreEqual(-10, rootChild0.Layout.Top);
            Assert.AreEqual(72, rootChild0.Layout.Width);
            Assert.AreEqual(72, rootChild0.Layout.Height);
        }

        [Test]
        public void margin_auto_left_fix_right_child_bigger_than_parent()
        {
            YogaNode rootChild0;
            YogaNode root = Node(justifyContent:Justify.Center, width: 52, height: 52)
               .Add(rootChild0 = Node(margin: new Edges(left: YogaValue.Auto, right:10), width: 72, height: 72));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(-10, rootChild0.Layout.Top);
            Assert.AreEqual(72, rootChild0.Layout.Width);
            Assert.AreEqual(72, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-30, rootChild0.Layout.Left);
            Assert.AreEqual(-10, rootChild0.Layout.Top);
            Assert.AreEqual(72, rootChild0.Layout.Width);
            Assert.AreEqual(72, rootChild0.Layout.Height);
        }

        [Test]
        public void margin_auto_top_stretching_child()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(alignItems:YogaAlign.Center, width: 200, height: 200)
                           .Add(rootChild0 = Node(flexGrow: 1, flexShrink: 1, flexBasis: 0.Percent(), margin: new Edges(top: YogaValue.Auto)))
                           .Add(rootChild1 = Node(width:50, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(100, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(0, rootChild0.Layout.Width);
            Assert.AreEqual(150, rootChild0.Layout.Height);

            Assert.AreEqual(75, rootChild1.Layout.Left);
            Assert.AreEqual(150, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(100, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(0, rootChild0.Layout.Width);
            Assert.AreEqual(150, rootChild0.Layout.Height);

            Assert.AreEqual(75, rootChild1.Layout.Left);
            Assert.AreEqual(150, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void margin_auto_left_stretching_child()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(alignItems: YogaAlign.Center, width: 200, height: 200)
                           .Add(rootChild0 = Node(flexGrow: 1, flexShrink: 1, flexBasis: 0.Percent(), margin: new Edges(left: YogaValue.Auto)))
                           .Add(rootChild1 = Node(width:50, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(200, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(0, rootChild0.Layout.Width);
            Assert.AreEqual(150, rootChild0.Layout.Height);

            Assert.AreEqual(75, rootChild1.Layout.Left);
            Assert.AreEqual(150, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(200, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(0, rootChild0.Layout.Width);
            Assert.AreEqual(150, rootChild0.Layout.Height);

            Assert.AreEqual(75, rootChild1.Layout.Left);
            Assert.AreEqual(150, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }
    }
}
