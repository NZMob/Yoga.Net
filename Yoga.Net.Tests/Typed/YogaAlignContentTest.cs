using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaAlignContentTest
    {
        [Test]
        public void align_content_flex_start()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(flexDirection: FlexDirection.Row, flexWrap: Wrap.Wrap, width: 130, height: 100)
                           .Add(rootChild0 = Node(width: 50, height: 10))
                           .Add(rootChild1 = Node(width: 50, height: 10))
                           .Add(rootChild2 = Node(width: 50, height: 10))
                           .Add(rootChild3 = Node(width: 50, height: 10))
                           .Add(rootChild4 = Node(width: 50, height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(130, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(10, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);

            Assert.AreEqual(50, rootChild3.Layout.Left);
            Assert.AreEqual(10, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(10, rootChild3.Layout.Height);

            Assert.AreEqual(0, rootChild4.Layout.Left);
            Assert.AreEqual(20, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(10, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(130, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(30, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(80, rootChild2.Layout.Left);
            Assert.AreEqual(10, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);

            Assert.AreEqual(30, rootChild3.Layout.Left);
            Assert.AreEqual(10, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(10, rootChild3.Layout.Height);

            Assert.AreEqual(80, rootChild4.Layout.Left);
            Assert.AreEqual(20, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(10, rootChild4.Layout.Height);
        }

        [Test]
        public void align_content_flex_start_without_height_on_children()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(flexWrap: Wrap.Wrap, width: 100, height: 100)
                           .Add(rootChild0 = Node(width: 50))
                           .Add(rootChild1 = Node(width: 50, height: 10))
                           .Add(rootChild2 = Node(width: 50))
                           .Add(rootChild3 = Node(width: 50, height: 10))
                           .Add(rootChild4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(0, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(10, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(0, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(10, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(10, rootChild3.Layout.Height);

            Assert.AreEqual(0, rootChild4.Layout.Left);
            Assert.AreEqual(20, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(0, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(0, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(50, rootChild2.Layout.Left);
            Assert.AreEqual(10, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(0, rootChild2.Layout.Height);

            Assert.AreEqual(50, rootChild3.Layout.Left);
            Assert.AreEqual(10, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(10, rootChild3.Layout.Height);

            Assert.AreEqual(50, rootChild4.Layout.Left);
            Assert.AreEqual(20, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(0, rootChild4.Layout.Height);
        }

        [Test]
        public void align_content_flex_start_with_flex()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(flexWrap: Wrap.Wrap, width: 100, height: 120)
                           .Add(rootChild0 = Node(flexGrow:1, flexBasis:0.Percent(), width: 50))
                           .Add(rootChild1 = Node(flexGrow:1, flexBasis:0.Percent(), width: 50, height: 10))
                           .Add(rootChild2 = Node(width: 50))
                           .Add(rootChild3 = Node(flexGrow:1, flexShrink:1,  flexBasis:0.Percent(), width: 50))
                           .Add(rootChild4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(120, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(40, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(40, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(80, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(0, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(80, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(40, rootChild3.Layout.Height);

            Assert.AreEqual(0, rootChild4.Layout.Left);
            Assert.AreEqual(120, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(0, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(120, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(40, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(40, rootChild1.Layout.Height);

            Assert.AreEqual(50, rootChild2.Layout.Left);
            Assert.AreEqual(80, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(0, rootChild2.Layout.Height);

            Assert.AreEqual(50, rootChild3.Layout.Left);
            Assert.AreEqual(80, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(40, rootChild3.Layout.Height);

            Assert.AreEqual(50, rootChild4.Layout.Left);
            Assert.AreEqual(120, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(0, rootChild4.Layout.Height);
        }

        [Ignore("Exactly the same results as the C++ library")]
        [Test]
        public void align_content_flex_end()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(alignContent:YogaAlign.FlexEnd, flexWrap:Wrap.Wrap, width: 100, height: 100)
                           .Add(rootChild0 = Node(width: 50, height: 10))
                           .Add(rootChild1 = Node(width: 50, height: 10))
                           .Add(rootChild2 = Node(width: 50, height: 10))
                           .Add(rootChild3 = Node(width: 50, height: 10))
                           .Add(rootChild4 = Node(width: 50, height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(10, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(20, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(30, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(10, rootChild3.Layout.Height);

            Assert.AreEqual(0, rootChild4.Layout.Left);
            Assert.AreEqual(40, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(10, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(10, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(50, rootChild2.Layout.Left);
            Assert.AreEqual(20, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);

            Assert.AreEqual(50, rootChild3.Layout.Left);
            Assert.AreEqual(30, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(10, rootChild3.Layout.Height);

            Assert.AreEqual(50, rootChild4.Layout.Left);
            Assert.AreEqual(40, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(10, rootChild4.Layout.Height);
        }

        [Test]
        public void align_content_stretch()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(alignContent:YogaAlign.Stretch, flexWrap:Wrap.Wrap, width: 150, height: 100)
                           .Add(rootChild0 = Node(width: 50))
                           .Add(rootChild1 = Node(width: 50))
                           .Add(rootChild2 = Node(width: 50))
                           .Add(rootChild3 = Node(width: 50))
                           .Add(rootChild4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(0, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(0, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(0, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(0, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(0, rootChild3.Layout.Height);

            Assert.AreEqual(0, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(0, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(0, rootChild0.Layout.Height);

            Assert.AreEqual(100, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(0, rootChild1.Layout.Height);

            Assert.AreEqual(100, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(0, rootChild2.Layout.Height);

            Assert.AreEqual(100, rootChild3.Layout.Left);
            Assert.AreEqual(0, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(0, rootChild3.Layout.Height);

            Assert.AreEqual(100, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(0, rootChild4.Layout.Height);
        }

        [Test]
        public void align_content_spacebetween()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.SpaceBetween, flexWrap:Wrap.Wrap, width: 130, height: 100)
                           .Add(rootChild0 = Node(width: 50, height: 10))
                           .Add(rootChild1 = Node(width: 50, height: 10))
                           .Add(rootChild2 = Node(width: 50, height: 10))
                           .Add(rootChild3 = Node(width: 50, height: 10))
                           .Add(rootChild4 = Node(width: 50, height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(130, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(45, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);

            Assert.AreEqual(50, rootChild3.Layout.Left);
            Assert.AreEqual(45, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(10, rootChild3.Layout.Height);

            Assert.AreEqual(0, rootChild4.Layout.Left);
            Assert.AreEqual(90, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(10, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(130, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(80, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(30, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(80, rootChild2.Layout.Left);
            Assert.AreEqual(45, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);

            Assert.AreEqual(30, rootChild3.Layout.Left);
            Assert.AreEqual(45, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(10, rootChild3.Layout.Height);

            Assert.AreEqual(80, rootChild4.Layout.Left);
            Assert.AreEqual(90, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(10, rootChild4.Layout.Height);
        }

        [Test]
        public void align_content_spacearound()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.SpaceAround, flexWrap:Wrap.Wrap, width: 140, height: 120)
                           .Add(rootChild0 = Node(width: 50, height: 10))
                           .Add(rootChild1 = Node(width: 50, height: 10))
                           .Add(rootChild2 = Node(width: 50, height: 10))
                           .Add(rootChild3 = Node(width: 50, height: 10))
                           .Add(rootChild4 = Node(width: 50, height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(140, root.Layout.Width);
            Assert.AreEqual(120, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(15, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(15, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(55, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);

            Assert.AreEqual(50, rootChild3.Layout.Left);
            Assert.AreEqual(55, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(10, rootChild3.Layout.Height);

            Assert.AreEqual(0, rootChild4.Layout.Left);
            Assert.AreEqual(95, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(10, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(140, root.Layout.Width);
            Assert.AreEqual(120, root.Layout.Height);

            Assert.AreEqual(90, rootChild0.Layout.Left);
            Assert.AreEqual(15, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(40, rootChild1.Layout.Left);
            Assert.AreEqual(15, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(90, rootChild2.Layout.Left);
            Assert.AreEqual(55, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);

            Assert.AreEqual(40, rootChild3.Layout.Left);
            Assert.AreEqual(55, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(10, rootChild3.Layout.Height);

            Assert.AreEqual(90, rootChild4.Layout.Left);
            Assert.AreEqual(95, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(10, rootChild4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.Stretch, flexWrap:Wrap.Wrap, width: 150, height: 100)
                           .Add(rootChild0 = Node(width: 50))
                           .Add(rootChild1 = Node(width: 50))
                           .Add(rootChild2 = Node(width: 50))
                           .Add(rootChild3 = Node(width: 50))
                           .Add(rootChild4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            Assert.AreEqual(100, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(50, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(50, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(50, rootChild3.Layout.Height);

            Assert.AreEqual(50, rootChild4.Layout.Left);
            Assert.AreEqual(50, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(50, rootChild2.Layout.Height);

            Assert.AreEqual(100, rootChild3.Layout.Left);
            Assert.AreEqual(50, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(50, rootChild3.Layout.Height);

            Assert.AreEqual(50, rootChild4.Layout.Left);
            Assert.AreEqual(50, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_children()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4, rootChild0Child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignContent: YogaAlign.Stretch, flexWrap: Wrap.Wrap, width: 150, height: 100)
                           .Add(
                                rootChild0 = Node(width: 50)
                                   .Add(rootChild0Child0 = Node(flexGrow: 1, flexShrink: 1, flexBasis: 0.Percent()))
                            )
                           .Add(rootChild1 = Node(width: 50))
                           .Add(rootChild2 = Node(width: 50))
                           .Add(rootChild3 = Node(width: 50))
                           .Add(rootChild4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(50, rootChild0Child0.Layout.Width);
            Assert.AreEqual(50, rootChild0Child0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            Assert.AreEqual(100, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(50, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(50, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(50, rootChild3.Layout.Height);

            Assert.AreEqual(50, rootChild4.Layout.Left);
            Assert.AreEqual(50, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(50, rootChild0Child0.Layout.Width);
            Assert.AreEqual(50, rootChild0Child0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(50, rootChild2.Layout.Height);

            Assert.AreEqual(100, rootChild3.Layout.Left);
            Assert.AreEqual(50, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(50, rootChild3.Layout.Height);

            Assert.AreEqual(50, rootChild4.Layout.Left);
            Assert.AreEqual(50, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_flex()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.Stretch, flexWrap:Wrap.Wrap, width: 150, height: 100)
                           .Add(rootChild0 = Node(width: 50))
                           .Add(rootChild1 = Node(flexGrow:1, flexShrink:1, flexBasis:0.Percent(), width: 50))
                           .Add(rootChild2 = Node(width: 50))
                           .Add(rootChild3 = Node(flexGrow:1, flexShrink:1, flexBasis:0.Percent(), width: 50))
                           .Add(rootChild4 = Node(width: 50));
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(0, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            Assert.AreEqual(50, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);

            Assert.AreEqual(100, rootChild3.Layout.Left);
            Assert.AreEqual(0, rootChild3.Layout.Top);
            Assert.AreEqual(0, rootChild3.Layout.Width);
            Assert.AreEqual(100, rootChild3.Layout.Height);

            Assert.AreEqual(100, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(100, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(100, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(0, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            Assert.AreEqual(50, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);

            Assert.AreEqual(50, rootChild3.Layout.Left);
            Assert.AreEqual(0, rootChild3.Layout.Top);
            Assert.AreEqual(0, rootChild3.Layout.Width);
            Assert.AreEqual(100, rootChild3.Layout.Height);

            Assert.AreEqual(0, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(100, rootChild4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_flex_no_shrink()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.Stretch, flexWrap:Wrap.Wrap, width: 150, height: 100)
                           .Add(rootChild0 = Node(width: 50))
                           .Add(rootChild1 = Node(flexGrow:1, flexShrink:1, flexBasis:0.Percent(), width: 50))
                           .Add(rootChild2 = Node(width: 50))
                           .Add(rootChild3 = Node(flexGrow:1, flexShrink:1, flexBasis:0.Percent(), width: 50))
                           .Add(rootChild4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(0, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            Assert.AreEqual(50, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);

            Assert.AreEqual(100, rootChild3.Layout.Left);
            Assert.AreEqual(0, rootChild3.Layout.Top);
            Assert.AreEqual(0, rootChild3.Layout.Width);
            Assert.AreEqual(100, rootChild3.Layout.Height);

            Assert.AreEqual(100, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(100, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(100, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(0, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            Assert.AreEqual(50, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);

            Assert.AreEqual(50, rootChild3.Layout.Left);
            Assert.AreEqual(0, rootChild3.Layout.Top);
            Assert.AreEqual(0, rootChild3.Layout.Width);
            Assert.AreEqual(100, rootChild3.Layout.Height);

            Assert.AreEqual(0, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(100, rootChild4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_margin()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.Stretch, flexWrap:Wrap.Wrap, width: 150, height: 100)
                           .Add(rootChild0 = Node(width: 50))
                           .Add(rootChild1 = Node(width: 50, margin:new Edges(10)))
                           .Add(rootChild2 = Node(width: 50))
                           .Add(rootChild3 = Node(width: 50, margin:new Edges(10)))
                           .Add(rootChild4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);

            Assert.AreEqual(60, rootChild1.Layout.Left);
            Assert.AreEqual(10, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(40, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(40, rootChild2.Layout.Height);

            Assert.AreEqual(60, rootChild3.Layout.Left);
            Assert.AreEqual(50, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(20, rootChild3.Layout.Height);

            Assert.AreEqual(0, rootChild4.Layout.Left);
            Assert.AreEqual(80, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(20, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(40, rootChild0.Layout.Height);

            Assert.AreEqual(40, rootChild1.Layout.Left);
            Assert.AreEqual(10, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(100, rootChild2.Layout.Left);
            Assert.AreEqual(40, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(40, rootChild2.Layout.Height);

            Assert.AreEqual(40, rootChild3.Layout.Left);
            Assert.AreEqual(50, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(20, rootChild3.Layout.Height);

            Assert.AreEqual(100, rootChild4.Layout.Left);
            Assert.AreEqual(80, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(20, rootChild4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_padding()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.Stretch, flexWrap:Wrap.Wrap, width: 150, height: 100)
                           .Add(rootChild0 = Node(width: 50))
                           .Add(rootChild1 = Node(width: 50, padding:new Edges(10)))
                           .Add(rootChild2 = Node(width: 50))
                           .Add(rootChild3 = Node(width: 50, padding:new Edges(10)))
                           .Add(rootChild4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            Assert.AreEqual(100, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(50, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(50, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(50, rootChild3.Layout.Height);

            Assert.AreEqual(50, rootChild4.Layout.Left);
            Assert.AreEqual(50, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(50, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(50, rootChild2.Layout.Height);

            Assert.AreEqual(100, rootChild3.Layout.Left);
            Assert.AreEqual(50, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(50, rootChild3.Layout.Height);

            Assert.AreEqual(50, rootChild4.Layout.Left);
            Assert.AreEqual(50, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_single_row()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(flexDirection: FlexDirection.Row, alignContent: YogaAlign.Stretch, flexWrap: Wrap.Wrap, width: 150, height: 100)
                           .Add(rootChild0 = Node(width: 50))
                           .Add(rootChild1 = Node(width: 50));
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_fixed_height()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.Stretch, flexWrap:Wrap.Wrap, width: 150, height: 100)
                           .Add(rootChild0 = Node(width: 50))
                           .Add(rootChild1 = Node(width: 50, height:60))
                           .Add(rootChild2 = Node(width: 50))
                           .Add(rootChild3 = Node(width: 50))
                           .Add(rootChild4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(80, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(60, rootChild1.Layout.Height);

            Assert.AreEqual(100, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(80, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(80, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(20, rootChild3.Layout.Height);

            Assert.AreEqual(50, rootChild4.Layout.Left);
            Assert.AreEqual(80, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(20, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(80, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(60, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(80, rootChild2.Layout.Height);

            Assert.AreEqual(100, rootChild3.Layout.Left);
            Assert.AreEqual(80, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(20, rootChild3.Layout.Height);

            Assert.AreEqual(50, rootChild4.Layout.Left);
            Assert.AreEqual(80, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(20, rootChild4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_max_height()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.Stretch, flexWrap:Wrap.Wrap, width: 150, height: 100)
                           .Add(rootChild0 = Node(width: 50))
                           .Add(rootChild1 = Node(width: 50, maxHeight:20))
                           .Add(rootChild2 = Node(width: 50))
                           .Add(rootChild3 = Node(width: 50))
                           .Add(rootChild4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(100, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(50, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(50, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(50, rootChild3.Layout.Height);

            Assert.AreEqual(50, rootChild4.Layout.Left);
            Assert.AreEqual(50, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(20, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(50, rootChild2.Layout.Height);

            Assert.AreEqual(100, rootChild3.Layout.Left);
            Assert.AreEqual(50, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(50, rootChild3.Layout.Height);

            Assert.AreEqual(50, rootChild4.Layout.Left);
            Assert.AreEqual(50, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_row_with_min_height()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4;
            YogaNode root = Node(flexDirection:FlexDirection.Row, alignContent:YogaAlign.Stretch, flexWrap:Wrap.Wrap, width: 150, height: 100)
                           .Add(rootChild0 = Node(width: 50))
                           .Add(rootChild1 = Node(width: 50, minHeight:80))
                           .Add(rootChild2 = Node(width: 50))
                           .Add(rootChild3 = Node(width: 50))
                           .Add(rootChild4 = Node(width: 50));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(90, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(90, rootChild1.Layout.Height);

            Assert.AreEqual(100, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(90, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(90, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(10, rootChild3.Layout.Height);

            Assert.AreEqual(50, rootChild4.Layout.Left);
            Assert.AreEqual(90, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(10, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(150, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(100, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(90, rootChild0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(90, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(90, rootChild2.Layout.Height);

            Assert.AreEqual(100, rootChild3.Layout.Left);
            Assert.AreEqual(90, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(10, rootChild3.Layout.Height);

            Assert.AreEqual(50, rootChild4.Layout.Left);
            Assert.AreEqual(90, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(10, rootChild4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_column()
        {
            YogaNode rootChild0, rootChild1, rootChild2, rootChild3, rootChild4, rootChild0Child0;
            YogaNode root = Node(alignContent:YogaAlign.Stretch, flexWrap:Wrap.Wrap, width: 100, height: 150)
                           .Add(rootChild0 = Node(height: 50)
                               .Add(rootChild0Child0 = Node(flexGrow:1, flexShrink:1, flexBasis:0.Percent()))
                            )
                           .Add(rootChild1 = Node(flexGrow:1, flexShrink:1, flexBasis:0.Percent(), height: 50))
                           .Add(rootChild2 = Node(height: 50))
                           .Add(rootChild3 = Node(height: 50))
                           .Add(rootChild4 = Node(height: 50));


            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(150, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(50, rootChild0Child0.Layout.Width);
            Assert.AreEqual(50, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(0, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(50, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(50, rootChild2.Layout.Height);

            Assert.AreEqual(0, rootChild3.Layout.Left);
            Assert.AreEqual(100, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(50, rootChild3.Layout.Height);

            Assert.AreEqual(50, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(150, root.Layout.Height);

            Assert.AreEqual(50, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(50, rootChild0.Layout.Width);
            Assert.AreEqual(50, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(50, rootChild0Child0.Layout.Width);
            Assert.AreEqual(50, rootChild0Child0.Layout.Height);

            Assert.AreEqual(50, rootChild1.Layout.Left);
            Assert.AreEqual(50, rootChild1.Layout.Top);
            Assert.AreEqual(50, rootChild1.Layout.Width);
            Assert.AreEqual(0, rootChild1.Layout.Height);

            Assert.AreEqual(50, rootChild2.Layout.Left);
            Assert.AreEqual(50, rootChild2.Layout.Top);
            Assert.AreEqual(50, rootChild2.Layout.Width);
            Assert.AreEqual(50, rootChild2.Layout.Height);

            Assert.AreEqual(50, rootChild3.Layout.Left);
            Assert.AreEqual(100, rootChild3.Layout.Top);
            Assert.AreEqual(50, rootChild3.Layout.Width);
            Assert.AreEqual(50, rootChild3.Layout.Height);

            Assert.AreEqual(0, rootChild4.Layout.Left);
            Assert.AreEqual(0, rootChild4.Layout.Top);
            Assert.AreEqual(50, rootChild4.Layout.Width);
            Assert.AreEqual(50, rootChild4.Layout.Height);
        }

        [Test]
        public void align_content_stretch_is_not_overriding_align_items()
        {
            YogaNode rootChild0, rootChild0Child0;
            YogaNode root = Node(alignContent: YogaAlign.Stretch)
               .Add(
                    rootChild0 = Node(flexDirection: FlexDirection.Row, alignContent: YogaAlign.Stretch, alignItems: YogaAlign.Center, width: 100, height: 100)
                       .Add(rootChild0Child0 = Node(alignContent:YogaAlign.Stretch, width:10, height:10))
                );
           
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(45, rootChild0Child0.Layout.Top);
            Assert.AreEqual(10, rootChild0Child0.Layout.Width);
            Assert.AreEqual(10, rootChild0Child0.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(90, rootChild0Child0.Layout.Left);
            Assert.AreEqual(45, rootChild0Child0.Layout.Top);
            Assert.AreEqual(10, rootChild0Child0.Layout.Width);
            Assert.AreEqual(10, rootChild0Child0.Layout.Height);
        }
    }
}
