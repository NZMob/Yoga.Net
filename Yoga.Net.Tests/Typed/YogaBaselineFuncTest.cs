using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaBaselineFuncTest
    {
        static BaselineFunc _baseline = (node, width, height, context) => (float)node.Context;

        [Test]
        public void align_baseline_customer_func()
        {
            float baselineValue = 10;

            YogaNode rootChild0, rootChild1, rootChild1Child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignItems: YogaAlign.Baseline, width: 100, height: 100)
                           .Add(rootChild0 = Node(width: 50, height: 50))
                           .Add(rootChild1 = Node(width:50, height:20)
                               .Add(rootChild1Child0 = Node(width:50, height:20))
                            );

            rootChild1Child0.Context = baselineValue;
            rootChild1Child0.BaselineFunc = _baseline;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(40, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild1Child0.Layout.Left);
            Assert.AreEqual(0, rootChild1Child0.Layout.Top);
            Assert.AreEqual(50, rootChild1Child0.Layout.Width);
            Assert.AreEqual(20, rootChild1Child0.Layout.Height);
        }
    }
}
