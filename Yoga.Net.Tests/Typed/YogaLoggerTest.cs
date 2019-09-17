using NUnit.Framework;
using System.Text;

using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaLoggerTest
    {
        StringBuilder _writeBuffer;

        [SetUp]
        public void Init()
        {
            _writeBuffer = new StringBuilder();
        }

        int _unmanagedLogger(
            LogLevel level,
            string message)
        {
            _writeBuffer.Append(message);
            return _writeBuffer.Length;
        }

        [Test]
        public void config_print_tree_enabled()
        {
            YogaConfig config = new YogaConfig {PrintTree = true, LoggerFunc = _unmanagedLogger};

            YogaNode root = Node(config)
                           .Add(Node(config))
                           .Add(Node(config));
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            config.LoggerFunc = null;

            string expected =
                "<div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" >\n  <div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>\n  <div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>\n</div>";
            Assert.AreEqual(expected, _writeBuffer.ToString());
        }

        [Test]
        public void config_print_tree_disabled()
        {
            YogaConfig config = new YogaConfig {PrintTree = false, LoggerFunc = _unmanagedLogger};
            
            YogaNode root = Node(config)
                           .Add(Node(config))
                           .Add(Node(config));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            config.LoggerFunc = null;

            string expected = "";
            Assert.AreEqual(expected, _writeBuffer.ToString());
        }

        [Test]
        public void logger_default_node_should_print_no_style_info()
        {
            YogaConfig config = new YogaConfig {LoggerFunc = _unmanagedLogger};

            YogaNode root = Node(config);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            new YogaNodePrint(PrintOptions.Layout | PrintOptions.Children | PrintOptions.Style)
               .Output(root);

            string expected = "<div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>";
            Assert.AreEqual(expected, _writeBuffer.ToString());
        }

        [Test]
        public void logger_node_with_percentage_absolute_position_and_margin()
        {
            YogaConfig config = new YogaConfig {LoggerFunc = _unmanagedLogger};

            YogaNode root = Node(config, 
                positionType:PositionType.Absolute, 
                width:50.Percent(), 
                height:75.Percent(), 
                flex:1, 
                margin:new Edges(right:10, left:YogaValue.Auto));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            new YogaNodePrint(PrintOptions.Layout | PrintOptions.Children | PrintOptions.Style)
               .Output(root);

            string expected = "<div layout=\"width: 0; height: 0; top: 0; left: 0; margin: (0, 0, 10, 0);\" style=\"flex: 1; margin-left: auto; margin-right: 10px; width: 50%; height: 75%; position: absolute; \" ></div>";
            Assert.AreEqual(expected, _writeBuffer.ToString());
        }

        [Test]
        public void logger_node_with_children_should_print_indented()
        {
            YogaConfig config = new YogaConfig {LoggerFunc = _unmanagedLogger};

            YogaNode root = Node(config)
                           .Add(Node(config))
                           .Add(Node(config));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            new YogaNodePrint(PrintOptions.Layout | PrintOptions.Children | PrintOptions.Style)
               .Output(root);

            string expected = "<div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" >\n  <div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>\n  <div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>\n</div>";
            Assert.AreEqual(expected, _writeBuffer.ToString());
        }
    }
}
