using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaBorderTest
    {
        [Test]
        public void border_no_size()
        {
            YogaConfig config = new YogaConfig();

            YogaNode root = Node(config, border: new Edges(left: 10, top: 10, right: 10, bottom: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(20, root.Layout.Width);
            Assert.AreEqual(20, root.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(20, root.Layout.Width);
            Assert.AreEqual(20, root.Layout.Height);
        }

        [Test]
        public void border_container_match_child()
        {
            YogaConfig config = new YogaConfig();

            YogaNode rootChild0;
            YogaNode root = Node(config, border: new Edges(left: 10, top: 10, right: 10, bottom: 10))
               .Add(rootChild0 = Node(width: 10, height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(30, root.Layout.Width);
            Assert.AreEqual(30, root.Layout.Height);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(30, root.Layout.Width);
            Assert.AreEqual(30, root.Layout.Height);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);
        }

        [Test]
        public void border_flex_child()
        {
            YogaConfig config = new YogaConfig();

            YogaNode rootChild0;
            YogaNode root = Node(config, border: new Edges(left: 10, top: 10, right: 10, bottom: 10), width: 100, height: 100)
               .Add(rootChild0 = Node(flexGrow: 1, width: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(80, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(80, rootChild0.Layout.Height);
        }

        [Test]
        public void border_stretch_child()
        {
            YogaConfig config = new YogaConfig();

            YogaNode rootChild0;
            YogaNode root = Node(config, border: new Edges(left: 10, top: 10, right: 10, bottom: 10), width: 100, height: 100)
               .Add(rootChild0 = Node(height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(80, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(10, rootChild0.Layout.Left);
            Assert.AreEqual(10, rootChild0.Layout.Top);
            Assert.AreEqual(80, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);
        }

        [Test]
        public void border_center_child()
        {
            YogaConfig config = new YogaConfig();

            YogaNode rootChild0;
            YogaNode root = Node(config, justifyContent: Justify.Center, alignItems: YogaAlign.Center, border: new Edges(start: 10, end: 20, bottom: 20), width: 100, height: 100)
               .Add(rootChild0 = Node(width: 10, height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(40, rootChild0.Layout.Left);
            Assert.AreEqual(35, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(35, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);
        }
    }
}
