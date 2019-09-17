using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGFlexWrapTest
    {
        [Test]
        public void wrap_column()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 30);
            YGNodeStyleSetHeight(rootChild0, 30);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 30);
            YGNodeStyleSetHeight(rootChild1, 30);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 30);
            YGNodeStyleSetHeight(rootChild2, 30);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 30);
            YGNodeStyleSetHeight(rootChild3, 30);
            YGNodeInsertChild(root, rootChild3, 3);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(60, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild3));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(60, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(60, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild3));
        }

        [Test]
        public void wrap_row()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 30);
            YGNodeStyleSetHeight(rootChild0, 30);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 30);
            YGNodeStyleSetHeight(rootChild1, 30);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 30);
            YGNodeStyleSetHeight(rootChild2, 30);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 30);
            YGNodeStyleSetHeight(rootChild3, 30);
            YGNodeInsertChild(root, rootChild3, 3);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild3));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild3));
        }

        [Test]
        public void wrap_row_align_items_flex_end()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexEnd);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 30);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 30);
            YGNodeStyleSetHeight(rootChild1, 20);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 30);
            YGNodeStyleSetHeight(rootChild2, 30);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 30);
            YGNodeStyleSetHeight(rootChild3, 30);
            YGNodeInsertChild(root, rootChild3, 3);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild3));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild3));
        }

        [Test]
        public void wrap_row_align_items_center()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 30);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 30);
            YGNodeStyleSetHeight(rootChild1, 20);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 30);
            YGNodeStyleSetHeight(rootChild2, 30);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 30);
            YGNodeStyleSetHeight(rootChild3, 30);
            YGNodeInsertChild(root, rootChild3, 3);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(5, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild3));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(5, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild3));
        }

        [Test]
        public void flex_wrap_children_with_min_main_overriding_flex_basis()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexBasis(rootChild0, 50);
            YGNodeStyleSetMinWidth(rootChild0, 55);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexBasis(rootChild1, 50);
            YGNodeStyleSetMinWidth(rootChild1, 55);
            YGNodeStyleSetHeight(rootChild1, 50);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(55, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(55, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(55, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(55, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void flex_wrap_wrap_to_child_height()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(rootChild0, FlexDirection.Row);
            YGNodeStyleSetAlignItems(rootChild0, YogaAlign.FlexStart);
            YGNodeStyleSetFlexWrap(rootChild0, Wrap.Wrap);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child0, 100);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild0Child0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child0Child0, 100);
            YGNodeStyleSetHeight(rootChild0Child0Child0, 100);
            YGNodeInsertChild(rootChild0Child0, rootChild0Child0Child0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 100);
            YGNodeStyleSetHeight(rootChild1, 100);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));
        }

        [Ignore("Exactly the same result as the c++ library")]
        [Test]
        public void flex_wrap_align_stretch_fits_one_row()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));
        }

        [Test]
        public void wrap_reverse_row_align_content_flex_start()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 30);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 30);
            YGNodeStyleSetHeight(rootChild1, 20);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 30);
            YGNodeStyleSetHeight(rootChild2, 30);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 30);
            YGNodeStyleSetHeight(rootChild3, 40);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 30);
            YGNodeStyleSetHeight(rootChild4, 50);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void wrap_reverse_row_align_content_center()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Center);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 30);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 30);
            YGNodeStyleSetHeight(rootChild1, 20);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 30);
            YGNodeStyleSetHeight(rootChild2, 30);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 30);
            YGNodeStyleSetHeight(rootChild3, 40);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 30);
            YGNodeStyleSetHeight(rootChild4, 50);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void wrap_reverse_row_single_line_different_size()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 300);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 30);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 30);
            YGNodeStyleSetHeight(rootChild1, 20);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 30);
            YGNodeStyleSetHeight(rootChild2, 30);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 30);
            YGNodeStyleSetHeight(rootChild3, 40);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 30);
            YGNodeStyleSetHeight(rootChild4, 50);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(300, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(120, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(300, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(270, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(240, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(210, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(180, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(150, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void wrap_reverse_row_align_content_stretch()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 30);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 30);
            YGNodeStyleSetHeight(rootChild1, 20);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 30);
            YGNodeStyleSetHeight(rootChild2, 30);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 30);
            YGNodeStyleSetHeight(rootChild3, 40);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 30);
            YGNodeStyleSetHeight(rootChild4, 50);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void wrap_reverse_row_align_content_space_around()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.SpaceAround);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 30);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 30);
            YGNodeStyleSetHeight(rootChild1, 20);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 30);
            YGNodeStyleSetHeight(rootChild2, 30);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 30);
            YGNodeStyleSetHeight(rootChild3, 40);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 30);
            YGNodeStyleSetHeight(rootChild4, 50);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(70, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(60, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void wrap_reverse_column_fixed_size()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexWrap(root, Wrap.WrapReverse);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 30);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 30);
            YGNodeStyleSetHeight(rootChild1, 20);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 30);
            YGNodeStyleSetHeight(rootChild2, 30);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 30);
            YGNodeStyleSetHeight(rootChild3, 40);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 30);
            YGNodeStyleSetHeight(rootChild4, 50);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(170, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(170, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(170, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(170, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(60, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(140, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(60, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void wrapped_row_within_align_items_center()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(rootChild0, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(rootChild0, Wrap.Wrap);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child0, 150);
            YGNodeStyleSetHeight(rootChild0Child0, 80);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild0Child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child1, 80);
            YGNodeStyleSetHeight(rootChild0Child1, 80);
            YGNodeInsertChild(rootChild0, rootChild0Child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild0Child1));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(rootChild0Child1));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0Child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(120, YGNodeLayoutGetLeft(rootChild0Child1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild0Child1));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(rootChild0Child1));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0Child1));
        }

        [Test]
        public void wrapped_row_within_align_items_flex_start()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexStart);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(rootChild0, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(rootChild0, Wrap.Wrap);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child0, 150);
            YGNodeStyleSetHeight(rootChild0Child0, 80);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild0Child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child1, 80);
            YGNodeStyleSetHeight(rootChild0Child1, 80);
            YGNodeInsertChild(rootChild0, rootChild0Child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild0Child1));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(rootChild0Child1));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0Child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(120, YGNodeLayoutGetLeft(rootChild0Child1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild0Child1));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(rootChild0Child1));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0Child1));
        }

        [Test]
        public void wrapped_row_within_align_items_flex_end()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root, YogaAlign.FlexEnd);
            YGNodeStyleSetWidth(root, 200);
            YGNodeStyleSetHeight(root, 200);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(rootChild0, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(rootChild0, Wrap.Wrap);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child0, 150);
            YGNodeStyleSetHeight(rootChild0Child0, 80);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild0Child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child1, 80);
            YGNodeStyleSetHeight(rootChild0Child1, 80);
            YGNodeInsertChild(rootChild0, rootChild0Child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild0Child1));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(rootChild0Child1));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0Child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(160, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(120, YGNodeLayoutGetLeft(rootChild0Child1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild0Child1));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(rootChild0Child1));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0Child1));
        }

        [Test]
        public void wrapped_column_max_height()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignContent(root, YogaAlign.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 700);
            YGNodeStyleSetHeight(root, 500);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 100);
            YGNodeStyleSetHeight(rootChild0, 500);
            YGNodeStyleSetMaxHeight(rootChild0, 200);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(rootChild1, Edge.Left, 20);
            YGNodeStyleSetMargin(rootChild1, Edge.Top, 20);
            YGNodeStyleSetMargin(rootChild1, Edge.Right, 20);
            YGNodeStyleSetMargin(rootChild1, Edge.Bottom, 20);
            YGNodeStyleSetWidth(rootChild1, 200);
            YGNodeStyleSetHeight(rootChild1, 200);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 100);
            YGNodeStyleSetHeight(rootChild2, 100);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(700, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(250, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(200, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(250, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(420, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(200, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(700, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(350, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(300, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(250, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(180, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(200, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void wrapped_column_max_height_flex()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetAlignContent(root, YogaAlign.Center);
            YGNodeStyleSetAlignItems(root, YogaAlign.Center);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 700);
            YGNodeStyleSetHeight(root, 500);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetFlexShrink(rootChild0, 1);
            YGNodeStyleSetFlexBasisPercent(rootChild0, 0);
            YGNodeStyleSetWidth(rootChild0, 100);
            YGNodeStyleSetHeight(rootChild0, 500);
            YGNodeStyleSetMaxHeight(rootChild0, 200);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeStyleSetFlexShrink(rootChild1, 1);
            YGNodeStyleSetFlexBasisPercent(rootChild1, 0);
            YGNodeStyleSetMargin(rootChild1, Edge.Left, 20);
            YGNodeStyleSetMargin(rootChild1, Edge.Top, 20);
            YGNodeStyleSetMargin(rootChild1, Edge.Right, 20);
            YGNodeStyleSetMargin(rootChild1, Edge.Bottom, 20);
            YGNodeStyleSetWidth(rootChild1, 200);
            YGNodeStyleSetHeight(rootChild1, 200);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 100);
            YGNodeStyleSetHeight(rootChild2, 100);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(700, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(300, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(180, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(250, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(200, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(180, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(300, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(400, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(700, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(300, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(180, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(250, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(200, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(200, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(180, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(300, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(400, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void wrap_nodes_with_content_sizing_overflowing_margin()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 500);
            YGNodeStyleSetHeight(root, 500);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(rootChild0, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(rootChild0, Wrap.Wrap);
            YGNodeStyleSetWidth(rootChild0, 85);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild0Child0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child0Child0, 40);
            YGNodeStyleSetHeight(rootChild0Child0Child0, 40);
            YGNodeInsertChild(rootChild0Child0, rootChild0Child0Child0, 0);

            YogaNode rootChild0Child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(rootChild0Child1, Edge.Right, 10);
            YGNodeInsertChild(rootChild0, rootChild0Child1, 1);

            YogaNode rootChild0Child1Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child1Child0, 40);
            YGNodeStyleSetHeight(rootChild0Child1Child0, 40);
            YGNodeInsertChild(rootChild0Child1, rootChild0Child1Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(85, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0Child0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild0Child1));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild0Child1));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0Child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child1Child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild0Child1Child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0Child1Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(415, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(85, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(45, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0Child0Child0));

            Assert.AreEqual(35, YGNodeLayoutGetLeft(rootChild0Child1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild0Child1));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild0Child1));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0Child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child1Child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild0Child1Child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0Child1Child0));
        }

        [Test]
        public void wrap_nodes_with_content_sizing_margin_cross()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 500);
            YGNodeStyleSetHeight(root, 500);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(rootChild0, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(rootChild0, Wrap.Wrap);
            YGNodeStyleSetWidth(rootChild0, 70);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild0Child0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child0Child0, 40);
            YGNodeStyleSetHeight(rootChild0Child0Child0, 40);
            YGNodeInsertChild(rootChild0Child0, rootChild0Child0Child0, 0);

            YogaNode rootChild0Child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(rootChild0Child1, Edge.Top, 10);
            YGNodeInsertChild(rootChild0, rootChild0Child1, 1);

            YogaNode rootChild0Child1Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0Child1Child0, 40);
            YGNodeStyleSetHeight(rootChild0Child1Child0, 40);
            YGNodeInsertChild(rootChild0Child1, rootChild0Child1Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(70, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(90, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0Child0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild0Child1));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild0Child1));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0Child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child1Child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild0Child1Child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0Child1Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(500, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(430, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(70, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(90, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0Child0Child0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild0Child1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild0Child1));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild0Child1));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0Child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child1Child0));
            Assert.AreEqual(40, YGNodeLayoutGetWidth(rootChild0Child1Child0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0Child1Child0));
        }
    }
}
