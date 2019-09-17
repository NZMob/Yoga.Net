using NUnit.Framework;

using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaPercentageTest
    {
        [Test]
        public void percentage_width_height()
        {
            

            YogaNode rootChild0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 200, height: 200)
               .Add(rootChild0 = Node(width: 30.Percent(), height: 30.Percent()));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(60, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(140, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(60, rootChild0.Layout.Height);
        }

        [Test]
        public void percentage_position_left_top()
        {
            

            YogaNode rootChild0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 400, height: 400)
               .Add(rootChild0 = Node(left: 10.Percent(), top: 20.Percent(), width: 45.Percent(), height: 55.Percent()));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(400, root.Layout.Width);
            Assert.AreEqual(400, root.Layout.Height);

            Assert.AreEqual(40, rootChild0.Layout.Left);
            Assert.AreEqual(80, rootChild0.Layout.Top);
            Assert.AreEqual(180, rootChild0.Layout.Width);
            Assert.AreEqual(220, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(400, root.Layout.Width);
            Assert.AreEqual(400, root.Layout.Height);

            Assert.AreEqual(260, rootChild0.Layout.Left);
            Assert.AreEqual(80, rootChild0.Layout.Top);
            Assert.AreEqual(180, rootChild0.Layout.Width);
            Assert.AreEqual(220, rootChild0.Layout.Height);
        }

        [Test]
        public void percentage_position_bottom_right()
        {
            

            YogaNode rootChild0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 500, height: 500)
               .Add(rootChild0 = Node(right: 20.Percent(), bottom: 10.Percent(), width: 55.Percent(), height: 15.Percent()));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(-100, rootChild0.Layout.Left);
            Assert.AreEqual(-50, rootChild0.Layout.Top);
            Assert.AreEqual(275, rootChild0.Layout.Width);
            Assert.AreEqual(75, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(125, rootChild0.Layout.Left);
            Assert.AreEqual(-50, rootChild0.Layout.Top);
            Assert.AreEqual(275, rootChild0.Layout.Width);
            Assert.AreEqual(75, rootChild0.Layout.Height);
        }

        [Test]
        public void percentage_flex_basis()
        {
            

            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 200, height: 200)
                           .Add(rootChild0 = Node(flexGrow: 1, flexBasis: 50.Percent()))
                           .Add(rootChild1 = Node(flexGrow: 1, flexBasis: 25.Percent()));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(125, rootChild0.Layout.Width);
            Assert.AreEqual(200, rootChild0.Layout.Height);

            Assert.AreEqual(125, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(75, rootChild1.Layout.Width);
            Assert.AreEqual(200, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(75, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(125, rootChild0.Layout.Width);
            Assert.AreEqual(200, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(75, rootChild1.Layout.Width);
            Assert.AreEqual(200, rootChild1.Layout.Height);
        }

        [Test]
        public void percentage_flex_basis_cross()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(width: 200, height: 200)
                           .Add(rootChild0 = Node(flexGrow: 1, flexBasis: 50.Percent()))
                           .Add(rootChild1 = Node(flexGrow: 1, flexBasis: 25.Percent()));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(200, rootChild0.Layout.Width);
            Assert.AreEqual(125, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(125, rootChild1.Layout.Top);
            Assert.AreEqual(200, rootChild1.Layout.Width);
            Assert.AreEqual(75, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(200, rootChild0.Layout.Width);
            Assert.AreEqual(125, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(125, rootChild1.Layout.Top);
            Assert.AreEqual(200, rootChild1.Layout.Width);
            Assert.AreEqual(75, rootChild1.Layout.Height);
        }

        [Test]
        public void percentage_flex_basis_cross_min_height()
        {
            

            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(width: 200, height: 200)
                           .Add(rootChild0 = Node(flexGrow: 1, minHeight:60.Percent()))
                           .Add(rootChild1 = Node(flexGrow: 2, minHeight:10.Percent()));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(200, rootChild0.Layout.Width);
            Assert.AreEqual(140, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(140, rootChild1.Layout.Top);
            Assert.AreEqual(200, rootChild1.Layout.Width);
            Assert.AreEqual(60, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(200, rootChild0.Layout.Width);
            Assert.AreEqual(140, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(140, rootChild1.Layout.Top);
            Assert.AreEqual(200, rootChild1.Layout.Width);
            Assert.AreEqual(60, rootChild1.Layout.Height);
        }

        [Test]
        public void percentage_flex_basis_main_max_height()
        {
            

            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(flexDirection:FlexDirection.Row, width: 200, height: 200)
                           .Add(rootChild0 = Node(flexGrow: 1, flexBasis: 10.Percent(), maxHeight:60.Percent()))
                           .Add(rootChild1 = Node(flexGrow: 4, flexBasis: 10.Percent(), maxHeight:20.Percent()));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(52, rootChild0.Layout.Width);
            Assert.AreEqual(120, rootChild0.Layout.Height);

            Assert.AreEqual(52, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(148, rootChild1.Layout.Width);
            Assert.AreEqual(40, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(148, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(52, rootChild0.Layout.Width);
            Assert.AreEqual(120, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(148, rootChild1.Layout.Width);
            Assert.AreEqual(40, rootChild1.Layout.Height);
        }

        [Test]
        public void percentage_flex_basis_cross_max_height()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(width: 200, height: 200)
                           .Add(rootChild0 = Node(flexGrow: 1, flexBasis: 10.Percent(), maxHeight:60.Percent()))
                           .Add(rootChild1 = Node(flexGrow: 4, flexBasis: 10.Percent(), maxHeight:20.Percent()));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(200, rootChild0.Layout.Width);
            Assert.AreEqual(120, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(120, rootChild1.Layout.Top);
            Assert.AreEqual(200, rootChild1.Layout.Width);
            Assert.AreEqual(40, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(200, rootChild0.Layout.Width);
            Assert.AreEqual(120, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(120, rootChild1.Layout.Top);
            Assert.AreEqual(200, rootChild1.Layout.Width);
            Assert.AreEqual(40, rootChild1.Layout.Height);
        }

        [Test]
        public void percentage_flex_basis_main_max_width()
        {
            

            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(flexDirection:FlexDirection.Row, width: 200, height: 200)
                           .Add(rootChild0 = Node(flexGrow: 1, flexBasis: 15.Percent(), maxWidth:60.Percent()))
                           .Add(rootChild1 = Node(flexGrow: 4, flexBasis: 10.Percent(), maxWidth:20.Percent()));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(120, rootChild0.Layout.Width);
            Assert.AreEqual(200, rootChild0.Layout.Height);

            Assert.AreEqual(120, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(40, rootChild1.Layout.Width);
            Assert.AreEqual(200, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(80, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(120, rootChild0.Layout.Width);
            Assert.AreEqual(200, rootChild0.Layout.Height);

            Assert.AreEqual(40, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(40, rootChild1.Layout.Width);
            Assert.AreEqual(200, rootChild1.Layout.Height);
        }

        [Test]
        public void percentage_flex_basis_cross_max_width()
        {
            

            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(width: 200, height: 200)
                           .Add(rootChild0 = Node(flexGrow: 1, flexBasis: 10.Percent(), maxWidth:60.Percent()))
                           .Add(rootChild1 = Node(flexGrow: 4, flexBasis: 15.Percent(), maxWidth:20.Percent()));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(120, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(40, rootChild1.Layout.Width);
            Assert.AreEqual(150, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(80, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(120, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(160, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(40, rootChild1.Layout.Width);
            Assert.AreEqual(150, rootChild1.Layout.Height);
        }

        [Test]
        public void percentage_flex_basis_main_min_width()
        {
            

            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(flexDirection:FlexDirection.Row, width: 200, height: 200)
                           .Add(rootChild0 = Node(flexGrow: 1, flexBasis: 15.Percent(), minWidth:60.Percent()))
                           .Add(rootChild1 = Node(flexGrow: 4, flexBasis: 10.Percent(), minWidth:20.Percent()));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(120, rootChild0.Layout.Width);
            Assert.AreEqual(200, rootChild0.Layout.Height);

            Assert.AreEqual(120, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(80, rootChild1.Layout.Width);
            Assert.AreEqual(200, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(80, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(120, rootChild0.Layout.Width);
            Assert.AreEqual(200, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(80, rootChild1.Layout.Width);
            Assert.AreEqual(200, rootChild1.Layout.Height);
        }

        [Test]
        public void percentage_flex_basis_cross_min_width()
        {
            

            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(width: 200, height: 200)
                           .Add(rootChild0 = Node(flexGrow: 1, flexBasis: 10.Percent(), minWidth:60.Percent()))
                           .Add(rootChild1 = Node(flexGrow: 4, flexBasis: 15.Percent(), minWidth:20.Percent()));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(200, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(200, rootChild1.Layout.Width);
            Assert.AreEqual(150, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(200, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(200, rootChild1.Layout.Width);
            Assert.AreEqual(150, rootChild1.Layout.Height);
        }

        [Test]
        public void percentage_multiple_nested_with_padding_margin_and_percentage_values()
        {
            

            YogaNode rootChild0, rootChild1, rootChild0Child0, rootChild0Child0Child0;
            YogaNode root = Node(width: 200, height: 200)
                           .Add(rootChild0 = Node(flexGrow: 1, flexBasis: 10.Percent(), margin:new Edges(5), padding:new Edges(3), minWidth:60.Percent())
                               .Add(rootChild0Child0 = Node(margin:new Edges(5), padding:new Edges(3.Percent()), width:50.Percent())
                                   .Add(rootChild0Child0Child0 = Node(margin:new Edges(5.Percent()), padding:new Edges(3), width:45.Percent()))))
                           .Add(rootChild1 = Node(flexGrow: 4, flexBasis: 15.Percent(), minWidth:20.Percent()));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(5, rootChild0.Layout.Left);
            Assert.AreEqual(5, rootChild0.Layout.Top);
            Assert.AreEqual(190, rootChild0.Layout.Width);
            Assert.AreEqual(48, rootChild0.Layout.Height);

            Assert.AreEqual(8, rootChild0Child0.Layout.Left);
            Assert.AreEqual(8, rootChild0Child0.Layout.Top);
            Assert.AreEqual(92, rootChild0Child0.Layout.Width);
            Assert.AreEqual(25, rootChild0Child0.Layout.Height);

            Assert.AreEqual(10, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(10, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(36, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(6, rootChild0Child0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(58, rootChild1.Layout.Top);
            Assert.AreEqual(200, rootChild1.Layout.Width);
            Assert.AreEqual(142, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(5, rootChild0.Layout.Left);
            Assert.AreEqual(5, rootChild0.Layout.Top);
            Assert.AreEqual(190, rootChild0.Layout.Width);
            Assert.AreEqual(48, rootChild0.Layout.Height);

            Assert.AreEqual(90, rootChild0Child0.Layout.Left);
            Assert.AreEqual(8, rootChild0Child0.Layout.Top);
            Assert.AreEqual(92, rootChild0Child0.Layout.Width);
            Assert.AreEqual(25, rootChild0Child0.Layout.Height);

            Assert.AreEqual(46, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(10, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(36, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(6, rootChild0Child0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(58, rootChild1.Layout.Top);
            Assert.AreEqual(200, rootChild1.Layout.Width);
            Assert.AreEqual(142, rootChild1.Layout.Height);
        }

        [Test]
        public void percentage_margin_should_calculate_based_only_on_width()
        {
            

            YogaNode rootChild0, rootChild0Child0;
            YogaNode root = Node(width: 200, height: 100)
               .Add(rootChild0 = Node(flexGrow: 1, margin: new Edges(10.Percent()))
                       .Add(rootChild0Child0 = Node(width: 10, height: 10)));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(20, rootChild0.Layout.Left);
            Assert.AreEqual(20, rootChild0.Layout.Top);
            Assert.AreEqual(160, rootChild0.Layout.Width);
            Assert.AreEqual(60, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(10, rootChild0Child0.Layout.Width);
            Assert.AreEqual(10, rootChild0Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(20, rootChild0.Layout.Left);
            Assert.AreEqual(20, rootChild0.Layout.Top);
            Assert.AreEqual(160, rootChild0.Layout.Width);
            Assert.AreEqual(60, rootChild0.Layout.Height);

            Assert.AreEqual(150, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(10, rootChild0Child0.Layout.Width);
            Assert.AreEqual(10, rootChild0Child0.Layout.Height);
        }

        [Test]
        public void percentage_padding_should_calculate_based_only_on_width()
        {
            

            YogaNode rootChild0, rootChild0Child0;
            YogaNode root = Node(width: 200, height: 100)
               .Add(rootChild0 = Node(flexGrow: 1, padding: new Edges(10.Percent()))
                       .Add(rootChild0Child0 = Node(width: 10, height: 10)));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(200, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(20, rootChild0Child0.Layout.Left);
            Assert.AreEqual(20, rootChild0Child0.Layout.Top);
            Assert.AreEqual(10, rootChild0Child0.Layout.Width);
            Assert.AreEqual(10, rootChild0Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(200, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(170, rootChild0Child0.Layout.Left);
            Assert.AreEqual(20, rootChild0Child0.Layout.Top);
            Assert.AreEqual(10, rootChild0Child0.Layout.Width);
            Assert.AreEqual(10, rootChild0Child0.Layout.Height);
        }

        [Test]
        public void percentage_absolute_position()
        {
            

            YogaNode rootChild0;
            YogaNode root = Node(width: 200, height: 100)
               .Add(rootChild0 = Node(positionType:PositionType.Absolute, left:30.Percent(), top: 10.Percent(), width:10, height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(60, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(60, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);
        }

        [Test]
        public void percentage_width_height_undefined_parent_size()
        {
            YogaNode rootChild0;
            YogaNode root = Node()
               .Add(rootChild0 = Node(width: 50.Percent(), height: 50.Percent()));
                       
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(0, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(0, rootChild0.Layout.Width);
            Assert.AreEqual(0, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(0, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(0, rootChild0.Layout.Width);
            Assert.AreEqual(0, rootChild0.Layout.Height);
        }

        [Test]
        public void percent_within_flex_grow()
        {
            

            YogaNode rootChild0, rootChild1, rootChild2, rootChild1Child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 350, height: 100)
               .Add(rootChild0 = Node(width: 100))
               .Add(rootChild1 = Node(flexGrow: 1)
                     .Add(rootChild1Child0 = Node(width: 100.Percent())))
               .Add(rootChild2 = Node(width:100));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(350, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(100, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(150, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(150, rootChild1Child0.Layout.Width);
            Assert.AreEqual(0, rootChild1Child0.Layout.Height);

            Assert.AreEqual(250, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(350, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(250, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(100, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(150, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(150, rootChild1Child0.Layout.Width);
            Assert.AreEqual(0, rootChild1Child0.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);
        }

        [Test]
        public void percentage_container_in_wrapping_container()
        {
            

            YogaNode rootChild0, rootChild0Child0, rootChild0Child0Child0, rootChild0Child0Child1;
            YogaNode root = Node(justifyContent: Justify.Center, alignItems: YogaAlign.Center, width: 200, height: 200)
               .Add(
                    rootChild0 = Node()
                       .Add(
                            rootChild0Child0 = Node(flexDirection: FlexDirection.Row, justifyContent: Justify.Center, width: 100.Percent())
                                                .Add(rootChild0Child0Child0 = Node(width: 50, height: 50))
                                                .Add(rootChild0Child0Child1 = Node(width: 50, height: 50))
                        )
                );
                           
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(75, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(100, rootChild0Child0.Layout.Width);
            Assert.AreEqual(50, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(50, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(50, rootChild0Child0Child0.Layout.Height);

            Assert.AreEqual(50, rootChild0Child0Child1.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child1.Layout.Top);
            Assert.AreEqual(50, rootChild0Child0Child1.Layout.Width);
            Assert.AreEqual(50, rootChild0Child0Child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(75, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(100, rootChild0Child0.Layout.Width);
            Assert.AreEqual(50, rootChild0Child0.Layout.Height);

            Assert.AreEqual(50, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(50, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(50, rootChild0Child0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child1.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child1.Layout.Top);
            Assert.AreEqual(50, rootChild0Child0Child1.Layout.Width);
            Assert.AreEqual(50, rootChild0Child0Child1.Layout.Height);
        }

        [Test]
        public void percent_absolute_position()
        {
            

            YogaNode rootChild0, rootChild0Child0, rootChild0Child1;
            YogaNode root = Node(width: 60, height: 50)
                   .Add(rootChild0 = Node(flexDirection: FlexDirection.Row, positionType:PositionType.Absolute, left:50.Percent(), width:100.Percent(), height:50)
                         .Add(rootChild0Child0 = Node(width:100.Percent()))
                         .Add(rootChild0Child1 = Node(width:100.Percent())));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(60, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(30, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(60, rootChild0Child0.Layout.Width);
            Assert.AreEqual(50, rootChild0Child0.Layout.Height);

            Assert.AreEqual(60, rootChild0Child1.Layout.Left);
            Assert.AreEqual(0, rootChild0Child1.Layout.Top);
            Assert.AreEqual(60, rootChild0Child1.Layout.Width);
            Assert.AreEqual(50, rootChild0Child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(60, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(30, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(60, rootChild0Child0.Layout.Width);
            Assert.AreEqual(50, rootChild0Child0.Layout.Height);

            Assert.AreEqual(-60, rootChild0Child1.Layout.Left);
            Assert.AreEqual(0, rootChild0Child1.Layout.Top);
            Assert.AreEqual(60, rootChild0Child1.Layout.Width);
            Assert.AreEqual(50, rootChild0Child1.Layout.Height);
        }
    }
}
