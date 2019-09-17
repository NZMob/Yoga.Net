using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaAlignItemsTest
    {
        [Test]
        public void align_items_stretch()
        {
            YogaNode rootChild0;
            YogaNode root = Node(width: 100, height: 100)
               .Add(rootChild0 = Node(height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);
        }

        [Test]
        public void align_items_center()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems:YogaAlign.Center, width: 100, height: 100)
               .Add(rootChild0 = Node(width:10, height:10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(45, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(45, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);
        }

        [Test]
        public void align_items_flex_start()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems:YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(width:10, height:10));
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(90, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);
        }

        [Test]
        public void align_items_flex_end()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems:YogaAlign.FlexEnd, width: 100, height: 100)
               .Add(rootChild0 = Node(width:10, height:10));
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(90, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);
        }

        [Test]
        public void align_baseline()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(rootChild0 = Node(width: 50, height: 50))
                           .Add(rootChild1 = Node(width: 50, height: 20));
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(30, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(30, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);
        }

        [Test]
        public void align_baseline_child()
        {
            YogaNode rootChild0, rootChild1, rootChild1Child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(rootChild0 = Node(width: 50, height: 50))
                           .Add(
                                rootChild1 = Node(width: 50, height: 20)
                                   .Add(rootChild1Child0 = Node(width: 50, height: 10))
                            );
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(40, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(50, rootChild1Child0.Layout.Width);
            Assert.AreEqual(10, rootChild1Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(40, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(50, rootChild1Child0.Layout.Width);
            Assert.AreEqual(10, rootChild1Child0.Layout.Height);
        }

        [Test]
        public void align_baseline_child_multiline()
        {
            YogaNode rootChild0, rootChild1, rootChild1Child0, rootChild1Child1, rootChild1Child2, rootChild1Child3;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(rootChild0 = Node(width: 50, height: 60))
                           .Add(
                                rootChild1 = Node(flexDirection: FlexDirection.Row, flexWrap: Wrap.Wrap, width: 50, height: 25)
                                             .Add(rootChild1Child0 = Node(width:25, height:20))
                                             .Add(rootChild1Child1 = Node(width:25, height:10))
                                             .Add(rootChild1Child2 = Node(width:25, height:20))
                                             .Add(rootChild1Child3 = Node(width:25, height:10))
                            );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(60, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(40, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(25, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(25, rootChild1Child0.Layout.Width);
            Assert.AreEqual(20, rootChild1Child0.Layout.Height);

            Assert.AreEqual(25, rootChild1Child1.Layout.Left);
            Assert.AreEqual(0, rootChild1Child1.Layout.Top);
            Assert.AreEqual(25, rootChild1Child1.Layout.Width);
            Assert.AreEqual(10, rootChild1Child1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child2.Layout.Left);
            Assert.AreEqual(20, rootChild1Child2.Layout.Top);
            Assert.AreEqual(25, rootChild1Child2.Layout.Width);
            Assert.AreEqual(20, rootChild1Child2.Layout.Height);

            Assert.AreEqual(25, rootChild1Child3.Layout.Left);
            Assert.AreEqual(20, rootChild1Child3.Layout.Top);
            Assert.AreEqual(25, rootChild1Child3.Layout.Width);
            Assert.AreEqual(10, rootChild1Child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(60, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(40, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(25, rootChild1.Layout.Height);

            Assert.AreEqual(25, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(25, rootChild1Child0.Layout.Width);
            Assert.AreEqual(20, rootChild1Child0.Layout.Height);

            Assert.AreEqual(0, rootChild1Child1.Layout.Left);
            Assert.AreEqual(0, rootChild1Child1.Layout.Top);
            Assert.AreEqual(25, rootChild1Child1.Layout.Width);
            Assert.AreEqual(10, rootChild1Child1.Layout.Height);

            Assert.AreEqual(25, rootChild1Child2.Layout.Left);
            Assert.AreEqual(20, rootChild1Child2.Layout.Top);
            Assert.AreEqual(25, rootChild1Child2.Layout.Width);
            Assert.AreEqual(20, rootChild1Child2.Layout.Height);

            Assert.AreEqual(0, rootChild1Child3.Layout.Left);
            Assert.AreEqual(20, rootChild1Child3.Layout.Top);
            Assert.AreEqual(25, rootChild1Child3.Layout.Width);
            Assert.AreEqual(10, rootChild1Child3.Layout.Height);
        }

        [Test]
        public void align_baseline_child_multiline_override()
        {
            YogaNode rootChild0, rootChild1, rootChild1Child0, rootChild1Child1, rootChild1Child2, rootChild1Child3;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(rootChild0 = Node(width: 50, height: 60))
                           .Add(
                                rootChild1 = Node(flexDirection: FlexDirection.Row, flexWrap: Wrap.Wrap, width: 50, height: 25)
                                             .Add(rootChild1Child0 = Node(width:25, height:20))
                                             .Add(rootChild1Child1 = Node( alignSelf:YogaAlign.Baseline, width:25, height:10))
                                             .Add(rootChild1Child2 = Node(width:25, height:20))
                                             .Add(rootChild1Child3 = Node(alignSelf:YogaAlign.Baseline, width:25, height:10))
                            );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(60, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(25, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(25, rootChild1Child0.Layout.Width);
            Assert.AreEqual(20, rootChild1Child0.Layout.Height);

            Assert.AreEqual(25, rootChild1Child1.Layout.Left);
            Assert.AreEqual(0, rootChild1Child1.Layout.Top);
            Assert.AreEqual(25, rootChild1Child1.Layout.Width);
            Assert.AreEqual(10, rootChild1Child1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child2.Layout.Left);
            Assert.AreEqual(20, rootChild1Child2.Layout.Top);
            Assert.AreEqual(25, rootChild1Child2.Layout.Width);
            Assert.AreEqual(20, rootChild1Child2.Layout.Height);

            Assert.AreEqual(25, rootChild1Child3.Layout.Left);
            Assert.AreEqual(20, rootChild1Child3.Layout.Top);
            Assert.AreEqual(25, rootChild1Child3.Layout.Width);
            Assert.AreEqual(10, rootChild1Child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(60, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(25, rootChild1.Layout.Height);

            Assert.AreEqual(25, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(25, rootChild1Child0.Layout.Width);
            Assert.AreEqual(20, rootChild1Child0.Layout.Height);

            Assert.AreEqual(0, rootChild1Child1.Layout.Left);
            Assert.AreEqual(0, rootChild1Child1.Layout.Top);
            Assert.AreEqual(25, rootChild1Child1.Layout.Width);
            Assert.AreEqual(10, rootChild1Child1.Layout.Height);

            Assert.AreEqual(25, rootChild1Child2.Layout.Left);
            Assert.AreEqual(20, rootChild1Child2.Layout.Top);
            Assert.AreEqual(25, rootChild1Child2.Layout.Width);
            Assert.AreEqual(20, rootChild1Child2.Layout.Height);

            Assert.AreEqual(0, rootChild1Child3.Layout.Left);
            Assert.AreEqual(20, rootChild1Child3.Layout.Top);
            Assert.AreEqual(25, rootChild1Child3.Layout.Width);
            Assert.AreEqual(10, rootChild1Child3.Layout.Height);
        }

        [Test]
        public void align_baseline_child_multiline_no_override_on_second_line()
        {
            YogaNode rootChild0, rootChild1, rootChild1Child0, rootChild1Child1, rootChild1Child2, rootChild1Child3;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(rootChild0 = Node(width: 50, height: 60))
                           .Add(
                                rootChild1 = Node(flexDirection: FlexDirection.Row, flexWrap: Wrap.Wrap, width: 50, height: 25)
                                             .Add(rootChild1Child0 = Node(width:25, height:20))
                                             .Add(rootChild1Child1 = Node(width:25, height:10))
                                             .Add(rootChild1Child2 = Node(width:25, height:20))
                                             .Add(rootChild1Child3 = Node(alignSelf:YogaAlign.Baseline,width:25, height:10))
                            );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(60, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(40, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(25, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(25, rootChild1Child0.Layout.Width);
            Assert.AreEqual(20, rootChild1Child0.Layout.Height);

            Assert.AreEqual(25, rootChild1Child1.Layout.Left);
            Assert.AreEqual(0, rootChild1Child1.Layout.Top);
            Assert.AreEqual(25, rootChild1Child1.Layout.Width);
            Assert.AreEqual(10, rootChild1Child1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child2.Layout.Left);
            Assert.AreEqual(20, rootChild1Child2.Layout.Top);
            Assert.AreEqual(25, rootChild1Child2.Layout.Width);
            Assert.AreEqual(20, rootChild1Child2.Layout.Height);

            Assert.AreEqual(25, rootChild1Child3.Layout.Left);
            Assert.AreEqual(20, rootChild1Child3.Layout.Top);
            Assert.AreEqual(25, rootChild1Child3.Layout.Width);
            Assert.AreEqual(10, rootChild1Child3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(60, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(40, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(25, rootChild1.Layout.Height);

            Assert.AreEqual(25, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(25, rootChild1Child0.Layout.Width);
            Assert.AreEqual(20, rootChild1Child0.Layout.Height);

            Assert.AreEqual(0, rootChild1Child1.Layout.Left);
            Assert.AreEqual(0, rootChild1Child1.Layout.Top);
            Assert.AreEqual(25, rootChild1Child1.Layout.Width);
            Assert.AreEqual(10, rootChild1Child1.Layout.Height);

            Assert.AreEqual(25, rootChild1Child2.Layout.Left);
            Assert.AreEqual(20, rootChild1Child2.Layout.Top);
            Assert.AreEqual(25, rootChild1Child2.Layout.Width);
            Assert.AreEqual(20, rootChild1Child2.Layout.Height);

            Assert.AreEqual(0, rootChild1Child3.Layout.Left);
            Assert.AreEqual(20, rootChild1Child3.Layout.Top);
            Assert.AreEqual(25, rootChild1Child3.Layout.Width);
            Assert.AreEqual(10, rootChild1Child3.Layout.Height);
        }

        [Test]
        public void align_baseline_child_top()
        {
            YogaNode rootChild0, rootChild1, rootChild1Child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(rootChild0 = Node(width: 50, height: 50, top:10))
                           .Add(
                                rootChild1 = Node(width: 50, height: 20)
                                             .Add(rootChild1Child0 = Node(width:50, height:10))
                            );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(40, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(50, rootChild1Child0.Layout.Width);
            Assert.AreEqual(10, rootChild1Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(40, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(50, rootChild1Child0.Layout.Width);
            Assert.AreEqual(10, rootChild1Child0.Layout.Height);
        }

        [Test]
        public void align_baseline_child_top2()
        {
            YogaNode rootChild0, rootChild1, rootChild1Child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(rootChild0 = Node(width: 50, height: 50))
                           .Add(
                                rootChild1 = Node(top:5, width: 50, height: 20)
                                             .Add(rootChild1Child0 = Node(width:50, height:10))
                            );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(45, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(50, rootChild1Child0.Layout.Width);
            Assert.AreEqual(10, rootChild1Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(45, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(50, rootChild1Child0.Layout.Width);
            Assert.AreEqual(10, rootChild1Child0.Layout.Height);
        }

        [Test]
        public void align_baseline_double_nested_child()
        {
            YogaNode rootChild0, rootChild0Child0, rootChild1, rootChild1Child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(rootChild0 = Node(width: 50, height: 50)
                               .Add(rootChild0Child0 = Node(width:50, height:20))
                            )
                           .Add(
                                rootChild1 = Node(width: 50, height: 20)
                                   .Add(rootChild1Child0 = Node(width:50, height:15))
                            );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(50, rootChild0Child0.Layout.Width);
            Assert.AreEqual(20, rootChild0Child0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(5, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(50, rootChild1Child0.Layout.Width);
            Assert.AreEqual(15, rootChild1Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(50, rootChild0Child0.Layout.Width);
            Assert.AreEqual(20, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(5, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(50, rootChild1Child0.Layout.Width);
            Assert.AreEqual(15, rootChild1Child0.Layout.Height);
        }

        [Test]
        public void align_baseline_column()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(rootChild0 = Node(width: 50, height: 50))
                           .Add(rootChild1 = Node(width: 50, height: 20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);
        }

        [Test]
        public void align_baseline_child_margin()
        {
            YogaNode rootChild0, rootChild1, rootChild1Child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(rootChild0 = Node(width: 50, height: 50, margin:new Edges(left:5, top:5, right:5, bottom:5)))
                           .Add(rootChild1 = Node(width: 50, height: 20)
                                   .Add(rootChild1Child0 = Node(width:50, height:10, margin:new Edges(left:1, top:1, right:1, bottom:1)))
                            );
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(5, rootChild0.Layout.Left);
            Assert.AreEqual(5, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(60, rootChild1.Layout.Left);
            Assert.AreEqual(44, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(1, rootChild1Child0.Layout.Left);
            Assert.AreEqual(1, rootChild1Child0.Layout.Top);
            Assert.AreEqual(50, rootChild1Child0.Layout.Width);
            Assert.AreEqual(10, rootChild1Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(45, rootChild0.Layout.Left);
            Assert.AreEqual(5, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(-10, rootChild1.Layout.Left);
            Assert.AreEqual(44, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(-1, rootChild1Child0.Layout.Left);
            Assert.AreEqual(1, rootChild1Child0.Layout.Top);
            Assert.AreEqual(50, rootChild1Child0.Layout.Width);
            Assert.AreEqual(10, rootChild1Child0.Layout.Height);
        }

        [Test]
        public void align_baseline_child_padding()
        {
            YogaNode rootChild0, rootChild1, rootChild1Child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100, padding:new Edges(5))
                           .Add(rootChild0 = Node(width: 50, height: 50))
                           .Add(rootChild1 = Node(width: 50, height: 20, padding:new Edges(5))
                               .Add(rootChild1Child0 = Node(width:50, height:10))
                            );
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(5, rootChild0.Layout.Left);
            Assert.AreEqual(5, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(55, rootChild1.Layout.Left);
            Assert.AreEqual(40, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(5, rootChild1Child0.Layout.Left);
            Assert.AreEqual(5, rootChild1Child0.Layout.Top);
            Assert.AreEqual(50, rootChild1Child0.Layout.Width);
            Assert.AreEqual(10, rootChild1Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(45, rootChild0.Layout.Left);
            Assert.AreEqual(5, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(-5, rootChild1.Layout.Left);
            Assert.AreEqual(40, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(-5, rootChild1Child0.Layout.Left);
            Assert.AreEqual(5, rootChild1Child0.Layout.Top);
            Assert.AreEqual(50, rootChild1Child0.Layout.Width);
            Assert.AreEqual(10, rootChild1Child0.Layout.Height);
        }

        [Test]
        public void align_baseline_multiline()
        {
            YogaNode rootChild0, rootChild1, rootChild1Child0, rootChild2, rootChild2Child0, rootChild3;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, flexWrap:Wrap.Wrap, width: 100, height: 100)
                           .Add(rootChild0 = Node(width: 50, height: 50))
                           .Add(rootChild1 = Node(width: 50, height: 20)
                               .Add(rootChild1Child0 = Node(width:50, height:10))
                            )
                           .Add(rootChild2 = Node(width:50, height:20)
                               .Add(rootChild2Child0 = Node(width:50, height:10))
                            )
                           .Add(rootChild3 = Node(width:50, height:50));
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(40, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(50, rootChild1Child0.Layout.Width);
            Assert.AreEqual(10, rootChild1Child0.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(100, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(20, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild2Child0.Layout.Left);
            Assert.AreEqual(0, rootChild2Child0.Layout.Top);
            Assert.AreEqual(50, rootChild2Child0.Layout.Width);
            Assert.AreEqual(10, rootChild2Child0.Layout.Height);

            Assert.AreEqual(50, rootChild3.Layout.Left);
            Assert.AreEqual(60, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(50, rootChild3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(40, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(50, rootChild1Child0.Layout.Width);
            Assert.AreEqual(10, rootChild1Child0.Layout.Height);

            Assert.AreEqual(50, rootChild2.Layout.Left);
            Assert.AreEqual(100, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(20, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild2Child0.Layout.Left);
            Assert.AreEqual(0, rootChild2Child0.Layout.Top);
            Assert.AreEqual(50, rootChild2Child0.Layout.Width);
            Assert.AreEqual(10, rootChild2Child0.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(60, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(50, rootChild3.Layout.Height);
        }

        [Test]
        public void align_baseline_multiline_column()
        {
            YogaNode rootChild0, rootChild1, rootChild1Child0, rootChild2, rootChild2Child0, rootChild3;
            YogaNode root = Node(alignItems: YogaAlign.Baseline, flexWrap:Wrap.Wrap, width: 100, height: 100)
                           .Add(rootChild0 = Node(width: 50, height: 50))
                           .Add(rootChild1 = Node(width: 30, height: 50)
                               .Add(rootChild1Child0 = Node(width:20, height:20))
                            )
                           .Add(rootChild2 = Node(width:40, height:70)
                               .Add(rootChild2Child0 = Node(width:10, height:10))
                            )
                           .Add(rootChild3 = Node(width:50, height:20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(20, rootChild1Child0.Layout.Width);
            Assert.AreEqual(20, rootChild1Child0.Layout.Height);

            Assert.AreEqual(50, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(40, rootChild2.Layout.Width);
            Assert.AreEqual(70, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild2Child0.Layout.Left);
            Assert.AreEqual(0, rootChild2Child0.Layout.Top);
            Assert.AreEqual(10, rootChild2Child0.Layout.Width);
            Assert.AreEqual(10, rootChild2Child0.Layout.Height);

            Assert.AreEqual(50, rootChild3.Layout.Left);
            Assert.AreEqual(70, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(20, rootChild3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(70, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            Assert.AreEqual(10, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(20, rootChild1Child0.Layout.Width);
            Assert.AreEqual(20, rootChild1Child0.Layout.Height);

            Assert.AreEqual(10, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(40, rootChild2.Layout.Width);
            Assert.AreEqual(70, rootChild2.Layout.Height);

            Assert.AreEqual(30, rootChild2Child0.Layout.Left);
            Assert.AreEqual(0, rootChild2Child0.Layout.Top);
            Assert.AreEqual(10, rootChild2Child0.Layout.Width);
            Assert.AreEqual(10, rootChild2Child0.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(70, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(20, rootChild3.Layout.Height);
        }

        [Test]
        public void align_baseline_multiline_column2()
        {
            YogaNode rootChild0, rootChild1, rootChild1Child0, rootChild2, rootChild2Child0, rootChild3;
            YogaNode root = Node(alignItems: YogaAlign.Baseline, flexWrap:Wrap.Wrap, width: 100, height: 100)
                           .Add(rootChild0 = Node(width: 50, height: 50))
                           .Add(rootChild1 = Node(width: 30, height: 50)
                               .Add(rootChild1Child0 = Node(width:20, height:20))
                            )
                           .Add(rootChild2 = Node(width:40, height:70)
                               .Add(rootChild2Child0 = Node(width:10, height:10))
                            )
                           .Add(rootChild3 = Node(width:50, height:20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(20, rootChild1Child0.Layout.Width);
            Assert.AreEqual(20, rootChild1Child0.Layout.Height);

            Assert.AreEqual(50, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(40, rootChild2.Layout.Width);
            Assert.AreEqual(70, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild2Child0.Layout.Left);
            Assert.AreEqual(0, rootChild2Child0.Layout.Top);
            Assert.AreEqual(10, rootChild2Child0.Layout.Width);
            Assert.AreEqual(10, rootChild2Child0.Layout.Height);

            Assert.AreEqual(50, rootChild3.Layout.Left);
            Assert.AreEqual(70, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(20, rootChild3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(70, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(30, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            Assert.AreEqual(10, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(20, rootChild1Child0.Layout.Width);
            Assert.AreEqual(20, rootChild1Child0.Layout.Height);

            Assert.AreEqual(10, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(40, rootChild2.Layout.Width);
            Assert.AreEqual(70, rootChild2.Layout.Height);

            Assert.AreEqual(30, rootChild2Child0.Layout.Left);
            Assert.AreEqual(0, rootChild2Child0.Layout.Top);
            Assert.AreEqual(10, rootChild2Child0.Layout.Width);
            Assert.AreEqual(10, rootChild2Child0.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(70, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(20, rootChild3.Layout.Height);
        }

        [Test]
        public void align_baseline_multiline_row_and_column()
        {
            YogaNode rootChild0, rootChild1, rootChild1Child0, rootChild2, rootChild2Child0, rootChild3;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignItems: YogaAlign.Baseline, flexWrap:Wrap.Wrap, width: 100, height: 100)
                           .Add(rootChild0 = Node(width: 50, height: 50))
                           .Add(rootChild1 = Node(width: 50, height: 50)
                               .Add(rootChild1Child0 = Node(width:50, height:10))
                            )
                           .Add(rootChild2 = Node(width:50, height:20)
                               .Add(rootChild2Child0 = Node(width:50, height:10))
                            )
                           .Add(rootChild3 = Node(width:50, height:20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(40, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(50, rootChild1Child0.Layout.Width);
            Assert.AreEqual(10, rootChild1Child0.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(100, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(20, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild2Child0.Layout.Left);
            Assert.AreEqual(0, rootChild2Child0.Layout.Top);
            Assert.AreEqual(50, rootChild2Child0.Layout.Width);
            Assert.AreEqual(10, rootChild2Child0.Layout.Height);

            Assert.AreEqual(50, rootChild3.Layout.Left);
            Assert.AreEqual(90, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(20, rootChild3.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(40, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(50, rootChild1Child0.Layout.Width);
            Assert.AreEqual(10, rootChild1Child0.Layout.Height);

            Assert.AreEqual(50, rootChild2.Layout.Left);
            Assert.AreEqual(100, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(20, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild2Child0.Layout.Left);
            Assert.AreEqual(0, rootChild2Child0.Layout.Top);
            Assert.AreEqual(50, rootChild2Child0.Layout.Width);
            Assert.AreEqual(10, rootChild2Child0.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(90, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(20, rootChild3.Layout.Height);
        }

        [Test]
        public void align_items_center_child_with_margin_bigger_than_parent()
        {
            YogaNode rootChild0, rootChild0Child0;
            YogaNode root = Node(justifyContent:Justify.Center, alignItems:YogaAlign.Center, width: 52, height: 52)
                           .Add(rootChild0 = Node(alignItems:YogaAlign.Center)
                               .Add(rootChild0Child0 = Node(width:52, height:52, margin:new Edges(left:10, right:10)))
                            );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(72, rootChild0.Layout.Width);
            Assert.AreEqual(52, rootChild0.Layout.Height);

            Assert.AreEqual(10, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(52, rootChild0Child0.Layout.Width);
            Assert.AreEqual(52, rootChild0Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(72, rootChild0.Layout.Width);
            Assert.AreEqual(52, rootChild0.Layout.Height);

            Assert.AreEqual(10, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(52, rootChild0Child0.Layout.Width);
            Assert.AreEqual(52, rootChild0Child0.Layout.Height);
        }

        [Test]
        public void align_items_flex_end_child_with_margin_bigger_than_parent()
        {
            YogaNode rootChild0, rootChild0Child0;
            YogaNode root = Node(justifyContent:Justify.Center, alignItems:YogaAlign.Center, width: 52, height: 52)
               .Add(rootChild0 = Node(alignItems:YogaAlign.FlexEnd)
                   .Add(rootChild0Child0 = Node(width:52, height:52, margin:new Edges(left:10, right:10)))
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(72, rootChild0.Layout.Width);
            Assert.AreEqual(52, rootChild0.Layout.Height);

            Assert.AreEqual(10, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(52, rootChild0Child0.Layout.Width);
            Assert.AreEqual(52, rootChild0Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(72, rootChild0.Layout.Width);
            Assert.AreEqual(52, rootChild0.Layout.Height);

            Assert.AreEqual(10, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(52, rootChild0Child0.Layout.Width);
            Assert.AreEqual(52, rootChild0Child0.Layout.Height);
        }

        [Test]
        public void align_items_center_child_without_margin_bigger_than_parent()
        {
            YogaNode rootChild0, rootChild0Child0;
            YogaNode root = Node(justifyContent:Justify.Center, alignItems:YogaAlign.Center, width: 52, height: 52)
               .Add(rootChild0 = Node(alignItems:YogaAlign.Center)
                   .Add(rootChild0Child0 = Node(width:72, height:72))
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, rootChild0.Layout.Left);
            Assert.AreEqual(-10, rootChild0.Layout.Top);
            Assert.AreEqual(72, rootChild0.Layout.Width);
            Assert.AreEqual(72, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(72, rootChild0Child0.Layout.Width);
            Assert.AreEqual(72, rootChild0Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, rootChild0.Layout.Left);
            Assert.AreEqual(-10, rootChild0.Layout.Top);
            Assert.AreEqual(72, rootChild0.Layout.Width);
            Assert.AreEqual(72, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(72, rootChild0Child0.Layout.Width);
            Assert.AreEqual(72, rootChild0Child0.Layout.Height);
        }

        [Test]
        public void align_items_flex_end_child_without_margin_bigger_than_parent()
        {
            YogaNode rootChild0, rootChild0Child0;
            YogaNode root = Node(justifyContent:Justify.Center, alignItems:YogaAlign.Center, width: 52, height: 52)
               .Add(rootChild0 = Node(alignItems:YogaAlign.FlexEnd)
                   .Add(rootChild0Child0 = Node(width:72, height:72))
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, rootChild0.Layout.Left);
            Assert.AreEqual(-10, rootChild0.Layout.Top);
            Assert.AreEqual(72, rootChild0.Layout.Width);
            Assert.AreEqual(72, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(72, rootChild0Child0.Layout.Width);
            Assert.AreEqual(72, rootChild0Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(52, root.Layout.Width);
            Assert.AreEqual(52, root.Layout.Height);

            Assert.AreEqual(-10, rootChild0.Layout.Left);
            Assert.AreEqual(-10, rootChild0.Layout.Top);
            Assert.AreEqual(72, rootChild0.Layout.Width);
            Assert.AreEqual(72, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(72, rootChild0Child0.Layout.Width);
            Assert.AreEqual(72, rootChild0Child0.Layout.Height);
        }

        [Test]
        public void align_center_should_size_based_on_content()
        {
            YogaNode rootChild0, rootChild0Child0, rootChild0Child0Child0;
            YogaNode root = Node(alignItems:YogaAlign.Center, width: 100, height: 100, margin:new Edges(top:20))
               .Add(rootChild0 = Node(alignItems:YogaAlign.Center, flexShrink:1)
                   .Add(rootChild0Child0 = Node(flexGrow:1, flexShrink:1)
                       .Add(rootChild0Child0Child0 = Node(width:20, height:20))
                    )
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(20, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(40, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(20, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(20, rootChild0Child0.Layout.Width);
            Assert.AreEqual(20, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(20, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(20, rootChild0Child0Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(20, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(40, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(20, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(20, rootChild0Child0.Layout.Width);
            Assert.AreEqual(20, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(20, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(20, rootChild0Child0Child0.Layout.Height);
        }

        [Test]
        public void align_strech_should_size_based_on_parent()
        {
            YogaNode rootChild0, rootChild0Child0, rootChild0Child0Child0;
            YogaNode root = Node(width: 100, height: 100, margin:new Edges(top:20))
               .Add(rootChild0 = Node(justifyContent:Justify.Center, flexShrink:1)
                   .Add(rootChild0Child0 = Node(flexGrow:1, flexShrink:1)
                       .Add(rootChild0Child0Child0 = Node(width:20, height:20))
                    )
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(20, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(100, rootChild0Child0.Layout.Width);
            Assert.AreEqual(20, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(20, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(20, rootChild0Child0Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(20, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(100, rootChild0Child0.Layout.Width);
            Assert.AreEqual(20, rootChild0Child0.Layout.Height);

            Assert.AreEqual(80, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(20, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(20, rootChild0Child0Child0.Layout.Height);
        }

        [Test]
        public void align_flex_start_with_shrinking_children()
        {
            YogaNode rootChild0, rootChild0Child0, rootChild0Child0Child0;
            YogaNode root = Node(width: 500, height: 500)
               .Add(rootChild0 = Node(alignItems:YogaAlign.FlexStart)
                   .Add(rootChild0Child0 = Node(flexGrow:1, flexShrink:1)
                       .Add(rootChild0Child0Child0 = Node(flexGrow:1, flexShrink:1))
                    )
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(500, rootChild0.Layout.Width);
            Assert.AreEqual(0, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(0, rootChild0Child0.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(500, rootChild0.Layout.Width);
            Assert.AreEqual(0, rootChild0.Layout.Height);

            Assert.AreEqual(500, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(0, rootChild0Child0.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Height);
        }

        [Test]
        public void align_flex_start_with_stretching_children()
        {
            YogaNode rootChild0, rootChild0Child0, rootChild0Child0Child0;
            YogaNode root = Node(width: 500, height: 500)
               .Add(rootChild0 = Node()
                   .Add(rootChild0Child0 = Node(flexGrow:1, flexShrink:1)
                       .Add(rootChild0Child0Child0 = Node(flexGrow:1, flexShrink:1))
                    )
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(500, rootChild0.Layout.Width);
            Assert.AreEqual(0, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(500, rootChild0Child0.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(500, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(500, rootChild0.Layout.Width);
            Assert.AreEqual(0, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(500, rootChild0Child0.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(500, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Height);
        }

        [Test]
        public void align_flex_start_with_shrinking_children_with_stretch()
        {
            YogaNode rootChild0, rootChild0Child0, rootChild0Child0Child0;
            YogaNode root = Node(width: 500, height: 500)
               .Add(rootChild0 = Node(alignItems:YogaAlign.FlexStart)
                   .Add(rootChild0Child0 = Node(flexGrow:1, flexShrink:1)
                       .Add(rootChild0Child0Child0 = Node(flexGrow:1, flexShrink:1))
                    )
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(500, rootChild0.Layout.Width);
            Assert.AreEqual(0, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(0, rootChild0Child0.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(500, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(500, rootChild0.Layout.Width);
            Assert.AreEqual(0, rootChild0.Layout.Height);

            Assert.AreEqual(500, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(0, rootChild0Child0.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Height);
        }
    }
}
