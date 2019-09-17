using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGJustifyContentTest
    {
        [Test]
        public void justify_content_row_flex_start()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(20, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(92, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(82, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(72, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void justify_content_row_flex_end()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.FlexEnd);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(72, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(82, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(92, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(20, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void justify_content_row_center()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(36, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(46, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(56, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(56, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(46, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(36, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void justify_content_row_space_between()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.SpaceBetween);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(46, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(92, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(92, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(46, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void justify_content_row_space_around()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.SpaceAround);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(12, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(46, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(46, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(12, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void justify_content_column_flex_start()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void justify_content_column_flex_end()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.FlexEnd);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(72, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(82, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(92, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(72, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(82, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(92, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void justify_content_column_center()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(36, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(46, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(56, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(36, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(46, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(56, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void justify_content_column_space_between()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.SpaceBetween);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(46, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(92, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(46, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(92, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void justify_content_column_space_around()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.SpaceAround);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(12, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(46, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(12, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(46, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void justify_content_row_min_width_and_margin()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetMargin(root, Edge.Left, 100);
            YGNodeStyleSetMinWidth(root, 50);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 20);
            YGNodeStyleSetHeight(rootChild0, 20);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(15, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(15, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void justify_content_min_width_with_padding_child_width_greater_than_parent()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetWidth(root, 1000);
            YGNodeStyleSetHeight(root, 1584);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(rootChild0, FlexDirection.Row);
            YGNodeStyleSetAlignContent(rootChild0, YogaAlign.Stretch);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(rootChild0Child0, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(rootChild0Child0, Justify.Center);
            YGNodeStyleSetAlignContent(rootChild0Child0, YogaAlign.Stretch);
            YGNodeStyleSetMinWidth(rootChild0Child0, 400);
            YGNodeStyleSetPadding(rootChild0Child0, Edge.Horizontal, 100);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild0Child0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(rootChild0Child0Child0, FlexDirection.Row);
            YGNodeStyleSetAlignContent(rootChild0Child0Child0, YogaAlign.Stretch);
            YGNodeStyleSetWidth(rootChild0Child0Child0, 300);
            YGNodeStyleSetHeight(rootChild0Child0Child0, 100);
            YGNodeInsertChild(rootChild0Child0, rootChild0Child0Child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(1000, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(1584, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(1000, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(300, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child0Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(1000, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(1584, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(1000, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(500, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(500, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(100, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(300, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child0Child0));
        }

        [Test]
        public void justify_content_min_width_with_padding_child_width_lower_than_parent()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetWidth(root, 1080);
            YGNodeStyleSetHeight(root, 1584);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(rootChild0, FlexDirection.Row);
            YGNodeStyleSetAlignContent(rootChild0, YogaAlign.Stretch);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(rootChild0Child0, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(rootChild0Child0, Justify.Center);
            YGNodeStyleSetAlignContent(rootChild0Child0, YogaAlign.Stretch);
            YGNodeStyleSetMinWidth(rootChild0Child0, 400);
            YGNodeStyleSetPadding(rootChild0Child0, Edge.Horizontal, 100);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild0Child0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(rootChild0Child0Child0, FlexDirection.Row);
            YGNodeStyleSetAlignContent(rootChild0Child0Child0, YogaAlign.Stretch);
            YGNodeStyleSetWidth(rootChild0Child0Child0, 199);
            YGNodeStyleSetHeight(rootChild0Child0Child0, 100);
            YGNodeInsertChild(rootChild0Child0, rootChild0Child0Child0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(1584, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(400, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(101, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(199, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child0Child0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(1584, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(680, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(400, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(101, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(199, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0Child0Child0));
            //
        }

        [Test]
        public void justify_content_row_max_width_and_margin()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetMargin(root, Edge.Left, 100);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetMaxWidth(root, 80);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 20);
            YGNodeStyleSetHeight(rootChild0, 20);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(100, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(80, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(30, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void justify_content_column_min_height_and_margin()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetMargin(root, Edge.Top, 100);
            YGNodeStyleSetMinHeight(root, 50);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 20);
            YGNodeStyleSetHeight(rootChild0, 20);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(100, YGNodeLayoutGetTop(root));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(15, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(100, YGNodeLayoutGetTop(root));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(15, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void justify_content_column_max_height_and_margin()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.Center);
            YGNodeStyleSetMargin(root, Edge.Top, 100);
            YGNodeStyleSetHeight(root, 100);
            YGNodeStyleSetMaxHeight(root, 80);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(rootChild0, 20);
            YGNodeStyleSetHeight(rootChild0, 20);
            YGNodeInsertChild(root, rootChild0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(100, YGNodeLayoutGetTop(root));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(100, YGNodeLayoutGetTop(root));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(80, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(30, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void justify_content_column_space_evenly()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetJustifyContent(root, Justify.SpaceEvenly);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(18, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(46, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(74, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(18, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(46, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(74, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void justify_content_row_space_evenly()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetJustifyContent(root, Justify.SpaceEvenly);
            YGNodeStyleSetWidth(root, 102);
            YGNodeStyleSetHeight(root, 102);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild1, 10);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeight(rootChild2, 10);
            YGNodeInsertChild(root, rootChild2, 2);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(26, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(51, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(77, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(102, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(102, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(77, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(51, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(26, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));
        }
    }
}
