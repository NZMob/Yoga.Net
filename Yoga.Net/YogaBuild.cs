namespace Yoga.Net
{
    public class YogaBuild
    {
        public YogaNode Value { get; }

        public YogaBuild(YogaNode value)
        {
            Value = value;
        }

        public static YogaBuild Node(
            YogaConfig config = null,
            Direction direction = Direction.Inherit,
            FlexDirection flexDirection = FlexDirection.Column,
            Justify justifyContent = Justify.FlexStart,
            YogaAlign alignContent = YogaAlign.FlexStart,
            YogaAlign alignItems = YogaAlign.Stretch,
            YogaAlign alignSelf = YogaAlign.Auto,
            float aspectRatio = Net.YogaValue.YGUndefined,
            PositionType positionType = PositionType.Relative,
            Wrap flexWrap = Wrap.NoWrap,
            Overflow overflow = Overflow.Visible,
            Display display = Display.Flex,
            float flex = float.NaN,
            float flexGrow = float.NaN,
            float flexShrink = float.NaN,
            YogaValue flexBasis = null, // YogaValue.Auto,
            YogaValue width = null,     // YogaValue.Auto,
            YogaValue height = null,    // YogaValue.Auto,
            YogaValue minWidth = null,  // YogaValue.Undefined,
            YogaValue minHeight = null, // YogaValue.Undefined,
            YogaValue maxWidth = null,  // YogaValue.Undefined,
            YogaValue maxHeight = null, // YogaValue.Undefined,
            YogaValue left = null,
            YogaValue top = null,
            YogaValue right = null,
            YogaValue bottom = null,
            YogaValue start = null,
            YogaValue end = null,
            Edges margin = null,
            Edges position = null,
            Edges padding = null,
            Edges border = null,
            MeasureFunc measureFunc = null
        )
        {
            var node = new YogaNode(config)
            {
                Style = new YogaStyle
                {
                    Direction      = direction,
                    FlexDirection  = flexDirection,
                    JustifyContent = justifyContent,
                    AlignContent   = alignContent,
                    AlignItems     = alignItems,
                    AlignSelf      = alignSelf,
                    AspectRatio    = aspectRatio,
                    PositionType   = positionType,
                    FlexWrap       = flexWrap,
                    Overflow       = overflow,
                    Display        = display,
                    Flex           = flex,
                    FlexGrow       = flexGrow,
                    FlexShrink     = flexShrink,
                    FlexBasis      = flexBasis ?? YogaValue.Auto,
                    Width          = width ?? YogaValue.Auto,
                    Height         = height ?? YogaValue.Auto,
                    MinWidth       = minWidth ?? YogaValue.Undefined,
                    MinHeight      = minHeight ?? YogaValue.Undefined,
                    MaxWidth       = maxWidth ?? YogaValue.Undefined,
                    MaxHeight      = maxHeight ?? YogaValue.Undefined
                }
            };
            if (margin != null) node.Style.Margin        = margin;
            if (position != null) node.Style.Position    = position;
            if (padding != null) node.Style.Padding      = padding;
            if (border != null) node.Style.Border        = border;
            if (start != null) node.Style.Position.Start = start;
            if (end != null) node.Style.Position.End     = end;
            if (left != null) node.Style.Left            = left;
            if (top != null) node.Style.Top              = top;
            if (right != null) node.Style.Right          = right;
            if (bottom != null) node.Style.Bottom        = bottom;

            if (measureFunc != null) node.MeasureFunc = measureFunc;

            return new YogaBuild(node);
        }

        public YogaBuild Add(YogaNode child)
        {
            Value.Children.Add(child);
            return this;
        }

        public static implicit operator YogaNode(YogaBuild build) => build.Value;
    }
}
