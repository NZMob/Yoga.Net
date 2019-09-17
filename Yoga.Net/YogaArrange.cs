using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static Yoga.Net.YogaMath;

namespace Yoga.Net
{
    public class YogaArrange
    {
        internal static readonly Edge[] Leading = {Edge.Top, Edge.Bottom, Edge.Left, Edge.Right};
        internal static readonly Edge[] Trailing = {Edge.Bottom, Edge.Top, Edge.Right, Edge.Left};
        internal static readonly Edge[] Pos = {Edge.Top, Edge.Bottom, Edge.Left, Edge.Right};
        internal static readonly Dimension[] Dim = {Dimension.Height, Dimension.Height, Dimension.Width, Dimension.Width};

        static int gCurrentGenerationCount = 0;

        void YGNodeComputeFlexBasisForChild(
            YogaNode node,
            YogaNode child,
            float width,
            MeasureMode widthMode,
            float height,
            float ownerWidth,
            float ownerHeight,
            MeasureMode heightMode,
            Direction direction,
            YogaConfig config,
            LayoutData layoutMarkerData,
            object layoutContext,
            int depth,
            int generationCount)
        {
            var mainAxis = node.Style.FlexDirection.Resolve(direction);
            var isMainAxisRow = mainAxis.IsRow();
            var mainAxisSize = isMainAxisRow ? width : height;
            var mainAxisOwnerSize = isMainAxisRow ? ownerWidth : ownerHeight;

            float childWidth;
            float childHeight;
            MeasureMode childWidthMeasureMode;
            MeasureMode childHeightMeasureMode;

            var resolvedFlexBasis = child.ResolveFlexBasisPtr().Resolve(mainAxisOwnerSize);
            var isRowStyleDimDefined = child.IsStyleDimDefined(FlexDirection.Row, ownerWidth);
            var isColumnStyleDimDefined = child.IsStyleDimDefined(FlexDirection.Column, ownerHeight);

            if (resolvedFlexBasis.HasValue() && mainAxisSize.HasValue())
            {
                if (child.Layout.ComputedFlexBasis.IsUndefined() ||
                    child.Config.ExperimentalFeatures[(int)ExperimentalFeature.WebFlexBasis] &&
                    child.Layout.ComputedFlexBasisGeneration != generationCount)
                {
                    var paddingAndBorder = child.PaddingAndBorderForAxis(mainAxis, ownerWidth);
                    child.SetLayoutComputedFlexBasis(Math.Max(resolvedFlexBasis, paddingAndBorder));
                }
            }
            else if (isMainAxisRow && isRowStyleDimDefined)
            {
                // The width is definite, so use that as the flex basis.
                var paddingAndBorder = child.PaddingAndBorderForAxis(FlexDirection.Row, ownerWidth);

                child.SetLayoutComputedFlexBasis(Math.Max(child.GetResolvedDimensions()[(int)Dimension.Width].Resolve(ownerWidth), paddingAndBorder));
            }
            else if (!isMainAxisRow && isColumnStyleDimDefined)
            {
                // The height is definite, so use that as the flex basis.
                var paddingAndBorder = child.PaddingAndBorderForAxis(FlexDirection.Column, ownerWidth);
                child.SetLayoutComputedFlexBasis(Math.Max(child.GetResolvedDimensions()[(int)Dimension.Height].Resolve(ownerHeight), paddingAndBorder));
            }
            else
            {
                // Compute the flex basis and hypothetical main size (i.e. the clamped flex
                // basis).
                childWidth             = YogaValue.YGUndefined;
                childHeight            = YogaValue.YGUndefined;
                childWidthMeasureMode  = MeasureMode.Undefined;
                childHeightMeasureMode = MeasureMode.Undefined;

                var marginRow = child.GetMarginForAxis(FlexDirection.Row, ownerWidth);
                var marginColumn = child.GetMarginForAxis(FlexDirection.Column, ownerWidth);

                if (isRowStyleDimDefined)
                {
                    childWidth = child.GetResolvedDimensions()[(int)Dimension.Width]
                                      .Resolve(ownerWidth)
                        + marginRow;
                    childWidthMeasureMode = MeasureMode.Exactly;
                }

                if (isColumnStyleDimDefined)
                {
                    childHeight = child.GetResolvedDimensions()[(int)Dimension.Height]
                                       .Resolve(ownerHeight) + marginColumn;
                    childHeightMeasureMode = MeasureMode.Exactly;
                }

                // The W3C spec doesn't say anything about the 'overflow' property, but all
                // major browsers appear to implement the following logic.
                if (!isMainAxisRow && node.Style.Overflow == Overflow.Scroll ||
                    node.Style.Overflow != Overflow.Scroll)
                {
                    if (childWidth.IsUndefined() && width.HasValue())
                    {
                        childWidth            = width;
                        childWidthMeasureMode = MeasureMode.AtMost;
                    }
                }

                if (isMainAxisRow && node.Style.Overflow == Overflow.Scroll ||
                    node.Style.Overflow != Overflow.Scroll)
                {
                    if (childHeight.IsUndefined() && height.HasValue())
                    {
                        childHeight            = height;
                        childHeightMeasureMode = MeasureMode.AtMost;
                    }
                }

                if (child.Style.AspectRatio.HasValue())
                {
                    if (!isMainAxisRow && childWidthMeasureMode == MeasureMode.Exactly)
                    {
                        childHeight = marginColumn + ((childWidth - marginRow) / child.Style.AspectRatio);
                        childHeightMeasureMode = MeasureMode.Exactly;
                    }
                    else if (isMainAxisRow && childHeightMeasureMode == MeasureMode.Exactly)
                    {
                        childWidth = marginRow + ((childHeight - marginColumn) * child.Style.AspectRatio);
                        childWidthMeasureMode = MeasureMode.Exactly;
                    }
                }

                // If child has no defined size in the cross axis and is set to stretch, set
                // the cross axis to be measured exactly with the available inner width

                var hasExactWidth = width.HasValue() && widthMode == MeasureMode.Exactly;
                var childWidthStretch = node.AlignItem(child) == YogaAlign.Stretch && childWidthMeasureMode != MeasureMode.Exactly;
                if (!isMainAxisRow && !isRowStyleDimDefined && hasExactWidth && childWidthStretch)
                {
                    childWidth            = width;
                    childWidthMeasureMode = MeasureMode.Exactly;
                    if (child.Style.AspectRatio.HasValue())
                    {
                        childHeight            = (childWidth - marginRow) / child.Style.AspectRatio;
                        childHeightMeasureMode = MeasureMode.Exactly;
                    }
                }

                var hasExactHeight = height.HasValue() && heightMode == MeasureMode.Exactly;
                var childHeightStretch = node.AlignItem(child) == YogaAlign.Stretch && childHeightMeasureMode != MeasureMode.Exactly;
                if (isMainAxisRow && !isColumnStyleDimDefined && hasExactHeight && childHeightStretch)
                {
                    childHeight            = height;
                    childHeightMeasureMode = MeasureMode.Exactly;

                    if (child.Style.AspectRatio.HasValue())
                    {
                        childWidth            = (childHeight - marginColumn) * child.Style.AspectRatio;
                        childWidthMeasureMode = MeasureMode.Exactly;
                    }
                }

                child.ConstrainMaxSizeForMode(
                    FlexDirection.Row,
                    ownerWidth,
                    ownerWidth,
                    ref childWidthMeasureMode,
                    ref childWidth);
                child.ConstrainMaxSizeForMode(
                    FlexDirection.Column,
                    ownerHeight,
                    ownerWidth,
                    ref childHeightMeasureMode,
                    ref childHeight);

                // Measure the child
                YGLayoutNodeInternal(
                    child,
                    childWidth,
                    childHeight,
                    direction,
                    childWidthMeasureMode,
                    childHeightMeasureMode,
                    ownerWidth,
                    ownerHeight,
                    false,
                    LayoutPassReason.MeasureChild,
                    config,
                    layoutMarkerData,
                    layoutContext,
                    depth,
                    generationCount);

                child.SetLayoutComputedFlexBasis(
                    FloatMax(
                        child.Layout.MeasuredDimensions[Dim[(int)mainAxis]],
                        child.PaddingAndBorderForAxis(mainAxis, ownerWidth)));
            }

            child.SetLayoutComputedFlexBasisGeneration(generationCount);
        }

        void YGNodeAbsoluteLayoutChild(
            YogaNode node,
            YogaNode child,
            float width,
            MeasureMode widthMode,
            float height,
            Direction direction,
            YogaConfig config,
            LayoutData layoutMarkerData,
            object layoutContext,
            int depth,
            int generationCount)
        {
            var mainAxis = node.Style.FlexDirection.Resolve(direction);
            var crossAxis = mainAxis.CrossAxis(direction);
            var isMainAxisRow = mainAxis.IsRow();

            var childWidth = YogaValue.YGUndefined;
            var childHeight = YogaValue.YGUndefined;
            var childWidthMeasureMode = MeasureMode.Undefined;
            var childHeightMeasureMode = MeasureMode.Undefined;

            var marginRow = child.GetMarginForAxis(FlexDirection.Row, width);
            var marginColumn =
                child.GetMarginForAxis(FlexDirection.Column, width);

            if (child.IsStyleDimDefined(FlexDirection.Row, width))
            {
                childWidth =
                    child.GetResolvedDimensions()[(int)Dimension.Width].Resolve(width) + marginRow;
            }
            else
            {
                // If the child doesn't have a specified width, compute the width based on
                // the left/right offsets if they're defined.
                if (child.IsLeadingPositionDefined(FlexDirection.Row) &&
                    child.IsTrailingPosDefined(FlexDirection.Row))
                {
                    childWidth = node.Layout.MeasuredDimensions.Width -
                        (node.GetLeadingBorder(FlexDirection.Row) +
                            node.GetTrailingBorder(FlexDirection.Row)) -
                        (child.GetLeadingPosition(FlexDirection.Row, width) +
                            child.GetTrailingPosition(FlexDirection.Row, width));
                    childWidth = child.BoundAxis(FlexDirection.Row, childWidth, width, width);
                }
            }

            if (child.IsStyleDimDefined(FlexDirection.Column, height))
            {
                childHeight = child.GetResolvedDimensions()[(int)Dimension.Height]
                                   .Resolve(height) + marginColumn;
            }
            else
            {
                // If the child doesn't have a specified height, compute the height based on
                // the top/bottom offsets if they're defined.
                if (child.IsLeadingPositionDefined(FlexDirection.Column) &&
                    child.IsTrailingPosDefined(FlexDirection.Column))
                {
                    childHeight = node.Layout.MeasuredDimensions.Height -
                        (node.GetLeadingBorder(FlexDirection.Column) +
                            node.GetTrailingBorder(FlexDirection.Column)) -
                        (child.GetLeadingPosition(FlexDirection.Column, height) +
                            child.GetTrailingPosition(FlexDirection.Column, height));
                    childHeight = child.BoundAxis(
                        FlexDirection.Column,
                        childHeight,
                        height,
                        width);
                }
            }

            // Exactly one dimension needs to be defined for us to be able to do aspect
            // ratio calculation. One dimension being the anchor and the other being
            // flexible.
            if (childWidth.IsUndefined() ^ childHeight.IsUndefined())
            {
                if (child.Style.AspectRatio.HasValue())
                {
                    if (childWidth.IsUndefined())
                    {
                        childWidth = marginRow + ((childHeight - marginColumn) * child.Style.AspectRatio);
                    }
                    else if (childHeight.IsUndefined())
                    {
                        childHeight = marginColumn + ((childWidth - marginRow) / child.Style.AspectRatio);
                    }
                }
            }

            // If we're still missing one or the other dimension, measure the content.
            if (childWidth.IsUndefined() || childHeight.IsUndefined())
            {
                childWidthMeasureMode = childWidth.IsUndefined()
                    ? MeasureMode.Undefined
                    : MeasureMode.Exactly;
                childHeightMeasureMode = childHeight.IsUndefined()
                    ? MeasureMode.Undefined
                    : MeasureMode.Exactly;

                // If the size of the owner is defined then try to constrain the absolute
                // child to that size as well. This allows text within the absolute child to
                // wrap to the size of its owner. This is the same behavior as many browsers
                // implement.
                if (!isMainAxisRow && childWidth.IsUndefined() &&
                    widthMode != MeasureMode.Undefined && width.HasValue() &&
                    width > 0)
                {
                    childWidth            = width;
                    childWidthMeasureMode = MeasureMode.AtMost;
                }

                YGLayoutNodeInternal(
                    child,
                    childWidth,
                    childHeight,
                    direction,
                    childWidthMeasureMode,
                    childHeightMeasureMode,
                    childWidth,
                    childHeight,
                    false,
                    LayoutPassReason.AbsMeasureChild,
                    config,
                    layoutMarkerData,
                    layoutContext,
                    depth,
                    generationCount);
                childWidth = child.Layout.MeasuredDimensions.Width +
                    child.GetMarginForAxis(FlexDirection.Row, width);
                childHeight = child.Layout.MeasuredDimensions.Height +
                    child.GetMarginForAxis(FlexDirection.Column, width);
            }

            YGLayoutNodeInternal(
                child,
                childWidth,
                childHeight,
                direction,
                MeasureMode.Exactly,
                MeasureMode.Exactly,
                childWidth,
                childHeight,
                true,
                LayoutPassReason.AbsLayout,
                config,
                layoutMarkerData,
                layoutContext,
                depth,
                generationCount);

            if (child.IsTrailingPosDefined(mainAxis) &&
                !child.IsLeadingPositionDefined(mainAxis))
            {
                child.SetLayoutPosition(
                    node.Layout.MeasuredDimensions[Dim[(int)mainAxis]] -
                    child.Layout.MeasuredDimensions[Dim[(int)mainAxis]] -
                    node.GetTrailingBorder(mainAxis) -
                    child.GetTrailingMargin(mainAxis, width) -
                    child.GetTrailingPosition(mainAxis, isMainAxisRow ? width : height),
                    (int)YogaArrange.Leading[(int)mainAxis]);
            }
            else if (
                !child.IsLeadingPositionDefined(mainAxis) &&
                node.Style.JustifyContent == Justify.Center)
            {
                child.SetLayoutPosition(
                    (node.Layout.MeasuredDimensions[Dim[(int)mainAxis]] -
                        child.Layout.MeasuredDimensions[Dim[(int)mainAxis]]) /
                    2.0f,
                    (int)YogaArrange.Leading[(int)mainAxis]);
            }
            else if (
                !child.IsLeadingPositionDefined(mainAxis) &&
                node.Style.JustifyContent == Justify.FlexEnd)
            {
                child.SetLayoutPosition(
                    node.Layout.MeasuredDimensions[Dim[(int)mainAxis]] -
                    child.Layout.MeasuredDimensions[Dim[(int)mainAxis]],
                    (int)YogaArrange.Leading[(int)mainAxis]);
            }

            if (child.IsTrailingPosDefined(crossAxis) &&
                !child.IsLeadingPositionDefined(crossAxis))
            {
                child.SetLayoutPosition(
                    node.Layout.MeasuredDimensions[Dim[(int)crossAxis]] -
                    child.Layout.MeasuredDimensions[Dim[(int)crossAxis]] -
                    node.GetTrailingBorder(crossAxis) -
                    child.GetTrailingMargin(crossAxis, width) -
                    child.GetTrailingPosition(crossAxis, isMainAxisRow ? height : width),
                    (int)YogaArrange.Leading[(int)crossAxis]);
            }
            else if (!child.IsLeadingPositionDefined(crossAxis) && node.AlignItem(child) == YogaAlign.Center)
            {
                child.SetLayoutPosition(
                    (node.Layout.MeasuredDimensions[Dim[(int)crossAxis]] -
                        child.Layout.MeasuredDimensions[Dim[(int)crossAxis]]) /
                    2.0f,
                    (int)YogaArrange.Leading[(int)crossAxis]);
            }
            else if (
                !child.IsLeadingPositionDefined(crossAxis) &&
                (node.AlignItem(child) == YogaAlign.FlexEnd) ^
                (node.Style.FlexWrap == Wrap.WrapReverse))
            {
                child.SetLayoutPosition(
                    node.Layout.MeasuredDimensions[Dim[(int)crossAxis]] -
                    child.Layout.MeasuredDimensions[Dim[(int)crossAxis]],
                    (int)YogaArrange.Leading[(int)crossAxis]);
            }
        }

        void YGNodeWithMeasureFuncSetMeasuredDimensions(
            YogaNode node,
            float availableWidth,
            float availableHeight,
            MeasureMode widthMeasureMode,
            MeasureMode heightMeasureMode,
            float ownerWidth,
            float ownerHeight,
            LayoutData layoutMarkerData,
            object layoutContext,
            LayoutPassReason reason)
        {
            Debug.Assert(
                node.MeasureFunc != null,
                "Expected node to have custom measure function");

            var paddingAndBorderAxisRow =
                node.PaddingAndBorderForAxis(FlexDirection.Row, availableWidth);
            var paddingAndBorderAxisColumn = node.PaddingAndBorderForAxis(
                FlexDirection.Column,
                availableWidth);
            var marginAxisRow = node.GetMarginForAxis(FlexDirection.Row, availableWidth);
            var marginAxisColumn = node.GetMarginForAxis(FlexDirection.Column, availableWidth);

            // We want to make sure we don't call measure with negative size
            var innerWidth = availableWidth.IsUndefined()
                ? availableWidth
                : FloatMax(0, availableWidth - marginAxisRow - paddingAndBorderAxisRow);
            var innerHeight = availableHeight.IsUndefined()
                ? availableHeight
                : FloatMax(
                    0,
                    availableHeight - marginAxisColumn - paddingAndBorderAxisColumn);

            if (widthMeasureMode == MeasureMode.Exactly &&
                heightMeasureMode == MeasureMode.Exactly)
            {
                // Don't bother sizing the text if both dimensions are already defined.
                node.SetLayoutMeasuredDimension(
                    node.BoundAxis(
                        FlexDirection.Row,
                        availableWidth - marginAxisRow,
                        ownerWidth,
                        ownerWidth),
                    Dimension.Width);
                node.SetLayoutMeasuredDimension(
                    node.BoundAxis(
                        FlexDirection.Column,
                        availableHeight - marginAxisColumn,
                        ownerHeight,
                        ownerWidth),
                    Dimension.Height);
            }
            else
            {
                Event.Hub.Publish(new MeasureCallbackStartEventArgs(node));

                // Measure the text under the current constraints.
                var measuredSize = node.Measure(
                    innerWidth,
                    widthMeasureMode,
                    innerHeight,
                    heightMeasureMode,
                    layoutContext);

                unsafe
                {
                    layoutMarkerData.MeasureCallbacks                         += 1;
                    layoutMarkerData.MeasureCallbackReasonsCount[(int)reason] += 1;
                }

                Event.Hub.Publish(
                    new MeasureCallbackEndEventArgs(
                        node,
                        layoutContext,
                        innerWidth,
                        widthMeasureMode,
                        innerHeight,
                        heightMeasureMode,
                        measuredSize.Width,
                        measuredSize.Height,
                        reason));

                node.SetLayoutMeasuredDimension(
                    node.BoundAxis(
                        FlexDirection.Row,
                        widthMeasureMode == MeasureMode.Undefined ||
                        widthMeasureMode == MeasureMode.AtMost
                            ? measuredSize.Width + paddingAndBorderAxisRow
                            : availableWidth - marginAxisRow,
                        ownerWidth,
                        ownerWidth),
                    Dimension.Width);

                node.SetLayoutMeasuredDimension(
                    node.BoundAxis(
                        FlexDirection.Column,
                        heightMeasureMode == MeasureMode.Undefined ||
                        heightMeasureMode == MeasureMode.AtMost
                            ? measuredSize.Height + paddingAndBorderAxisColumn
                            : availableHeight - marginAxisColumn,
                        ownerHeight,
                        ownerWidth),
                    Dimension.Height);
            }
        }

        // For nodes with no children, use the available values if they were provided,
        // or the minimum size as indicated by the padding and border sizes.
         void YGNodeEmptyContainerSetMeasuredDimensions(
            YogaNode node,
            float availableWidth,
            float availableHeight,
            MeasureMode widthMeasureMode,
            MeasureMode heightMeasureMode,
            float ownerWidth,
            float ownerHeight)
        {
            var paddingAndBorderAxisRow = node.PaddingAndBorderForAxis(FlexDirection.Row, ownerWidth);
            var paddingAndBorderAxisColumn = node.PaddingAndBorderForAxis(FlexDirection.Column, ownerWidth);
            var marginAxisRow = node.GetMarginForAxis(FlexDirection.Row, ownerWidth);
            var marginAxisColumn = node.GetMarginForAxis(FlexDirection.Column, ownerWidth);

            node.SetLayoutMeasuredDimension(
                node.BoundAxis(
                    FlexDirection.Row,
                    widthMeasureMode == MeasureMode.Undefined ||
                    widthMeasureMode == MeasureMode.AtMost
                        ? paddingAndBorderAxisRow
                        : availableWidth - marginAxisRow,
                    ownerWidth,
                    ownerWidth),
                Dimension.Width);

            node.SetLayoutMeasuredDimension(
                node.BoundAxis(
                    FlexDirection.Column,
                    heightMeasureMode == MeasureMode.Undefined ||
                    heightMeasureMode == MeasureMode.AtMost
                        ? paddingAndBorderAxisColumn
                        : availableHeight - marginAxisColumn,
                    ownerHeight,
                    ownerWidth),
                Dimension.Height);
        }

         bool YGNodeFixedSizeSetMeasuredDimensions(
            YogaNode node,
            float availableWidth,
            float availableHeight,
            MeasureMode widthMeasureMode,
            MeasureMode heightMeasureMode,
            float ownerWidth,
            float ownerHeight)
        {
            if (availableWidth.HasValue() &&
                widthMeasureMode == MeasureMode.AtMost && availableWidth <= 0.0f ||
                availableHeight.HasValue() &&
                heightMeasureMode == MeasureMode.AtMost && availableHeight <= 0.0f ||
                widthMeasureMode == MeasureMode.Exactly &&
                heightMeasureMode == MeasureMode.Exactly)
            {
                var marginAxisColumn = node.GetMarginForAxis(FlexDirection.Column, ownerWidth);
                var marginAxisRow = node.GetMarginForAxis(FlexDirection.Row, ownerWidth);

                node.SetLayoutMeasuredDimension(
                    node.BoundAxis(
                        FlexDirection.Row,
                        availableWidth.IsUndefined() ||
                        widthMeasureMode == MeasureMode.AtMost &&
                        availableWidth < 0.0f
                            ? 0.0f
                            : availableWidth - marginAxisRow,
                        ownerWidth,
                        ownerWidth),
                    Dimension.Width);

                node.SetLayoutMeasuredDimension(
                    node.BoundAxis(
                        FlexDirection.Column,
                        availableHeight.IsUndefined() ||
                        heightMeasureMode == MeasureMode.AtMost &&
                        availableHeight < 0.0f
                            ? 0.0f
                            : availableHeight - marginAxisColumn,
                        ownerHeight,
                        ownerWidth),
                    Dimension.Height);
                return true;
            }

            return false;
        }

         void YGZeroOutLayoutRecursively(YogaNode node,object layoutContext)
        {
            node.Layout = new YogaLayout {Width = 0f, Height = 0f};
            node.HasNewLayout = true;

            node.IterChildrenAfterCloningIfNeeded(YGZeroOutLayoutRecursively, layoutContext);
        }

         float YGNodeCalculateAvailableInnerDim(
            in YogaNode node,
            FlexDirection axis,
            float availableDim,
            float ownerDim)
        {
            var direction = axis.IsRow() ? FlexDirection.Row : FlexDirection.Column;
            var dimension = axis.IsRow() ? Dimension.Width : Dimension.Height;

            var margin = node.GetMarginForAxis(direction, ownerDim);
            var paddingAndBorder = node.PaddingAndBorderForAxis(direction, ownerDim);

            var availableInnerDim = availableDim - margin - paddingAndBorder;
            // Max dimension overrides predefined dimension value; Min dimension in turn
            // overrides both of the above
            if (availableInnerDim.HasValue())
            {
                // We want to make sure our available height does not violate min and max
                // constraints
                var minDimensionOptional = node.Style.MinDimension(dimension).Resolve(ownerDim);
                var minInnerDim = minDimensionOptional.IsUndefined()
                    ? 0.0f
                    : minDimensionOptional - paddingAndBorder;

                var maxDimensionOptional = node.Style.MaxDimension(dimension).Resolve(ownerDim);

                var maxInnerDim = maxDimensionOptional.IsUndefined()
                    ? float.MaxValue
                    : maxDimensionOptional - paddingAndBorder;
                availableInnerDim = FloatMax(FloatMin(availableInnerDim, maxInnerDim), minInnerDim);
            }

            return availableInnerDim;
        }

         float YGNodeComputeFlexBasisForChildren(
            YogaNode node,
            float availableInnerWidth,
            float availableInnerHeight,
            MeasureMode widthMeasureMode,
            MeasureMode heightMeasureMode,
            Direction direction,
            FlexDirection mainAxis,
            YogaConfig config,
            bool performLayout,
            LayoutData layoutMarkerData,
            object layoutContext,
            int depth,
            int generationCount)
        {
            var totalOuterFlexBasis = 0.0f;
            YogaNode singleFlexChild = null;
            var children = new YogaNodes(node.Children);
            var measureModeMainDim =
                mainAxis.IsRow() ? widthMeasureMode : heightMeasureMode;
            // If there is only one child with flexGrow + flexShrink it means we can set
            // the computedFlexBasis to 0 instead of measuring and shrinking / flexing the
            // child to exactly match the remaining space
            if (measureModeMainDim == MeasureMode.Exactly)
            {
                foreach (var child in children)
                {
                    if (child.IsNodeFlexible())
                    {
                        if (singleFlexChild != null ||
                            FloatsEqual(child.ResolveFlexGrow(), 0.0f) ||
                            FloatsEqual(child.ResolveFlexShrink(), 0.0f))
                        {
                            // There is already a flexible child, or this flexible child doesn't
                            // have flexGrow and flexShrink, abort
                            singleFlexChild = null;
                            break;
                        }
                        else
                        {
                            singleFlexChild = child;
                        }
                    }
                }
            }

            foreach (var child in children)
            {
                child.ResolveDimension();
                if (child.Style.Display == Display.None)
                {
                    YGZeroOutLayoutRecursively(child, layoutContext);
                    child.HasNewLayout = true;
                    child.IsDirty = false;
                    continue;
                }

                if (performLayout)
                {
                    // Set the initial position (relative to the owner).
                    var childDirection = child.ResolveDirection(direction);
                    var mainDim = mainAxis.IsRow() ? availableInnerWidth : availableInnerHeight;
                    var crossDim = mainAxis.IsRow() ? availableInnerHeight : availableInnerWidth;
                    child.SetPosition(
                        childDirection,
                        mainDim,
                        crossDim,
                        availableInnerWidth);
                }

                if (child.Style.PositionType == PositionType.Absolute)
                {
                    continue;
                }

                if (child == singleFlexChild)
                {
                    child.SetLayoutComputedFlexBasisGeneration(generationCount);
                    child.SetLayoutComputedFlexBasis(0f);
                }
                else
                {
                    YGNodeComputeFlexBasisForChild(
                        node,
                        child,
                        availableInnerWidth,
                        widthMeasureMode,
                        availableInnerHeight,
                        availableInnerWidth,
                        availableInnerHeight,
                        heightMeasureMode,
                        direction,
                        config,
                        layoutMarkerData,
                        layoutContext,
                        depth,
                        generationCount);
                }

                totalOuterFlexBasis +=
                    child.Layout.ComputedFlexBasis + child.GetMarginForAxis(mainAxis, availableInnerWidth);
            }

            return totalOuterFlexBasis;
        }

        // This function assumes that all the children of node have their
        // computedFlexBasis properly computed(To do this use
        // YGNodeComputeFlexBasisForChildren function). This function calculates
        // YGCollectFlexItemsRowMeasurement
         CollectFlexItemsRowValues YGCalculateCollectFlexItemsRowValues(
            YogaNode node,
            Direction ownerDirection,
            float mainAxisownerSize,
            float availableInnerWidth,
            float availableInnerMainDim,
            int startOfLineIndex,
            int lineCount)
        {
            var flexAlgoRowMeasurement = new CollectFlexItemsRowValues();
            flexAlgoRowMeasurement.RelativeChildren = new List<YogaNode>(node.Children.Count);

            float sizeConsumedOnCurrentLineIncludingMinConstraint = 0;
            var mainAxis = node.Style.FlexDirection.Resolve(node.ResolveDirection(ownerDirection));
            var isNodeFlexWrap = node.Style.FlexWrap != Wrap.NoWrap;

            // Add items to the current line until it's full or we run out of items.
            var endOfLineIndex = startOfLineIndex;
            for (; endOfLineIndex < node.Children.Count; endOfLineIndex++)
            {
                var child = node.Children[endOfLineIndex];
                if (child.Style.Display == Display.None ||
                    child.Style.PositionType == PositionType.Absolute)
                {
                    continue;
                }

                child.LineIndex = lineCount;
                var childMarginMainAxis =
                    child.GetMarginForAxis(mainAxis, availableInnerWidth);
                var flexBasisWithMinAndMaxConstraints =
                    child.BoundAxisWithinMinAndMax(
                        mainAxis,
                        child.Layout.ComputedFlexBasis,
                        mainAxisownerSize);

                // If this is a multi-line flow and this item pushes us over the available
                // size, we've hit the end of the current line. Break out of the loop and
                // lay out the current line.
                if (sizeConsumedOnCurrentLineIncludingMinConstraint +
                    flexBasisWithMinAndMaxConstraints + childMarginMainAxis >
                    availableInnerMainDim &&
                    isNodeFlexWrap && flexAlgoRowMeasurement.ItemsOnLine > 0)
                {
                    break;
                }

                sizeConsumedOnCurrentLineIncludingMinConstraint +=
                    flexBasisWithMinAndMaxConstraints + childMarginMainAxis;
                flexAlgoRowMeasurement.SizeConsumedOnCurrentLine +=
                    flexBasisWithMinAndMaxConstraints + childMarginMainAxis;
                flexAlgoRowMeasurement.ItemsOnLine++;

                if (child.IsNodeFlexible())
                {
                    flexAlgoRowMeasurement.TotalFlexGrowFactors += child.ResolveFlexGrow();

                    // Unlike the grow factor, the shrink factor is scaled relative to the
                    // child dimension.
                    flexAlgoRowMeasurement.TotalFlexShrinkScaledFactors +=
                        -child.ResolveFlexShrink() *
                        child.Layout.ComputedFlexBasis;
                }

                flexAlgoRowMeasurement.RelativeChildren.Add(child);
            }

            // The total flex factor needs to be floored to 1.
            if (flexAlgoRowMeasurement.TotalFlexGrowFactors > 0 &&
                flexAlgoRowMeasurement.TotalFlexGrowFactors < 1)
            {
                flexAlgoRowMeasurement.TotalFlexGrowFactors = 1;
            }

            // The total flex shrink factor needs to be floored to 1.
            if (flexAlgoRowMeasurement.TotalFlexShrinkScaledFactors > 0 &&
                flexAlgoRowMeasurement.TotalFlexShrinkScaledFactors < 1)
            {
                flexAlgoRowMeasurement.TotalFlexShrinkScaledFactors = 1;
            }

            flexAlgoRowMeasurement.EndOfLineIndex = endOfLineIndex;
            return flexAlgoRowMeasurement;
        }

        // It distributes the free space to the flexible items and ensures that the size
        // of the flex items abide the min and max constraints. At the end of this
        // function the child nodes would have proper size. Prior using this function
        // please ensure that YGDistributeFreeSpaceFirstPass is called.
         float YGDistributeFreeSpaceSecondPass(
            CollectFlexItemsRowValues collectedFlexItemsValues,
            YogaNode node,
            FlexDirection mainAxis,
            FlexDirection crossAxis,
            float mainAxisownerSize,
            float availableInnerMainDim,
            float availableInnerCrossDim,
            float availableInnerWidth,
            float availableInnerHeight,
            bool flexBasisOverflows,
            MeasureMode measureModeCrossDim,
            bool performLayout,
            YogaConfig config,
            LayoutData layoutMarkerData,
            object layoutContext,
            int depth,
            int generationCount)
        {
            float childFlexBasis = 0;
            float flexShrinkScaledFactor = 0;
            float flexGrowFactor = 0;
            float deltaFreeSpace = 0;
            var isMainAxisRow = mainAxis.IsRow();
            var isNodeFlexWrap = node.Style.FlexWrap != Wrap.NoWrap;

            foreach (var currentRelativeChild in collectedFlexItemsValues.RelativeChildren)
            {
                childFlexBasis = currentRelativeChild.BoundAxisWithinMinAndMax(
                    mainAxis,
                    currentRelativeChild.Layout.ComputedFlexBasis,
                    mainAxisownerSize);
                var updatedMainSize = childFlexBasis;

                if (collectedFlexItemsValues.RemainingFreeSpace.HasValue() &&
                    collectedFlexItemsValues.RemainingFreeSpace < 0)
                {
                    flexShrinkScaledFactor =
                        -currentRelativeChild.ResolveFlexShrink() * childFlexBasis;
                    // Is this child able to shrink?
                    if (flexShrinkScaledFactor.IsNotZero())
                    {
                        float childSize;

                        if (collectedFlexItemsValues.TotalFlexShrinkScaledFactors.HasValue() &&
                            collectedFlexItemsValues.TotalFlexShrinkScaledFactors.IsZero())
                        {
                            childSize = childFlexBasis + flexShrinkScaledFactor;
                        }
                        else
                        {
                            childSize = childFlexBasis +
                                ((collectedFlexItemsValues.RemainingFreeSpace /
                                        collectedFlexItemsValues.TotalFlexShrinkScaledFactors) *
                                    flexShrinkScaledFactor);
                        }

                        updatedMainSize = currentRelativeChild.BoundAxis(
                            mainAxis,
                            childSize,
                            availableInnerMainDim,
                            availableInnerWidth);
                    }
                }
                else if (
                    collectedFlexItemsValues.RemainingFreeSpace.HasValue() &&
                    collectedFlexItemsValues.RemainingFreeSpace > 0)
                {
                    flexGrowFactor = currentRelativeChild.ResolveFlexGrow();

                    // Is this child able to grow?
                    if (flexGrowFactor.HasValue() && flexGrowFactor.IsNotZero())
                    {
                        updatedMainSize = currentRelativeChild.BoundAxis(
                            mainAxis,
                            childFlexBasis +
                            ((collectedFlexItemsValues.RemainingFreeSpace /
                                    collectedFlexItemsValues.TotalFlexGrowFactors) *
                                flexGrowFactor),
                            availableInnerMainDim,
                            availableInnerWidth);
                    }
                }

                deltaFreeSpace += updatedMainSize - childFlexBasis;

                var marginMain =
                    currentRelativeChild.GetMarginForAxis(mainAxis, availableInnerWidth);
                var marginCross =
                    currentRelativeChild.GetMarginForAxis(crossAxis, availableInnerWidth);

                float childCrossSize;
                var childMainSize = updatedMainSize + marginMain;
                MeasureMode childCrossMeasureMode;
                var childMainMeasureMode = MeasureMode.Exactly;

                if (currentRelativeChild.Style.AspectRatio.HasValue())
                {
                    childCrossSize = isMainAxisRow
                        ? (childMainSize - marginMain) / currentRelativeChild.Style.AspectRatio
                        : (childMainSize - marginMain) * currentRelativeChild.Style.AspectRatio;
                    childCrossMeasureMode = MeasureMode.Exactly;

                    childCrossSize += marginCross;
                }
                else if (
                    availableInnerCrossDim.HasValue() &&
                    !currentRelativeChild.IsStyleDimDefined(crossAxis, availableInnerCrossDim) &&
                    measureModeCrossDim == MeasureMode.Exactly &&
                    !(isNodeFlexWrap && flexBasisOverflows) &&
                    node.AlignItem(currentRelativeChild) == YogaAlign.Stretch &&
                    currentRelativeChild.MarginLeadingValue(crossAxis).Unit != YogaUnit.Auto &&
                    currentRelativeChild.MarginTrailingValue(crossAxis).Unit != YogaUnit.Auto)
                {
                    childCrossSize        = availableInnerCrossDim;
                    childCrossMeasureMode = MeasureMode.Exactly;
                }
                else if (!currentRelativeChild.IsStyleDimDefined(crossAxis, availableInnerCrossDim))
                {
                    childCrossSize = availableInnerCrossDim;
                    childCrossMeasureMode = childCrossSize.IsUndefined()
                        ? MeasureMode.Undefined
                        : MeasureMode.AtMost;
                }
                else
                {
                    childCrossSize = currentRelativeChild.GetResolvedDimension(YogaArrange.Dim[(int)crossAxis])
                                                         .Resolve(availableInnerCrossDim)
                        + marginCross;
                    var isLoosePercentageMeasurement =
                        currentRelativeChild.GetResolvedDimension(YogaArrange.Dim[(int)crossAxis]).Unit == YogaUnit.Percent &&
                        measureModeCrossDim != MeasureMode.Exactly;
                    childCrossMeasureMode =
                        childCrossSize.IsUndefined() || isLoosePercentageMeasurement
                            ? MeasureMode.Undefined
                            : MeasureMode.Exactly;
                }

                currentRelativeChild.ConstrainMaxSizeForMode(
                    mainAxis,
                    availableInnerMainDim,
                    availableInnerWidth,
                    ref childMainMeasureMode,
                    ref childMainSize);
                currentRelativeChild.ConstrainMaxSizeForMode(
                    crossAxis,
                    availableInnerCrossDim,
                    availableInnerWidth,
                    ref childCrossMeasureMode,
                    ref childCrossSize);

                var requiresStretchLayout =
                    !currentRelativeChild.IsStyleDimDefined(crossAxis,availableInnerCrossDim) &&
                    node.AlignItem(currentRelativeChild) == YogaAlign.Stretch &&
                    currentRelativeChild.MarginLeadingValue(crossAxis).Unit !=
                    YogaUnit.Auto &&
                    currentRelativeChild.MarginTrailingValue(crossAxis).Unit != YogaUnit.Auto;

                var childWidth = isMainAxisRow ? childMainSize : childCrossSize;
                var childHeight = !isMainAxisRow ? childMainSize : childCrossSize;

                var childWidthMeasureMode =
                    isMainAxisRow ? childMainMeasureMode : childCrossMeasureMode;
                var childHeightMeasureMode =
                    !isMainAxisRow ? childMainMeasureMode : childCrossMeasureMode;

                var isLayoutPass = performLayout && !requiresStretchLayout;
                // Recursively call the layout algorithm for this child with the updated
                // main size.
                YGLayoutNodeInternal(
                    currentRelativeChild,
                    childWidth,
                    childHeight,
                    node.Layout.Direction,
                    childWidthMeasureMode,
                    childHeightMeasureMode,
                    availableInnerWidth,
                    availableInnerHeight,
                    isLayoutPass,
                    isLayoutPass
                        ? LayoutPassReason.FlexLayout
                        : LayoutPassReason.FlexMeasure,
                    config,
                    layoutMarkerData,
                    layoutContext,
                    depth,
                    generationCount);
                node.SetLayoutHadOverflow(
                    node.Layout.HadOverflow |
                    currentRelativeChild.Layout.HadOverflow);
            }

            return deltaFreeSpace;
        }

        // It distributes the free space to the flexible items.For those flexible items
        // whose min and max constraints are triggered, those flex item's clamped size
        // is removed from the remaingfreespace.
         void YGDistributeFreeSpaceFirstPass(
            CollectFlexItemsRowValues collectedFlexItemsValues,
            FlexDirection mainAxis,
            float mainAxisownerSize,
            float availableInnerMainDim,
            float availableInnerWidth)
        {
            float flexShrinkScaledFactor = 0;
            float flexGrowFactor = 0;
            float baseMainSize = 0;
            float boundMainSize = 0;
            float deltaFreeSpace = 0;

            foreach (var currentRelativeChild in collectedFlexItemsValues.RelativeChildren)
            {
                var childFlexBasis =
                    currentRelativeChild.BoundAxisWithinMinAndMax(
                        mainAxis,
                        currentRelativeChild.Layout.ComputedFlexBasis,
                        mainAxisownerSize);

                if (collectedFlexItemsValues.RemainingFreeSpace < 0)
                {
                    flexShrinkScaledFactor =
                        -currentRelativeChild.ResolveFlexShrink() * childFlexBasis;

                    // Is this child able to shrink?
                    if (flexShrinkScaledFactor.HasValue() &&
                        flexShrinkScaledFactor.IsNotZero())
                    {
                        baseMainSize = childFlexBasis +
                            ((collectedFlexItemsValues.RemainingFreeSpace /
                                    collectedFlexItemsValues.TotalFlexShrinkScaledFactors) *
                                flexShrinkScaledFactor);
                        boundMainSize = currentRelativeChild.BoundAxis(
                            mainAxis,
                            baseMainSize,
                            availableInnerMainDim,
                            availableInnerWidth);
                        if (baseMainSize.HasValue() && boundMainSize.HasValue() &&
                            !FloatsEqual(baseMainSize, boundMainSize))
                        {
                            // By excluding this item's size and flex factor from remaining, this
                            // item's min/max constraints should also trigger in the second pass
                            // resulting in the item's size calculation being identical in the
                            // first and second passes.
                            deltaFreeSpace += boundMainSize - childFlexBasis;
                            collectedFlexItemsValues.TotalFlexShrinkScaledFactors -=
                                flexShrinkScaledFactor;
                        }
                    }
                }
                else if (
                    collectedFlexItemsValues.RemainingFreeSpace.HasValue() &&
                    collectedFlexItemsValues.RemainingFreeSpace > 0)
                {
                    flexGrowFactor = currentRelativeChild.ResolveFlexGrow();

                    // Is this child able to grow?
                    if (flexGrowFactor.HasValue() && flexGrowFactor.IsNotZero())
                    {
                        baseMainSize = childFlexBasis +
                            ((collectedFlexItemsValues.RemainingFreeSpace /
                                collectedFlexItemsValues.TotalFlexGrowFactors) * flexGrowFactor);
                        boundMainSize = currentRelativeChild.BoundAxis(
                            mainAxis,
                            baseMainSize,
                            availableInnerMainDim,
                            availableInnerWidth);

                        if (baseMainSize.HasValue() && boundMainSize.HasValue() &&
                            !FloatsEqual(baseMainSize, boundMainSize))
                        {
                            // By excluding this item's size and flex factor from remaining, this
                            // item's min/max constraints should also trigger in the second pass
                            // resulting in the item's size calculation being identical in the
                            // first and second passes.
                            deltaFreeSpace                                += boundMainSize - childFlexBasis;
                            collectedFlexItemsValues.TotalFlexGrowFactors -= flexGrowFactor;
                        }
                    }
                }
            }

            collectedFlexItemsValues.RemainingFreeSpace -= deltaFreeSpace;
        }

        // Do two passes over the flex items to figure out how to distribute the
        // remaining space.
        //
        // The first pass finds the items whose min/max constraints trigger, freezes
        // them at those sizes, and excludes those sizes from the remaining space.
        //
        // The second pass sets the size of each flexible item. It distributes the
        // remaining space amongst the items whose min/max constraints didn't trigger in
        // the first pass. For the other items, it sets their sizes by forcing their
        // min/max constraints to trigger again.
        //
        // This two pass approach for resolving min/max constraints deviates from the
        // spec. The spec
        // (https://www.w3.org/TR/CSS-flexbox-1/#resolve-flexible-lengths) describes a
        // process that needs to be repeated a variable number of times. The algorithm
        // implemented here won't handle all cases but it was simpler to implement and
        // it mitigates performance concerns because we know exactly how many passes
        // it'll do.
        //
        // At the end of this function the child nodes would have the proper size
        // assigned to them.
        //
         void YGResolveFlexibleLength(
            YogaNode node,
            CollectFlexItemsRowValues collectedFlexItemsValues,
            FlexDirection mainAxis,
            FlexDirection crossAxis,
            float mainAxisownerSize,
            float availableInnerMainDim,
            float availableInnerCrossDim,
            float availableInnerWidth,
            float availableInnerHeight,
            bool flexBasisOverflows,
            MeasureMode measureModeCrossDim,
            bool performLayout,
            YogaConfig config,
            LayoutData layoutMarkerData,
            object layoutContext,
            int depth,
            int generationCount)
        {
            var originalFreeSpace = collectedFlexItemsValues.RemainingFreeSpace;
            // First pass: detect the flex items whose min/max constraints trigger
            YGDistributeFreeSpaceFirstPass(
                collectedFlexItemsValues,
                mainAxis,
                mainAxisownerSize,
                availableInnerMainDim,
                availableInnerWidth);

            // Second pass: resolve the sizes of the flexible items
            var distributedFreeSpace = YGDistributeFreeSpaceSecondPass(
                collectedFlexItemsValues,
                node,
                mainAxis,
                crossAxis,
                mainAxisownerSize,
                availableInnerMainDim,
                availableInnerCrossDim,
                availableInnerWidth,
                availableInnerHeight,
                flexBasisOverflows,
                measureModeCrossDim,
                performLayout,
                config,
                layoutMarkerData,
                layoutContext,
                depth,
                generationCount);

            collectedFlexItemsValues.RemainingFreeSpace =
                originalFreeSpace - distributedFreeSpace;
        }

         void YGJustifyMainAxis(
            YogaNode node,
            CollectFlexItemsRowValues collectedFlexItemsValues,
            int startOfLineIndex,
            FlexDirection mainAxis,
            FlexDirection crossAxis,
            MeasureMode measureModeMainDim,
            MeasureMode measureModeCrossDim,
            float mainAxisownerSize,
            float ownerWidth,
            float availableInnerMainDim,
            float availableInnerCrossDim,
            float availableInnerWidth,
            bool performLayout,
            object layoutContext)
        {
            var leadingPaddingAndBorderMain = node.GetLeadingPaddingAndBorder(mainAxis, ownerWidth);
            var trailingPaddingAndBorderMain =
                node.GetTrailingPaddingAndBorder(mainAxis, ownerWidth);
            // If we are using "at most" rules in the main axis, make sure that
            // remainingFreeSpace is 0 when min main dimension is not given
            if (measureModeMainDim == MeasureMode.AtMost &&
                collectedFlexItemsValues.RemainingFreeSpace > 0)
            {
                if (node.Style.MinDimension(Dim[(int)mainAxis]).HasValue &&
                    node.Style.MinDimension(Dim[(int)mainAxis]).Resolve(mainAxisownerSize).HasValue())
                {
                    // This condition makes sure that if the size of main dimension(after
                    // considering child nodes main dim, leading and trailing padding etc)
                    // falls below min dimension, then the remainingFreeSpace is reassigned
                    // considering the min dimension

                    // `minAvailableMainDim` denotes minimum available space in which child
                    // can be laid out, it will exclude space consumed by padding and border.
                    var minAvailableMainDim = node.Style.MinDimension(Dim[(int)mainAxis])
                                                   .Resolve(mainAxisownerSize)
                        - leadingPaddingAndBorderMain - trailingPaddingAndBorderMain;
                    var occupiedSpaceByChildNodes = availableInnerMainDim - collectedFlexItemsValues.RemainingFreeSpace;
                    collectedFlexItemsValues.RemainingFreeSpace =
                        FloatMax(0, minAvailableMainDim - occupiedSpaceByChildNodes);
                }
                else
                {
                    collectedFlexItemsValues.RemainingFreeSpace = 0;
                }
            }

            var numberOfAutoMarginsOnCurrentLine = 0;
            for (var i = startOfLineIndex;
                 i < collectedFlexItemsValues.EndOfLineIndex;
                 i++)
            {
                var child = node.Children[i];
                if (child.Style.PositionType == PositionType.Relative)
                {
                    if (child.MarginLeadingValue(mainAxis).Unit == YogaUnit.Auto)
                    {
                        numberOfAutoMarginsOnCurrentLine++;
                    }

                    if (child.MarginTrailingValue(mainAxis).Unit == YogaUnit.Auto)
                    {
                        numberOfAutoMarginsOnCurrentLine++;
                    }
                }
            }

            // In order to position the elements in the main axis, we have two controls.
            // The space between the beginning and the first element and the space between
            // each two elements.
            float leadingMainDim = 0;
            float betweenMainDim = 0;
            var justifyContent = node.Style.JustifyContent;

            if (numberOfAutoMarginsOnCurrentLine == 0)
            {
                switch (justifyContent)
                {
                case Justify.Center:
                    leadingMainDim = collectedFlexItemsValues.RemainingFreeSpace / 2;
                    break;
                case Justify.FlexEnd:
                    leadingMainDim = collectedFlexItemsValues.RemainingFreeSpace;
                    break;
                case Justify.SpaceBetween:
                    if (collectedFlexItemsValues.ItemsOnLine > 1)
                    {
                        betweenMainDim =
                            FloatMax(collectedFlexItemsValues.RemainingFreeSpace, 0) /
                            (collectedFlexItemsValues.ItemsOnLine - 1);
                    }
                    else
                    {
                        betweenMainDim = 0;
                    }

                    break;
                case Justify.SpaceEvenly:
                    // Space is distributed evenly across all elements
                    betweenMainDim = collectedFlexItemsValues.RemainingFreeSpace /
                        (collectedFlexItemsValues.ItemsOnLine + 1);
                    leadingMainDim = betweenMainDim;
                    break;
                case Justify.SpaceAround:
                    // Space on the edges is half of the space between elements
                    betweenMainDim = collectedFlexItemsValues.RemainingFreeSpace /
                        collectedFlexItemsValues.ItemsOnLine;
                    leadingMainDim = betweenMainDim / 2;
                    break;
                case Justify.FlexStart:
                    break;
                }
            }

            collectedFlexItemsValues.MainDim =
                leadingPaddingAndBorderMain + leadingMainDim;
            collectedFlexItemsValues.CrossDim = 0;

            float maxAscentForCurrentLine = 0;
            float maxDescentForCurrentLine = 0;
            var isNodeBaselineLayout = node.IsBaselineLayout();
            for (var i = startOfLineIndex; i < collectedFlexItemsValues.EndOfLineIndex; i++)
            {
                var child = node.Children[i];
                var childLayout = child.Layout;
                if (child.Style.Display == Display.None)
                    continue;

                if (child.Style.PositionType == PositionType.Absolute &&
                    child.IsLeadingPositionDefined(mainAxis))
                {
                    if (performLayout)
                    {
                        // In case the child is position absolute and has left/top being
                        // defined, we override the position to whatever the user said (and
                        // margin/border).
                        child.SetLayoutPosition(
                            child.GetLeadingPosition(mainAxis, availableInnerMainDim)
                            +
                            node.GetLeadingBorder(mainAxis) +
                            child.GetLeadingMargin(mainAxis, availableInnerWidth),
                            (int)YogaArrange.Pos[(int)mainAxis]);
                    }
                }
                else
                {
                    // Now that we placed the element, we need to update the variables.
                    // We need to do that only for relative elements. Absolute elements do not
                    // take part in that phase.
                    if (child.Style.PositionType == PositionType.Relative)
                    {
                        if (child.MarginLeadingValue(mainAxis).Unit == YogaUnit.Auto)
                        {
                            collectedFlexItemsValues.MainDim +=
                                collectedFlexItemsValues.RemainingFreeSpace /
                                numberOfAutoMarginsOnCurrentLine;
                        }

                        if (performLayout)
                        {
                            child.SetLayoutPosition(
                                childLayout.Position[Pos[(int)mainAxis]] +
                                collectedFlexItemsValues.MainDim,
                                (int)YogaArrange.Pos[(int)mainAxis]);
                        }

                        if (child.MarginTrailingValue(mainAxis).Unit == YogaUnit.Auto)
                        {
                            collectedFlexItemsValues.MainDim +=
                                collectedFlexItemsValues.RemainingFreeSpace /
                                numberOfAutoMarginsOnCurrentLine;
                        }

                        var canSkipFlex =
                            !performLayout && measureModeCrossDim == MeasureMode.Exactly;
                        if (canSkipFlex)
                        {
                            // If we skipped the flex step, then we can't rely on the measuredDims
                            // because they weren't computed. This means we can't call
                            // YGNodeDimWithMargin.
                            collectedFlexItemsValues.MainDim += betweenMainDim +
                                child.GetMarginForAxis(mainAxis, availableInnerWidth) +
                                childLayout.ComputedFlexBasis;
                            collectedFlexItemsValues.CrossDim = availableInnerCrossDim;
                        }
                        else
                        {
                            // The main dimension is the sum of all the elements dimension plus
                            // the spacing.
                            collectedFlexItemsValues.MainDim += betweenMainDim + child.DimWithMargin(mainAxis, availableInnerWidth);

                            if (isNodeBaselineLayout)
                            {
                                // If the child is baseline aligned then the cross dimension is
                                // calculated by adding maxAscent and maxDescent from the baseline.
                                var ascent = child.Baseline(layoutContext) +
                                    child.GetLeadingMargin(
                                            FlexDirection.Column,
                                            availableInnerWidth);
                                var descent =
                                    (child.Layout.MeasuredDimensions.Height +
                                        child.GetMarginForAxis(
                                                FlexDirection.Column,
                                                availableInnerWidth)) - ascent;

                                maxAscentForCurrentLine =
                                    FloatMax(maxAscentForCurrentLine, ascent);
                                maxDescentForCurrentLine =
                                    FloatMax(maxDescentForCurrentLine, descent);
                            }
                            else
                            {
                                // The cross dimension is the max of the elements dimension since
                                // there can only be one element in that cross dimension in the case
                                // when the items are not baseline aligned
                                collectedFlexItemsValues.CrossDim = FloatMax(
                                    collectedFlexItemsValues.CrossDim,
                                    child.DimWithMargin(crossAxis, availableInnerWidth));
                            }
                        }
                    }
                    else if (performLayout)
                    {
                        child.SetLayoutPosition(
                            childLayout.Position[Pos[(int)mainAxis]] +
                            node.GetLeadingBorder(mainAxis) + leadingMainDim,
                            (int)YogaArrange.Pos[(int)mainAxis]);
                    }
                }
            }

            collectedFlexItemsValues.MainDim += trailingPaddingAndBorderMain;

            if (isNodeBaselineLayout)
            {
                collectedFlexItemsValues.CrossDim =
                    maxAscentForCurrentLine + maxDescentForCurrentLine;
            }
        }

        //
        // This is the main routine that implements a subset of the flexbox layout
        // algorithm described in the W3C CSS documentation:
        // https://www.w3.org/TR/CSS3-flexbox/.
        //
        // Limitations of this algorithm, compared to the full standard:
        //  * Display property is always assumed to be 'flex' except for Text nodes,
        //    which are assumed to be 'inline-flex'.
        //  * The 'zIndex' property (or any form of z ordering) is not supported. Nodes
        //    are stacked in document order.
        //  * The 'order' property is not supported. The order of flex items is always
        //    defined by document order.
        //  * The 'visibility' property is always assumed to be 'visible'. Values of
        //    'collapse' and 'hidden' are not supported.
        //  * There is no support for forced breaks.
        //  * It does not support vertical inline directions (top-to-bottom or
        //    bottom-to-top text).
        //
        // Deviations from standard:
        //  * Section 4.5 of the spec indicates that all flex items have a default
        //    minimum main size. For text blocks, for example, this is the width of the
        //    widest word. Calculating the minimum width is expensive, so we forego it
        //    and assume a default minimum main size of 0.
        //  * Min/Max sizes in the main axis are not honored when resolving flexible
        //    lengths.
        //  * The spec indicates that the default value for 'flexDirection' is 'row',
        //    but the algorithm below assumes a default of 'column'.
        //
        // Input parameters:
        //    - node: current node to be sized and laid out
        //    - availableWidth & availableHeight: available size to be used for sizing
        //      the node or YGUndefined if the size is not available; interpretation
        //      depends on layout flags
        //    - ownerDirection: the inline (text) direction within the owner
        //      (left-to-right or right-to-left)
        //    - widthMeasureMode: indicates the sizing rules for the width (see below
        //      for explanation)
        //    - heightMeasureMode: indicates the sizing rules for the height (see below
        //      for explanation)
        //    - performLayout: specifies whether the caller is interested in just the
        //      dimensions of the node or it requires the entire node and its subtree to
        //      be laid out (with final positions)
        //
        // Details:
        //    This routine is called recursively to lay out subtrees of flexbox
        //    elements. It uses the information in node.style, which is treated as a
        //    read-only input. It is responsible for setting the layout.direction and
        //    layout.measuredDimensions fields for the input node as well as the
        //    layout.position and layout.lineIndex fields for its child nodes. The
        //    layout.measuredDimensions field includes any border or padding for the
        //    node but does not include margins.
        //
        //    The spec describes four different layout modes: "fill available", "max
        //    content", "min content", and "fit content". Of these, we don't use "min
        //    content" because we don't support default minimum main sizes (see above
        //    for details). Each of our measure modes maps to a layout mode from the
        //    spec (https://www.w3.org/TR/CSS3-sizing/#terms):
        //      - MeasureMode.Undefined: max content
        //      - MeasureMode.Exactly: fill available
        //      - MeasureMode.AtMost: fit content
        //
        //    When calling YGNodelayoutImpl and YGLayoutNodeInternal, if the caller
        //    passes an available size of undefined then it must also pass a measure
        //    mode of MeasureMode.Undefined in that dimension.
        //
         void YGNodelayoutImpl(
            YogaNode node,
            float availableWidth,
            float availableHeight,
            Direction ownerDirection,
            MeasureMode widthMeasureMode,
            MeasureMode heightMeasureMode,
            float ownerWidth,
            float ownerHeight,
            bool performLayout,
            YogaConfig config,
            LayoutData layoutMarkerData,
            object layoutContext,
            int depth,
            int generationCount,
            LayoutPassReason reason)
        {
            Debug.Assert(
                availableWidth.HasValue() || widthMeasureMode == MeasureMode.Undefined,
                "availableWidth is indefinite so widthMeasureMode must be MeasureMode.Undefined");
            Debug.Assert(
                availableHeight.HasValue() || heightMeasureMode == MeasureMode.Undefined,
                "availableHeight is indefinite so heightMeasureMode must be MeasureMode.Undefined");

            if (performLayout)
                layoutMarkerData.Layouts++;
            else
                layoutMarkerData.Measures++;

            // Set the resolved resolution in the node's layout.
            var direction = node.ResolveDirection(ownerDirection);
            node.SetLayoutDirection(direction);

            var flexRowDirection = FlexDirection.Row.Resolve(direction);
            var flexColumnDirection = FlexDirection.Column.Resolve(direction);

            var startEdge =
                direction == Direction.LTR ? Edge.Left : Edge.Right;
            var endEdge = direction == Direction.LTR ? Edge.Right : Edge.Left;
            node.SetLayoutMargin(
                node.GetLeadingMargin(flexRowDirection, ownerWidth),
                startEdge);
            node.SetLayoutMargin(
                node.GetTrailingMargin(flexRowDirection, ownerWidth),
                endEdge);
            node.SetLayoutMargin(
                node.GetLeadingMargin(flexColumnDirection, ownerWidth),
                Edge.Top);
            node.SetLayoutMargin(
                node.GetTrailingMargin(flexColumnDirection, ownerWidth),
                Edge.Bottom);

            node.SetLayoutBorder(node.GetLeadingBorder(flexRowDirection), startEdge);
            node.SetLayoutBorder(node.GetTrailingBorder(flexRowDirection), endEdge);
            node.SetLayoutBorder(node.GetLeadingBorder(flexColumnDirection), Edge.Top);
            node.SetLayoutBorder(
                node.GetTrailingBorder(flexColumnDirection),
                Edge.Bottom);

            node.SetLayoutPadding(
                node.GetLeadingPadding(flexRowDirection, ownerWidth),
                startEdge);
            node.SetLayoutPadding(
                node.GetTrailingPadding(flexRowDirection, ownerWidth),
                endEdge);
            node.SetLayoutPadding(
                node.GetLeadingPadding(flexColumnDirection, ownerWidth),
                Edge.Top);
            node.SetLayoutPadding(
                node.GetTrailingPadding(flexColumnDirection, ownerWidth),
                Edge.Bottom);

            if (node.MeasureFunc != null)
            {
                YGNodeWithMeasureFuncSetMeasuredDimensions(
                    node,
                    availableWidth,
                    availableHeight,
                    widthMeasureMode,
                    heightMeasureMode,
                    ownerWidth,
                    ownerHeight,
                    layoutMarkerData,
                    layoutContext,
                    reason);
                return;
            }

            var childCount = node.Children.Count;
            if (childCount == 0)
            {
                YGNodeEmptyContainerSetMeasuredDimensions(
                    node,
                    availableWidth,
                    availableHeight,
                    widthMeasureMode,
                    heightMeasureMode,
                    ownerWidth,
                    ownerHeight);
                return;
            }

            // If we're not being asked to perform a full layout we can skip the algorithm
            // if we already know the size
            if (!performLayout &&
                YGNodeFixedSizeSetMeasuredDimensions(
                    node,
                    availableWidth,
                    availableHeight,
                    widthMeasureMode,
                    heightMeasureMode,
                    ownerWidth,
                    ownerHeight))
            {
                return;
            }

            // At this point we know we're going to perform work. Ensure that each child
            // has a mutable copy.
            node.CloneChildrenIfNeeded(layoutContext);
            // Reset layout flags, as they could have changed.
            node.SetLayoutHadOverflow(false);

            // STEP 1: CALCULATE VALUES FOR REMAINDER OF ALGORITHM
            var mainAxis = node.Style.FlexDirection.Resolve(direction);
            var crossAxis = mainAxis.CrossAxis(direction);
            var isMainAxisRow = mainAxis.IsRow();
            var isNodeFlexWrap = node.Style.FlexWrap != Wrap.NoWrap;

            var mainAxisownerSize = isMainAxisRow ? ownerWidth : ownerHeight;
            var crossAxisownerSize = isMainAxisRow ? ownerHeight : ownerWidth;

            var leadingPaddingAndBorderCross = node.GetLeadingPaddingAndBorder(crossAxis, ownerWidth);
            var paddingAndBorderAxisMain = node.PaddingAndBorderForAxis(mainAxis, ownerWidth);
            var paddingAndBorderAxisCross = node.PaddingAndBorderForAxis(crossAxis, ownerWidth);

            var measureModeMainDim =
                isMainAxisRow ? widthMeasureMode : heightMeasureMode;
            var measureModeCrossDim =
                isMainAxisRow ? heightMeasureMode : widthMeasureMode;

            var paddingAndBorderAxisRow =
                isMainAxisRow ? paddingAndBorderAxisMain : paddingAndBorderAxisCross;
            var paddingAndBorderAxisColumn =
                isMainAxisRow ? paddingAndBorderAxisCross : paddingAndBorderAxisMain;

            var marginAxisRow =
                node.GetMarginForAxis(FlexDirection.Row, ownerWidth);
            var marginAxisColumn =
                node.GetMarginForAxis(FlexDirection.Column, ownerWidth);

            var minInnerWidth = node.Style.MinWidth.Resolve(ownerWidth) - paddingAndBorderAxisRow;
            var maxInnerWidth = node.Style.MaxWidth.Resolve(ownerWidth) - paddingAndBorderAxisRow;
            var minInnerHeight = node.Style.MinHeight.Resolve(ownerHeight) - paddingAndBorderAxisColumn;
            var maxInnerHeight = node.Style.MaxHeight.Resolve(ownerHeight) - paddingAndBorderAxisColumn;

            var minInnerMainDim = isMainAxisRow ? minInnerWidth : minInnerHeight;
            var maxInnerMainDim = isMainAxisRow ? maxInnerWidth : maxInnerHeight;

            // STEP 2: DETERMINE AVAILABLE SIZE IN MAIN AND CROSS DIRECTIONS

            var availableInnerWidth = YGNodeCalculateAvailableInnerDim(
                node,
                FlexDirection.Row,
                availableWidth,
                ownerWidth);
            var availableInnerHeight = YGNodeCalculateAvailableInnerDim(
                node,
                FlexDirection.Column,
                availableHeight,
                ownerHeight);

            var availableInnerMainDim =
                isMainAxisRow ? availableInnerWidth : availableInnerHeight;
            var availableInnerCrossDim =
                isMainAxisRow ? availableInnerHeight : availableInnerWidth;

            // STEP 3: DETERMINE FLEX BASIS FOR EACH ITEM

            var totalOuterFlexBasis = YGNodeComputeFlexBasisForChildren(
                node,
                availableInnerWidth,
                availableInnerHeight,
                widthMeasureMode,
                heightMeasureMode,
                direction,
                mainAxis,
                config,
                performLayout,
                layoutMarkerData,
                layoutContext,
                depth,
                generationCount);

            var flexBasisOverflows = measureModeMainDim == MeasureMode.Undefined
                ? false
                : totalOuterFlexBasis > availableInnerMainDim;
            if (isNodeFlexWrap && flexBasisOverflows &&
                measureModeMainDim == MeasureMode.AtMost)
            {
                measureModeMainDim = MeasureMode.Exactly;
            }
            // STEP 4: COLLECT FLEX ITEMS INTO FLEX LINES

            // Indexes of children that represent the first and last items in the line.
            var startOfLineIndex = 0;
            var endOfLineIndex = 0;

            // Number of lines.
            var lineCount = 0;

            // Accumulated cross dimensions of all lines so far.
            float totalLineCrossDim = 0;

            // Max main dimension of all the lines.
            float maxLineMainDim = 0;
            CollectFlexItemsRowValues collectedFlexItemsValues;
            for (;
                endOfLineIndex < childCount;
                lineCount++, startOfLineIndex = endOfLineIndex)
            {
                collectedFlexItemsValues = YGCalculateCollectFlexItemsRowValues(
                    node,
                    ownerDirection,
                    mainAxisownerSize,
                    availableInnerWidth,
                    availableInnerMainDim,
                    startOfLineIndex,
                    lineCount);
                endOfLineIndex = collectedFlexItemsValues.EndOfLineIndex;

                // If we don't need to measure the cross axis, we can skip the entire flex
                // step.
                var canSkipFlex =
                    !performLayout && measureModeCrossDim == MeasureMode.Exactly;

                // STEP 5: RESOLVING FLEXIBLE LENGTHS ON MAIN AXIS
                // Calculate the remaining available space that needs to be allocated. If
                // the main dimension size isn't known, it is computed based on the line
                // length, so there's no more space left to distribute.

                var sizeBasedOnContent = false;
                // If we don't measure with exact main dimension we want to ensure we don't
                // violate min and max
                if (measureModeMainDim != MeasureMode.Exactly)
                {
                    if (minInnerMainDim.HasValue() &&
                        collectedFlexItemsValues.SizeConsumedOnCurrentLine <
                        minInnerMainDim)
                    {
                        availableInnerMainDim = minInnerMainDim;
                    }
                    else if (
                        maxInnerMainDim.HasValue() &&
                        collectedFlexItemsValues.SizeConsumedOnCurrentLine >
                        maxInnerMainDim)
                    {
                        availableInnerMainDim = maxInnerMainDim;
                    }
                    else
                    {
                        if (collectedFlexItemsValues.TotalFlexGrowFactors.IsUndefined() && collectedFlexItemsValues.TotalFlexGrowFactors.IsZero() ||
                            node.ResolveFlexGrow().IsUndefined() && node.ResolveFlexGrow().IsZero())
                        {
                            // If we don't have any children to flex or we can't flex the node
                            // itself, space we've used is all space we need. Root node also
                            // should be shrunk to minimum
                            availableInnerMainDim = collectedFlexItemsValues.SizeConsumedOnCurrentLine;
                        }

                        sizeBasedOnContent = true;
                    }
                }

                if (!sizeBasedOnContent && availableInnerMainDim.HasValue())
                {
                    collectedFlexItemsValues.RemainingFreeSpace = availableInnerMainDim - collectedFlexItemsValues.SizeConsumedOnCurrentLine;
                }
                else if (collectedFlexItemsValues.SizeConsumedOnCurrentLine < 0)
                {
                    // availableInnerMainDim is indefinite which means the node is being sized
                    // based on its content. sizeConsumedOnCurrentLine is negative which means
                    // the node will allocate 0 points for its content. Consequently,
                    // remainingFreeSpace is 0 - sizeConsumedOnCurrentLine.
                    collectedFlexItemsValues.RemainingFreeSpace =
                        -collectedFlexItemsValues.SizeConsumedOnCurrentLine;
                }

                if (!canSkipFlex)
                {
                    YGResolveFlexibleLength(
                        node,
                        collectedFlexItemsValues,
                        mainAxis,
                        crossAxis,
                        mainAxisownerSize,
                        availableInnerMainDim,
                        availableInnerCrossDim,
                        availableInnerWidth,
                        availableInnerHeight,
                        flexBasisOverflows,
                        measureModeCrossDim,
                        performLayout,
                        config,
                        layoutMarkerData,
                        layoutContext,
                        depth,
                        generationCount);
                }

                node.SetLayoutHadOverflow(
                    node.Layout.HadOverflow | (collectedFlexItemsValues.RemainingFreeSpace < 0));

                // STEP 6: MAIN-AXIS JUSTIFICATION & CROSS-AXIS SIZE DETERMINATION

                // At this point, all the children have their dimensions set in the main
                // axis. Their dimensions are also set in the cross axis with the exception
                // of items that are aligned "stretch". We need to compute these stretch
                // values and set the final positions.

                YGJustifyMainAxis(
                    node,
                    collectedFlexItemsValues,
                    startOfLineIndex,
                    mainAxis,
                    crossAxis,
                    measureModeMainDim,
                    measureModeCrossDim,
                    mainAxisownerSize,
                    ownerWidth,
                    availableInnerMainDim,
                    availableInnerCrossDim,
                    availableInnerWidth,
                    performLayout,
                    layoutContext);

                var containerCrossAxis = availableInnerCrossDim;
                if (measureModeCrossDim == MeasureMode.Undefined ||
                    measureModeCrossDim == MeasureMode.AtMost)
                {
                    // Compute the cross axis from the max cross dimension of the children.
                    containerCrossAxis =
                        node.BoundAxis(
                            crossAxis,
                            collectedFlexItemsValues.CrossDim + paddingAndBorderAxisCross,
                            crossAxisownerSize,
                            ownerWidth) -
                        paddingAndBorderAxisCross;
                }

                // If there's no flex wrap, the cross dimension is defined by the container.
                if (!isNodeFlexWrap && measureModeCrossDim == MeasureMode.Exactly)
                {
                    collectedFlexItemsValues.CrossDim = availableInnerCrossDim;
                }

                // Clamp to the min/max size specified on the container.
                collectedFlexItemsValues.CrossDim =
                    node.BoundAxis(
                        crossAxis,
                        collectedFlexItemsValues.CrossDim + paddingAndBorderAxisCross,
                        crossAxisownerSize,
                        ownerWidth) -
                    paddingAndBorderAxisCross;

                // STEP 7: CROSS-AXIS ALIGNMENT
                // We can skip child alignment if we're just measuring the container.
                if (performLayout)
                {
                    for (var i = startOfLineIndex; i < endOfLineIndex; i++)
                    {
                        var child = node.Children[i];
                        if (child.Style.Display == Display.None)
                        {
                            continue;
                        }

                        if (child.Style.PositionType == PositionType.Absolute)
                        {
                            // If the child is absolutely positioned and has a
                            // top/left/bottom/right set, override all the previously computed
                            // positions to set it correctly.
                            var isChildLeadingPosDefined =
                                child.IsLeadingPositionDefined(crossAxis);
                            if (isChildLeadingPosDefined)
                            {
                                child.SetLayoutPosition(
                                    child.GetLeadingPosition(crossAxis, availableInnerCrossDim) +
                                    node.GetLeadingBorder(crossAxis) +
                                    child.GetLeadingMargin(crossAxis, availableInnerWidth),
                                    (int)YogaArrange.Pos[(int)crossAxis]);
                            }

                            // If leading position is not defined or calculations result in Nan,
                            // default to border + margin
                            if (!isChildLeadingPosDefined ||
                                child.Layout.Position[Pos[(int)crossAxis]].IsUndefined())
                            {
                                child.SetLayoutPosition(
                                    node.GetLeadingBorder(crossAxis) +
                                    child.GetLeadingMargin(crossAxis, availableInnerWidth),
                                    (int)YogaArrange.Pos[(int)crossAxis]);
                            }
                        }
                        else
                        {
                            var leadingCrossDim = leadingPaddingAndBorderCross;

                            // For a relative children, we're either using alignItems (owner) or
                            // alignSelf (child) in order to determine the position in the cross
                            // axis
                            var alignItem = node.AlignItem(child);

                            // If the child uses align stretch, we need to lay it out one more
                            // time, this time forcing the cross-axis size to be the computed
                            // cross size for the current line.
                            if (alignItem == YogaAlign.Stretch &&
                                child.MarginLeadingValue(crossAxis).Unit != YogaUnit.Auto &&
                                child.MarginTrailingValue(crossAxis).Unit != YogaUnit.Auto)
                            {
                                // If the child defines a definite size for its cross axis, there's
                                // no need to stretch.
                                if (!child.IsStyleDimDefined( crossAxis, availableInnerCrossDim))
                                {
                                    var childMainSize =
                                        child.Layout.MeasuredDimensions[Dim[(int)mainAxis]];
                                    var childCrossSize = child.Style.AspectRatio.HasValue()
                                        ? child.GetMarginForAxis(crossAxis, availableInnerWidth)
                                        +
                                        (isMainAxisRow
                                            ? childMainSize / child.Style.AspectRatio
                                            : childMainSize * child.Style.AspectRatio)
                                        : collectedFlexItemsValues.CrossDim;

                                    childMainSize +=
                                        child.GetMarginForAxis(mainAxis, availableInnerWidth);

                                    var childMainMeasureMode = MeasureMode.Exactly;
                                    var childCrossMeasureMode = MeasureMode.Exactly;
                                    child.ConstrainMaxSizeForMode(
                                        mainAxis,
                                        availableInnerMainDim,
                                        availableInnerWidth,
                                        ref childMainMeasureMode,
                                        ref childMainSize);
                                    child.ConstrainMaxSizeForMode(
                                        crossAxis,
                                        availableInnerCrossDim,
                                        availableInnerWidth,
                                        ref childCrossMeasureMode,
                                        ref childCrossSize);

                                    var childWidth =
                                        isMainAxisRow ? childMainSize : childCrossSize;
                                    var childHeight =
                                        !isMainAxisRow ? childMainSize : childCrossSize;

                                    var alignContent = node.Style.AlignContent;
                                    var crossAxisDoesNotGrow =
                                        alignContent != YogaAlign.Stretch && isNodeFlexWrap;
                                    var childWidthMeasureMode =
                                        childWidth.IsUndefined() ||
                                        !isMainAxisRow && crossAxisDoesNotGrow
                                            ? MeasureMode.Undefined
                                            : MeasureMode.Exactly;
                                    var childHeightMeasureMode =
                                        childHeight.IsUndefined() ||
                                        isMainAxisRow && crossAxisDoesNotGrow
                                            ? MeasureMode.Undefined
                                            : MeasureMode.Exactly;

                                    YGLayoutNodeInternal(
                                        child,
                                        childWidth,
                                        childHeight,
                                        direction,
                                        childWidthMeasureMode,
                                        childHeightMeasureMode,
                                        availableInnerWidth,
                                        availableInnerHeight,
                                        true,
                                        LayoutPassReason.Stretch,
                                        config,
                                        layoutMarkerData,
                                        layoutContext,
                                        depth,
                                        generationCount);
                                }
                            }
                            else
                            {
                                var remainingCrossDim = containerCrossAxis - child.DimWithMargin(crossAxis, availableInnerWidth);

                                if (child.MarginLeadingValue(crossAxis).Unit == YogaUnit.Auto &&
                                    child.MarginTrailingValue(crossAxis).Unit == YogaUnit.Auto)
                                {
                                    leadingCrossDim += FloatMax(0.0f, remainingCrossDim / 2);
                                }
                                else if (
                                    child.MarginTrailingValue(crossAxis).Unit == YogaUnit.Auto)
                                {
                                    // No-Op
                                }
                                else if (
                                    child.MarginLeadingValue(crossAxis).Unit == YogaUnit.Auto)
                                {
                                    leadingCrossDim += FloatMax(0.0f, remainingCrossDim);
                                }
                                else if (alignItem == YogaAlign.FlexStart)
                                {
                                    // No-Op
                                }
                                else if (alignItem == YogaAlign.Center)
                                {
                                    leadingCrossDim += remainingCrossDim / 2;
                                }
                                else
                                {
                                    leadingCrossDim += remainingCrossDim;
                                }
                            }

                            // And we apply the position
                            child.SetLayoutPosition(
                                child.Layout.Position[Pos[(int)crossAxis]] + totalLineCrossDim +
                                leadingCrossDim,
                                (int)YogaArrange.Pos[(int)crossAxis]);
                        }
                    }
                }

                totalLineCrossDim += collectedFlexItemsValues.CrossDim;
                maxLineMainDim =
                    FloatMax(maxLineMainDim, collectedFlexItemsValues.MainDim);
            }

            // STEP 8: MULTI-LINE CONTENT ALIGNMENT
            // currentLead stores the size of the cross dim
            if (performLayout && (isNodeFlexWrap || node.IsBaselineLayout()))
            {
                float crossDimLead = 0;
                var currentLead = leadingPaddingAndBorderCross;
                if (availableInnerCrossDim.HasValue())
                {
                    var remainingAlignContentDim =
                        availableInnerCrossDim - totalLineCrossDim;
                    switch (node.Style.AlignContent)
                    {
                    case YogaAlign.FlexEnd:
                        currentLead += remainingAlignContentDim;
                        break;
                    case YogaAlign.Center:
                        currentLead += remainingAlignContentDim / 2;
                        break;
                    case YogaAlign.Stretch:
                        if (availableInnerCrossDim > totalLineCrossDim)
                        {
                            crossDimLead = remainingAlignContentDim / lineCount;
                        }

                        break;
                    case YogaAlign.SpaceAround:
                        if (availableInnerCrossDim > totalLineCrossDim)
                        {
                            currentLead += remainingAlignContentDim / (2 * lineCount);
                            if (lineCount > 1)
                            {
                                crossDimLead = remainingAlignContentDim / lineCount;
                            }
                        }
                        else
                        {
                            currentLead += remainingAlignContentDim / 2;
                        }

                        break;
                    case YogaAlign.SpaceBetween:
                        if (availableInnerCrossDim > totalLineCrossDim && lineCount > 1)
                        {
                            crossDimLead = remainingAlignContentDim / (lineCount - 1);
                        }

                        break;
                    case YogaAlign.Auto:
                    case YogaAlign.FlexStart:
                    case YogaAlign.Baseline:
                        break;
                    }
                }

                var endIndex = 0;
                for (var i = 0; i < lineCount; i++)
                {
                    var startIndex = endIndex;
                    int ii;

                    // compute the line's height and find the endIndex
                    float lineHeight = 0;
                    float maxAscentForCurrentLine = 0;
                    float maxDescentForCurrentLine = 0;
                    for (ii = startIndex; ii < childCount; ii++)
                    {
                        var child = node.Children[ii];
                        if (child.Style.Display == Display.None)
                        {
                            continue;
                        }

                        if (child.Style.PositionType == PositionType.Relative)
                        {
                            if (child.LineIndex != i)
                            {
                                break;
                            }

                            if (child.IsLayoutDimDefined(crossAxis))
                            {
                                lineHeight = FloatMax(
                                    lineHeight,
                                    child.Layout.MeasuredDimensions[Dim[(int)crossAxis]] +
                                    child.GetMarginForAxis(crossAxis, availableInnerWidth));
                            }

                            if (node.AlignItem(child) == YogaAlign.Baseline)
                            {
                                var ascent = child.Baseline(layoutContext) + child.GetLeadingMargin(FlexDirection.Column, availableInnerWidth);
                                var descent = (child.Layout.MeasuredDimensions.Height +
                                        child.GetMarginForAxis(FlexDirection.Column, availableInnerWidth)) - ascent;
                                maxAscentForCurrentLine = FloatMax(maxAscentForCurrentLine, ascent);
                                maxDescentForCurrentLine = FloatMax(maxDescentForCurrentLine, descent);
                                lineHeight = FloatMax(lineHeight, maxAscentForCurrentLine + maxDescentForCurrentLine);
                            }
                        }
                    }

                    endIndex   =  ii;
                    lineHeight += crossDimLead;

                    if (performLayout)
                    {
                        for (ii = startIndex; ii < endIndex; ii++)
                        {
                            var child = node.Children[ii];
                            if (child.Style.Display == Display.None)
                            {
                                continue;
                            }

                            if (child.Style.PositionType == PositionType.Relative)
                            {
                                switch (node.AlignItem(child))
                                {
                                case YogaAlign.FlexStart:
                                {
                                    child.SetLayoutPosition(
                                        currentLead +
                                        child.GetLeadingMargin(crossAxis, availableInnerWidth),
                                        (int)YogaArrange.Pos[(int)crossAxis]);
                                    break;
                                }
                                case YogaAlign.FlexEnd:
                                {
                                    child.SetLayoutPosition(
                                        (currentLead + lineHeight) -
                                        child.GetTrailingMargin(crossAxis, availableInnerWidth)
                                        -
                                        child.Layout.MeasuredDimensions[Dim[(int)crossAxis]],
                                        (int)YogaArrange.Pos[(int)crossAxis]);
                                    break;
                                }
                                case YogaAlign.Center:
                                {
                                    var childHeight =
                                        child.Layout.MeasuredDimensions[Dim[(int)crossAxis]];

                                    child.SetLayoutPosition(
                                        currentLead + ((lineHeight - childHeight) / 2),
                                        (int)YogaArrange.Pos[(int)crossAxis]);
                                    break;
                                }
                                case YogaAlign.Stretch:
                                {
                                    child.SetLayoutPosition(
                                        currentLead +
                                        child.GetLeadingMargin(crossAxis, availableInnerWidth),
                                        (int)YogaArrange.Pos[(int)crossAxis]);

                                    // Remeasure child with the line height as it as been only
                                    // measured with the owners height yet.
                                    if (!child.IsStyleDimDefined( crossAxis, availableInnerCrossDim))
                                    {
                                        var childWidth = isMainAxisRow
                                            ? child.Layout
                                                   .MeasuredDimensions.Width +
                                            child.GetMarginForAxis(mainAxis, availableInnerWidth)
                                            : lineHeight;

                                        var childHeight = !isMainAxisRow
                                            ? child.Layout.MeasuredDimensions.Height +
                                            child.GetMarginForAxis(crossAxis, availableInnerWidth)
                                            : lineHeight;

                                        if (!(FloatsEqual(
                                                childWidth,
                                                child.Layout.MeasuredDimensions.Width) &&
                                            FloatsEqual(
                                                childHeight,
                                                child.Layout.MeasuredDimensions.Height)))
                                        {
                                            YGLayoutNodeInternal(
                                                child,
                                                childWidth,
                                                childHeight,
                                                direction,
                                                MeasureMode.Exactly,
                                                MeasureMode.Exactly,
                                                availableInnerWidth,
                                                availableInnerHeight,
                                                true,
                                                LayoutPassReason.MultilineStretch,
                                                config,
                                                layoutMarkerData,
                                                layoutContext,
                                                depth,
                                                generationCount);
                                        }
                                    }

                                    break;
                                }
                                case YogaAlign.Baseline:
                                {
                                    child.SetLayoutPosition(
                                        ((currentLead + maxAscentForCurrentLine) -
                                            child.Baseline(layoutContext)) +
                                        child.GetLeadingPosition(FlexDirection.Column, availableInnerCrossDim),
                                        (int)Edge.Top);

                                    break;
                                }
                                case YogaAlign.Auto:
                                case YogaAlign.SpaceBetween:
                                case YogaAlign.SpaceAround:
                                    break;
                                }
                            }
                        }
                    }

                    currentLead += lineHeight;
                }
            }

            // STEP 9: COMPUTING FINAL DIMENSIONS

            node.SetLayoutMeasuredDimension(
                node.BoundAxis(
                    FlexDirection.Row,
                    availableWidth - marginAxisRow,
                    ownerWidth,
                    ownerWidth),
                (int)Dimension.Width);

            node.SetLayoutMeasuredDimension(
                node.BoundAxis(
                    FlexDirection.Column,
                    availableHeight - marginAxisColumn,
                    ownerHeight,
                    ownerWidth),
                (int)Dimension.Height);

            // If the user didn't specify a width or height for the node, set the
            // dimensions based on the children.
            if (measureModeMainDim == MeasureMode.Undefined ||
                node.Style.Overflow != Overflow.Scroll &&
                measureModeMainDim == MeasureMode.AtMost)
            {
                // Clamp the size to the min/max size, if specified, and make sure it
                // doesn't go below the padding and border amount.
                node.SetLayoutMeasuredDimension(
                    node.BoundAxis(
                        mainAxis,
                        maxLineMainDim,
                        mainAxisownerSize,
                        ownerWidth),
                    (int)YogaArrange.Dim[(int)mainAxis]);
            }
            else if (
                measureModeMainDim == MeasureMode.AtMost &&
                node.Style.Overflow == Overflow.Scroll)
            {
                node.SetLayoutMeasuredDimension(
                    FloatMax(
                        FloatMin(
                            availableInnerMainDim + paddingAndBorderAxisMain,
                            node.BoundAxisWithinMinAndMax(
                                mainAxis,
                                maxLineMainDim,
                                mainAxisownerSize)
                        ),
                        paddingAndBorderAxisMain),
                    (int)YogaArrange.Dim[(int)mainAxis]);
            }

            if (measureModeCrossDim == MeasureMode.Undefined ||
                node.Style.Overflow != Overflow.Scroll &&
                measureModeCrossDim == MeasureMode.AtMost)
            {
                // Clamp the size to the min/max size, if specified, and make sure it
                // doesn't go below the padding and border amount.
                node.SetLayoutMeasuredDimension(
                    node.BoundAxis(
                        crossAxis,
                        totalLineCrossDim + paddingAndBorderAxisCross,
                        crossAxisownerSize,
                        ownerWidth),
                    (int)YogaArrange.Dim[(int)crossAxis]);
            }
            else if (
                measureModeCrossDim == MeasureMode.AtMost &&
                node.Style.Overflow == Overflow.Scroll)
            {
                node.SetLayoutMeasuredDimension(
                    FloatMax(
                        FloatMin(
                            availableInnerCrossDim + paddingAndBorderAxisCross,
                            node.BoundAxisWithinMinAndMax(
                                crossAxis,
                                totalLineCrossDim + paddingAndBorderAxisCross,
                                crossAxisownerSize)
                        ),
                        paddingAndBorderAxisCross),
                    (int)YogaArrange.Dim[(int)crossAxis]);
            }

            // As we only wrapped in normal direction yet, we need to reverse the
            // positions on wrap-reverse.
            if (performLayout && node.Style.FlexWrap == Wrap.WrapReverse)
            {
                for (var i = 0; i < childCount; i++)
                {
                    var child = node.Children[i];
                    if (child.Style.PositionType == PositionType.Relative)
                    {
                        child.SetLayoutPosition(
                            node.Layout.MeasuredDimensions[Dim[(int)crossAxis]] -
                            child.Layout.Position[Pos[(int)crossAxis]] -
                            child.Layout.MeasuredDimensions[Dim[(int)crossAxis]],
                            (int)YogaArrange.Pos[(int)crossAxis]);
                    }
                }
            }

            if (performLayout)
            {
                // STEP 10: SIZING AND POSITIONING ABSOLUTE CHILDREN
                foreach (var child in node.Children)
                {
                    if (child.Style.PositionType != PositionType.Absolute)
                    {
                        continue;
                    }

                    YGNodeAbsoluteLayoutChild(
                        node,
                        child,
                        availableInnerWidth,
                        isMainAxisRow ? measureModeMainDim : measureModeCrossDim,
                        availableInnerHeight,
                        direction,
                        config,
                        layoutMarkerData,
                        layoutContext,
                        depth,
                        generationCount);
                }

                // STEP 11: SETTING TRAILING POSITIONS FOR CHILDREN
                var needsMainTrailingPos = mainAxis == FlexDirection.RowReverse ||
                    mainAxis == FlexDirection.ColumnReverse;
                var needsCrossTrailingPos = crossAxis == FlexDirection.RowReverse ||
                    crossAxis == FlexDirection.ColumnReverse;

                // Set trailing position if necessary.
                if (needsMainTrailingPos || needsCrossTrailingPos)
                {
                    for (var i = 0; i < childCount; i++)
                    {
                        var child = node.Children[i];
                        if (child.Style.Display == Display.None)
                        {
                            continue;
                        }

                        if (needsMainTrailingPos)
                        {
                            node.SetChildTrailingPosition(child, mainAxis);
                        }

                        if (needsCrossTrailingPos)
                        {
                            node.SetChildTrailingPosition(child, crossAxis);
                        }
                    }
                }
            }
        }

#if DEBUG
        public static bool PrintChanges = false;
        public static bool PrintSkips = false;
#else
        static bool PrintChanges = false;
        static bool PrintSkips = false;
#endif

        static  string spacer = "                                                            ";

        static  string YGSpacer(int level)
        {
            var spacerLen = spacer.Length;
            if (level > spacerLen)
                return spacer;
            return spacer.Substring(spacerLen - level);
        }

         string YGMeasureModeName(MeasureMode mode, bool performLayout)
        {
            var kMeasureModeNames = new Dictionary<MeasureMode, string>
            {
                {MeasureMode.Undefined, "UNDEFINED"},
                {MeasureMode.Exactly, "EXACTLY"},
                {MeasureMode.AtMost, "AT_MOST"}
            };
            var kLayoutModeNames = new Dictionary<MeasureMode, string>
            {
                {MeasureMode.Undefined, "LAY_UNDEFINED"},
                {MeasureMode.Exactly, "LAY_EXACTLY"},
                {MeasureMode.AtMost, "LAY_AT_MOST"}
            };

            if (mode >= MeasureMode.AtMost)
                return "";

            return performLayout ? kLayoutModeNames[mode] : kMeasureModeNames[mode];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
         bool YGMeasureModeSizeIsExactAndMatchesOldMeasuredSize(MeasureMode sizeMode,float size,float lastComputedSize) =>sizeMode == MeasureMode.Exactly && FloatsEqual(size, lastComputedSize);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
         bool YGMeasureModeOldSizeIsUnspecifiedAndStillFits(MeasureMode sizeMode,float size,MeasureMode lastSizeMode,float lastComputedSize) =>
            sizeMode == MeasureMode.AtMost && 
            lastSizeMode == MeasureMode.Undefined &&
            (size >= lastComputedSize || FloatsEqual(size, lastComputedSize));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
         bool YGMeasureModeNewMeasureSizeIsStricterAndStillValid(MeasureMode sizeMode,float size,MeasureMode lastSizeMode,float lastSize,float lastComputedSize) =>
            lastSizeMode == MeasureMode.AtMost &&
            sizeMode == MeasureMode.AtMost && lastSize.HasValue() &&
            size.HasValue() && lastComputedSize.HasValue() &&
            lastSize > size &&
            (lastComputedSize <= size || FloatsEqual(size, lastComputedSize));

         bool YGNodeCanUseCachedMeasurement(
            MeasureMode widthMode,
            float width,
            MeasureMode heightMode,
            float height,
            MeasureMode lastWidthMode,
            float lastWidth,
            MeasureMode lastHeightMode,
            float lastHeight,
            float lastComputedWidth,
            float lastComputedHeight,
            float marginRow,
            float marginColumn,
            YogaConfig config)
        {
            if (lastComputedHeight.HasValue() && lastComputedHeight < 0 ||
                lastComputedWidth.HasValue() && lastComputedWidth < 0)
            {
                return false;
            }

            var useRoundedComparison =
                config != null && config.PointScaleFactor != 0;
            var effectiveWidth = useRoundedComparison
                ? RoundValueToPixelGrid(width, config.PointScaleFactor, false, false)
                : width;
            var effectiveHeight = useRoundedComparison
                ? RoundValueToPixelGrid(height, config.PointScaleFactor, false, false)
                : height;
            var effectiveLastWidth = useRoundedComparison
                ? RoundValueToPixelGrid(
                    lastWidth,
                    config.PointScaleFactor,
                    false,
                    false)
                : lastWidth;
            var effectiveLastHeight = useRoundedComparison
                ? RoundValueToPixelGrid(
                    lastHeight,
                    config.PointScaleFactor,
                    false,
                    false)
                : lastHeight;

            var hasSameWidthSpec = lastWidthMode == widthMode &&
                FloatsEqual(effectiveLastWidth, effectiveWidth);
            var hasSameHeightSpec = lastHeightMode == heightMode &&
                FloatsEqual(effectiveLastHeight, effectiveHeight);

            var widthIsCompatible =
                hasSameWidthSpec ||
                YGMeasureModeSizeIsExactAndMatchesOldMeasuredSize(
                    widthMode,
                    width - marginRow,
                    lastComputedWidth) ||
                YGMeasureModeOldSizeIsUnspecifiedAndStillFits(
                    widthMode,
                    width - marginRow,
                    lastWidthMode,
                    lastComputedWidth) ||
                YGMeasureModeNewMeasureSizeIsStricterAndStillValid(
                    widthMode,
                    width - marginRow,
                    lastWidthMode,
                    lastWidth,
                    lastComputedWidth);

            var heightIsCompatible =
                hasSameHeightSpec ||
                YGMeasureModeSizeIsExactAndMatchesOldMeasuredSize(
                    heightMode,
                    height - marginColumn,
                    lastComputedHeight) ||
                YGMeasureModeOldSizeIsUnspecifiedAndStillFits(
                    heightMode,
                    height - marginColumn,
                    lastHeightMode,
                    lastComputedHeight) ||
                YGMeasureModeNewMeasureSizeIsStricterAndStillValid(
                    heightMode,
                    height - marginColumn,
                    lastHeightMode,
                    lastHeight,
                    lastComputedHeight);

            return widthIsCompatible && heightIsCompatible;
        }

        //
        // This is a wrapper around the YGNodelayoutImpl function. It determines whether
        // the layout request is redundant and can be skipped.
        //
        // Parameters:
        //  Input parameters are the same as YGNodelayoutImpl (see above)
        //  Return parameter is true if layout was performed, false if skipped
        //
         bool YGLayoutNodeInternal(
            YogaNode node,
            float availableWidth,
            float availableHeight,
            Direction ownerDirection,
            MeasureMode widthMeasureMode,
            MeasureMode heightMeasureMode,
            float ownerWidth,
            float ownerHeight,
            bool performLayout,
            LayoutPassReason reason,
            YogaConfig config,
            LayoutData layoutMarkerData,
            object layoutContext,
            int depth,
            int generationCount)
        {
            var layout = node.Layout;

            depth++;

            var needToVisitNode =
                node.IsDirty && layout.GenerationCount != generationCount ||
                layout.LastOwnerDirection != ownerDirection;

            if (needToVisitNode)
            {
                // Invalidate the cached results.
                layout.NextCachedMeasurementsIndex    = 0;
                layout.CachedLayout.WidthMeasureMode  = MeasureMode.Undefined;
                layout.CachedLayout.HeightMeasureMode = MeasureMode.Undefined;
                layout.CachedLayout.ComputedWidth     = -1;
                layout.CachedLayout.ComputedHeight    = -1;
            }

            YogaCachedMeasurement cachedResults = null;

            // Determine whether the results are already cached. We maintain a separate
            // cache for layouts and measurements. A layout operation modifies the
            // positions and dimensions for nodes in the subtree. The algorithm assumes
            // that each node gets laid out a maximum of one time per tree layout, but
            // multiple measurements may be required to resolve all of the flex
            // dimensions. We handle nodes with measure functions specially here because
            // they are the most expensive to measure, so it's worth avoiding redundant
            // measurements if at all possible.
            if (node.MeasureFunc != null)
            {
                var marginAxisRow = node.GetMarginForAxis(FlexDirection.Row, ownerWidth);
                var marginAxisColumn = node.GetMarginForAxis(FlexDirection.Column, ownerWidth);

                // First, try to use the layout cache.
                if (YGNodeCanUseCachedMeasurement(
                    widthMeasureMode,
                    availableWidth,
                    heightMeasureMode,
                    availableHeight,
                    layout.CachedLayout.WidthMeasureMode,
                    layout.CachedLayout.AvailableWidth,
                    layout.CachedLayout.HeightMeasureMode,
                    layout.CachedLayout.AvailableHeight,
                    layout.CachedLayout.ComputedWidth,
                    layout.CachedLayout.ComputedHeight,
                    marginAxisRow,
                    marginAxisColumn,
                    config))
                {
                    cachedResults = layout.CachedLayout;
                }
                else
                {
                    // Try to use the measurement cache.
                    for (var i = 0; i < layout.NextCachedMeasurementsIndex; i++)
                    {
                        if (YGNodeCanUseCachedMeasurement(
                            widthMeasureMode,
                            availableWidth,
                            heightMeasureMode,
                            availableHeight,
                            layout.CachedMeasurements[i].WidthMeasureMode,
                            layout.CachedMeasurements[i].AvailableWidth,
                            layout.CachedMeasurements[i].HeightMeasureMode,
                            layout.CachedMeasurements[i].AvailableHeight,
                            layout.CachedMeasurements[i].ComputedWidth,
                            layout.CachedMeasurements[i].ComputedHeight,
                            marginAxisRow,
                            marginAxisColumn,
                            config))
                        {
                            cachedResults = layout.CachedMeasurements[i];
                            break;
                        }
                    }
                }
            }
            else if (performLayout)
            {
                if (FloatsEqual(layout.CachedLayout.AvailableWidth, availableWidth) &&
                    FloatsEqual(layout.CachedLayout.AvailableHeight, availableHeight) &&
                    layout.CachedLayout.WidthMeasureMode == widthMeasureMode &&
                    layout.CachedLayout.HeightMeasureMode == heightMeasureMode)
                {
                    cachedResults = layout.CachedLayout;
                }
            }
            else
            {
                for (var i = 0; i < layout.NextCachedMeasurementsIndex; i++)
                {
                    if (FloatsEqual(
                            layout.CachedMeasurements[i].AvailableWidth,
                            availableWidth) &&
                        FloatsEqual(
                            layout.CachedMeasurements[i].AvailableHeight,
                            availableHeight) &&
                        layout.CachedMeasurements[i].WidthMeasureMode == widthMeasureMode &&
                        layout.CachedMeasurements[i].HeightMeasureMode ==
                        heightMeasureMode)
                    {
                        cachedResults = layout.CachedMeasurements[i];
                        break;
                    }
                }
            }

            if (!needToVisitNode && cachedResults != null)
            {
                layout.MeasuredDimensions.Width  = cachedResults.ComputedWidth;
                layout.MeasuredDimensions.Height = cachedResults.ComputedHeight;
                if (performLayout)
                    layoutMarkerData.CachedLayouts++;
                else
                    layoutMarkerData.CachedMeasures++;

                if (PrintChanges && PrintSkips)
                {
                    Logger.Log(
                        node,
                        LogLevel.Verbose,
                        $"{YGSpacer(depth)}{depth}.([skipped] ");
                    node.Print(layoutContext);
                    Logger.Log(
                        node,
                        LogLevel.Verbose,
                        $"wm: {YGMeasureModeName(widthMeasureMode, performLayout)}, hm: {YGMeasureModeName(heightMeasureMode, performLayout)}, aw: {availableWidth} ah: {availableHeight} => d: ({cachedResults.ComputedWidth}, {cachedResults.ComputedHeight}) {reason.ToString()}\n");
                }
            }
            else
            {
                if (PrintChanges)
                {
                    Logger.Log(
                        node,
                        LogLevel.Verbose,
                        $"{YGSpacer(depth)}{depth}.({(needToVisitNode ? "*" : "")}");
                    node.Print(layoutContext);
                    Logger.Log(
                        node,
                        LogLevel.Verbose,
                        $"wm: {YGMeasureModeName(widthMeasureMode, performLayout)}, hm: {YGMeasureModeName(heightMeasureMode, performLayout)}, aw: {availableWidth} ah: {availableHeight} {reason.ToString()}\n");
                }

                YGNodelayoutImpl(
                    node,
                    availableWidth,
                    availableHeight,
                    ownerDirection,
                    widthMeasureMode,
                    heightMeasureMode,
                    ownerWidth,
                    ownerHeight,
                    performLayout,
                    config,
                    layoutMarkerData,
                    layoutContext,
                    depth,
                    generationCount,
                    reason);

                if (PrintChanges)
                {
                    Logger.Log(
                        node,
                        LogLevel.Verbose,
                        $"{YGSpacer(depth)}{depth}.){(needToVisitNode ? "*" : "")}");
                    node.Print(layoutContext);
                    Logger.Log(
                        node,
                        LogLevel.Verbose,
                        $"wm: {YGMeasureModeName(widthMeasureMode, performLayout)}, hm: {YGMeasureModeName(heightMeasureMode, performLayout)}, d: ({layout.MeasuredDimensions.Width}, {layout.MeasuredDimensions.Height}) {reason.ToString()}\n");
                }

                layout.LastOwnerDirection = ownerDirection;

                if (cachedResults == null)
                {
                    if (layout.NextCachedMeasurementsIndex + 1 > layoutMarkerData.MaxMeasureCache)
                    {
                        layoutMarkerData.MaxMeasureCache =
                            layout.NextCachedMeasurementsIndex + 1;
                    }

                    if (layout.NextCachedMeasurementsIndex == YogaGlobal.MaxCachedResultCount)
                    {
                        if (PrintChanges)
                        {
                            Logger.Log(node, LogLevel.Verbose, "Out of cache entries!\n");
                        }

                        layout.NextCachedMeasurementsIndex = 0;
                    }

                    YogaCachedMeasurement newCacheEntry;
                    if (performLayout)
                    {
                        // Use the single layout cache entry.
                        newCacheEntry = layout.CachedLayout;
                    }
                    else
                    {
                        // Allocate a new measurement cache entry.
                        newCacheEntry = layout.CachedMeasurements[layout.NextCachedMeasurementsIndex];
                        layout.NextCachedMeasurementsIndex++;
                    }

                    newCacheEntry.AvailableWidth    = availableWidth;
                    newCacheEntry.AvailableHeight   = availableHeight;
                    newCacheEntry.WidthMeasureMode  = widthMeasureMode;
                    newCacheEntry.HeightMeasureMode = heightMeasureMode;
                    newCacheEntry.ComputedWidth     = layout.MeasuredDimensions.Width;
                    newCacheEntry.ComputedHeight    = layout.MeasuredDimensions.Height;
                }
            }

            if (performLayout)
            {
                node.Layout.Width  = node.Layout.MeasuredDimensions.Width;
                node.Layout.Height = node.Layout.MeasuredDimensions.Height;

                node.HasNewLayout = true;
                node.IsDirty = false;
            }

            layout.GenerationCount = generationCount;

            LayoutType layoutType;
            if (performLayout)
            {
                layoutType = !needToVisitNode && cachedResults == layout.CachedLayout
                    ? LayoutType.CachedLayout
                    : LayoutType.Layout;
            }
            else
            {
                layoutType = cachedResults != null
                    ? LayoutType.CachedMeasure
                    : LayoutType.Measure;
            }

            Event.Hub.Publish(new NodeLayoutEventArgs(node, layoutType, (LayoutData)layoutContext));

            return needToVisitNode || cachedResults == null;
        }
        
        void YGRoundToPixelGrid(YogaNode node,float pointScaleFactor,float absoluteLeft,float absoluteTop)
        {
            if (pointScaleFactor.IsZero())
                return;

            var nodeLeft = node.Layout.Left;
            var nodeTop = node.Layout.Top;

            var nodeWidth = node.Layout.Width;
            var nodeHeight = node.Layout.Height;

            var absoluteNodeLeft = absoluteLeft + nodeLeft;
            var absoluteNodeTop = absoluteTop + nodeTop;

            var absoluteNodeRight = absoluteNodeLeft + nodeWidth;
            var absoluteNodeBottom = absoluteNodeTop + nodeHeight;

            // If a node has a custom measure function we never want to round down its
            // size as this could lead to unwanted text truncation.
            var textRounding = node.NodeType == NodeType.Text;

            node.SetLayoutPosition(
                RoundValueToPixelGrid(nodeLeft, pointScaleFactor, false, textRounding),
                (int)Edge.Left);

            node.SetLayoutPosition(
                RoundValueToPixelGrid(nodeTop, pointScaleFactor, false, textRounding),
                (int)Edge.Top);

            // We multiply dimension by scale factor and if the result is close to the
            // whole number, we don't have any fraction To verify if the result is close
            // to whole number we want to check both floor and ceil numbers
            var hasFractionalWidth =
                !FloatsEqual(FloatMod(nodeWidth * pointScaleFactor, 1.0f), 0f) &&
                !FloatsEqual(FloatMod(nodeWidth * pointScaleFactor, 1.0f), 1f);
            var hasFractionalHeight =
                !FloatsEqual(FloatMod(nodeHeight * pointScaleFactor, 1.0f), 0f) &&
                !FloatsEqual(FloatMod(nodeHeight * pointScaleFactor, 1.0f), 1f);

            node.Layout.Width =
                RoundValueToPixelGrid(
                    absoluteNodeRight,
                    pointScaleFactor,
                    textRounding && hasFractionalWidth,
                    textRounding && !hasFractionalWidth) -
                RoundValueToPixelGrid(
                    absoluteNodeLeft,
                    pointScaleFactor,
                    false,
                    textRounding);

            node.Layout.Height =
                RoundValueToPixelGrid(
                    absoluteNodeBottom,
                    pointScaleFactor,
                    textRounding && hasFractionalHeight,
                    textRounding && !hasFractionalHeight) -
                RoundValueToPixelGrid(
                    absoluteNodeTop,
                    pointScaleFactor,
                    false,
                    textRounding);

            var childCount = node.Children.Count;
            for (var i = 0; i < childCount; i++)
            {
                YGRoundToPixelGrid(
                    node.Children[i],
                    pointScaleFactor,
                    absoluteNodeLeft,
                    absoluteNodeTop);
            }
        }

         void YGNodeCalculateLayoutWithContext(
            YogaNode node,
            float ownerWidth,
            float ownerHeight,
            Direction ownerDirection,
            object layoutContext)
        {
            Event.Hub.Publish(new LayoutPassStartEventArgs(node, layoutContext));
            var markerData = new LayoutData();

            // Increment the generation count. This will force the recursive routine to
            // visit all dirty nodes at least once. Subsequent visits will be skipped if
            // the input parameters don't change.
            gCurrentGenerationCount++;
            node.ResolveDimension();
            var width = YogaValue.YGUndefined;
            var widthMeasureMode = MeasureMode.Undefined;
            if (node.IsStyleDimDefined(FlexDirection.Row, ownerWidth))
            {
                width =
                    node.GetResolvedDimension(YogaArrange.Dim[(int)FlexDirection.Row]).Resolve(ownerWidth) +
                    node.GetMarginForAxis(FlexDirection.Row, ownerWidth);
                widthMeasureMode = MeasureMode.Exactly;
            }
            else if (node.Style.MaxWidth.Resolve(ownerWidth).HasValue())
            {
                width            = node.Style.MaxWidth.Resolve(ownerWidth);
                widthMeasureMode = MeasureMode.AtMost;
            }
            else
            {
                width = ownerWidth;
                widthMeasureMode = width.IsUndefined()
                    ? MeasureMode.Undefined
                    : MeasureMode.Exactly;
            }

            var height = YogaValue.YGUndefined;
            var heightMeasureMode = MeasureMode.Undefined;
            if (node.IsStyleDimDefined(FlexDirection.Column, ownerHeight))
            {
                height = node.GetResolvedDimension(YogaArrange.Dim[(int)FlexDirection.Column])
                             .Resolve(ownerHeight)
                    + node.GetMarginForAxis(FlexDirection.Column, ownerWidth);
                heightMeasureMode = MeasureMode.Exactly;
            }
            else if (node.Style.MaxHeight.Resolve(ownerHeight).HasValue())
            {
                height            = node.Style.MaxHeight.Resolve(ownerHeight);
                heightMeasureMode = MeasureMode.AtMost;
            }
            else
            {
                height = ownerHeight;
                heightMeasureMode = height.IsUndefined()
                    ? MeasureMode.Undefined
                    : MeasureMode.Exactly;
            }

            if (YGLayoutNodeInternal(
                node,
                width,
                height,
                ownerDirection,
                widthMeasureMode,
                heightMeasureMode,
                ownerWidth,
                ownerHeight,
                true,
                LayoutPassReason.Initial,
                node.Config,
                markerData,
                layoutContext,
                0, // tree root
                gCurrentGenerationCount))
            {
                node.SetPosition(
                    node.Layout.Direction,
                    ownerWidth,
                    ownerHeight,
                    ownerWidth);
                YGRoundToPixelGrid(node, node.Config.PointScaleFactor, 0.0f, 0.0f);

#if DEBUG
                if (node.Config.PrintTree)
                {
                    new YogaNodePrint(PrintOptions.Layout | PrintOptions.Children | PrintOptions.Style)
                       .Output(node);
                }
#endif
            }

            Event.Hub.Publish(new LayoutPassEndEventArgs(node, layoutContext, markerData));
        }

         public static void CalculateLayout(YogaNode node, float ownerWidth, float ownerHeight, Direction ownerDirection)
         {
             new YogaArrange().YGNodeCalculateLayoutWithContext(node, ownerWidth, ownerHeight, ownerDirection, null);
         }
    }
}
