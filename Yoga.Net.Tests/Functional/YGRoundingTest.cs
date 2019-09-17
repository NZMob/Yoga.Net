using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGRoundingTest
    {
        [Test]
        public void rounding_flex_basis_flex_grow_row_width_of_100()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild2, 1);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(33, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(33, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(34, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(67, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(33, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(67, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(33, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(33, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(34, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(33, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void rounding_flex_basis_flex_grow_row_prime_number_width()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 113);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild2, 1);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild3, 1);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild4, 1);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(113, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(23, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(23, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(22, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(23, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(68, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(22, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(23, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(113, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(23, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(68, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(22, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(23, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(23, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(22, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(23, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void rounding_flex_basis_flex_shrink_row()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 101);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexShrink(rootChild0, 1);
            YGNodeStyleSetFlexBasis(rootChild0, 100);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexBasis(rootChild1, 25);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexBasis(rootChild2, 25);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(101, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(51, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(51, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(76, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(101, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(51, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(25, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(25, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void rounding_flex_basis_overrides_main_size()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 113);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetFlexBasis(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 20);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild2, 1);
            YGNodeStyleSetHeight(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(113, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(64, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(64, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(113, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(64, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(64, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void rounding_total_fractial()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 87.4f);
            YGNodeStyleSetHeight(root, 113.4f);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 0.7f);
            YGNodeStyleSetFlexBasis(rootChild0, 50.3f);
            YGNodeStyleSetHeight(rootChild0, 20.3f);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1.6f);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild2, 1.1f);
            YGNodeStyleSetHeight(rootChild2, 10.7f);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(113, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(59, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(59, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(113, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(59, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(59, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void rounding_total_fractial_nested()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 87.4f);
            YGNodeStyleSetHeight(root, 113.4f);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 0.7f);
            YGNodeStyleSetFlexBasis(rootChild0, 50.3f);
            YGNodeStyleSetHeight(rootChild0, 20.3f);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0Child0, 1);
            YGNodeStyleSetFlexBasis(rootChild0Child0, 0.3f);
            YGNodeStyleSetPosition(rootChild0Child0, Edge.Bottom, 13.3f);
            YGNodeStyleSetHeight(rootChild0Child0, 9.9f);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild0Child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0Child1, 4);
            YGNodeStyleSetFlexBasis(rootChild0Child1, 0.3f);
            YGNodeStyleSetPosition(rootChild0Child1, Edge.Top, 13.3f);
            YGNodeStyleSetHeight(rootChild0Child1, 1.1f);
            YGNodeInsertChild(rootChild0, rootChild0Child1, 1);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1.6f);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild2, 1.1f);
            YGNodeStyleSetHeight(rootChild2, 10.7f);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(113, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(59, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(-13, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(12, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child1));
            Assert.AreEqual(25, YGNodeLayoutGetTop(rootChild0Child1));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(rootChild0Child1));
            Assert.AreEqual(47, YGNodeLayoutGetHeight(rootChild0Child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(59, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(113, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(59, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(-13, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(12, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child1));
            Assert.AreEqual(25, YGNodeLayoutGetTop(rootChild0Child1));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(rootChild0Child1));
            Assert.AreEqual(47, YGNodeLayoutGetHeight(rootChild0Child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(59, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(87, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void rounding_fractial_input_1()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 113.4f);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetFlexBasis(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 20);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild2, 1);
            YGNodeStyleSetHeight(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(113, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(64, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(64, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(113, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(64, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(64, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void rounding_fractal_input_2()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 113.6f);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetFlexBasis(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 20);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild2, 1);
            YGNodeStyleSetHeight(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(114, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(65, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(65, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(114, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(65, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(65, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void rounding_fractial_input_3()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetPosition(root, Edge.Top, 0.3f);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 113.4f);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetFlexBasis(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 20);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild2, 1);
            YGNodeStyleSetHeight(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(114, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(65, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(64, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(114, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(65, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(64, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void rounding_fractial_input_4()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetPosition(root, Edge.Top, 0.7f);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 113.4f);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetFlexBasis(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 20);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild2, 1);
            YGNodeStyleSetHeight(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(1, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(113, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(64, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(64, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(1, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(113, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(64, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(64, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(89, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(24, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void rounding_inner_node_controversy_horizontal()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 320);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild1Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1Child0, 1);
            YGNodeStyleSetHeight(rootChild1Child0, 10);
            YGNodeInsertChild(rootChild1, rootChild1Child0, 0);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild2, 1);
            YGNodeStyleSetHeight(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(320, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(107, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(107, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(106, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(106, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child0));

            Assert.AreEqual(213, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(107, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(320, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(213, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(107, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(107, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(106, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(106, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(107, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void rounding_inner_node_controversy_vertical()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(root, 320);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetWidth(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeStyleSetWidth(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild1Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1Child0, 1);
            YGNodeStyleSetWidth(rootChild1Child0, 10);
            YGNodeInsertChild(rootChild1, rootChild1Child0, 0);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild2, 1);
            YGNodeStyleSetWidth(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(320, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(107, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(107, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(106, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(106, YGNodeLayoutGetHeight(rootChild1Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(213, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(107, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(320, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(107, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(107, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(106, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(106, YGNodeLayoutGetHeight(rootChild1Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(213, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(107, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void rounding_inner_node_controversy_combined()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 640);
            YGNodeStyleSetHeight(root, 320);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetHeightPercent(rootChild0, 100);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeStyleSetHeightPercent(rootChild1, 100);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild1Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1Child0, 1);
            YGNodeStyleSetWidthPercent(rootChild1Child0, 100);
            YGNodeInsertChild(rootChild1, rootChild1Child0, 0);

            YogaNode rootChild1Child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1Child1, 1);
            YGNodeStyleSetWidthPercent(rootChild1Child1, 100);
            YGNodeInsertChild(rootChild1, rootChild1Child1, 1);

            YogaNode rootChild1Child1Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1Child1Child0, 1);
            YGNodeStyleSetWidthPercent(rootChild1Child1Child0, 100);
            YGNodeInsertChild(rootChild1Child1, rootChild1Child1Child0, 0);

            YogaNode rootChild1Child2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1Child2, 1);
            YGNodeStyleSetWidthPercent(rootChild1Child2, 100);
            YGNodeInsertChild(rootChild1, rootChild1Child2, 2);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild2, 1);
            YGNodeStyleSetHeightPercent(rootChild2, 100);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(640, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(320, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(213, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(320, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(213, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(214, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(320, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(214, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(107, YGNodeLayoutGetHeight(rootChild1Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child1));
            Assert.AreEqual(107, YGNodeLayoutGetTop(rootChild1Child1));
            Assert.AreEqual(214, YGNodeLayoutGetWidth(rootChild1Child1));
            Assert.AreEqual(106, YGNodeLayoutGetHeight(rootChild1Child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child1Child0));
            Assert.AreEqual(214, YGNodeLayoutGetWidth(rootChild1Child1Child0));
            Assert.AreEqual(106, YGNodeLayoutGetHeight(rootChild1Child1Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child2));
            Assert.AreEqual(213, YGNodeLayoutGetTop(rootChild1Child2));
            Assert.AreEqual(214, YGNodeLayoutGetWidth(rootChild1Child2));
            Assert.AreEqual(107, YGNodeLayoutGetHeight(rootChild1Child2));

            Assert.AreEqual(427, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(213, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(320, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(640, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(320, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(427, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(213, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(320, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(213, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(214, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(320, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(214, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(107, YGNodeLayoutGetHeight(rootChild1Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child1));
            Assert.AreEqual(107, YGNodeLayoutGetTop(rootChild1Child1));
            Assert.AreEqual(214, YGNodeLayoutGetWidth(rootChild1Child1));
            Assert.AreEqual(106, YGNodeLayoutGetHeight(rootChild1Child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child1Child0));
            Assert.AreEqual(214, YGNodeLayoutGetWidth(rootChild1Child1Child0));
            Assert.AreEqual(106, YGNodeLayoutGetHeight(rootChild1Child1Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child2));
            Assert.AreEqual(213, YGNodeLayoutGetTop(rootChild1Child2));
            Assert.AreEqual(214, YGNodeLayoutGetWidth(rootChild1Child2));
            Assert.AreEqual(107, YGNodeLayoutGetHeight(rootChild1Child2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(213, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(320, YGNodeLayoutGetHeight(rootChild2));
        }
    }
}
