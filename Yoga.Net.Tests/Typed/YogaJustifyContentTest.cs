using NUnit.Framework;

using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaJustifyContentTest
    {
        [Test]
        public void justify_content_row_flex_start()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 102, height: 102)
                           .Add(rootChild0 = Node(width:10))
                           .Add(rootChild1 = Node(width:10))
                           .Add(rootChild2 = Node(width:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(102, rootChild0.Layout.Height);

            Assert.AreEqual(10, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(10, rootChild1.Layout.Width);
            Assert.AreEqual(102, rootChild1.Layout.Height);

            Assert.AreEqual(20, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(10, rootChild2.Layout.Width);
            Assert.AreEqual(102, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(92, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(102, rootChild0.Layout.Height);

            Assert.AreEqual(82, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(10, rootChild1.Layout.Width);
            Assert.AreEqual(102, rootChild1.Layout.Height);

            Assert.AreEqual(72, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(10, rootChild2.Layout.Width);
            Assert.AreEqual(102, rootChild2.Layout.Height);
        }

        [Test]
        public void justify_content_row_flex_end()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(flexDirection: FlexDirection.Row, justifyContent:Justify.FlexEnd, width: 102, height: 102)
                           .Add(rootChild0 = Node(width:10))
                           .Add(rootChild1 = Node(width:10))
                           .Add(rootChild2 = Node(width:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(72, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(102, rootChild0.Layout.Height);

            Assert.AreEqual(82, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(10, rootChild1.Layout.Width);
            Assert.AreEqual(102, rootChild1.Layout.Height);

            Assert.AreEqual(92, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(10, rootChild2.Layout.Width);
            Assert.AreEqual(102, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(20, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(102, rootChild0.Layout.Height);

            Assert.AreEqual(10, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(10, rootChild1.Layout.Width);
            Assert.AreEqual(102, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(10, rootChild2.Layout.Width);
            Assert.AreEqual(102, rootChild2.Layout.Height);
        }

        [Test]
        public void justify_content_row_center()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(flexDirection: FlexDirection.Row, justifyContent:Justify.Center, width: 102, height: 102)
                           .Add(rootChild0 = Node(width:10))
                           .Add(rootChild1 = Node(width:10))
                           .Add(rootChild2 = Node(width:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(36, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(102, rootChild0.Layout.Height);

            Assert.AreEqual(46, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(10, rootChild1.Layout.Width);
            Assert.AreEqual(102, rootChild1.Layout.Height);

            Assert.AreEqual(56, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(10, rootChild2.Layout.Width);
            Assert.AreEqual(102, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(56, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(102, rootChild0.Layout.Height);

            Assert.AreEqual(46, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(10, rootChild1.Layout.Width);
            Assert.AreEqual(102, rootChild1.Layout.Height);

            Assert.AreEqual(36, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(10, rootChild2.Layout.Width);
            Assert.AreEqual(102, rootChild2.Layout.Height);
        }

        [Test]
        public void justify_content_row_space_between()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(flexDirection: FlexDirection.Row, justifyContent:Justify.SpaceBetween, width: 102, height: 102)
                           .Add(rootChild0 = Node(width:10))
                           .Add(rootChild1 = Node(width:10))
                           .Add(rootChild2 = Node(width:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(102, rootChild0.Layout.Height);

            Assert.AreEqual(46, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(10, rootChild1.Layout.Width);
            Assert.AreEqual(102, rootChild1.Layout.Height);

            Assert.AreEqual(92, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(10, rootChild2.Layout.Width);
            Assert.AreEqual(102, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(92, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(102, rootChild0.Layout.Height);

            Assert.AreEqual(46, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(10, rootChild1.Layout.Width);
            Assert.AreEqual(102, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(10, rootChild2.Layout.Width);
            Assert.AreEqual(102, rootChild2.Layout.Height);
        }

        [Test]
        public void justify_content_row_space_around()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(flexDirection: FlexDirection.Row, justifyContent:Justify.SpaceAround, width: 102, height: 102)
                           .Add(rootChild0 = Node(width:10))
                           .Add(rootChild1 = Node(width:10))
                           .Add(rootChild2 = Node(width:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(12, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(102, rootChild0.Layout.Height);

            Assert.AreEqual(46, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(10, rootChild1.Layout.Width);
            Assert.AreEqual(102, rootChild1.Layout.Height);

            Assert.AreEqual(80, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(10, rootChild2.Layout.Width);
            Assert.AreEqual(102, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(80, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(102, rootChild0.Layout.Height);

            Assert.AreEqual(46, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(10, rootChild1.Layout.Width);
            Assert.AreEqual(102, rootChild1.Layout.Height);

            Assert.AreEqual(12, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(10, rootChild2.Layout.Width);
            Assert.AreEqual(102, rootChild2.Layout.Height);
        }

        [Test]
        public void justify_content_column_flex_start()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(width: 102, height: 102)
                           .Add(rootChild0 = Node(height:10))
                           .Add(rootChild1 = Node(height:10))
                           .Add(rootChild2 = Node(height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(102, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(10, rootChild1.Layout.Top);
            Assert.AreEqual(102, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(20, rootChild2.Layout.Top);
            Assert.AreEqual(102, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(102, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(10, rootChild1.Layout.Top);
            Assert.AreEqual(102, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(20, rootChild2.Layout.Top);
            Assert.AreEqual(102, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);
        }

        [Test]
        public void justify_content_column_flex_end()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(justifyContent:Justify.FlexEnd, width: 102, height: 102)
                           .Add(rootChild0 = Node(height:10))
                           .Add(rootChild1 = Node(height:10))
                           .Add(rootChild2 = Node(height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(72, rootChild0.Layout.Top);
            Assert.AreEqual(102, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(82, rootChild1.Layout.Top);
            Assert.AreEqual(102, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(92, rootChild2.Layout.Top);
            Assert.AreEqual(102, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(72, rootChild0.Layout.Top);
            Assert.AreEqual(102, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(82, rootChild1.Layout.Top);
            Assert.AreEqual(102, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(92, rootChild2.Layout.Top);
            Assert.AreEqual(102, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);
        }

        [Test]
        public void justify_content_column_center()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(justifyContent:Justify.Center, width: 102, height: 102)
                           .Add(rootChild0 = Node(height:10))
                           .Add(rootChild1 = Node(height:10))
                           .Add(rootChild2 = Node(height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(36, rootChild0.Layout.Top);
            Assert.AreEqual(102, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(46, rootChild1.Layout.Top);
            Assert.AreEqual(102, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(56, rootChild2.Layout.Top);
            Assert.AreEqual(102, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(36, rootChild0.Layout.Top);
            Assert.AreEqual(102, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(46, rootChild1.Layout.Top);
            Assert.AreEqual(102, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(56, rootChild2.Layout.Top);
            Assert.AreEqual(102, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);
        }

        [Test]
        public void justify_content_column_space_between()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(justifyContent:Justify.SpaceBetween, width: 102, height: 102)
                           .Add(rootChild0 = Node(height:10))
                           .Add(rootChild1 = Node(height:10))
                           .Add(rootChild2 = Node(height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(102, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(46, rootChild1.Layout.Top);
            Assert.AreEqual(102, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(92, rootChild2.Layout.Top);
            Assert.AreEqual(102, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(102, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(46, rootChild1.Layout.Top);
            Assert.AreEqual(102, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(92, rootChild2.Layout.Top);
            Assert.AreEqual(102, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);
        }

        [Test]
        public void justify_content_column_space_around()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(justifyContent:Justify.SpaceAround, width: 102, height: 102)
                           .Add(rootChild0 = Node(height:10))
                           .Add(rootChild1 = Node(height:10))
                           .Add(rootChild2 = Node(height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(12, rootChild0.Layout.Top);
            Assert.AreEqual(102, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(46, rootChild1.Layout.Top);
            Assert.AreEqual(102, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(80, rootChild2.Layout.Top);
            Assert.AreEqual(102, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(12, rootChild0.Layout.Top);
            Assert.AreEqual(102, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(46, rootChild1.Layout.Top);
            Assert.AreEqual(102, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(80, rootChild2.Layout.Top);
            Assert.AreEqual(102, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);
        }

        [Test]
        public void justify_content_row_min_width_and_margin()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, justifyContent: Justify.Center, margin: new Edges(left: 100), minWidth: 50)
               .Add(rootChild0 = Node(width:20, height: 20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(20, root.Layout.Height);

            Assert.AreEqual(15, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(20, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(100, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(20, root.Layout.Height);

            Assert.AreEqual(15, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(20, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);
        }

        [Test]
        public void justify_content_min_width_with_padding_child_width_greater_than_parent()
        {
            YogaNode rootChild0, rootChild0Child0, rootChild0Child0Child0;
            YogaNode root = Node(alignContent: YogaAlign.Stretch, width: 1000, height: 1584)
               .Add(rootChild0 = Node(flexDirection: FlexDirection.Row, alignContent: YogaAlign.Stretch)
                       .Add(rootChild0Child0 = Node(flexDirection: FlexDirection.Row, justifyContent: Justify.Center, alignContent: YogaAlign.Stretch, minWidth: 400, padding: new Edges(horizontal: 100))
                               .Add(rootChild0Child0Child0 = Node(flexDirection: FlexDirection.Row, alignContent: YogaAlign.Stretch, width: 300, height: 100))
                        )
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(1000, root.Layout.Width);
            Assert.AreEqual(1584, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(1000, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(500, rootChild0Child0.Layout.Width);
            Assert.AreEqual(100, rootChild0Child0.Layout.Height);

            Assert.AreEqual(100, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(300, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(100, rootChild0Child0Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(1000, root.Layout.Width);
            Assert.AreEqual(1584, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(1000, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(500, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(500, rootChild0Child0.Layout.Width);
            Assert.AreEqual(100, rootChild0Child0.Layout.Height);

            Assert.AreEqual(100, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(300, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(100, rootChild0Child0Child0.Layout.Height);
        }

        [Test]
        public void justify_content_min_width_with_padding_child_width_lower_than_parent()
        {
            YogaNode rootChild0, rootChild0Child0, rootChild0Child0Child0;
            YogaNode root = Node(alignContent: YogaAlign.Stretch, width: 1080, height: 1584)
               .Add(rootChild0 = Node(flexDirection: FlexDirection.Row, alignContent: YogaAlign.Stretch)
                   .Add(rootChild0Child0 = Node(flexDirection: FlexDirection.Row, justifyContent: Justify.Center, alignContent: YogaAlign.Stretch, minWidth: 400, padding: new Edges(horizontal: 100))
                       .Add(rootChild0Child0Child0 = Node(flexDirection: FlexDirection.Row, alignContent: YogaAlign.Stretch, width: 199, height: 100))
                    )
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(1080, root.Layout.Width);
            Assert.AreEqual(1584, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(1080, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(400, rootChild0Child0.Layout.Width);
            Assert.AreEqual(100, rootChild0Child0.Layout.Height);

            Assert.AreEqual(101, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(199, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(100, rootChild0Child0Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(1080, root.Layout.Width);
            Assert.AreEqual(1584, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(1080, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(680, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(400, rootChild0Child0.Layout.Width);
            Assert.AreEqual(100, rootChild0Child0.Layout.Height);

            Assert.AreEqual(101, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(199, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(100, rootChild0Child0Child0.Layout.Height);
        }

        [Test]
        public void justify_content_row_max_width_and_margin()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexDirection:FlexDirection.Row, justifyContent:Justify.Center, margin:new Edges(left:100), width:100, maxWidth:80)
               .Add(rootChild0 = Node(width:20, height:20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(80, root.Layout.Width);
            Assert.AreEqual(20, root.Layout.Height);

            Assert.AreEqual(30, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(20, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(100, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(80, root.Layout.Width);
            Assert.AreEqual(20, root.Layout.Height);

            Assert.AreEqual(30, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(20, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);
        }

        [Test]
        public void justify_content_column_min_height_and_margin()
        {
            YogaNode rootChild0;
            YogaNode root = Node(justifyContent:Justify.Center, margin:new Edges(top:100), minHeight:50)
               .Add(rootChild0 = Node(width:20, height:20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(100, root.Layout.Top);
            Assert.AreEqual(20, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(15, rootChild0.Layout.Top);
            Assert.AreEqual(20, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(100, root.Layout.Top);
            Assert.AreEqual(20, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(15, rootChild0.Layout.Top);
            Assert.AreEqual(20, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);
        }

        [Test]
        public void justify_content_column_max_height_and_margin()
        {
            YogaNode rootChild0;
            YogaNode root = Node(justifyContent:Justify.Center, margin:new Edges(top:100), height:100, maxHeight:80)
               .Add(rootChild0 = Node(width:20, height:20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(100, root.Layout.Top);
            Assert.AreEqual(20, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(30, rootChild0.Layout.Top);
            Assert.AreEqual(20, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(100, root.Layout.Top);
            Assert.AreEqual(20, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(30, rootChild0.Layout.Top);
            Assert.AreEqual(20, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);
        }

        [Test]
        public void justify_content_column_space_evenly()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(justifyContent: Justify.SpaceEvenly, width: 102, height: 102)
                           .Add(rootChild0 = Node(height: 10))
                           .Add(rootChild1 = Node(height: 10))
                           .Add(rootChild2 = Node(height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(18, rootChild0.Layout.Top);
            Assert.AreEqual(102, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(46, rootChild1.Layout.Top);
            Assert.AreEqual(102, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(74, rootChild2.Layout.Top);
            Assert.AreEqual(102, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(18, rootChild0.Layout.Top);
            Assert.AreEqual(102, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(46, rootChild1.Layout.Top);
            Assert.AreEqual(102, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(74, rootChild2.Layout.Top);
            Assert.AreEqual(102, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);
        }

        [Test]
        public void justify_content_row_space_evenly()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(flexDirection:FlexDirection.Row, justifyContent:Justify.SpaceEvenly, width: 102, height: 102)
                           .Add(rootChild0 = Node(height: 10))
                           .Add(rootChild1 = Node(height: 10))
                           .Add(rootChild2 = Node(height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(26, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(0, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(51, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(0, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(77, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(0, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(102, root.Layout.Width);
            Assert.AreEqual(102, root.Layout.Height);

            Assert.AreEqual(77, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(0, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(51, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(0, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(26, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(0, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);
        }
    }
}
