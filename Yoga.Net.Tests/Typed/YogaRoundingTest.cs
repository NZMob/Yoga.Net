using NUnit.Framework;

using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaRoundingTest
    {
        [Test]
        public void rounding_flex_basis_flex_grow_row_width_of_100()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(
                                 flexDirection: FlexDirection.Row,
                                 width: 100, 
                                 height: 100)
                            .Add(rootChild0 = Node(flexGrow: 1))
                            .Add(rootChild1 = Node(flexGrow: 1))
                            .Add(rootChild2 = Node(flexGrow: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(33, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(33, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(34, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            Assert.AreEqual(67, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(33, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(67, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(33, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(33, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(34, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(33, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);
        }

        [Test]
        public void rounding_flex_basis_flex_grow_row_prime_number_width()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(
                                flexDirection: FlexDirection.Row,
                                minWidth: 113,
                                minHeight: 100)
                           .Add(rootChild0 = Node(flexGrow: 1))
                           .Add(rootChild1 = Node(flexGrow: 1))
                           .Add(rootChild2 = Node(flexGrow: 1))
                           .Add(rootChild3 = Node(flexGrow: 1))
                           .Add(rootChild4 = Node(flexGrow: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(113, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(23, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(23, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(22, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            Assert.AreEqual(45, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(23, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);

            Assert.AreEqual(68, rootChild3.Layout.Left);
            Assert.AreEqual(0, rootChild3.Layout.Top);
            Assert.AreEqual(22, rootChild3.Layout.Width);
            Assert.AreEqual(100, rootChild3.Layout.Height);

            Assert.AreEqual(90, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(23, rootChild4.Layout.Width);
            Assert.AreEqual(100, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(113, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(90, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(23, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(68, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(22, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            Assert.AreEqual(45, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(23, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);

            Assert.AreEqual(23, rootChild3.Layout.Left);
            Assert.AreEqual(0, rootChild3.Layout.Top);
            Assert.AreEqual(22, rootChild3.Layout.Width);
            Assert.AreEqual(100, rootChild3.Layout.Height);

            Assert.AreEqual(0, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(23, rootChild4.Layout.Width);
            Assert.AreEqual(100, rootChild4.Layout.Height);
        }

        [Test]
        public void rounding_flex_basis_flex_shrink_row()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(
                       flexDirection: FlexDirection.Row,
                       width: 101,
                       height: 100)
                  .Add(rootChild0 = Node(flexShrink: 1, flexBasis: 100))
                  .Add(rootChild1 = Node(flexBasis: 25))
                  .Add(rootChild2 = Node(flexBasis: 25));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(101, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(51, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(51, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(25, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            Assert.AreEqual(76, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(25, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(101, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(51, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(25, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(25, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(25, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);
        }

        [Test]
        public void rounding_flex_basis_overrides_main_size()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(width: 100, height: 113)
                  .Add(rootChild0 = Node(flexGrow: 1, flexBasis: 50, height: 20))
                  .Add(rootChild1 = Node(flexGrow: 1, height: 10))
                  .Add(rootChild2 = Node(flexGrow: 1, height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(64, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(64, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(25, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(89, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(24, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(64, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(64, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(25, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(89, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(24, rootChild2.Layout.Height);
        }

        [Test]
        public void rounding_total_fractal()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(width: 87.4f, height: 113.4f)
                  .Add(rootChild0 = Node(flexGrow: 0.7f, flexBasis: 50.3f, height: 20.3f))
                  .Add(rootChild1 = Node(flexGrow: 1.6f, height: 10))
                  .Add(rootChild2 = Node(flexGrow: 1.1f, height: 10.7f));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(87, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(87, rootChild0.Layout.Width);
            Assert.AreEqual(59, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(59, rootChild1.Layout.Top);
            Assert.AreEqual(87, rootChild1.Layout.Width);
            Assert.AreEqual(30, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(89, rootChild2.Layout.Top);
            Assert.AreEqual(87, rootChild2.Layout.Width);
            Assert.AreEqual(24, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(87, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(87, rootChild0.Layout.Width);
            Assert.AreEqual(59, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(59, rootChild1.Layout.Top);
            Assert.AreEqual(87, rootChild1.Layout.Width);
            Assert.AreEqual(30, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(89, rootChild2.Layout.Top);
            Assert.AreEqual(87, rootChild2.Layout.Width);
            Assert.AreEqual(24, rootChild2.Layout.Height);
        }

        [Test]
        public void rounding_total_fractal_nested()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild0Child0, rootChild0Child1;
            YogaNode root = Node(width: 87.4f, height: 113.4f)
                            .Add(
                                 rootChild0 = Node(flexGrow: 0.7f, flexBasis: 50.3f, height: 20.3f)
                                              .Add(rootChild0Child0 = Node(flexGrow: 1f, flexBasis: 0.3f, bottom: 13.3f, height: 9.9f))
                                              .Add(rootChild0Child1 = Node(flexGrow: 4f, flexBasis: 0.3f, top: 13.3f, height: 1.1f))
                             )
                            .Add(rootChild1 = Node(flexGrow: 1.6f, height: 10f))
                            .Add(rootChild2 = Node(flexGrow: 1.1f, height: 10.7f));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(87, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(87, rootChild0.Layout.Width);
            Assert.AreEqual(59, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(-13, rootChild0Child0.Layout.Top);
            Assert.AreEqual(87, rootChild0Child0.Layout.Width);
            Assert.AreEqual(12, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child1.Layout.Left);
            Assert.AreEqual(25, rootChild0Child1.Layout.Top);
            Assert.AreEqual(87, rootChild0Child1.Layout.Width);
            Assert.AreEqual(47, rootChild0Child1.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(59, rootChild1.Layout.Top);
            Assert.AreEqual(87, rootChild1.Layout.Width);
            Assert.AreEqual(30, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(89, rootChild2.Layout.Top);
            Assert.AreEqual(87, rootChild2.Layout.Width);
            Assert.AreEqual(24, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(87, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(87, rootChild0.Layout.Width);
            Assert.AreEqual(59, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(-13, rootChild0Child0.Layout.Top);
            Assert.AreEqual(87, rootChild0Child0.Layout.Width);
            Assert.AreEqual(12, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child1.Layout.Left);
            Assert.AreEqual(25, rootChild0Child1.Layout.Top);
            Assert.AreEqual(87, rootChild0Child1.Layout.Width);
            Assert.AreEqual(47, rootChild0Child1.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(59, rootChild1.Layout.Top);
            Assert.AreEqual(87, rootChild1.Layout.Width);
            Assert.AreEqual(30, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(89, rootChild2.Layout.Top);
            Assert.AreEqual(87, rootChild2.Layout.Width);
            Assert.AreEqual(24, rootChild2.Layout.Height);
        }

        [Test]
        public void rounding_fractal_input_1()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(width: 100, height: 113.4f)
                  .Add(rootChild0 = Node(flexGrow: 1, flexBasis: 50, height: 20))
                  .Add(rootChild1 = Node(flexGrow: 1, height: 10))
                  .Add(rootChild2 = Node(flexGrow: 1, height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(64, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(64, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(25, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(89, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(24, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(64, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(64, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(25, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(89, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(24, rootChild2.Layout.Height);
        }

        [Test]
        public void rounding_fractal_input_2()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(width  : 100,height : 113.6f)
                  .Add(rootChild0 = Node( flexGrow  : 1,flexBasis : 50,height    : 20))
                  .Add(rootChild1 = Node(flexGrow : 1,height   : 10))
                  .Add(rootChild2 = Node(flexGrow : 1,height   : 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(114, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(65, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(65, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(24, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(89, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(25, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(114, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(65, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(65, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(24, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(89, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(25, rootChild2.Layout.Height);
        }

        [Test]
        public void rounding_fractal_input_3()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(top: 0.3f, width: 100, height: 113.4f)
                  .Add(rootChild0 = Node(flexGrow: 1, flexBasis: 50, height: 20))
                  .Add(rootChild1 = Node(flexGrow: 1, height: 10))
                  .Add(rootChild2 = Node(flexGrow: 1, height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(114, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(65, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(64, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(24, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(89, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(25, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(114, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(65, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(64, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(24, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(89, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(25, rootChild2.Layout.Height);
        }

        [Test]
        public void rounding_fractal_input_4()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(top: 0.7f, width: 100, height: 113.4f)
                           .Add(rootChild0 = Node(flexGrow: 1, flexBasis: 50, height: 20))
                           .Add(rootChild1 = Node(flexGrow: 1, height: 10))
                           .Add(rootChild2 = Node(flexGrow: 1, height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(1, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(64, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(64, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(25, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(89, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(24, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(1, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(113, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(64, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(64, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(25, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(89, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(24, rootChild2.Layout.Height);
        }

        [Test]
        public void rounding_inner_node_controversy_horizontal()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild1Child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 320)
                  .Add(rootChild0 = Node(flexGrow: 1, height: 10))
                  .Add(rootChild1 = Node(flexGrow: 1, height: 10)
                          .Add(rootChild1Child0 = Node(flexGrow: 1, height: 10)))
                  .Add(rootChild2 = Node(flexGrow: 1, height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(320, root.Layout.Width);
            Assert.AreEqual(10, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(107, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(107, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(106, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(106, rootChild1Child0.Layout.Width);
            Assert.AreEqual(10, rootChild1Child0.Layout.Height);

            Assert.AreEqual(213, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(107, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(320, root.Layout.Width);
            Assert.AreEqual(10, root.Layout.Height);

            Assert.AreEqual(213, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(107, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(107, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(106, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(106, rootChild1Child0.Layout.Width);
            Assert.AreEqual(10, rootChild1Child0.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(107, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);
        }

        [Test]
        public void rounding_inner_node_controversy_vertical()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild1Child0;
            YogaNode root = Node(height: 320)
                  .Add(rootChild0 = Node(flexGrow: 1, width: 10))
                  .Add(rootChild1 = Node(flexGrow: 1, width: 10)
                          .Add(rootChild1Child0 = Node(flexGrow: 1, width: 10))
                   )
                  .Add(rootChild2 = Node(flexGrow: 1, width: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(10, root.Layout.Width);
            Assert.AreEqual(320, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(107, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(107, rootChild1.Layout.Top);
            Assert.AreEqual(10, rootChild1.Layout.Width);
            Assert.AreEqual(106, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(10, rootChild1Child0.Layout.Width);
            Assert.AreEqual(106, rootChild1Child0.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(213, rootChild2.Layout.Top);
            Assert.AreEqual(10, rootChild2.Layout.Width);
            Assert.AreEqual(107, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(10, root.Layout.Width);
            Assert.AreEqual(320, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(107, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(107, rootChild1.Layout.Top);
            Assert.AreEqual(10, rootChild1.Layout.Width);
            Assert.AreEqual(106, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(10, rootChild1Child0.Layout.Width);
            Assert.AreEqual(106, rootChild1Child0.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(213, rootChild2.Layout.Top);
            Assert.AreEqual(10, rootChild2.Layout.Width);
            Assert.AreEqual(107, rootChild2.Layout.Height);
        }

        [Test]
        public void rounding_inner_node_controversy_combined()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild1Child0, rootChild1Child1, rootChild1Child2, rootChild1Child1Child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, width: 640, height: 320)
                  .Add(rootChild0 = Node(flexGrow: 1, height: 100.Percent()))
                  .Add(rootChild1 = Node(flexGrow: 1, height: 100.Percent())
                                    .Add(rootChild1Child0 = Node(flexGrow: 1, width: 100.Percent()))
                                    .Add(rootChild1Child1 = Node(flexGrow: 1, width: 100.Percent())
                                            .Add(rootChild1Child1Child0 = Node(flexGrow: 1, width: 100.Percent()))
                                     )
                                    .Add(rootChild1Child2 = Node(flexGrow: 1, width: 100.Percent()))
                   )
                  .Add(rootChild2 = Node(flexGrow: 1, height: 100.Percent()));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(640, root.Layout.Width);
            Assert.AreEqual(320, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(213, rootChild0.Layout.Width);
            Assert.AreEqual(320, rootChild0.Layout.Height);

            Assert.AreEqual(213, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(214, rootChild1.Layout.Width);
            Assert.AreEqual(320, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(214, rootChild1Child0.Layout.Width);
            Assert.AreEqual(107, rootChild1Child0.Layout.Height);

            Assert.AreEqual(0, rootChild1Child1.Layout.Left);
            Assert.AreEqual(107, rootChild1Child1.Layout.Top);
            Assert.AreEqual(214, rootChild1Child1.Layout.Width);
            Assert.AreEqual(106, rootChild1Child1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child1Child0.Layout.Top);
            Assert.AreEqual(214, rootChild1Child1Child0.Layout.Width);
            Assert.AreEqual(106, rootChild1Child1Child0.Layout.Height);

            Assert.AreEqual(0, rootChild1Child2.Layout.Left);
            Assert.AreEqual(213, rootChild1Child2.Layout.Top);
            Assert.AreEqual(214, rootChild1Child2.Layout.Width);
            Assert.AreEqual(107, rootChild1Child2.Layout.Height);

            Assert.AreEqual(427, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(213, rootChild2.Layout.Width);
            Assert.AreEqual(320, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(640, root.Layout.Width);
            Assert.AreEqual(320, root.Layout.Height);

            Assert.AreEqual(427, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(213, rootChild0.Layout.Width);
            Assert.AreEqual(320, rootChild0.Layout.Height);

            Assert.AreEqual(213, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(214, rootChild1.Layout.Width);
            Assert.AreEqual(320, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(214, rootChild1Child0.Layout.Width);
            Assert.AreEqual(107, rootChild1Child0.Layout.Height);

            Assert.AreEqual(0, rootChild1Child1.Layout.Left);
            Assert.AreEqual(107, rootChild1Child1.Layout.Top);
            Assert.AreEqual(214, rootChild1Child1.Layout.Width);
            Assert.AreEqual(106, rootChild1Child1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child1Child0.Layout.Top);
            Assert.AreEqual(214, rootChild1Child1Child0.Layout.Width);
            Assert.AreEqual(106, rootChild1Child1Child0.Layout.Height);

            Assert.AreEqual(0, rootChild1Child2.Layout.Left);
            Assert.AreEqual(213, rootChild1Child2.Layout.Top);
            Assert.AreEqual(214, rootChild1Child2.Layout.Width);
            Assert.AreEqual(107, rootChild1Child2.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(213, rootChild2.Layout.Width);
            Assert.AreEqual(320, rootChild2.Layout.Height);
        }
    }
}
