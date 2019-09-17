using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGHadOverflowTest
    {
        [SetUp]
        public void Setup()
        {
            _config = YGConfigNew();
            _root   = YGNodeNewWithConfig(_config);
            YGNodeStyleSetWidth(_root, 200);
            YGNodeStyleSetHeight(_root, 100);
            YGNodeStyleSetFlexDirection(_root, FlexDirection.Column);
            YGNodeStyleSetFlexWrap(_root, Wrap.NoWrap);
        }

        [TearDown]
        public void Teardown()
        {
            _root   = null;
            _config = null;
            //
            //
        }

        YogaNode _root;
        YogaConfig _config;

        [Test]
        public void children_overflow_no_wrap_and_no_flex_children()
        {
            YogaNode child0 = YGNodeNewWithConfig(_config);
            YGNodeStyleSetWidth(child0, 80);
            YGNodeStyleSetHeight(child0, 40);
            YGNodeStyleSetMargin(child0, Edge.Top, 10);
            YGNodeStyleSetMargin(child0, Edge.Bottom, 15);
            YGNodeInsertChild(_root, child0, 0);
            YogaNode child1 = YGNodeNewWithConfig(_config);
            YGNodeStyleSetWidth(child1, 80);
            YGNodeStyleSetHeight(child1, 40);
            YGNodeStyleSetMargin(child1, Edge.Bottom, 5);
            YGNodeInsertChild(_root, child1, 1);

            YGNodeCalculateLayout(_root, 200, 100, Direction.LTR);

            Assert.IsTrue(YGNodeLayoutGetHadOverflow(_root));
        }

        [Test]
        public void spacing_overflow_no_wrap_and_no_flex_children()
        {
            YogaNode child0 = YGNodeNewWithConfig(_config);
            YGNodeStyleSetWidth(child0, 80);
            YGNodeStyleSetHeight(child0, 40);
            YGNodeStyleSetMargin(child0, Edge.Top, 10);
            YGNodeStyleSetMargin(child0, Edge.Bottom, 10);
            YGNodeInsertChild(_root, child0, 0);
            YogaNode child1 = YGNodeNewWithConfig(_config);
            YGNodeStyleSetWidth(child1, 80);
            YGNodeStyleSetHeight(child1, 40);
            YGNodeStyleSetMargin(child1, Edge.Bottom, 5);
            YGNodeInsertChild(_root, child1, 1);

            YGNodeCalculateLayout(_root, 200, 100, Direction.LTR);

            Assert.IsTrue(YGNodeLayoutGetHadOverflow(_root));
        }

        [Test]
        public void no_overflow_no_wrap_and_flex_children()
        {
            YogaNode child0 = YGNodeNewWithConfig(_config);
            YGNodeStyleSetWidth(child0, 80);
            YGNodeStyleSetHeight(child0, 40);
            YGNodeStyleSetMargin(child0, Edge.Top, 10);
            YGNodeStyleSetMargin(child0, Edge.Bottom, 10);
            YGNodeInsertChild(_root, child0, 0);
            YogaNode child1 = YGNodeNewWithConfig(_config);
            YGNodeStyleSetWidth(child1, 80);
            YGNodeStyleSetHeight(child1, 40);
            YGNodeStyleSetMargin(child1, Edge.Bottom, 5);
            YGNodeStyleSetFlexShrink(child1, 1);
            YGNodeInsertChild(_root, child1, 1);

            YGNodeCalculateLayout(_root, 200, 100, Direction.LTR);

            Assert.IsFalse(YGNodeLayoutGetHadOverflow(_root));
        }

        [Test]
        public void hadOverflow_gets_reset_if_not_logger_valid()
        {
            YogaNode child0 = YGNodeNewWithConfig(_config);
            YGNodeStyleSetWidth(child0, 80);
            YGNodeStyleSetHeight(child0, 40);
            YGNodeStyleSetMargin(child0, Edge.Top, 10);
            YGNodeStyleSetMargin(child0, Edge.Bottom, 10);
            YGNodeInsertChild(_root, child0, 0);
            YogaNode child1 = YGNodeNewWithConfig(_config);
            YGNodeStyleSetWidth(child1, 80);
            YGNodeStyleSetHeight(child1, 40);
            YGNodeStyleSetMargin(child1, Edge.Bottom, 5);
            YGNodeInsertChild(_root, child1, 1);

            YGNodeCalculateLayout(_root, 200, 100, Direction.LTR);

            Assert.IsTrue(YGNodeLayoutGetHadOverflow(_root));

            YGNodeStyleSetFlexShrink(child1, 1);

            YGNodeCalculateLayout(_root, 200, 100, Direction.LTR);

            Assert.IsFalse(YGNodeLayoutGetHadOverflow(_root));
        }

        [Test]
        public void spacing_overflow_in_nested_nodes()
        {
            YogaNode child0 = YGNodeNewWithConfig(_config);
            YGNodeStyleSetWidth(child0, 80);
            YGNodeStyleSetHeight(child0, 40);
            YGNodeStyleSetMargin(child0, Edge.Top, 10);
            YGNodeStyleSetMargin(child0, Edge.Bottom, 10);
            YGNodeInsertChild(_root, child0, 0);
            YogaNode child1 = YGNodeNewWithConfig(_config);
            YGNodeStyleSetWidth(child1, 80);
            YGNodeStyleSetHeight(child1, 40);
            YGNodeInsertChild(_root, child1, 1);
            YogaNode child11 = YGNodeNewWithConfig(_config);
            YGNodeStyleSetWidth(child11, 80);
            YGNodeStyleSetHeight(child11, 40);
            YGNodeStyleSetMargin(child11, Edge.Bottom, 5);
            YGNodeInsertChild(child1, child11, 0);

            YGNodeCalculateLayout(_root, 200, 100, Direction.LTR);

            Assert.IsTrue(YGNodeLayoutGetHadOverflow(_root));
        }
    }
}
