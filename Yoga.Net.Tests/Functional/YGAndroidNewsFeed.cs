using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGAndroidNewsFeed
    {
        [Test]
        public void android_news_feed()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(root, YogaAlign.Stretch);
            YGNodeStyleSetWidth(root, 1080);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(rootChild0Child0, YogaAlign.Stretch);
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            YogaNode rootChild0Child0Child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(rootChild0Child0Child0, YogaAlign.Stretch);
            YGNodeInsertChild(rootChild0Child0, rootChild0Child0Child0, 0);

            YogaNode rootChild0Child0Child0Child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(
                rootChild0Child0Child0Child0,
                FlexDirection.Row);
            YGNodeStyleSetAlignContent(rootChild0Child0Child0Child0, YogaAlign.Stretch);
            YGNodeStyleSetAlignItems(rootChild0Child0Child0Child0, YogaAlign.FlexStart);
            YGNodeStyleSetMargin(rootChild0Child0Child0Child0, Edge.Start, 36);
            YGNodeStyleSetMargin(rootChild0Child0Child0Child0, Edge.Top, 24);
            YGNodeInsertChild(
                rootChild0Child0Child0,
                rootChild0Child0Child0Child0,
                0);

            YogaNode rootChild0Child0Child0Child0Child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(
                rootChild0Child0Child0Child0Child0,
                FlexDirection.Row);
            YGNodeStyleSetAlignContent(
                rootChild0Child0Child0Child0Child0,
                YogaAlign.Stretch);
            YGNodeInsertChild(
                rootChild0Child0Child0Child0,
                rootChild0Child0Child0Child0Child0,
                0);

            YogaNode rootChild0Child0Child0Child0Child0Child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(
                rootChild0Child0Child0Child0Child0Child0,
                YogaAlign.Stretch);
            YGNodeStyleSetWidth(rootChild0Child0Child0Child0Child0Child0, 120);
            YGNodeStyleSetHeight(rootChild0Child0Child0Child0Child0Child0, 120);
            YGNodeInsertChild(
                rootChild0Child0Child0Child0Child0,
                rootChild0Child0Child0Child0Child0Child0,
                0);

            YogaNode rootChild0Child0Child0Child0Child1 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(
                rootChild0Child0Child0Child0Child1,
                YogaAlign.Stretch);
            YGNodeStyleSetFlexShrink(rootChild0Child0Child0Child0Child1, 1);
            YGNodeStyleSetMargin(
                rootChild0Child0Child0Child0Child1,
                Edge.Right,
                36);
            YGNodeStyleSetPadding(
                rootChild0Child0Child0Child0Child1,
                Edge.Left,
                36);
            YGNodeStyleSetPadding(rootChild0Child0Child0Child0Child1, Edge.Top, 21);
            YGNodeStyleSetPadding(
                rootChild0Child0Child0Child0Child1,
                Edge.Right,
                36);
            YGNodeStyleSetPadding(
                rootChild0Child0Child0Child0Child1,
                Edge.Bottom,
                18);
            YGNodeInsertChild(
                rootChild0Child0Child0Child0,
                rootChild0Child0Child0Child0Child1,
                1);

            YogaNode rootChild0Child0Child0Child0Child1Child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(
                rootChild0Child0Child0Child0Child1Child0,
                FlexDirection.Row);
            YGNodeStyleSetAlignContent(
                rootChild0Child0Child0Child0Child1Child0,
                YogaAlign.Stretch);
            YGNodeStyleSetFlexShrink(rootChild0Child0Child0Child0Child1Child0, 1);
            YGNodeInsertChild(
                rootChild0Child0Child0Child0Child1,
                rootChild0Child0Child0Child0Child1Child0,
                0);

            YogaNode rootChild0Child0Child0Child0Child1Child1 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(
                rootChild0Child0Child0Child0Child1Child1,
                YogaAlign.Stretch);
            YGNodeStyleSetFlexShrink(rootChild0Child0Child0Child0Child1Child1, 1);
            YGNodeInsertChild(
                rootChild0Child0Child0Child0Child1,
                rootChild0Child0Child0Child0Child1Child1,
                1);

            YogaNode rootChild0Child0Child1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(rootChild0Child0Child1, YogaAlign.Stretch);
            YGNodeInsertChild(rootChild0Child0, rootChild0Child0Child1, 1);

            YogaNode rootChild0Child0Child1Child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(
                rootChild0Child0Child1Child0,
                FlexDirection.Row);
            YGNodeStyleSetAlignContent(rootChild0Child0Child1Child0, YogaAlign.Stretch);
            YGNodeStyleSetAlignItems(rootChild0Child0Child1Child0, YogaAlign.FlexStart);
            YGNodeStyleSetMargin(rootChild0Child0Child1Child0, Edge.Start, 174);
            YGNodeStyleSetMargin(rootChild0Child0Child1Child0, Edge.Top, 24);
            YGNodeInsertChild(
                rootChild0Child0Child1,
                rootChild0Child0Child1Child0,
                0);

            YogaNode rootChild0Child0Child1Child0Child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(
                rootChild0Child0Child1Child0Child0,
                FlexDirection.Row);
            YGNodeStyleSetAlignContent(
                rootChild0Child0Child1Child0Child0,
                YogaAlign.Stretch);
            YGNodeInsertChild(
                rootChild0Child0Child1Child0,
                rootChild0Child0Child1Child0Child0,
                0);

            YogaNode rootChild0Child0Child1Child0Child0Child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(
                rootChild0Child0Child1Child0Child0Child0,
                YogaAlign.Stretch);
            YGNodeStyleSetWidth(rootChild0Child0Child1Child0Child0Child0, 72);
            YGNodeStyleSetHeight(rootChild0Child0Child1Child0Child0Child0, 72);
            YGNodeInsertChild(
                rootChild0Child0Child1Child0Child0,
                rootChild0Child0Child1Child0Child0Child0,
                0);

            YogaNode rootChild0Child0Child1Child0Child1 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(
                rootChild0Child0Child1Child0Child1,
                YogaAlign.Stretch);
            YGNodeStyleSetFlexShrink(rootChild0Child0Child1Child0Child1, 1);
            YGNodeStyleSetMargin(
                rootChild0Child0Child1Child0Child1,
                Edge.Right,
                36);
            YGNodeStyleSetPadding(
                rootChild0Child0Child1Child0Child1,
                Edge.Left,
                36);
            YGNodeStyleSetPadding(rootChild0Child0Child1Child0Child1, Edge.Top, 21);
            YGNodeStyleSetPadding(
                rootChild0Child0Child1Child0Child1,
                Edge.Right,
                36);
            YGNodeStyleSetPadding(
                rootChild0Child0Child1Child0Child1,
                Edge.Bottom,
                18);
            YGNodeInsertChild(
                rootChild0Child0Child1Child0,
                rootChild0Child0Child1Child0Child1,
                1);

            YogaNode rootChild0Child0Child1Child0Child1Child0 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(
                rootChild0Child0Child1Child0Child1Child0,
                FlexDirection.Row);
            YGNodeStyleSetAlignContent(
                rootChild0Child0Child1Child0Child1Child0,
                YogaAlign.Stretch);
            YGNodeStyleSetFlexShrink(rootChild0Child0Child1Child0Child1Child0, 1);
            YGNodeInsertChild(
                rootChild0Child0Child1Child0Child1,
                rootChild0Child0Child1Child0Child1Child0,
                0);

            YogaNode rootChild0Child0Child1Child0Child1Child1 =
                YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignContent(
                rootChild0Child0Child1Child0Child1Child1,
                YogaAlign.Stretch);
            YGNodeStyleSetFlexShrink(rootChild0Child0Child1Child0Child1Child1, 1);
            YGNodeInsertChild(
                rootChild0Child0Child1Child0Child1,
                rootChild0Child0Child1Child0Child1Child1,
                1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(240, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(240, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(240, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(144, YGNodeLayoutGetHeight(rootChild0Child0Child0));

            Assert.AreEqual(36, YGNodeLayoutGetLeft(rootChild0Child0Child0Child0));
            Assert.AreEqual(24, YGNodeLayoutGetTop(rootChild0Child0Child0Child0));
            Assert.AreEqual(1044, YGNodeLayoutGetWidth(rootChild0Child0Child0Child0));
            Assert.AreEqual(120, YGNodeLayoutGetHeight(rootChild0Child0Child0Child0));

            Assert.AreEqual(
                0,
                YGNodeLayoutGetLeft(rootChild0Child0Child0Child0Child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(rootChild0Child0Child0Child0Child0));
            Assert.AreEqual(
                120,
                YGNodeLayoutGetWidth(rootChild0Child0Child0Child0Child0));
            Assert.AreEqual(
                120,
                YGNodeLayoutGetHeight(rootChild0Child0Child0Child0Child0));

            Assert.AreEqual(
                0,
                YGNodeLayoutGetLeft(rootChild0Child0Child0Child0Child0Child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(rootChild0Child0Child0Child0Child0Child0));
            Assert.AreEqual(
                120,
                YGNodeLayoutGetWidth(rootChild0Child0Child0Child0Child0Child0));
            Assert.AreEqual(
                120,
                YGNodeLayoutGetHeight(rootChild0Child0Child0Child0Child0Child0));

            Assert.AreEqual(
                120,
                YGNodeLayoutGetLeft(rootChild0Child0Child0Child0Child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(rootChild0Child0Child0Child0Child1));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetWidth(rootChild0Child0Child0Child0Child1));
            Assert.AreEqual(
                39,
                YGNodeLayoutGetHeight(rootChild0Child0Child0Child0Child1));

            Assert.AreEqual(
                36,
                YGNodeLayoutGetLeft(rootChild0Child0Child0Child0Child1Child0));
            Assert.AreEqual(
                21,
                YGNodeLayoutGetTop(rootChild0Child0Child0Child0Child1Child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetWidth(rootChild0Child0Child0Child0Child1Child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetHeight(rootChild0Child0Child0Child0Child1Child0));

            Assert.AreEqual(
                36,
                YGNodeLayoutGetLeft(rootChild0Child0Child0Child0Child1Child1));
            Assert.AreEqual(
                21,
                YGNodeLayoutGetTop(rootChild0Child0Child0Child0Child1Child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetWidth(rootChild0Child0Child0Child0Child1Child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetHeight(rootChild0Child0Child0Child0Child1Child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child1));
            Assert.AreEqual(144, YGNodeLayoutGetTop(rootChild0Child0Child1));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(rootChild0Child0Child1));
            Assert.AreEqual(96, YGNodeLayoutGetHeight(rootChild0Child0Child1));

            Assert.AreEqual(174, YGNodeLayoutGetLeft(rootChild0Child0Child1Child0));
            Assert.AreEqual(24, YGNodeLayoutGetTop(rootChild0Child0Child1Child0));
            Assert.AreEqual(906, YGNodeLayoutGetWidth(rootChild0Child0Child1Child0));
            Assert.AreEqual(72, YGNodeLayoutGetHeight(rootChild0Child0Child1Child0));

            Assert.AreEqual(
                0,
                YGNodeLayoutGetLeft(rootChild0Child0Child1Child0Child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(rootChild0Child0Child1Child0Child0));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetWidth(rootChild0Child0Child1Child0Child0));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetHeight(rootChild0Child0Child1Child0Child0));

            Assert.AreEqual(
                0,
                YGNodeLayoutGetLeft(rootChild0Child0Child1Child0Child0Child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(rootChild0Child0Child1Child0Child0Child0));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetWidth(rootChild0Child0Child1Child0Child0Child0));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetHeight(rootChild0Child0Child1Child0Child0Child0));

            Assert.AreEqual(
                72,
                YGNodeLayoutGetLeft(rootChild0Child0Child1Child0Child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(rootChild0Child0Child1Child0Child1));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetWidth(rootChild0Child0Child1Child0Child1));
            Assert.AreEqual(
                39,
                YGNodeLayoutGetHeight(rootChild0Child0Child1Child0Child1));

            Assert.AreEqual(
                36,
                YGNodeLayoutGetLeft(rootChild0Child0Child1Child0Child1Child0));
            Assert.AreEqual(
                21,
                YGNodeLayoutGetTop(rootChild0Child0Child1Child0Child1Child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetWidth(rootChild0Child0Child1Child0Child1Child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetHeight(rootChild0Child0Child1Child0Child1Child0));

            Assert.AreEqual(
                36,
                YGNodeLayoutGetLeft(rootChild0Child0Child1Child0Child1Child1));
            Assert.AreEqual(
                21,
                YGNodeLayoutGetTop(rootChild0Child0Child1Child0Child1Child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetWidth(rootChild0Child0Child1Child0Child1Child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetHeight(rootChild0Child0Child1Child0Child1Child1));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(240, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(240, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(rootChild0Child0));
            Assert.AreEqual(240, YGNodeLayoutGetHeight(rootChild0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0Child0Child0));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(rootChild0Child0Child0));
            Assert.AreEqual(144, YGNodeLayoutGetHeight(rootChild0Child0Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child0Child0));
            Assert.AreEqual(24, YGNodeLayoutGetTop(rootChild0Child0Child0Child0));
            Assert.AreEqual(1044, YGNodeLayoutGetWidth(rootChild0Child0Child0Child0));
            Assert.AreEqual(120, YGNodeLayoutGetHeight(rootChild0Child0Child0Child0));

            Assert.AreEqual(
                924,
                YGNodeLayoutGetLeft(rootChild0Child0Child0Child0Child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(rootChild0Child0Child0Child0Child0));
            Assert.AreEqual(
                120,
                YGNodeLayoutGetWidth(rootChild0Child0Child0Child0Child0));
            Assert.AreEqual(
                120,
                YGNodeLayoutGetHeight(rootChild0Child0Child0Child0Child0));

            Assert.AreEqual(
                0,
                YGNodeLayoutGetLeft(rootChild0Child0Child0Child0Child0Child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(rootChild0Child0Child0Child0Child0Child0));
            Assert.AreEqual(
                120,
                YGNodeLayoutGetWidth(rootChild0Child0Child0Child0Child0Child0));
            Assert.AreEqual(
                120,
                YGNodeLayoutGetHeight(rootChild0Child0Child0Child0Child0Child0));

            Assert.AreEqual(
                816,
                YGNodeLayoutGetLeft(rootChild0Child0Child0Child0Child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(rootChild0Child0Child0Child0Child1));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetWidth(rootChild0Child0Child0Child0Child1));
            Assert.AreEqual(
                39,
                YGNodeLayoutGetHeight(rootChild0Child0Child0Child0Child1));

            Assert.AreEqual(
                36,
                YGNodeLayoutGetLeft(rootChild0Child0Child0Child0Child1Child0));
            Assert.AreEqual(
                21,
                YGNodeLayoutGetTop(rootChild0Child0Child0Child0Child1Child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetWidth(rootChild0Child0Child0Child0Child1Child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetHeight(rootChild0Child0Child0Child0Child1Child0));

            Assert.AreEqual(
                36,
                YGNodeLayoutGetLeft(rootChild0Child0Child0Child0Child1Child1));
            Assert.AreEqual(
                21,
                YGNodeLayoutGetTop(rootChild0Child0Child0Child0Child1Child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetWidth(rootChild0Child0Child0Child0Child1Child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetHeight(rootChild0Child0Child0Child0Child1Child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child1));
            Assert.AreEqual(144, YGNodeLayoutGetTop(rootChild0Child0Child1));
            Assert.AreEqual(1080, YGNodeLayoutGetWidth(rootChild0Child0Child1));
            Assert.AreEqual(96, YGNodeLayoutGetHeight(rootChild0Child0Child1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0Child0Child1Child0));
            Assert.AreEqual(24, YGNodeLayoutGetTop(rootChild0Child0Child1Child0));
            Assert.AreEqual(906, YGNodeLayoutGetWidth(rootChild0Child0Child1Child0));
            Assert.AreEqual(72, YGNodeLayoutGetHeight(rootChild0Child0Child1Child0));

            Assert.AreEqual(
                834,
                YGNodeLayoutGetLeft(rootChild0Child0Child1Child0Child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(rootChild0Child0Child1Child0Child0));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetWidth(rootChild0Child0Child1Child0Child0));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetHeight(rootChild0Child0Child1Child0Child0));

            Assert.AreEqual(
                0,
                YGNodeLayoutGetLeft(rootChild0Child0Child1Child0Child0Child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(rootChild0Child0Child1Child0Child0Child0));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetWidth(rootChild0Child0Child1Child0Child0Child0));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetHeight(rootChild0Child0Child1Child0Child0Child0));

            Assert.AreEqual(
                726,
                YGNodeLayoutGetLeft(rootChild0Child0Child1Child0Child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetTop(rootChild0Child0Child1Child0Child1));
            Assert.AreEqual(
                72,
                YGNodeLayoutGetWidth(rootChild0Child0Child1Child0Child1));
            Assert.AreEqual(
                39,
                YGNodeLayoutGetHeight(rootChild0Child0Child1Child0Child1));

            Assert.AreEqual(
                36,
                YGNodeLayoutGetLeft(rootChild0Child0Child1Child0Child1Child0));
            Assert.AreEqual(
                21,
                YGNodeLayoutGetTop(rootChild0Child0Child1Child0Child1Child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetWidth(rootChild0Child0Child1Child0Child1Child0));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetHeight(rootChild0Child0Child1Child0Child1Child0));

            Assert.AreEqual(
                36,
                YGNodeLayoutGetLeft(rootChild0Child0Child1Child0Child1Child1));
            Assert.AreEqual(
                21,
                YGNodeLayoutGetTop(rootChild0Child0Child1Child0Child1Child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetWidth(rootChild0Child0Child1Child0Child1Child1));
            Assert.AreEqual(
                0,
                YGNodeLayoutGetHeight(rootChild0Child0Child1Child0Child1Child1));
        }
    }
}
