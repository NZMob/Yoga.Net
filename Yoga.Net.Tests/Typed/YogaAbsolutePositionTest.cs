using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaAbsolutePositionTest
    {
        [Test]
        public void absolute_layout_width_height_start_top()
        {
            YogaNode rootChild0;
            YogaNode root = Node(width: 100, height: 100)
               .Add(rootChild0 = Node(positionType:PositionType.Absolute, start: 10, top: 10, width:10, height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);
        }

        [Test]
        public void absolute_layout_width_height_end_bottom()
        {
            YogaNode rootChild0;
            YogaNode root = Node(width: 100, height: 100)
               .Add(rootChild0 = Node(positionType:PositionType.Absolute, end: 10, bottom: 10, width:10, height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, rootChild0.Layout.Left);
            Assert.AreEqual(80, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(80, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);
        }

        [Test]
        public void absolute_layout_start_top_end_bottom()
        {
            YogaNode rootChild0;
            YogaNode root = Node(width: 100, height: 100)
               .Add(rootChild0 = Node(positionType:PositionType.Absolute, start: 10, top: 10, end:10, bottom:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(80, rootChild0.Layout.Width);
            Assert.AreEqual(80, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(80, rootChild0.Layout.Width);
            Assert.AreEqual(80, rootChild0.Layout.Height);
        }

        [Test]
        public void absolute_layout_width_height_start_top_end_bottom()
        {
            YogaNode rootChild0;
            YogaNode root = Node(width: 100, height: 100)
               .Add(rootChild0 = Node(positionType:PositionType.Absolute, start: 10, top: 10, end:10, bottom:10, width:10, height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);
        }

        [Test]
        public void do_not_clamp_height_of_absolute_node_to_height_of_its_overflow_hidden_parent()
        {
            YogaNode rootChild0, rootChild0Child0;
            YogaNode root = Node(flexDirection:FlexDirection.Row, overflow:Overflow.Hidden, width:50, height:50)
               .Add(rootChild0 = Node(positionType:PositionType.Absolute, start:0, top:0)
                   .Add(rootChild0Child0 = Node(width:100, height:100))
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(100, rootChild0Child0.Layout.Width);
            Assert.AreEqual(100, rootChild0Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(-50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(100, rootChild0Child0.Layout.Width);
            Assert.AreEqual(100, rootChild0Child0.Layout.Height);
        }

        [Test]
        public void absolute_layout_within_border()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3;
            YogaNode root = Node(width: 100, height: 100, margin: new Edges(10), padding: new Edges(10), border: new Edges(10))
                           .Add(rootChild0 = Node(positionType: PositionType.Absolute, left: 0, top: 0, width: 50, height: 50))
                           .Add(rootChild1 = Node(positionType: PositionType.Absolute, right: 0, bottom: 0, width: 50, height: 50))
                           .Add(rootChild2 = Node(positionType: PositionType.Absolute, left: 0, top: 0, width: 50, height: 50, margin: new Edges(10)))
                           .Add(rootChild3 = Node(positionType: PositionType.Absolute, right: 0, bottom: 0, width: 50, height: 50, margin: new Edges(10)));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(10, root.Layout.Left);
            Assert.AreEqual(10, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(40, rootChild1.Layout.Left);
            Assert.AreEqual(40, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            Assert.AreEqual(20, rootChild2.Layout.Left);
            Assert.AreEqual(20, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(50, rootChild2.Layout.Height);

            Assert.AreEqual(30, rootChild3.Layout.Left);
            Assert.AreEqual(30, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(50, rootChild3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(10, root.Layout.Left);
            Assert.AreEqual(10, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(40, rootChild1.Layout.Left);
            Assert.AreEqual(40, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            Assert.AreEqual(20, rootChild2.Layout.Left);
            Assert.AreEqual(20, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(50, rootChild2.Layout.Height);

            Assert.AreEqual(30, rootChild3.Layout.Left);
            Assert.AreEqual(30, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(50, rootChild3.Layout.Height);
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_center()
        {
            YogaNode rootChild0;
            YogaNode root = Node(justifyContent: Justify.Center, alignItems: YogaAlign.Center, flexGrow: 1, width: 110, height: 100)
               .Add(rootChild0 = Node(positionType:PositionType.Absolute, width:60, height:40));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, rootChild0.Layout.Left);
            Assert.AreEqual(30, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, rootChild0.Layout.Left);
            Assert.AreEqual(30, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_flex_end()
        {
            YogaNode rootChild0;
            YogaNode root = Node(justifyContent: Justify.FlexEnd, alignItems: YogaAlign.FlexEnd, width: 110, height: 100)
               .Add(rootChild0 = Node(positionType:PositionType.Absolute, width:60, height:40));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(60, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(60, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);
        }

        [Test]
        public void absolute_layout_justify_content_center()
        {
            YogaNode rootChild0;
            YogaNode root = Node(justifyContent: Justify.Center, flexGrow: 1, width: 110, height: 100)
               .Add(rootChild0 = Node(positionType:PositionType.Absolute, width:60, height:40));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(30, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(30, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);
        }

        [Test]
        public void absolute_layout_align_items_center()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.Center, flexGrow: 1, width: 110, height: 100)
               .Add(rootChild0 = Node(positionType:PositionType.Absolute, width:60, height:40));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);
        }

        [Test]
        public void absolute_layout_align_items_center_on_child_only()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexGrow: 1, width: 110, height: 100)
               .Add(rootChild0 = Node(alignSelf:YogaAlign.Center, positionType:PositionType.Absolute, width:60, height:40));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_center_and_top_position()
        {
            YogaNode rootChild0;
            YogaNode root = Node(justifyContent: Justify.Center, alignItems: YogaAlign.Center, flexGrow: 1, width: 110, height: 100)
               .Add(rootChild0 = Node(positionType:PositionType.Absolute, width:60, height:40, top:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_center_and_bottom_position()
        {
            YogaNode rootChild0;
            YogaNode root = Node(justifyContent: Justify.Center, alignItems: YogaAlign.Center, flexGrow: 1, width: 110, height: 100)
               .Add(rootChild0 = Node(positionType:PositionType.Absolute, bottom:10, width:60, height:40));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, rootChild0.Layout.Left);
            Assert.AreEqual(50, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(25, rootChild0.Layout.Left);
            Assert.AreEqual(50, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_center_and_left_position()
        {
            YogaNode rootChild0;
            YogaNode root = Node(justifyContent: Justify.Center, alignItems: YogaAlign.Center, flexGrow: 1, width: 110, height: 100)
               .Add(rootChild0 = Node(positionType:PositionType.Absolute, left:5, width:60, height:40));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(5, rootChild0.Layout.Left);
            Assert.AreEqual(30, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(5, rootChild0.Layout.Left);
            Assert.AreEqual(30, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);
        }

        [Test]
        public void absolute_layout_align_items_and_justify_content_center_and_right_position()
        {
            YogaNode rootChild0;
            YogaNode root = Node(justifyContent: Justify.Center, alignItems: YogaAlign.Center, flexGrow: 1, width: 110, height: 100)
               .Add(rootChild0 = Node(positionType:PositionType.Absolute, right:5, width:60, height:40));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(45, rootChild0.Layout.Left);
            Assert.AreEqual(30, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(110, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(45, rootChild0.Layout.Left);
            Assert.AreEqual(30, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);
        }

        [Test]
        public void position_root_with_rtl_should_position_without_direction()
        {
            YogaNode root = Node(left: 72, width: 52, height: 52);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(72, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(72, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);
        }

        [Test]
        public void absolute_layout_percentage_bottom_based_on_parent_height()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(width: 100, height: 200)
                           .Add(rootChild0 = Node(positionType: PositionType.Absolute, top: 50.Percent(), width: 10, height: 10))
                           .Add(rootChild1 = Node(positionType: PositionType.Absolute, bottom: 50.Percent(), width: 10, height: 10))
                           .Add(rootChild2 = Node(positionType: PositionType.Absolute, top:10.Percent(), bottom: 10.Percent(), width: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(100, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(90, rootChild1.Layout.Top);
            Assert.AreEqual(10, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(20, rootChild2.Layout.Top);
            Assert.AreEqual(10, rootChild2.Layout.Width);
            Assert.AreEqual(160, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(90, rootChild0.Layout.Left);
            Assert.AreEqual(100, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(90, rootChild1.Layout.Left);
            Assert.AreEqual(90, rootChild1.Layout.Top);
            Assert.AreEqual(10, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(90, rootChild2.Layout.Left);
            Assert.AreEqual(20, rootChild2.Layout.Top);
            Assert.AreEqual(10, rootChild2.Layout.Width);
            Assert.AreEqual(160, rootChild2.Layout.Height);
        }

        [Test]
        public void absolute_layout_in_wrap_reverse_column_container()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexWrap: Wrap.WrapReverse, width: 100, height: 100)
               .Add(rootChild0 = Node(positionType: PositionType.Absolute, width: 20, height: 20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(20, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(20, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);
        }

        [Test]
        public void absolute_layout_in_wrap_reverse_row_container()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexDirection:FlexDirection.Row, flexWrap: Wrap.WrapReverse, width: 100, height: 100)
               .Add(rootChild0 = Node(positionType: PositionType.Absolute, width: 20, height: 20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(80, rootChild0.Layout.Top);
            Assert.AreEqual(20, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, rootChild0.Layout.Left);
            Assert.AreEqual(80, rootChild0.Layout.Top);
            Assert.AreEqual(20, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);
        }

        [Test]
        public void absolute_layout_in_wrap_reverse_column_container_flex_end()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexWrap: Wrap.WrapReverse, width: 100, height: 100)
               .Add(rootChild0 = Node(alignSelf:YogaAlign.FlexEnd, positionType: PositionType.Absolute, width: 20, height: 20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(20, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(20, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);
        }

        [Test]
        public void absolute_layout_in_wrap_reverse_row_container_flex_end()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexDirection:FlexDirection.Row, flexWrap: Wrap.WrapReverse, width: 100, height: 100)
               .Add(rootChild0 = Node(alignSelf:YogaAlign.FlexEnd, positionType: PositionType.Absolute, width: 20, height: 20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(20, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(20, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);
        }
    }
}
