using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaHadOverflowTest
    {
        [SetUp]
        public void Setup()
        {
            _config = new YogaConfig();
            _root   = Node(_config, width:200, height:100);
        }

        YogaNode _root;
        YogaConfig _config;

        [Test]
        public void children_overflow_no_wrap_and_no_flex_children()
        {
            _root.Children.Add(Node(_config, width: 80, height: 40, margin: new Edges(top: 10, bottom: 15)));
            _root.Children.Add(Node(_config, width: 80, height: 40, margin: new Edges(bottom: 5)));

            YogaArrange.CalculateLayout(_root, 200, 100, Direction.LTR);

            Assert.IsTrue(_root.Layout.HadOverflow);
        }

        [Test]
        public void spacing_overflow_no_wrap_and_no_flex_children()
        {
            _root.Children.Add(Node(_config, width: 80, height: 40, margin: new Edges(top: 10, bottom: 10)));
            _root.Children.Add(Node(_config, width: 80, height: 40, margin: new Edges(bottom: 5)));

            YogaArrange.CalculateLayout(_root, 200, 100, Direction.LTR);

            Assert.IsTrue(_root.Layout.HadOverflow);
        }

        [Test]
        public void no_overflow_no_wrap_and_flex_children()
        {
            _root.Children.Add(Node(_config, width: 80, height: 40, margin: new Edges(top: 10, bottom: 10)));
            _root.Children.Add(Node(_config, width: 80, height: 40, margin: new Edges(bottom: 5), flexShrink: 1));

            YogaArrange.CalculateLayout(_root, 200, 100, Direction.LTR);

            Assert.IsFalse(_root.Layout.HadOverflow);
        }

        [Test]
        public void hadOverflow_gets_reset_if_not_logger_valid()
        {
            YogaNode child1;
            _root.Children.Add(Node(_config, width: 80, height: 40, margin: new Edges(top: 10, bottom: 10)));
            _root.Children.Add(child1 = Node(_config, width: 80, height: 40, margin: new Edges(bottom: 5)));

            YogaArrange.CalculateLayout(_root, 200, 100, Direction.LTR);

            Assert.IsTrue(_root.Layout.HadOverflow);

            child1.Style.FlexShrink = 1;

            YogaArrange.CalculateLayout(_root, 200, 100, Direction.LTR);

            Assert.IsFalse(_root.Layout.HadOverflow);
        }

        [Test]
        public void spacing_overflow_in_nested_nodes()
        {
            _root.Children.Add(Node(_config, width: 80, height: 40, margin: new Edges(top: 10, bottom: 10)));
            _root.Children.Add(
                Node(_config, width: 80, height: 40)
                   .Add(Node(width: 80, height: 40, margin: new Edges(bottom: 5)))
            );

            YogaArrange.CalculateLayout(_root, 200, 100, Direction.LTR);

            Assert.IsTrue(_root.Layout.HadOverflow);
        }
    }
}
