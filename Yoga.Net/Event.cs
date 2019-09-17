using System;

namespace Yoga.Net
{
    public enum LayoutType
    {
        Layout = 0,
        Measure = 1,
        CachedLayout = 2,
        CachedMeasure = 3
    }

    public enum LayoutPassReason
    {
        Initial = 0,
        AbsLayout = 1,
        Stretch = 2,
        MultilineStretch = 3,
        FlexLayout = 4,
        MeasureChild = 5,
        AbsMeasureChild = 6,
        FlexMeasure = 7,

        // ReSharper disable once InconsistentNaming Used for Sizing
        COUNT
    };


    public class LayoutData
    {
        public int Layouts;
        public int Measures;
        public int MaxMeasureCache;
        public int CachedLayouts;
        public int CachedMeasures;
        public int MeasureCallbacks;

        public readonly byte[] MeasureCallbackReasonsCount = new byte[(int)LayoutPassReason.COUNT];
    };

    public static class Event
    {
        public static TinyMessengerHub Hub { get; } = new TinyMessengerHub();
    }


    public abstract class YGNodeEventArgs : EventArgs
    {
        public YogaNode Node { get; }

        protected YGNodeEventArgs(YogaNode node)
        {
            Node = node;
        }
    }

    public class NodeAllocationEventArgs : YGNodeEventArgs
    {
        public YogaConfig Config { get; }

        public NodeAllocationEventArgs(YogaNode node, YogaConfig config) : base(node)
        {
            Config = config;
        }
    }

    public class NodeDeallocationEventArgs : YGNodeEventArgs
    {
        public YogaConfig Config { get; }

        public NodeDeallocationEventArgs(YogaNode node, YogaConfig config) : base(node)
        {
            Config = config;
        }
    }

    public class LayoutPassStartEventArgs : YGNodeEventArgs
    {
        public object LayoutContext { get; }

        /// <inheritdoc />
        public LayoutPassStartEventArgs(YogaNode node, object layoutContext) : base(node)
        {
            LayoutContext = layoutContext;
        }
    }

    public class LayoutPassEndEventArgs : YGNodeEventArgs
    {
        public object LayoutContext { get; }
        public LayoutData LayoutData { get; }

        /// <inheritdoc />
        public LayoutPassEndEventArgs(YogaNode node, object layoutContext, LayoutData layoutData) : base(node)
        {
            LayoutContext = layoutContext;
            LayoutData    = layoutData;
        }
    }

    public class NodeLayoutEventArgs : YGNodeEventArgs
    {
        public LayoutType LayoutType { get; }
        public object LayoutContext { get; }

        /// <inheritdoc />
        public NodeLayoutEventArgs(YogaNode node, LayoutType layoutType, object layoutContext) : base(node)
        {
            LayoutType    = layoutType;
            LayoutContext = layoutContext;
        }
    }

    public class MeasureCallbackEndEventArgs : YGNodeEventArgs
    {
        public object LayoutContext { get; }
        public float Width { get; }
        public MeasureMode WidthMeasureMode { get; }
        public float Height { get; }
        public MeasureMode HeightMeasureMode { get; }
        public float MeasuredWidth { get; }
        public float MeasuredHeight { get; }
        public LayoutPassReason Reason { get; }

        /// <inheritdoc />
        public MeasureCallbackEndEventArgs(
            YogaNode node,
            object layoutContext,
            float width,
            MeasureMode widthMeasureMode,
            float height,
            MeasureMode heightMeasureMode,
            float measuredWidth,
            float measuredHeight,
            LayoutPassReason reason
        ) : base(node)
        {
            LayoutContext     = layoutContext;
            Width             = width;
            WidthMeasureMode  = widthMeasureMode;
            Height            = height;
            HeightMeasureMode = heightMeasureMode;
            MeasuredWidth     = measuredWidth;
            MeasuredHeight    = measuredHeight;
            Reason            = reason;
        }
    }

    public class MeasureCallbackStartEventArgs : YGNodeEventArgs
    {
        /// <inheritdoc />
        public MeasureCallbackStartEventArgs(YogaNode node) : base(node) { }
    }

    public class NodeBaselineStartEventArgs : YGNodeEventArgs
    {
        /// <inheritdoc />
        public NodeBaselineStartEventArgs(YogaNode node) : base(node) { }
    }

    public class NodeBaselineEndEventArgs : YGNodeEventArgs
    {
        /// <inheritdoc />
        public NodeBaselineEndEventArgs(YogaNode node) : base(node) { }
    }
}
