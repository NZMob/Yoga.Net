using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaMinMaxDimensionTest
    {
        [Test]
        public void max_width()
        {
            YogaNode rootChild0;
            YogaNode root = Node(width: 100, height: 100)
               .Add(rootChild0 = Node(maxWidth: 50, height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);
        }

        [Test]
        public void max_height()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 100, height: 100)
               .Add(rootChild0 = Node(width: 10, maxHeight: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(90, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);
        }

        [Test]
        public void min_height()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(width: 100, height: 100)
                           .Add(rootChild0 = Node(flexGrow: 1, minHeight: 60))
                           .Add(rootChild1 = Node(flexGrow: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(80, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(80, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(80, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(80, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);
        }

        [Test]
        public void min_width()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 100, height: 100)
                           .Add(rootChild0 = Node(flexGrow: 1, minWidth: 60))
                           .Add(rootChild1 = Node(flexGrow: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(80, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(80, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(20, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(20, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(80, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(20, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);
        }

        [Test]
        public void justify_content_min_max()
        {
            YogaNode rootChild0;
            YogaNode root = Node(justifyContent: Justify.Center, width: 100, minHeight: 100, maxHeight: 200)
               .Add(rootChild0 = Node(width: 60, height: 60));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(20, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(60, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(40, rootChild0.Layout.Left);
            Assert.AreEqual(20, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(60, rootChild0.Layout.Height);
        }

        [Test]
        public void align_items_min_max()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.Center, minWidth: 100, maxWidth: 200, height: 100)
               .Add(rootChild0 = Node(width: 60, height: 60));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(20, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(60, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(20, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(60, rootChild0.Layout.Width);
            Assert.AreEqual(60, rootChild0.Layout.Height);
        }

        [Test]
        public void justify_content_overflow_min_max()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(justifyContent: Justify.Center, minHeight: 100, maxHeight: 110)
                           .Add(rootChild0 = Node(width: 50, height: 50))
                           .Add(rootChild1 = Node(width: 50, height: 50))
                           .Add(rootChild2 = Node(width: 50, height: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(110, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(-20, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(30, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(80, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(50, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(50, root.Layout.Width);
            Assert.AreEqual(110, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(-20, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(30, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(80, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(50, rootChild2.Layout.Height);
        }

        [Test]
        public void flex_grow_to_min()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(width:100, minHeight: 100, maxHeight: 500)
                           .Add(rootChild0 = Node(flexGrow:1, flexShrink:1))
                           .Add(rootChild1 = Node(height: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void flex_grow_in_at_most_container()
        {
            YogaNode rootChild0, rootChild0Child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(flexDirection: FlexDirection.Row)
                       .Add(rootChild0Child0 = Node(flexGrow:1, flexBasis:0))
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(0, rootChild0.Layout.Width);
            Assert.AreEqual(0, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(0, rootChild0Child0.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(0, rootChild0.Layout.Width);
            Assert.AreEqual(0, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(0, rootChild0Child0.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0.Layout.Height);
        }

        [Test]
        public void flex_grow_child()
        {
            YogaNode rootChild0;
            YogaNode root = Node(flexDirection: FlexDirection.Row)
               .Add(rootChild0 = Node(flexGrow: 1, flexBasis: 0, height: 100));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(0, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(0, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);
        }

        [Test]
        public void flex_grow_within_constrained_min_max_column()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(minHeight: 100, maxHeight: 100)
                           .Add(rootChild0 = Node(flexGrow: 1))
                           .Add(rootChild1 = Node(height: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(0, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(0, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(0, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(0, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void flex_grow_within_max_width()
        {
            YogaNode rootChild0, rootChild0Child0;
            YogaNode root = Node(width: 200, height: 100)
               .Add(rootChild0 = Node(flexDirection: FlexDirection.Row, maxWidth: 100)
                       .Add(rootChild0Child0 = Node(flexGrow: 1, height: 20))
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(100, rootChild0Child0.Layout.Width);
            Assert.AreEqual(20, rootChild0Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(100, rootChild0Child0.Layout.Width);
            Assert.AreEqual(20, rootChild0Child0.Layout.Height);
        }

        [Test]
        public void flex_grow_within_constrained_max_width()
        {
            YogaNode rootChild0, rootChild0Child0;
            YogaNode root = Node(width: 200, height: 100)
               .Add(rootChild0 = Node(flexDirection: FlexDirection.Row, maxWidth: 300)
                       .Add(rootChild0Child0 = Node(flexGrow: 1, height: 20))
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(200, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(200, rootChild0Child0.Layout.Width);
            Assert.AreEqual(20, rootChild0Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(200, rootChild0.Layout.Width);
            Assert.AreEqual(20, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(200, rootChild0Child0.Layout.Width);
            Assert.AreEqual(20, rootChild0Child0.Layout.Height);
        }

        [Test]
        public void flex_root_ignored()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(flexGrow: 1, width: 100, minHeight: 100, maxHeight: 500)
                           .Add(rootChild0 = Node(flexGrow: 1, flexBasis: 200))
                           .Add(rootChild1 = Node(height:100));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(300, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(200, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(200, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(300, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(200, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(200, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);
        }

        [Test]
        public void flex_grow_root_minimized()
        {
            YogaNode rootChild0, rootChild0Child0, rootChild0Child1;
            YogaNode root = Node(width: 100, minHeight: 100, maxHeight: 500)
               .Add(rootChild0 = Node(flexGrow: 1, minHeight: 100, maxHeight: 500)
                                .Add(rootChild0Child0 = Node(flexGrow: 1, flexBasis: 200))
                                .Add(rootChild0Child1 = Node(height: 100))
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(300, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(300, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(100, rootChild0Child0.Layout.Width);
            Assert.AreEqual(200, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child1.Layout.Left);
            Assert.AreEqual(200, rootChild0Child1.Layout.Top);
            Assert.AreEqual(100, rootChild0Child1.Layout.Width);
            Assert.AreEqual(100, rootChild0Child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(300, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(300, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(100, rootChild0Child0.Layout.Width);
            Assert.AreEqual(200, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child1.Layout.Left);
            Assert.AreEqual(200, rootChild0Child1.Layout.Top);
            Assert.AreEqual(100, rootChild0Child1.Layout.Width);
            Assert.AreEqual(100, rootChild0Child1.Layout.Height);
        }

        [Test]
        public void flex_grow_height_maximized()
        {
            YogaNode rootChild0, rootChild0Child0, rootChild0Child1;
            YogaNode root = Node(width: 100, height: 500)
               .Add(rootChild0 = Node(flexGrow: 1, minHeight: 100, maxHeight: 500)
                                .Add(rootChild0Child0 = Node(flexGrow: 1, flexBasis: 200))
                                .Add(rootChild0Child1 = Node(height: 100))
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(500, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(100, rootChild0Child0.Layout.Width);
            Assert.AreEqual(400, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child1.Layout.Left);
            Assert.AreEqual(400, rootChild0Child1.Layout.Top);
            Assert.AreEqual(100, rootChild0Child1.Layout.Width);
            Assert.AreEqual(100, rootChild0Child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(500, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(500, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(100, rootChild0Child0.Layout.Width);
            Assert.AreEqual(400, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child1.Layout.Left);
            Assert.AreEqual(400, rootChild0Child1.Layout.Top);
            Assert.AreEqual(100, rootChild0Child1.Layout.Width);
            Assert.AreEqual(100, rootChild0Child1.Layout.Height);
        }

        [Test]
        public void flex_grow_within_constrained_min_row()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(flexDirection: FlexDirection.Row, minWidth: 100, height: 100)
                           .Add(rootChild0 = Node(flexGrow: 1))
                           .Add(rootChild1 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
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
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);
        }

        [Test]
        public void flex_grow_within_constrained_min_column()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(minHeight: 100)
                           .Add(rootChild0 = Node(flexGrow: 1))
                           .Add(rootChild1 = Node(height: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(0, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(0, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(0, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(0, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void flex_grow_within_constrained_max_row()
        {
            YogaNode rootChild0, rootChild0Child0, rootChild0Child1;
            YogaNode root = Node(width: 200)
               .Add(
                    rootChild0 = Node(flexDirection: FlexDirection.Row, maxWidth: 100, height: 100)
                                .Add(rootChild0Child0 = Node(flexShrink: 1, flexBasis: 100))
                                .Add(rootChild0Child1 = Node(width: 50))
                );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(50, rootChild0Child0.Layout.Width);
            Assert.AreEqual(100, rootChild0Child0.Layout.Height);

            Assert.AreEqual(50, rootChild0Child1.Layout.Left);
            Assert.AreEqual(0, rootChild0Child1.Layout.Top);
            Assert.AreEqual(50, rootChild0Child1.Layout.Width);
            Assert.AreEqual(100, rootChild0Child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(200, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(50, rootChild0Child0.Layout.Width);
            Assert.AreEqual(100, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child1.Layout.Left);
            Assert.AreEqual(0, rootChild0Child1.Layout.Top);
            Assert.AreEqual(50, rootChild0Child1.Layout.Width);
            Assert.AreEqual(100, rootChild0Child1.Layout.Height);
        }

        [Test]
        public void flex_grow_within_constrained_max_column()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(width: 100, maxHeight: 100)
                           .Add(rootChild0 = Node(flexShrink: 1, flexBasis: 100))
                           .Add(rootChild1 = Node(height:50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void child_min_max_width_flexing()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 120, height: 50)
                           .Add(rootChild0 = Node(flexGrow: 1, flexBasis: 0, minWidth: 60))
                           .Add(rootChild1 = Node(flexGrow:1, flexBasis:50.Percent(), maxWidth:20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(120, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(100, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(20, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(120, root.Layout.Width);
            Assert.AreEqual(50, root.Layout.Height);

            Assert.AreEqual(20, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(20, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);
        }

        [Test]
        public void min_width_overrides_width()
        {
            YogaNode root = Node(width: 50, minWidth: 100);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(0, root.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(0, root.Layout.Height);
        }

        [Test]
        public void max_width_overrides_width()
        {
            YogaNode root = Node(width: 200, maxWidth: 100);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(0, root.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(0, root.Layout.Height);
        }

        [Test]
        public void min_height_overrides_height()
        {
            YogaNode root = Node(height: 50, minHeight: 100);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);
        }

        [Test]
        public void max_height_overrides_height()
        {
            YogaNode root = Node(height: 200, maxHeight: 100);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(0, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);
        }

        [Test]
        public void min_max_percent_no_width_height()
        {
            YogaNode rootChild0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
               .Add(rootChild0 = Node(minWidth: 10.Percent(), maxWidth: 10.Percent(), minHeight: 10.Percent(), maxHeight: 10.Percent()));

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
    }
}
