using System.Diagnostics;
using System.Text;
using static Yoga.Net.YogaMath;

namespace Yoga.Net
{
    public class YogaNodePrint
    {
        StringBuilder _sb;
        PrintOptions _options;
        YogaNode _currentNode;

        public static YogaNode DefaultYogaNode { get; } = new YogaNode();

        public YogaNodePrint(PrintOptions printOptions, StringBuilder sb = null)
        {
            _options = printOptions;
            _sb = sb ?? new StringBuilder();
        }

        void Indent(int level)
        {
            for (int i = 0; i < level; ++i)
                AppendString("  ");
        }

        bool AreFourValuesEqual(EdgesReadonly four)
        {
            return
                four[Edge.Left] == four[Edge.Top] &&
                four[Edge.Left] == four[Edge.Right] &&
                four[Edge.Left] == four[Edge.Bottom];
        }

        void AppendString(string str)
        {
            _currentNode?.Config?.LoggerFunc(LogLevel.Info, str);
            _sb.Append(str);
        }

        void AppendFloatOptionalIfDefined(
            string key,
            float num)
        {
            if (num.HasValue())
                AppendString($"{key}: {num:G}; ");
        }

        void AppendNumberIfNotUndefined(
            string key,
            YogaValue number)
        {
            if (number.Unit == YogaUnit.Undefined)
                return;

            if (number.Unit == YogaUnit.Auto)
                AppendString($"{key}: auto; ");
            else
                AppendString($"{key}: {number}; ");
        }

        void AppendNumberIfNotAuto(
            string key,
            YogaValue number)
        {
            if (number.Unit != YogaUnit.Auto)
                AppendNumberIfNotUndefined(key, number);
        }

        void AppendNumberIfNotZero(
            string str,
            YogaValue number)
        {
            if (number.Unit == YogaUnit.Auto)
            {
                AppendString(str + ": auto; ");
            }
            else if (!FloatsEqual(number.Value, 0))
            {
                AppendNumberIfNotUndefined(str, number);
            }
        }

        void AppendEdges(string key, EdgesReadonly edges)
        {
            if (AreFourValuesEqual(edges))
            {
                AppendNumberIfNotZero(key, edges[Edge.Left]);
            }
            else
            {
                for (var edge = Edge.Left; edge != Edge.All; ++edge)
                {
                    string str = key + "-" + (edge.ToString().ToLower());
                    AppendNumberIfNotZero(str, edges[edge]);
                }
            }
        }

        void AppendEdgeIfNotUndefined(string str, EdgesReadonly edges, Edge edge)
        {
            AppendNumberIfNotUndefined(str, edges.ComputedEdgeValue(edge, YogaValue.Undefined));
        }

        public YogaNodePrint Output(YogaNode node, int level = 0)
        {
            _currentNode = node;
            Indent(level);
            AppendString("<div ");

            if (!string.IsNullOrWhiteSpace(node.Trace))
                AppendString(node.Trace + "; ");

            if (_options.HasFlag(PrintOptions.Layout))
            {
                AppendString("layout=\"");
                AppendString($"width: {node.Layout.Width:G};");
                AppendString($" height: {node.Layout.Height:G};");
                AppendString($" top: {node.Layout.Top:G};");
                AppendString($" left: {node.Layout.Left:G};");
                if (!node.Layout.Margin.IsZero)
                    AppendString($" margin: {node.Layout.Margin};");
                if (!node.Layout.Border.IsZero)
                    AppendString($" border: {node.Layout.Border};");
                if (!node.Layout.Padding.IsZero)
                    AppendString($" padding: {node.Layout.Padding};");
                AppendString("\" ");
            }

            if (_options.HasFlag(PrintOptions.Style))
            {
                AppendString("style=\"");
                if (node.Style.FlexDirection != DefaultYogaNode.Style.FlexDirection)
                {
                    AppendString($"flex-direction: {node.Style.FlexDirection.ToString().ToLower()}; ");
                }

                if (node.Style.JustifyContent != DefaultYogaNode.Style.JustifyContent)
                {
                    AppendString($"justify-content: {node.Style.JustifyContent.ToString().ToLower()}; ");
                }

                if (node.Style.AlignItems != DefaultYogaNode.Style.AlignItems)
                {
                    AppendString($"align-items: {node.Style.AlignItems.ToString().ToLower()}; ");
                }

                if (node.Style.AlignContent != DefaultYogaNode.Style.AlignContent)
                {
                    AppendString($"align-content: {node.Style.AlignContent.ToString().ToLower()}; ");
                }

                if (node.Style.AlignSelf != DefaultYogaNode.Style.AlignSelf)
                {
                    AppendString($"align-self: {node.Style.AlignSelf.ToString().ToLower()}; ");
                }

                AppendNumberIfNotZero("flex-grow", node.StyleReadonly.FlexGrow);
                AppendNumberIfNotZero("flex-shrink", node.StyleReadonly.FlexShrink);
                AppendNumberIfNotAuto("flex-basis", node.Style.FlexBasis);
                AppendFloatOptionalIfDefined("flex", node.StyleReadonly.Flex);

                if (node.Style.FlexWrap != DefaultYogaNode.Style.FlexWrap)
                {
                    AppendString($"flex-wrap: {node.Style.FlexWrap.ToString().ToLower()}; ");
                }

                if (node.Style.Overflow != DefaultYogaNode.Style.Overflow)
                {
                    AppendString($"overflow: {node.Style.Overflow.ToString().ToLower()}; ");
                }

                if (node.Style.Display != DefaultYogaNode.Style.Display)
                {
                    AppendString($"display: {node.Style.Display.ToString().ToLower()}; ");
                }

                AppendEdges("margin", node.Style.Margin);
                AppendEdges("padding", node.Style.Padding);
                AppendEdges("border", node.Style.Border);

                AppendNumberIfNotAuto("width", node.Style.Width);
                AppendNumberIfNotAuto("height", node.Style.Height);
                AppendNumberIfNotAuto("max-width", node.Style.MaxWidth);
                AppendNumberIfNotAuto("max-height", node.Style.MaxHeight);
                AppendNumberIfNotAuto("min-width", node.Style.MinWidth);
                AppendNumberIfNotAuto("min-height", node.Style.MinHeight);

                if (node.Style.PositionType != DefaultYogaNode.Style.PositionType)
                {
                    AppendString($"position: {node.Style.PositionType.ToString().ToLower()}; ");
                }

                AppendEdgeIfNotUndefined("left", node.Style.Position, Edge.Left);
                AppendEdgeIfNotUndefined("right", node.Style.Position, Edge.Right);
                AppendEdgeIfNotUndefined("top", node.Style.Position, Edge.Top);
                AppendEdgeIfNotUndefined("bottom", node.Style.Position, Edge.Bottom);
                AppendString("\" ");

                if (node.HasMeasureFunc)
                {
                    AppendString("has-custom-measure=\"true\"");
                }
            }

            AppendString(">");

            var childCount = node.Children.Count;
            if (_options.HasFlag(PrintOptions.Children) && childCount > 0)
            {
                for (int i = 0; i < childCount; i++)
                {
                    AppendString("\n");
                    Output(node.Children[i], level + 1);
                    _currentNode = node;
                }

                AppendString("\n");
                Indent(level);
            }

            AppendString("</div>");

            return this;
        }

        [Conditional("DEBUG")]
        public static void Output(string message, YogaNode node, PrintOptions options = PrintOptions.Layout | PrintOptions.Style | PrintOptions.Children)
        {
            var print = new YogaNodePrint(options);
            print.Output(node);
            Logger.Log(LogLevel.Debug, "\n" + message);
            Logger.Log(LogLevel.Debug, print.ToString());
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return _sb.ToString();
        }
    }
}
