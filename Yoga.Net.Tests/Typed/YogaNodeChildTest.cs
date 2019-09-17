using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaNodeChildTest
    {
        [Test]
        public void reset_layout_when_child_removed()
        {
            YogaNode rootChild0;
            YogaNode root = Node()
               .Add(rootChild0 = Node(width: 100, height: 100));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            root.Children.Remove(rootChild0);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.IsTrue(rootChild0.Layout.Width.IsUndefined());
            Assert.IsTrue(rootChild0.Layout.Height.IsUndefined());
        }
    }
}
