using NUnit.Framework;
using static Yoga.Net.YogaGlobal;
using System.Text;

namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGLoggerTest
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
            YogaConfig config = YGConfigNew();
            YGConfigSetPrintTreeFlag(config, true);
            YGConfigSetLogger(config, _unmanagedLogger);
            YogaNode root = YGNodeNewWithConfig(config);
            YogaNode child0 = YGNodeNewWithConfig(config);
            YogaNode child1 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, child0, 0);
            YGNodeInsertChild(root, child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            YGConfigSetLogger(config, null);


            string expected =
                "<div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" >\n  <div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>\n  <div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>\n</div>";
            Assert.AreEqual(expected, _writeBuffer.ToString());
        }

        [Test]
        public void config_print_tree_disabled()
        {
            YogaConfig config = YGConfigNew();
            YGConfigSetPrintTreeFlag(config, false);
            YGConfigSetLogger(config, _unmanagedLogger);
            YogaNode root = YGNodeNewWithConfig(config);
            YogaNode child0 = YGNodeNewWithConfig(config);
            YogaNode child1 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, child0, 0);
            YGNodeInsertChild(root, child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            YGConfigSetLogger(config, null);


            string expected = "";
            Assert.AreEqual(expected, _writeBuffer.ToString());
        }

        [Test]
        public void logger_default_node_should_print_no_style_info()
        {
            YogaConfig config = YGConfigNew();
            YGConfigSetLogger(config, _unmanagedLogger);
            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            YGNodePrint(root, (PrintOptions.Layout | PrintOptions.Children | PrintOptions.Style));
            YGConfigSetLogger(config, null);


            string expected = "<div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>";
            Assert.AreEqual(expected, _writeBuffer.ToString());
        }

        [Test]
        public void logger_node_with_percentage_absolute_position_and_margin()
        {
            YogaConfig config = YGConfigNew();
            YGConfigSetLogger(config, _unmanagedLogger);
            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetPositionType(root, PositionType.Absolute);
            YGNodeStyleSetWidthPercent(root, 50);
            YGNodeStyleSetHeightPercent(root, 75);
            YGNodeStyleSetFlex(root, 1);
            YGNodeStyleSetMargin(root, Edge.Right, 10);
            YGNodeStyleSetMarginAuto(root, Edge.Left);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            YGNodePrint(root, (PrintOptions.Layout | PrintOptions.Children | PrintOptions.Style));
            YGConfigSetLogger(config, null);


            string expected = "<div layout=\"width: 0; height: 0; top: 0; left: 0; margin: (0, 0, 10, 0);\" style=\"flex: 1; margin-left: auto; margin-right: 10px; width: 50%; height: 75%; position: absolute; \" ></div>";
            Assert.AreEqual(expected, _writeBuffer.ToString());
        }

        [Test]
        public void logger_node_with_children_should_print_indented()
        {
            YogaConfig config = YGConfigNew();
            YGConfigSetLogger(config, _unmanagedLogger);
            YogaNode root = YGNodeNewWithConfig(config);
            YogaNode child0 = YGNodeNewWithConfig(config);
            YogaNode child1 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, child0, 0);
            YGNodeInsertChild(root, child1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            YGNodePrint(root, (PrintOptions.Layout | PrintOptions.Children | PrintOptions.Style));
            YGConfigSetLogger(config, null);


            string expected = "<div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" >\n  <div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>\n  <div layout=\"width: 0; height: 0; top: 0; left: 0;\" style=\"\" ></div>\n</div>";
            Assert.AreEqual(expected, _writeBuffer.ToString());
        }
    }
}
