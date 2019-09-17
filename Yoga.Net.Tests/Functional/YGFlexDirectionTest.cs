using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGFlexDirectionTest
    {
        [Test]
        public void flex_direction_column_no_height()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);

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
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(30, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void flex_direction_row_no_width()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetHeight(root, 100);

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
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(20, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(30, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(20, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void flex_direction_column()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

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
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(20, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void flex_direction_row()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

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
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(20, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void flex_direction_column_reverse()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.ColumnReverse);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

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
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(90, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(70, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(90, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(80, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(70, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild2));
        }

        [Test]
        public void flex_direction_row_reverse()
        {
            YogaConfig config = YGConfigNew();

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexDirection(root, FlexDirection.RowReverse);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

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
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(90, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(80, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(70, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(10, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(20, YGNodeLayoutGetLeft(rootChild2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild2));
            Assert.AreEqual(10, YGNodeLayoutGetWidth(rootChild2));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild2));
        }
    }
}
