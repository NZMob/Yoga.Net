using System;

namespace Yoga.Net
{
    public enum YogaAlign
    {
        Auto,
        FlexStart,
        Center,
        FlexEnd,
        Stretch,
        Baseline,
        SpaceBetween,
        SpaceAround
    }

    public enum Dimension
    {
        Width,
        Height
    }

    public enum Direction
    {
        Unknown = -1,

        /// <summary>Inherit from owner</summary>
        Inherit = 0,

        /// <summary>Left to right</summary>
        LTR = 1,

        /// <summary>Right to left</summary>
        RTL = 2
    }

    public enum Display
    {
        Flex,
        None
    }

    public enum Edge
    {
        Left,
        Top,
        Right,
        Bottom,
        Start,
        End,
        Horizontal,
        Vertical,
        All
    }

    public enum ExperimentalFeature
    {
        WebFlexBasis
    }

    public enum FlexDirection
    {
        Column,
        ColumnReverse,
        Row,
        RowReverse
    }

    public enum Justify
    {
        FlexStart,
        Center,
        FlexEnd,
        SpaceBetween,
        SpaceAround,
        SpaceEvenly
    }

    public enum LogLevel
    {
        Error,
        Warn,
        Info,
        Debug,
        Verbose,
        Fatal
    }

    public enum MeasureMode
    {
        Undefined = -1,
        Exactly = 0,
        AtMost = 1
    }

    public enum NodeType
    {
        Default,
        Text
    }

    public enum Overflow
    {
        Visible,
        Hidden,
        Scroll
    }

    public enum PositionType
    {
        Relative,
        Absolute
    }


    [Flags]
    public enum PrintOptions
    {
        Layout = 1,
        Style = 2,
        Children = 4
    }

    public enum YogaUnit
    {
        Undefined,
        Point,
        Percent,
        Auto
    }

    public enum Wrap
    {
        NoWrap,
        Wrap,
        WrapReverse
    }
}
