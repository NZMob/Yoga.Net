using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaFlexWrapTest
    {
        [Test]
        public void wrap_column()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3;
            YogaNode root = Node(flexWrap:Wrap.Wrap, height:100)
                           .Add(rootChild0 = Node(width:30, height:30))
                           .Add(rootChild1 = Node(width:30, height:30))
                           .Add(rootChild2 = Node(width:30, height:30))
                           .Add(rootChild3 = Node(width:30, height:30));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(60, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(30, rootChild0.Layout.Width);
            Assert.AreEqual(30, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(30, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(30, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(60, rootChild2.Layout.Top);
            Assert.AreEqual(30, rootChild2.Layout.Width);
            Assert.AreEqual(30, rootChild2.Layout.Height);

            Assert.AreEqual(30, rootChild3.Layout.Left);
            Assert.AreEqual(0, rootChild3.Layout.Top);
            Assert.AreEqual(30, rootChild3.Layout.Width);
            Assert.AreEqual(30, rootChild3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(60, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(30, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(30, rootChild0.Layout.Width);
            Assert.AreEqual(30, rootChild0.Layout.Height);

            Assert.AreEqual(30, rootChild1.Layout.Left);
            Assert.AreEqual(30, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(30, rootChild1.Layout.Height);

            Assert.AreEqual(30, rootChild2.Layout.Left);
            Assert.AreEqual(60, rootChild2.Layout.Top);
            Assert.AreEqual(30, rootChild2.Layout.Width);
            Assert.AreEqual(30, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(0, rootChild3.Layout.Top);
            Assert.AreEqual(30, rootChild3.Layout.Width);
            Assert.AreEqual(30, rootChild3.Layout.Height);
        }

        [Test]
        public void wrap_row()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3;
            YogaNode root = Node(flexDirection:FlexDirection.Row, flexWrap:Wrap.Wrap, width:100)
                           .Add(rootChild0 = Node(width:30, height:30))
                           .Add(rootChild1 = Node(width:30, height:30))
                           .Add(rootChild2 = Node(width:30, height:30))
                           .Add(rootChild3 = Node(width:30, height:30));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(60, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(30, rootChild0.Layout.Width);
            Assert.AreEqual(30, rootChild0.Layout.Height);

            Assert.AreEqual(30, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(30, rootChild1.Layout.Height);

            Assert.AreEqual(60, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(30, rootChild2.Layout.Width);
            Assert.AreEqual(30, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(30, rootChild3.Layout.Top);
            Assert.AreEqual(30, rootChild3.Layout.Width);
            Assert.AreEqual(30, rootChild3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(60, root.Layout.Height);

            Assert.AreEqual(70, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(30, rootChild0.Layout.Width);
            Assert.AreEqual(30, rootChild0.Layout.Height);

            Assert.AreEqual(40, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(30, rootChild1.Layout.Height);

            Assert.AreEqual(10, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(30, rootChild2.Layout.Width);
            Assert.AreEqual(30, rootChild2.Layout.Height);

            Assert.AreEqual(70, rootChild3.Layout.Left);
            Assert.AreEqual(30, rootChild3.Layout.Top);
            Assert.AreEqual(30, rootChild3.Layout.Width);
            Assert.AreEqual(30, rootChild3.Layout.Height);
        }

        [Test]
        public void wrap_row_align_items_flex_end()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignItems:YogaAlign.FlexEnd, flexWrap:Wrap.Wrap, width:100)
                           .Add(rootChild0 = Node(width:30, height:10))
                           .Add(rootChild1 = Node(width:30, height:20))
                           .Add(rootChild2 = Node(width:30, height:30))
                           .Add(rootChild3 = Node(width:30, height:30));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(60, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(20, rootChild0.Layout.Top);
            Assert.AreEqual(30, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(30, rootChild1.Layout.Left);
            Assert.AreEqual(10, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(60, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(30, rootChild2.Layout.Width);
            Assert.AreEqual(30, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(30, rootChild3.Layout.Top);
            Assert.AreEqual(30, rootChild3.Layout.Width);
            Assert.AreEqual(30, rootChild3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(60, root.Layout.Height);

            Assert.AreEqual(70, rootChild0.Layout.Left);
            Assert.AreEqual(20, rootChild0.Layout.Top);
            Assert.AreEqual(30, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(40, rootChild1.Layout.Left);
            Assert.AreEqual(10, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(10, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(30, rootChild2.Layout.Width);
            Assert.AreEqual(30, rootChild2.Layout.Height);

            Assert.AreEqual(70, rootChild3.Layout.Left);
            Assert.AreEqual(30, rootChild3.Layout.Top);
            Assert.AreEqual(30, rootChild3.Layout.Width);
            Assert.AreEqual(30, rootChild3.Layout.Height);
        }

        [Test]
        public void wrap_row_align_items_center()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignItems:YogaAlign.Center, flexWrap:Wrap.Wrap, width:100)
                           .Add(rootChild0 = Node(width:30, height:10))
                           .Add(rootChild1 = Node(width:30, height:20))
                           .Add(rootChild2 = Node(width:30, height:30))
                           .Add(rootChild3 = Node(width:30, height:30));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(60, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(30, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(30, rootChild1.Layout.Left);
            Assert.AreEqual(5, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(60, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(30, rootChild2.Layout.Width);
            Assert.AreEqual(30, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(30, rootChild3.Layout.Top);
            Assert.AreEqual(30, rootChild3.Layout.Width);
            Assert.AreEqual(30, rootChild3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(60, root.Layout.Height);

            Assert.AreEqual(70, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(30, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(40, rootChild1.Layout.Left);
            Assert.AreEqual(5, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(10, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(30, rootChild2.Layout.Width);
            Assert.AreEqual(30, rootChild2.Layout.Height);

            Assert.AreEqual(70, rootChild3.Layout.Left);
            Assert.AreEqual(30, rootChild3.Layout.Top);
            Assert.AreEqual(30, rootChild3.Layout.Width);
            Assert.AreEqual(30, rootChild3.Layout.Height);
        }

        [Test]
        public void flex_wrap_children_with_min_main_overriding_flex_basis()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(flexDirection:FlexDirection.Row, flexWrap:Wrap.Wrap, width:100)
                           .Add(rootChild0 = Node(flexBasis:50, minWidth:55, height:50))
                           .Add(rootChild1 = Node(flexBasis:50, minWidth:55, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(55, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(55, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(45, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(55, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(45, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(55, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void flex_wrap_wrap_to_child_height()
        {
            YogaNode rootChild0, rootChild1, rootChild0Child0, rootChild0Child0Child0;
            YogaNode root = Node()
                           .Add(
                                rootChild0 = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.FlexStart, flexWrap: Wrap.Wrap)
                                   .Add(
                                        rootChild0Child0 = Node(width:100)
                                           .Add(rootChild0Child0Child0 = Node(width:100, height:100))
                                    )
                            )
                           .Add(rootChild1 = Node(width: 100, height: 100));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(100, rootChild0Child0.Layout.Width);
            Assert.AreEqual(100, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(100, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(100, rootChild0Child0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(100, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(100, rootChild0Child0.Layout.Width);
            Assert.AreEqual(100, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(100, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(100, rootChild0Child0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(100, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);
        }

        [Ignore("Exactly the same result as the c++ library")]
        [Test]
        public void flex_wrap_align_stretch_fits_one_row()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(flexDirection:FlexDirection.Row, flexWrap:Wrap.Wrap, width:150, height:100)
                           .Add(rootChild0 = Node(width:50))
                           .Add(rootChild1 = Node(width:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);
        }

        [Test]
        public void wrap_reverse_row_align_content_flex_start()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, flexWrap:Wrap.WrapReverse, width:100)
                           .Add(rootChild0 = Node(width:30, height:10))
                           .Add(rootChild1 = Node(width:30, height:20))
                           .Add(rootChild2 = Node(width:30, height:30))
                           .Add(rootChild3 = Node(width:30, height:40))
                           .Add(rootChild4 = Node(width:30, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(70, rootChild0.Layout.Top);
            Assert.AreEqual(30, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(30, rootChild1.Layout.Left);
            Assert.AreEqual(60, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(60, rootChild2.Layout.Left);
            Assert.AreEqual(50, rootChild2.Layout.Top);
            Assert.AreEqual(30, rootChild2.Layout.Width);
            Assert.AreEqual(30, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(10, rootChild3.Layout.Top);
            Assert.AreEqual(30, rootChild3.Layout.Width);
            Assert.AreEqual(40, rootChild3.Layout.Height);

            Assert.AreEqual(30, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(30, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(70, rootChild0.Layout.Left);
            Assert.AreEqual(70, rootChild0.Layout.Top);
            Assert.AreEqual(30, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(40, rootChild1.Layout.Left);
            Assert.AreEqual(60, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(10, rootChild2.Layout.Left);
            Assert.AreEqual(50, rootChild2.Layout.Top);
            Assert.AreEqual(30, rootChild2.Layout.Width);
            Assert.AreEqual(30, rootChild2.Layout.Height);

            Assert.AreEqual(70, rootChild3.Layout.Left);
            Assert.AreEqual(10, rootChild3.Layout.Top);
            Assert.AreEqual(30, rootChild3.Layout.Width);
            Assert.AreEqual(40, rootChild3.Layout.Height);

            Assert.AreEqual(40, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(30, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);
        }

        [Test]
        public void wrap_reverse_row_align_content_center()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.Center, flexWrap:Wrap.WrapReverse, width:100)
                           .Add(rootChild0 = Node(width:30, height:10))
                           .Add(rootChild1 = Node(width:30, height:20))
                           .Add(rootChild2 = Node(width:30, height:30))
                           .Add(rootChild3 = Node(width:30, height:40))
                           .Add(rootChild4 = Node(width:30, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(70, rootChild0.Layout.Top);
            Assert.AreEqual(30, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(30, rootChild1.Layout.Left);
            Assert.AreEqual(60, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(60, rootChild2.Layout.Left);
            Assert.AreEqual(50, rootChild2.Layout.Top);
            Assert.AreEqual(30, rootChild2.Layout.Width);
            Assert.AreEqual(30, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(10, rootChild3.Layout.Top);
            Assert.AreEqual(30, rootChild3.Layout.Width);
            Assert.AreEqual(40, rootChild3.Layout.Height);

            Assert.AreEqual(30, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(30, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(70, rootChild0.Layout.Left);
            Assert.AreEqual(70, rootChild0.Layout.Top);
            Assert.AreEqual(30, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(40, rootChild1.Layout.Left);
            Assert.AreEqual(60, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(10, rootChild2.Layout.Left);
            Assert.AreEqual(50, rootChild2.Layout.Top);
            Assert.AreEqual(30, rootChild2.Layout.Width);
            Assert.AreEqual(30, rootChild2.Layout.Height);

            Assert.AreEqual(70, rootChild3.Layout.Left);
            Assert.AreEqual(10, rootChild3.Layout.Top);
            Assert.AreEqual(30, rootChild3.Layout.Width);
            Assert.AreEqual(40, rootChild3.Layout.Height);

            Assert.AreEqual(40, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(30, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);
        }

        [Test]
        public void wrap_reverse_row_single_line_different_size()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, flexWrap:Wrap.WrapReverse, width:300)
                           .Add(rootChild0 = Node(width:30, height:10))
                           .Add(rootChild1 = Node(width:30, height:20))
                           .Add(rootChild2 = Node(width:30, height:30))
                           .Add(rootChild3 = Node(width:30, height:40))
                           .Add(rootChild4 = Node(width:30, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(300, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(40, rootChild0.Layout.Top);
            Assert.AreEqual(30, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(30, rootChild1.Layout.Left);
            Assert.AreEqual(30, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(60, rootChild2.Layout.Left);
            Assert.AreEqual(20, rootChild2.Layout.Top);
            Assert.AreEqual(30, rootChild2.Layout.Width);
            Assert.AreEqual(30, rootChild2.Layout.Height);

            Assert.AreEqual(90, rootChild3.Layout.Left);
            Assert.AreEqual(10, rootChild3.Layout.Top);
            Assert.AreEqual(30, rootChild3.Layout.Width);
            Assert.AreEqual(40, rootChild3.Layout.Height);

            Assert.AreEqual(120, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(30, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(300, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(270, rootChild0.Layout.Left);
            Assert.AreEqual(40, rootChild0.Layout.Top);
            Assert.AreEqual(30, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(240, rootChild1.Layout.Left);
            Assert.AreEqual(30, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(210, rootChild2.Layout.Left);
            Assert.AreEqual(20, rootChild2.Layout.Top);
            Assert.AreEqual(30, rootChild2.Layout.Width);
            Assert.AreEqual(30, rootChild2.Layout.Height);

            Assert.AreEqual(180, rootChild3.Layout.Left);
            Assert.AreEqual(10, rootChild3.Layout.Top);
            Assert.AreEqual(30, rootChild3.Layout.Width);
            Assert.AreEqual(40, rootChild3.Layout.Height);

            Assert.AreEqual(150, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(30, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);
        }

        [Test]
        public void wrap_reverse_row_align_content_stretch()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.Stretch, flexWrap:Wrap.WrapReverse, width:100)
                           .Add(rootChild0 = Node(width:30, height:10))
                           .Add(rootChild1 = Node(width:30, height:20))
                           .Add(rootChild2 = Node(width:30, height:30))
                           .Add(rootChild3 = Node(width:30, height:40))
                           .Add(rootChild4 = Node(width:30, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(70, rootChild0.Layout.Top);
            Assert.AreEqual(30, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(30, rootChild1.Layout.Left);
            Assert.AreEqual(60, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(60, rootChild2.Layout.Left);
            Assert.AreEqual(50, rootChild2.Layout.Top);
            Assert.AreEqual(30, rootChild2.Layout.Width);
            Assert.AreEqual(30, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(10, rootChild3.Layout.Top);
            Assert.AreEqual(30, rootChild3.Layout.Width);
            Assert.AreEqual(40, rootChild3.Layout.Height);

            Assert.AreEqual(30, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(30, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(70, rootChild0.Layout.Left);
            Assert.AreEqual(70, rootChild0.Layout.Top);
            Assert.AreEqual(30, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(40, rootChild1.Layout.Left);
            Assert.AreEqual(60, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(10, rootChild2.Layout.Left);
            Assert.AreEqual(50, rootChild2.Layout.Top);
            Assert.AreEqual(30, rootChild2.Layout.Width);
            Assert.AreEqual(30, rootChild2.Layout.Height);

            Assert.AreEqual(70, rootChild3.Layout.Left);
            Assert.AreEqual(10, rootChild3.Layout.Top);
            Assert.AreEqual(30, rootChild3.Layout.Width);
            Assert.AreEqual(40, rootChild3.Layout.Height);

            Assert.AreEqual(40, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(30, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);
        }

        [Test]
        public void wrap_reverse_row_align_content_space_around()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.SpaceAround, flexWrap:Wrap.WrapReverse, width:100)
                           .Add(rootChild0 = Node(width:30, height:10))
                           .Add(rootChild1 = Node(width:30, height:20))
                           .Add(rootChild2 = Node(width:30, height:30))
                           .Add(rootChild3 = Node(width:30, height:40))
                           .Add(rootChild4 = Node(width:30, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(70, rootChild0.Layout.Top);
            Assert.AreEqual(30, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(30, rootChild1.Layout.Left);
            Assert.AreEqual(60, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(60, rootChild2.Layout.Left);
            Assert.AreEqual(50, rootChild2.Layout.Top);
            Assert.AreEqual(30, rootChild2.Layout.Width);
            Assert.AreEqual(30, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(10, rootChild3.Layout.Top);
            Assert.AreEqual(30, rootChild3.Layout.Width);
            Assert.AreEqual(40, rootChild3.Layout.Height);

            Assert.AreEqual(30, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(30, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(80, root.Layout.Height);

            Assert.AreEqual(70, rootChild0.Layout.Left);
            Assert.AreEqual(70, rootChild0.Layout.Top);
            Assert.AreEqual(30, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(40, rootChild1.Layout.Left);
            Assert.AreEqual(60, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(10, rootChild2.Layout.Left);
            Assert.AreEqual(50, rootChild2.Layout.Top);
            Assert.AreEqual(30, rootChild2.Layout.Width);
            Assert.AreEqual(30, rootChild2.Layout.Height);

            Assert.AreEqual(70, rootChild3.Layout.Left);
            Assert.AreEqual(10, rootChild3.Layout.Top);
            Assert.AreEqual(30, rootChild3.Layout.Width);
            Assert.AreEqual(40, rootChild3.Layout.Height);

            Assert.AreEqual(40, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(30, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);
        }

        [Test]
        public void wrap_reverse_column_fixed_size()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(alignItems:YogaAlign.Center, flexWrap:Wrap.WrapReverse, width:200, height:100)
                           .Add(rootChild0 = Node(width:30, height:10))
                           .Add(rootChild1 = Node(width:30, height:20))
                           .Add(rootChild2 = Node(width:30, height:30))
                           .Add(rootChild3 = Node(width:30, height:40))
                           .Add(rootChild4 = Node(width:30, height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(170, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(30, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(170, rootChild1.Layout.Left);
            Assert.AreEqual(10, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(170, rootChild2.Layout.Left);
            Assert.AreEqual(30, rootChild2.Layout.Top);
            Assert.AreEqual(30, rootChild2.Layout.Width);
            Assert.AreEqual(30, rootChild2.Layout.Height);

            Assert.AreEqual(170, rootChild3.Layout.Left);
            Assert.AreEqual(60, rootChild3.Layout.Top);
            Assert.AreEqual(30, rootChild3.Layout.Width);
            Assert.AreEqual(40, rootChild3.Layout.Height);

            Assert.AreEqual(140, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(30, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(30, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(10, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(30, rootChild2.Layout.Top);
            Assert.AreEqual(30, rootChild2.Layout.Width);
            Assert.AreEqual(30, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(60, rootChild3.Layout.Top);
            Assert.AreEqual(30, rootChild3.Layout.Width);
            Assert.AreEqual(40, rootChild3.Layout.Height);

            Assert.AreEqual(30, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(30, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);
        }

        [Test]
        public void wrapped_row_within_align_items_center()
        {
            YogaNode rootChild0, rootChild0Child0, rootChild0Child1;
            YogaNode root = Node(alignItems: YogaAlign.Center, width: 200, height: 200)
                           .Add(
                                rootChild0 = Node(flexDirection: FlexDirection.Row, flexWrap: Wrap.Wrap)
                                             .Add(rootChild0Child0 = Node(width: 150, height: 80))
                                             .Add(rootChild0Child1 = Node(width: 80, height:80))
                            );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(200, rootChild0.Layout.Width);
            Assert.AreEqual(160, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(150, rootChild0Child0.Layout.Width);
            Assert.AreEqual(80, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child1.Layout.Left);
            Assert.AreEqual(80, rootChild0Child1.Layout.Top);
            Assert.AreEqual(80, rootChild0Child1.Layout.Width);
            Assert.AreEqual(80, rootChild0Child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(200, rootChild0.Layout.Width);
            Assert.AreEqual(160, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(150, rootChild0Child0.Layout.Width);
            Assert.AreEqual(80, rootChild0Child0.Layout.Height);

            Assert.AreEqual(120, rootChild0Child1.Layout.Left);
            Assert.AreEqual(80, rootChild0Child1.Layout.Top);
            Assert.AreEqual(80, rootChild0Child1.Layout.Width);
            Assert.AreEqual(80, rootChild0Child1.Layout.Height);
        }

        [Test]
        public void wrapped_row_within_align_items_flex_start()
        {
            YogaNode rootChild0, rootChild0Child0, rootChild0Child1;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 200, height: 200)
               .Add(
                    rootChild0 = Node(flexDirection: FlexDirection.Row, flexWrap: Wrap.Wrap)
                                 .Add(rootChild0Child0 = Node(width:150, height:80))
                                 .Add(rootChild0Child1 = Node(width:80, height:80))
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(200, rootChild0.Layout.Width);
            Assert.AreEqual(160, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(150, rootChild0Child0.Layout.Width);
            Assert.AreEqual(80, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child1.Layout.Left);
            Assert.AreEqual(80, rootChild0Child1.Layout.Top);
            Assert.AreEqual(80, rootChild0Child1.Layout.Width);
            Assert.AreEqual(80, rootChild0Child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(200, rootChild0.Layout.Width);
            Assert.AreEqual(160, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(150, rootChild0Child0.Layout.Width);
            Assert.AreEqual(80, rootChild0Child0.Layout.Height);

            Assert.AreEqual(120, rootChild0Child1.Layout.Left);
            Assert.AreEqual(80, rootChild0Child1.Layout.Top);
            Assert.AreEqual(80, rootChild0Child1.Layout.Width);
            Assert.AreEqual(80, rootChild0Child1.Layout.Height);
        }

        [Test]
        public void wrapped_row_within_align_items_flex_end()
        {
            YogaNode rootChild0, rootChild0Child0, rootChild0Child1;
            YogaNode root = Node(alignItems: YogaAlign.FlexEnd, width: 200, height: 200)
               .Add(
                    rootChild0 = Node(flexDirection: FlexDirection.Row, flexWrap: Wrap.Wrap)
                                 .Add(rootChild0Child0 = Node(width:150, height:80))
                                 .Add(rootChild0Child1 = Node(width:80, height:80))
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(200, rootChild0.Layout.Width);
            Assert.AreEqual(160, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(150, rootChild0Child0.Layout.Width);
            Assert.AreEqual(80, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child1.Layout.Left);
            Assert.AreEqual(80, rootChild0Child1.Layout.Top);
            Assert.AreEqual(80, rootChild0Child1.Layout.Width);
            Assert.AreEqual(80, rootChild0Child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(200, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(200, rootChild0.Layout.Width);
            Assert.AreEqual(160, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(150, rootChild0Child0.Layout.Width);
            Assert.AreEqual(80, rootChild0Child0.Layout.Height);

            Assert.AreEqual(120, rootChild0Child1.Layout.Left);
            Assert.AreEqual(80, rootChild0Child1.Layout.Top);
            Assert.AreEqual(80, rootChild0Child1.Layout.Width);
            Assert.AreEqual(80, rootChild0Child1.Layout.Height);
        }

        [Test]
        public void wrapped_column_max_height()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(justifyContent: Justify.Center, alignContent: YogaAlign.Center, alignItems: YogaAlign.Center, flexWrap: Wrap.Wrap, width: 700, height: 500)
                           .Add(rootChild0 = Node(width: 100, height: 500, maxHeight: 200))
                           .Add(rootChild1 = Node(width: 200, height: 200, margin:new Edges(left:20, top:20, right:20, bottom:20)))
                           .Add(rootChild2 = Node(width: 100, height: 100));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(700, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(250, rootChild0.Layout.Left);
            Assert.AreEqual(30, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(200, rootChild0.Layout.Height);

            Assert.AreEqual(200, rootChild1.Layout.Left);
            Assert.AreEqual(250, rootChild1.Layout.Top);
            Assert.AreEqual(200, rootChild1.Layout.Width);
            Assert.AreEqual(200, rootChild1.Layout.Height);

            Assert.AreEqual(420, rootChild2.Layout.Left);
            Assert.AreEqual(200, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(700, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(350, rootChild0.Layout.Left);
            Assert.AreEqual(30, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(200, rootChild0.Layout.Height);

            Assert.AreEqual(300, rootChild1.Layout.Left);
            Assert.AreEqual(250, rootChild1.Layout.Top);
            Assert.AreEqual(200, rootChild1.Layout.Width);
            Assert.AreEqual(200, rootChild1.Layout.Height);

            Assert.AreEqual(180, rootChild2.Layout.Left);
            Assert.AreEqual(200, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);
        }

        [Test]
        public void wrapped_column_max_height_flex()
        {
            
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(justifyContent: Justify.Center, alignContent: YogaAlign.Center, alignItems: YogaAlign.Center, flexWrap: Wrap.Wrap, width: 700, height: 500)
                           .Add(rootChild0 = Node(flexGrow:1, flexShrink:1, flexBasis:0.Percent(), width: 100, height: 150, maxHeight: 200))
                           .Add(rootChild1 = Node(flexGrow:1, flexShrink:1, flexBasis:0.Percent(), margin:new Edges(left:20, top:20, right:20, bottom:20), width: 200, height: 200))
                           .Add(rootChild2 = Node(width: 100, height: 100));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(700, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(300, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(180, rootChild0.Layout.Height);

            Assert.AreEqual(250, rootChild1.Layout.Left);
            Assert.AreEqual(200, rootChild1.Layout.Top);
            Assert.AreEqual(200, rootChild1.Layout.Width);
            Assert.AreEqual(180, rootChild1.Layout.Height);

            Assert.AreEqual(300, rootChild2.Layout.Left);
            Assert.AreEqual(400, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(700, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(300, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(180, rootChild0.Layout.Height);

            Assert.AreEqual(250, rootChild1.Layout.Left);
            Assert.AreEqual(200, rootChild1.Layout.Top);
            Assert.AreEqual(200, rootChild1.Layout.Width);
            Assert.AreEqual(180, rootChild1.Layout.Height);

            Assert.AreEqual(300, rootChild2.Layout.Left);
            Assert.AreEqual(400, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);
        }

        [Test]
        public void wrap_nodes_with_content_sizing_overflowing_margin()
        {
            YogaNode rootChild0, rootChild0Child0, rootChild0Child0Child0, rootChild0Child1, rootChild0Child1Child0;
            YogaNode root = Node(width: 500, height: 500)
               .Add(
                    rootChild0 = Node(flexDirection:FlexDirection.Row, flexWrap:Wrap.Wrap, width:85)
                                 .Add(
                                      rootChild0Child0 = Node()
                                         .Add(rootChild0Child0Child0 = Node(width:40, height:40))
                                  )
                                 .Add(
                                      rootChild0Child1 = Node(margin:new Edges(right:10))
                                         .Add(rootChild0Child1Child0 = Node(width:40, height:40))
                                  )
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(85, rootChild0.Layout.Width);
            Assert.AreEqual(80, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(40, rootChild0Child0.Layout.Width);
            Assert.AreEqual(40, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(40, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(40, rootChild0Child0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child1.Layout.Left);
            Assert.AreEqual(40, rootChild0Child1.Layout.Top);
            Assert.AreEqual(40, rootChild0Child1.Layout.Width);
            Assert.AreEqual(40, rootChild0Child1.Layout.Height);

            Assert.AreEqual(0, rootChild0Child1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child1Child0.Layout.Top);
            Assert.AreEqual(40, rootChild0Child1Child0.Layout.Width);
            Assert.AreEqual(40, rootChild0Child1Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(415, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(85, rootChild0.Layout.Width);
            Assert.AreEqual(80, rootChild0.Layout.Height);

            Assert.AreEqual(45, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(40, rootChild0Child0.Layout.Width);
            Assert.AreEqual(40, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(40, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(40, rootChild0Child0Child0.Layout.Height);

            Assert.AreEqual(35, rootChild0Child1.Layout.Left);
            Assert.AreEqual(40, rootChild0Child1.Layout.Top);
            Assert.AreEqual(40, rootChild0Child1.Layout.Width);
            Assert.AreEqual(40, rootChild0Child1.Layout.Height);

            Assert.AreEqual(0, rootChild0Child1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child1Child0.Layout.Top);
            Assert.AreEqual(40, rootChild0Child1Child0.Layout.Width);
            Assert.AreEqual(40, rootChild0Child1Child0.Layout.Height);
        }

        [Test]
        public void wrap_nodes_with_content_sizing_margin_cross()
        {
            YogaNode rootChild0, rootChild0Child0, rootChild0Child0Child0, rootChild0Child1, rootChild0Child1Child0;
            YogaNode root = Node(width: 500, height: 500)
               .Add(
                    rootChild0 = Node(flexDirection:FlexDirection.Row, flexWrap:Wrap.Wrap, width:70)
                                 .Add(
                                      rootChild0Child0 = Node()
                                         .Add(rootChild0Child0Child0 = Node(width:40, height:40))
                                  )
                                 .Add(
                                      rootChild0Child1 = Node(margin:new Edges(top:10))
                                         .Add(rootChild0Child1Child0 = Node(width:40, height:40))
                                  )
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(70, rootChild0.Layout.Width);
            Assert.AreEqual(90, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(40, rootChild0Child0.Layout.Width);
            Assert.AreEqual(40, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(40, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(40, rootChild0Child0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child1.Layout.Left);
            Assert.AreEqual(50, rootChild0Child1.Layout.Top);
            Assert.AreEqual(40, rootChild0Child1.Layout.Width);
            Assert.AreEqual(40, rootChild0Child1.Layout.Height);

            Assert.AreEqual(0, rootChild0Child1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child1Child0.Layout.Top);
            Assert.AreEqual(40, rootChild0Child1Child0.Layout.Width);
            Assert.AreEqual(40, rootChild0Child1Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(430, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(70, rootChild0.Layout.Width);
            Assert.AreEqual(90, rootChild0.Layout.Height);

            Assert.AreEqual(30, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(40, rootChild0Child0.Layout.Width);
            Assert.AreEqual(40, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(40, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(40, rootChild0Child0Child0.Layout.Height);

            Assert.AreEqual(30, rootChild0Child1.Layout.Left);
            Assert.AreEqual(50, rootChild0Child1.Layout.Top);
            Assert.AreEqual(40, rootChild0Child1.Layout.Width);
            Assert.AreEqual(40, rootChild0Child1.Layout.Height);

            Assert.AreEqual(0, rootChild0Child1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child1Child0.Layout.Top);
            Assert.AreEqual(40, rootChild0Child1Child0.Layout.Width);
            Assert.AreEqual(40, rootChild0Child1Child0.Layout.Height);
        }
    }
}
