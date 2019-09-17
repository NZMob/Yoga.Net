using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGBaselineFuncTest
    {
        static BaselineFunc _baseline = (YogaNode node, float width, float height, object context) => { return (float)node.Context; };

        [Test]
        public void align_baseline_customer_func()
        {
            YogaNode root = YGNodeNew();
            YGNodeStyleSetFlexDirection(root, FlexDirection.Row);
            YGNodeStyleSetAlignItems(root, YogaAlign.Baseline);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild0, 50);
            YGNodeStyleSetHeight(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild1, 50);
            YGNodeStyleSetHeight(rootChild1, 20);
            YGNodeInsertChild(root, rootChild1, 1);

            float baselineValue = 10;
            YogaNode rootChild1Child0 = YGNodeNew();
            rootChild1Child0.Context = baselineValue;
            YGNodeStyleSetWidth(rootChild1Child0, 50);
            rootChild1Child0.BaselineFunc = _baseline;
            YGNodeStyleSetHeight(rootChild1Child0, 20);
            YGNodeInsertChild(rootChild1, rootChild1Child0, 0);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(50, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(50, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(40, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild1Child0));
            Assert.AreEqual(50, YGNodeLayoutGetWidth(rootChild1Child0));
            Assert.AreEqual(20, YGNodeLayoutGetHeight(rootChild1Child0));
        }
    }
}
