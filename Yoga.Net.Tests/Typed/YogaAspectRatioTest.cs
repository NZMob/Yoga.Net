using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaAspectRatioTest
    {
        static MeasureFunc _measure = (node, width, widthMode, height, heightMode, context) => new YogaSize(
            widthMode == MeasureMode.Exactly ? width : 50,
            heightMode == MeasureMode.Exactly ? height : 50);

        [Test]
        public void aspect_ratio_cross_defined()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(width:50, aspectRatio:1 ));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_main_defined()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(height:50, aspectRatio:1 ));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_both_dimensions_defined_row()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(width:100, height:50, aspectRatio:1 ));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_both_dimensions_defined_column()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(width:100, height:50, aspectRatio:1 ));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_align_stretch()
        {
            YogaNode rootChild0;
            YogaNode root = Node(width: 100, height: 100)
               .Add(rootChild0 = Node(aspectRatio:1 ));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_flex_grow()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(height:50, flexGrow:1, aspectRatio:1 ));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_flex_shrink()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(height:100, flexShrink:1, aspectRatio:1 ));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_flex_shrink_2()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(width: 100, height: 100)
                           .Add(rootChild0 = Node(height: 100.Percent(), flexShrink: 1, aspectRatio: 1))
                           .Add(rootChild1 = Node(height: 100.Percent(), flexShrink: 1, aspectRatio: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void aspect_ratio_basis()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(flexBasis:50, aspectRatio:1 ));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_absolute_layout_width_defined()
        {
            YogaNode rootChild0;
            YogaNode root = Node(width: 100, height: 100)
               .Add(rootChild0 = Node(positionType:PositionType.Absolute, left:0, top:0, width:50, aspectRatio:1 ));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_absolute_layout_height_defined()
        {
            YogaNode rootChild0;
            YogaNode root = Node(width: 100, height: 100)
               .Add(rootChild0 = Node(positionType:PositionType.Absolute, left:0, top:0, height:50, aspectRatio:1 ));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_with_max_cross_defined()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(height:50, maxWidth:40, aspectRatio: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(40, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_with_max_main_defined()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(width:50, maxHeight:40, aspectRatio: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(40, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_with_min_cross_defined()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(height:30, minWidth:40, aspectRatio: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(40, rootChild0.Layout.Width);
            Assert.AreEqual(30, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_with_min_main_defined()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(width:30, minHeight:40, aspectRatio: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(40, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_double_cross()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(height:50, aspectRatio: 2));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_half_cross()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(height:100, aspectRatio: 0.5f));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_double_main()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(width:50, aspectRatio: 0.5f));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_half_main()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(width:100, aspectRatio: 2));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_with_measure_func()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(measureFunc:_measure, aspectRatio: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_width_height_flex_grow_row()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignItems: YogaAlign.FlexStart, width: 100, height: 200)
               .Add(rootChild0 = Node(width:50, height:50, flexGrow:1, aspectRatio: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_width_height_flex_grow_column()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 200, height: 100)
               .Add(rootChild0 = Node(width:50, height:50, flexGrow:1, aspectRatio: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_height_as_flex_basis()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, flexDirection: FlexDirection.Row, width: 200, height: 200)
                           .Add(rootChild0 = Node(height: 50, flexGrow: 1, aspectRatio: 1))
                           .Add(rootChild1 = Node(height: 100, flexGrow: 1, aspectRatio: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(75, rootChild0.Layout.Width);
            Assert.AreEqual(75, rootChild0.Layout.Height);

            Assert.AreEqual(75, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(125, rootChild1.Layout.Width);
            Assert.AreEqual(125, rootChild1.Layout.Height);
        }

        [Test]
        public void aspect_ratio_width_as_flex_basis()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 200, height: 200)
                           .Add(rootChild0 = Node(width: 50, flexGrow: 1, aspectRatio: 1))
                           .Add(rootChild1 = Node(width: 100, flexGrow: 1, aspectRatio: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(75, rootChild0.Layout.Width);
            Assert.AreEqual(75, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(75, rootChild1.Layout.Top);
            Assert.AreEqual(125, rootChild1.Layout.Width);
            Assert.AreEqual(125, rootChild1.Layout.Height);
        }

        [Test]
        public void aspect_ratio_overrides_flex_grow_row()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, flexDirection:FlexDirection.Row, width: 100, height: 100)
               .Add(rootChild0 = Node(height:50, flexGrow:1, aspectRatio: 0.5f));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(200, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_overrides_flex_grow_column()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(height:50, flexGrow:1, aspectRatio: 2));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(200, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_left_right_absolute()
        {
            YogaNode rootChild0;
            YogaNode root = Node(width: 100, height: 100)
               .Add(rootChild0 = Node(positionType:PositionType.Absolute, left:10, top:10, right:10, aspectRatio: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(80, rootChild0.Layout.Width);
            Assert.AreEqual(80, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_top_bottom_absolute()
        {
            YogaNode rootChild0;
            YogaNode root = Node(width: 100, height: 100)
               .Add(rootChild0 = Node(positionType:PositionType.Absolute, left:10, top:10, bottom:10, aspectRatio: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(80, rootChild0.Layout.Width);
            Assert.AreEqual(80, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_width_overrides_align_stretch_row()
        {

            YogaNode rootChild0;
            YogaNode root = Node(flexDirection:FlexDirection.Row, width: 100, height: 100)
               .Add(rootChild0 = Node(width:50, aspectRatio: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_height_overrides_align_stretch_column()
        {
            YogaNode rootChild0;
            YogaNode root = Node(width: 100, height: 100)
               .Add(rootChild0 = Node(height:50, aspectRatio: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_allow_child_overflow_parent_size()
        {
            YogaNode rootChild0;
            YogaNode root = Node(width: 100, alignItems:YogaAlign.FlexStart)
               .Add(rootChild0 = Node(height:50, aspectRatio: 4));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(200, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_defined_main_with_margin()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems:YogaAlign.Center, justifyContent:Justify.Center, width: 100, height: 100)
               .Add(rootChild0 = Node(height:50, aspectRatio: 1, margin:new Edges(left:10, right:10)));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_defined_cross_with_margin()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.Center, justifyContent: Justify.Center, width: 100, height: 100)
               .Add(rootChild0 = Node(width:50, aspectRatio: 1, margin:new Edges(left:10, right:10)));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);
        }

        [Test]
        public void aspect_ratio_defined_cross_with_main_margin()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems:YogaAlign.Center, justifyContent:Justify.Center, width: 100, height: 100)
               .Add(rootChild0 = Node(width:50, aspectRatio: 1, margin:new Edges(top:10, bottom:10)));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);
        }

        /*
        [Test] public void aspect_ratio_should_prefer_explicit_height() {
            YGConfig config = new YogaConfig();
            YGConfigSetUseWebDefaults(config, true);

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Column);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Column);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0_child0, FlexDirection.Column);
            YGNodeStyleSetHeight(root_child0_child0, 100);
            YGNodeStyleSetAspectRatio(root_child0_child0, 2);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaArrange.CalculateLayout(root, 100, 200, Direction.LTR);

            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(200, root_child0_child0.Layout.Width);
            Assert.AreEqual(100, root_child0_child0.Layout.Height);

            
        }
        */

        /*
        [Test] public void aspect_ratio_should_prefer_explicit_width() {
            YGConfig config = new YogaConfig();
            YGConfigSetUseWebDefaults(config, true);

            YogaNode root = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Row);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0_child0, FlexDirection.Row);
            YGNodeStyleSetWidth(root_child0_child0, 100);
            YGNodeStyleSetAspectRatio(root_child0_child0, 0.5f);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaArrange.CalculateLayout(root, 200, 100, Direction.LTR);

            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(100, root_child0.Layout.Height);

            Assert.AreEqual(100, root_child0_child0.Layout.Width);
            Assert.AreEqual(200, root_child0_child0.Layout.Height);

            
        }
        */

        /*
        [Test] public void aspect_ratio_should_prefer_flexed_dimension() {
            YGConfig config = new YogaConfig();
            YGConfigSetUseWebDefaults(config, true);

            YogaNode root = new YogaNode(config);

            YogaNode root_child0 = new YogaNode(config);
            YGNodeStyleSetFlexDirection(root_child0, FlexDirection.Column);
            YGNodeStyleSetAspectRatio(root_child0, 2);
            YGNodeStyleSetFlexGrow(root_child0, 1);
            YGNodeInsertChild(root, root_child0, 0);

            YogaNode root_child0_child0 = new YogaNode(config);
            YGNodeStyleSetAspectRatio(root_child0_child0, 4);
            YGNodeStyleSetFlexGrow(root_child0_child0, 1);
            YGNodeInsertChild(root_child0, root_child0_child0, 0);

            YogaArrange.CalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, root_child0.Layout.Width);
            Assert.AreEqual(50, root_child0.Layout.Height);

            Assert.AreEqual(200, root_child0_child0.Layout.Width);
            Assert.AreEqual(50, root_child0_child0.Layout.Height);

            
        }
        */
    }
}
