using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGAlignContentTest
    {
        [Test]
        public void align_content_flex_start()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 130);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 50);
            YGNodeStyleSetHeight(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeStyleSetHeight(rootChild3, 10);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 50);
            YGNodeStyleSetHeight(rootChild4, 10);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(130, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(130, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void align_content_flex_start_without_height_on_children()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 50);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeStyleSetHeight(rootChild3, 10);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 50);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void align_content_flex_start_with_flex()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 120);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetFlexBasisPercent(rootChild0, 0);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeStyleSetFlexBasisPercent(rootChild1, 0);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 50);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild3, 1);
            YGNodeStyleSetFlexShrink(rootChild3, 1);
            YGNodeStyleSetFlexBasisPercent(rootChild3, 0);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 50);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(120, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(120, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(120, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(120, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild4));
        }

        [Ignore("Exactly the same results as the C++ library")]
        [Test]
        public void align_content_flex_end()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root, YogaAlign.FlexEnd);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 50);
            YGNodeStyleSetHeight(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeStyleSetHeight(rootChild3, 10);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 50);
            YGNodeStyleSetHeight(rootChild4, 10);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void align_content_stretch()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 50);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 50);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void align_content_spacebetween()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.SpaceBetween);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 130);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 50);
            YGNodeStyleSetHeight(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeStyleSetHeight(rootChild3, 10);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 50);
            YGNodeStyleSetHeight(rootChild4, 10);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(130, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(45, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(45, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(90, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(130, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(45, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(45, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(90, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void align_content_spacearound()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.SpaceAround);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 140);
            YGNodeStyleSetHeight(root, 120);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 50);
            YGNodeStyleSetHeight(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeStyleSetHeight(rootChild3, 10);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 50);
            YGNodeStyleSetHeight(rootChild4, 10);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(140, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(120, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(15, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(15, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(55, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(55, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(95, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(140, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(120, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(15, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(15, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(55, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(55, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(95, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void align_content_stretch_row()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 50);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 50);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void align_content_stretch_row_with_children()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0Child0, 1);
            YGNodeStyleSetFlexShrink(rootChild0Child0, 1);
            YGNodeStyleSetFlexBasisPercent(rootChild0Child0, 0);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 50);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 50);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void align_content_stretch_row_with_flex()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeStyleSetFlexShrink(rootChild1, 1);
            YGNodeStyleSetFlexBasisPercent(rootChild1, 0);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 50);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild3, 1);
            YGNodeStyleSetFlexShrink(rootChild3, 1);
            YGNodeStyleSetFlexBasisPercent(rootChild3, 0);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 50);
            YGNodeInsertChild(root, rootChild4, 4);
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
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void align_content_stretch_row_with_flex_no_shrink()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeStyleSetFlexShrink(rootChild1, 1);
            YGNodeStyleSetFlexBasisPercent(rootChild1, 0);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 50);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild3, 1);
            YGNodeStyleSetFlexBasisPercent(rootChild3, 0);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 50);
            YGNodeInsertChild(root, rootChild4, 4);
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
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void align_content_stretch_row_with_margin()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(rootChild1, Edge.Left, 10);
            YGNodeStyleSetMargin(rootChild1, Edge.Top, 10);
            YGNodeStyleSetMargin(rootChild1, Edge.Right, 10);
            YGNodeStyleSetMargin(rootChild1, Edge.Bottom, 10);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 50);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetMargin(rootChild3, Edge.Left, 10);
            YGNodeStyleSetMargin(rootChild3, Edge.Top, 10);
            YGNodeStyleSetMargin(rootChild3, Edge.Right, 10);
            YGNodeStyleSetMargin(rootChild3, Edge.Bottom, 10);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 50);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(60, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(40, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void align_content_stretch_row_with_padding()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPadding(rootChild1, Edge.Left, 10);
            YGNodeStyleSetPadding(rootChild1, Edge.Top, 10);
            YGNodeStyleSetPadding(rootChild1, Edge.Right, 10);
            YGNodeStyleSetPadding(rootChild1, Edge.Bottom, 10);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 50);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetPadding(rootChild3, Edge.Left, 10);
            YGNodeStyleSetPadding(rootChild3, Edge.Top, 10);
            YGNodeStyleSetPadding(rootChild3, Edge.Right, 10);
            YGNodeStyleSetPadding(rootChild3, Edge.Bottom, 10);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 50);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void align_content_stretch_row_with_single_row()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
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
        public void align_content_stretch_row_with_fixed_height()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 60);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 50);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 50);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void align_content_stretch_row_with_max_height()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetMaxHeight(rootChild1, 20);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 50);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 50);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void align_content_stretch_row_with_min_height()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 150);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetMinHeight(rootChild1, 80);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 50);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild3, 50);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild4, 50);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(90, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(90, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(90, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(90, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(90, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(90, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(90, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(90, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(90, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(90, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void align_content_stretch_column()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetFlexWrap(root, Wrap.Wrap);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 150);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0Child0, 1);
            YGNodeStyleSetFlexShrink(rootChild0Child0, 1);
            YGNodeStyleSetFlexBasisPercent(rootChild0Child0, 0);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeStyleSetFlexShrink(rootChild1, 1);
            YGNodeStyleSetFlexBasisPercent(rootChild1, 0);
            YGNodeStyleSetHeight(rootChild1, 50);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild2, 50);
            YGNodeInsertChild(root, rootChild2, 2);

            YogaNode rootChild3 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild3, 50);
            YGNodeInsertChild(root, rootChild3, 3);

            YogaNode rootChild4 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild4, 50);
            YGNodeInsertChild(root, rootChild4, 4);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(150, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(100, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(150, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild2));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild3));
            Assert.AreEqual(100, YGNodeLayoutGetTop(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild3));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild3));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild4));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild4));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild4));
        }

        [Test]
        public void align_content_stretch_is_not_overriding_align_items()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(rootChild0, FlexDirection.Row);
            YGNodeStyleSetAlignContent(rootChild0, YogaAlign.Stretch);
            YGNodeStyleSetAlignItems(rootChild0, YogaAlign.Center);
            YGNodeStyleSetWidth(rootChild0, 100);
            YGNodeStyleSetHeight(rootChild0, 100);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(rootChild0Child0, YogaAlign.Stretch);
            YGNodeStyleSetWidth(rootChild0Child0, 10);
            YGNodeStyleSetHeight(rootChild0Child0, 10);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(45, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(45, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0Child0));
        }
    }
}
