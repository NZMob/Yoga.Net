using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGNodeChildTest
    {
        [Test]
        public void reset_layout_when_child_removed()
        {
            YogaNode root = YGNodeNew();

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetWidth(rootChild0, 100);
            YGNodeStyleSetHeight(rootChild0, 100);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));

            YGNodeRemoveChild(root, rootChild0);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.IsTrue(YGNodeLayoutGetWidth(rootChild0).IsUndefined());
            Assert.IsTrue(YGNodeLayoutGetHeight(rootChild0).IsUndefined());
        }
    }
}
