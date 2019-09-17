using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using static Yoga.Net.YogaMath;


namespace Yoga.Net
{
    public class YogaNode
    {
        /// <summary>
        /// the YogaNode that owns this YogaNode. An owner is used to identify
        /// the YogaTree that a YogaNode belongs to. This method will return the parent
        /// of the YogaNode when a YogaNode only belongs to one YogaTree or null when
        /// the YogaNode is shared between two or more YogaTrees.
        /// </summary>
        public YogaNode Owner { get; set; }

        public object Context { get; set; }
        public YogaConfig Config { get; private set; }
        public YogaLayout Layout { get; set; } = new YogaLayout();
        public int LineIndex { get; set; }
        public NodeType NodeType { get; set; } = NodeType.Default;
        public bool HasNewLayout { get; set; } = true;
        public string Trace { get; set; }

        public BaselineFunc BaselineFunc { get; set; }
        public DirtiedFunc DirtiedFunc { get; set; }
        public PrintFunc PrintFunc { get; set; }
        public MeasureFunc MeasureFunc
        {
            get => _measureFunc;
            set
            {
                _measureFunc = value;
                if (_measureFunc == null)
                {
                    NodeType = NodeType.Default;
                }
                else
                {
                    Debug.Assert(_children.Count == 0, "Cannot set measure function: Nodes with measure functions cannot have children.");
                    NodeType = NodeType.Text;
                }
            }
        }

        public bool HasMeasureFunc => _measureFunc != null;

        public YogaStyle Style
        {
            get => _style;
            set
            {
                if (value != _style)
                {
                    if (_style != null)
                    {
                        _style.Owner = null;
                        MarkDirtyAndPropagate();
                    }

                    _style = value;
                    _style.Owner = this;
                }
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public YogaStyleReadonly StyleReadonly => Style;

        public bool IsDirty
        {
            get => _isDirty;
            set
            {
                if (value == IsDirty)
                    return;

                _isDirty = value;
                if (value)
                    DirtiedFunc?.Invoke(this);
            }
        }

        public bool IsReferenceBaseline
        {
            get => _isReferenceBaseline;
            set
            {
                if (value != _isReferenceBaseline)
                {
                    _isReferenceBaseline = value;
                    MarkDirtyAndPropagate();
                }
            }
        }


        YogaStyle _style = new YogaStyle();
        YogaNodes _children = new YogaNodes();
        MeasureFunc _measureFunc;
        
        YogaValue[] _resolvedDimensions = {YogaValue.Undefined, YogaValue.Undefined};
        bool _isReferenceBaseline;
        bool _isDirty;

        public YogaNode(YogaConfig config = null)
        {
            _children.Owner = this;
            _style.Owner = this;
            Config = config ?? YogaConfig.DefaultConfig;
            Event.Hub.Publish(new NodeAllocationEventArgs(this, config));
        }

        public YogaNode([NotNull] YogaNode other, YogaConfig config = null)
        {
            Context      = other.Context;
            MeasureFunc  = other.MeasureFunc;
            BaselineFunc = other.BaselineFunc;
            PrintFunc    = other.PrintFunc;
            DirtiedFunc  = other.DirtiedFunc;
            _style       = new YogaStyle(other.Style);
            Layout       = new YogaLayout(other.Layout);
            LineIndex    = other.LineIndex;
            Owner        = other.Owner;
            Config       = config ?? other.Config ?? YogaConfig.DefaultConfig;
            Array.Copy(other._resolvedDimensions, _resolvedDimensions, _resolvedDimensions.Length);

            // Lazy-clone
            _children.AddRange(other.Children);
            _children.Owner = this;
            _style.Owner = this;

            Event.Hub.Publish(new NodeAllocationEventArgs(this, Config));
        }

        public static YogaNode Clone(YogaNode oldNode) => new YogaNode(oldNode) { Owner = null };

        public static YogaNode DeepClone(YogaNode oldNode)
        {
            var node = new YogaNode(oldNode, new YogaConfig(oldNode.Config)) {Owner = null};

            var children = new YogaNodes(oldNode.Children.Count);
            foreach (var item in oldNode.Children)
            {
                var childNode = DeepClone(item);
                childNode.Owner = node;
                children.Add(childNode);
            }

            node.SetChildren(children);

            return node;
        }

        public void InsertChild(YogaNode child, int index)
        {
            _children.Insert(index, child);
        }

        public void RemoveChild(YogaNode excludedChild)
        {
            _children.Remove(excludedChild);
        }

        public void RemoveAllChildren()
        {
            _children.Clear();
        }

        public void SetChildren(IEnumerable<YogaNode> childs)
        {
            var newChildren = childs.ToList();
            if (newChildren.Count == 0)
            {
                _children.Clear();
            }
            else
            {
                if (_children.Count > 0)
                {
                    foreach (var oldChild in _children)
                    {
                        // Our new children may have nodes in common with the old children. We don't reset these common nodes.
                        if (!newChildren.Contains(oldChild))
                        {
                            oldChild.Layout = new YogaLayout();
                            oldChild.Owner  = null;
                        }
                    }
                }

                _children = new YogaNodes(newChildren) { Owner = this };
                foreach (var child in newChildren)
                    child.Owner = this;

                MarkDirtyAndPropagate();
            }
        }

        // If both left and right are defined, then use left. Otherwise return +left or
        // -right depending on which is defined.
        float RelativePosition(FlexDirection axis, float axisSize)
        {
            if (IsLeadingPositionDefined(axis))
            {
                return GetLeadingPosition(axis, axisSize);
            }

            float trailingPosition = GetTrailingPosition(axis, axisSize);
            if (trailingPosition.HasValue())
            {
                trailingPosition = (-1f * trailingPosition);
            }

            return trailingPosition;
        }

        public void Print(object printContext) => PrintFunc?.Invoke(this, printContext);

        public YogaSize Measure(float width, MeasureMode widthMode, float height, MeasureMode heightMode, object layoutContext)
        {
            return MeasureFunc?.Invoke(this, width, widthMode, height, heightMode, layoutContext) ?? new YogaSize();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public YogaAlign AlignItem(YogaNode child)
        {
            var align = child.Style.AlignSelf == YogaAlign.Auto
                ? Style.AlignItems
                : child.Style.AlignSelf;
            if (align == YogaAlign.Baseline && Style.FlexDirection.IsColumn())
                return YogaAlign.FlexStart;

            return align;
        }


        public float Baseline(float width, float height, object layoutContext)
        {
            return BaselineFunc?.Invoke(this, width, height, layoutContext) ?? 0f;
        }

        public float Baseline(object layoutContext = null)
        {
            if (BaselineFunc != null)
            {
                Event.Hub.Publish(new NodeBaselineStartEventArgs(this));

                var layoutBaseline = Baseline(
                    Layout.MeasuredDimensions.Width,
                    Layout.MeasuredDimensions.Height,
                    layoutContext);

                Event.Hub.Publish(new NodeBaselineEndEventArgs(this));

                Debug.Assert(layoutBaseline.HasValue(), "Expect custom baseline function to not return NaN");
                return layoutBaseline;
            }

            YogaNode baselineChild = null;
            var childCount = _children.Count;
            for (var i = 0; i < childCount; i++)
            {
                var child = _children[i];
                if (child.LineIndex > 0)
                    break;

                if (child.Style.PositionType == PositionType.Absolute)
                    continue;

                if (AlignItem(child) == YogaAlign.Baseline || child.IsReferenceBaseline)
                {
                    baselineChild = child;
                    break;
                }

                if (baselineChild == null)
                    baselineChild = child;
            }

            if (baselineChild == null)
                return Layout.MeasuredDimensions.Height;

            var baseline = baselineChild.Baseline(layoutContext);
            return baseline + baselineChild.Layout.Top;
        }

        public bool IsBaselineLayout()
        {
            if (Style.FlexDirection.IsColumn())
                return false;

            if (Style.AlignItems == YogaAlign.Baseline)
                return true;

            var childCount = _children.Count;
            for (var i = 0; i < childCount; i++)
            {
                var child = _children[i];
                if (child.Style.PositionType == PositionType.Relative && child.Style.AlignSelf == YogaAlign.Baseline)
                    return true;
            }

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsStyleDimDefined(FlexDirection axis, float ownerSize)
        {
            var isUndefined = GetResolvedDimension(YogaArrange.Dim[(int)axis]).IsUndefined;
            return !(
                GetResolvedDimension(YogaArrange.Dim[(int)axis]).Unit == YogaUnit.Auto ||
                GetResolvedDimension(YogaArrange.Dim[(int)axis]).Unit == YogaUnit.Undefined ||
                GetResolvedDimension(YogaArrange.Dim[(int)axis]).Unit == YogaUnit.Point &&
                !isUndefined && GetResolvedDimension(YogaArrange.Dim[(int)axis]).Value < 0.0f ||
                GetResolvedDimension(YogaArrange.Dim[(int)axis]).Unit == YogaUnit.Percent &&
                !isUndefined &&
                (GetResolvedDimension(YogaArrange.Dim[(int)axis]).Value < 0.0f || ownerSize.IsUndefined()));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsLayoutDimDefined(FlexDirection axis)
        {
            var value = Layout.MeasuredDimensions[YogaArrange.Dim[(int)axis]];
            return value.HasValue() && value >= 0.0f;
        }

        public float BoundAxisWithinMinAndMax(FlexDirection axis,float value,float axisSize)
        {
            var min = float.NaN;
            var max = float.NaN;

            if (axis.IsColumn())
            {
                min = Style.MinHeight.Resolve(axisSize);
                max = Style.MaxHeight.Resolve(axisSize);
            }
            else if (axis.IsRow())
            {
                min = Style.MinWidth.Resolve(axisSize);
                max = Style.MaxWidth.Resolve(axisSize);
            }

            if (max >= 0f && value > max)
                return max;

            if (min >= 0f && value < min)
                return min;

            return value;
        }

        // Like YGNodeBoundAxisWithinMinAndMax but also ensures that the value doesn't go below the padding and border amount.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float BoundAxis(FlexDirection axis,float value,float axisSize,float widthSize) =>
            FloatMax(
                BoundAxisWithinMinAndMax(axis,value,axisSize), 
                GetLeadingPaddingAndBorder(axis, widthSize));

        public void SetChildTrailingPosition(YogaNode child,FlexDirection axis)
        {
            var size = child.Layout.MeasuredDimensions[YogaArrange.Dim[(int)axis]];
            child.SetLayoutPosition(
                Layout.MeasuredDimensions[YogaArrange.Dim[(int)axis]] - size -
                child.Layout.Position[YogaArrange.Pos[(int)axis]],
                (int)YogaArrange.Trailing[(int)axis]);
        }

        public void ConstrainMaxSizeForMode(FlexDirection axis,float ownerAxisSize,float ownerWidth,ref MeasureMode mode,ref float size)
        {
            var maxSize = Style.MaxDimension(YogaArrange.Dim[(int)axis]).Resolve(ownerAxisSize) + GetMarginForAxis(axis, ownerWidth);
            switch (mode)
            {
            case MeasureMode.Exactly:
            case MeasureMode.AtMost:
                size = maxSize.IsUndefined() || size < maxSize ? size : maxSize;
                break;
            case MeasureMode.Undefined:
                if (maxSize.HasValue())
                {
                    mode = MeasureMode.AtMost;
                    size = maxSize;
                }
                break;
            }
        }

        // Applies a callback to all children, after cloning them if they are not owned.
        public void IterChildrenAfterCloningIfNeeded(Action<YogaNode, object> callback, object cloneContext)
        {
            for (int i = 0; i < _children.Count; i++)
            {
                var child = _children[i];
                if (child.Owner != this)
                {
                    child       = Config.CloneNode(child, this, i, cloneContext);
                    child.Owner = this;
                }

                _children[i] = child;
                callback?.Invoke(child, cloneContext);
            }
        }

        [Obsolete("use Children[i]")]
        public YogaNode GetChild(int index) => _children[index];

        public int ChildCount => _children.Count;
        public YogaNodes Children => _children;
        
        public YogaValue[] GetResolvedDimensions() => _resolvedDimensions;

        public YogaValue GetResolvedDimension(Dimension index) => _resolvedDimensions[(int)index];

        // Methods related to positions, margin, padding and border
        public float GetLeadingPosition(FlexDirection axis, in float axisSize)
        {
            if (axis.IsRow())
            {
                var lp = Style.Position.ComputedEdgeValue(Edge.Start);
                if (!lp.IsUndefined)
                {
                    return lp.Resolve(axisSize);
                }
            }

            var leadingPosition = Style.Position.ComputedEdgeValue(YogaArrange.Leading[(int)axis]);

            return leadingPosition.IsUndefined ? 0f : leadingPosition.Resolve(axisSize);
        }

        public bool IsLeadingPositionDefined(FlexDirection axis)
        {
            return (axis.IsRow() &&
                    !Style.Position.ComputedEdgeValue(Edge.Start).IsUndefined) ||
                !Style.Position.ComputedEdgeValue(YogaArrange.Leading[(int)axis]).IsUndefined;
        }

        public bool IsTrailingPosDefined(FlexDirection axis)
        {
            return (axis.IsRow() &&
                    !Style.Position.ComputedEdgeValue(Edge.End).IsUndefined) ||
                !Style.Position.ComputedEdgeValue(YogaArrange.Trailing[(int)axis]).IsUndefined;
        }

        public float GetTrailingPosition(FlexDirection axis, in float axisSize)
        {
            if (axis.IsRow())
            {
                var tp = Style.Position.ComputedEdgeValue(Edge.End);
                if (!tp.IsUndefined)
                {
                    return tp.Resolve(axisSize);
                }
            }

            var trailingPosition = Style.Position.ComputedEdgeValue(YogaArrange.Trailing[(int)axis]);

            return trailingPosition.IsUndefined ? 0f : trailingPosition.Resolve(axisSize);
        }

        public float GetLeadingMargin(FlexDirection axis, in float widthSize)
        {
            if (axis.IsRow() &&
                !Style.Margin[Edge.Start].IsUndefined)
            {
                return Style.Margin[Edge.Start].ResolveValueMargin(widthSize);
            }

            return Style.Margin.ComputedEdgeValue(YogaArrange.Leading[(int)axis], YogaValue.Zero)
                        .ResolveValueMargin(widthSize);
        }

        public float GetTrailingMargin(FlexDirection axis, in float widthSize)
        {
            if (axis.IsRow() && !Style.Margin[Edge.End].IsUndefined)
            {
                return Style.Margin[Edge.End].ResolveValueMargin(widthSize);
            }

            return Style.Margin.ComputedEdgeValue(YogaArrange.Trailing[(int)axis], YogaValue.Zero)
                        .ResolveValueMargin(widthSize);
        }

        public float GetLeadingBorder(FlexDirection axis)
        {
            YogaValue leadingBorder;
            if (axis.IsRow() &&
                !Style.Border[Edge.Start].IsUndefined)
            {
                leadingBorder = Style.Border[Edge.Start];
                if (leadingBorder.Value >= 0)
                    return leadingBorder.Value;
            }

            leadingBorder = Style.Border.ComputedEdgeValue(YogaArrange.Leading[(int)axis], YogaValue.Zero);
            return FloatMax(leadingBorder.Value, 0.0f);
        }

        public float GetTrailingBorder(FlexDirection flexDirection)
        {
            YogaValue trailingBorder;
            if (flexDirection.IsRow() && !Style.Border[Edge.End].IsUndefined)
            {
                trailingBorder = Style.Border[Edge.End];
                if (trailingBorder.Value >= 0.0f)
                {
                    return trailingBorder.Value;
                }
            }

            trailingBorder = Style.Border.ComputedEdgeValue(YogaArrange.Trailing[(int)flexDirection], YogaValue.Zero);
            return FloatMax(trailingBorder.Value, 0.0f);
        }

        public float GetLeadingPadding(FlexDirection axis, in float widthSize)
        {
            float paddingEdgeStart = Style.Padding[Edge.Start].Resolve(widthSize);
            if (axis.IsRow() &&
                !Style.Padding[Edge.Start].IsUndefined &&
                paddingEdgeStart.HasValue() && paddingEdgeStart >= 0.0f)
            {
                return paddingEdgeStart;
            }

            var resolvedValue = Style.Padding.ComputedEdgeValue(YogaArrange.Leading[(int)axis], YogaValue.Zero).Resolve(widthSize);
            return Math.Max(resolvedValue, 0f);
        }

        public float GetTrailingPadding(FlexDirection axis, float widthSize)
        {
            float paddingEdgeEnd = Style.Padding[Edge.End].Resolve(widthSize);
            if (axis.IsRow() && paddingEdgeEnd >= 0f)
            {
                return paddingEdgeEnd;
            }

            var resolvedValue = Style.Padding.ComputedEdgeValue(YogaArrange.Trailing[(int)axis], YogaValue.Zero).Resolve(widthSize);

            return Math.Max(resolvedValue, 0f);
        }

        public float GetLeadingPaddingAndBorder(FlexDirection axis, float widthSize) => GetLeadingPadding(axis, widthSize) + GetLeadingBorder(axis);

        public float GetTrailingPaddingAndBorder(FlexDirection axis, float widthSize) => GetTrailingPadding(axis, widthSize) + GetTrailingBorder(axis);

        public float GetMarginForAxis(FlexDirection axis, in float widthSize) => GetLeadingMargin(axis, widthSize) + GetTrailingMargin(axis, widthSize);

        public void SetLayoutLastOwnerDirection(Direction direction) => Layout.LastOwnerDirection = direction;

        public void SetLayoutComputedFlexBasis(float computedFlexBasis) => Layout.ComputedFlexBasis = computedFlexBasis;

        public void SetLayoutComputedFlexBasisGeneration(int computedFlexBasisGeneration) => Layout.ComputedFlexBasisGeneration = computedFlexBasisGeneration;

        public void SetLayoutMeasuredDimension(float measuredDimension, int index) => Layout.MeasuredDimensions[(Dimension)index] = measuredDimension;

        public void SetLayoutMeasuredDimension(float measuredDimension, Dimension index) => Layout.MeasuredDimensions[index] = measuredDimension;

        public void SetLayoutHadOverflow(bool hadOverflow) => Layout.HadOverflow = hadOverflow;

        public void SetLayoutDirection(Direction direction) => Layout.Direction = direction;

        public void SetLayoutMargin(float margin, Edge edge) => Layout.Margin[edge] = margin;

        public void SetLayoutBorder(float border, Edge edge) => Layout.Border[edge] = border;

        public void SetLayoutPadding(float padding, Edge edge) => Layout.Padding[edge] = padding;

        public void SetLayoutPosition(float position, int index) => Layout.Position[(Edge)index] = position;

        public void SetLayoutPosition(float position, Edge edge) => Layout.Position[edge] = position;

        public float LayoutMargin(Edge edge) => LayoutResolvedProperty(Layout.Margin, edge);

        public float LayoutBorder(Edge edge) => LayoutResolvedProperty(Layout.Border, edge);

        public float LayoutPadding(Edge edge) => LayoutResolvedProperty(Layout.Padding, edge);

        float LayoutResolvedProperty(LTRBEdge instanceName, Edge edge)
        {
            Debug.Assert(edge <= Edge.End, "Cannot get layout properties of multi-edge shorthands");
            if (edge == Edge.Start)
            {
                if (Layout.Direction == Direction.RTL)
                    return instanceName.Right;
                return instanceName.Left;
            }

            if (edge == Edge.End)
            {
                if (Layout.Direction == Direction.RTL)
                    return instanceName.Left;
                return instanceName.Right;
            }

            return instanceName[edge];
        }

        public float PaddingAndBorderForAxis(FlexDirection axis, float widthSize) => 
            GetLeadingPaddingAndBorder(axis, widthSize) + 
            GetTrailingPaddingAndBorder(axis, widthSize);

        public float DimWithMargin(FlexDirection axis, float widthSize) => 
            Layout.MeasuredDimensions[YogaArrange.Dim[(int)axis]] + 
            GetLeadingMargin(axis, widthSize) + 
            GetTrailingMargin(axis, widthSize);

        public void SetPosition(
            in Direction direction,
            in float mainSize,
            in float crossSize,
            in float ownerWidth)
        {
            // Root nodes should be always layed out as LTR, so we don't return negative values.
            Direction directionRespectingRoot = Owner != null ? direction : Direction.LTR;
            FlexDirection mainAxis = Style.FlexDirection.Resolve(directionRespectingRoot);
            FlexDirection crossAxis = mainAxis.CrossAxis(directionRespectingRoot);

            float relativePositionMain = RelativePosition(mainAxis, mainSize);
            float relativePositionCross = RelativePosition(crossAxis, crossSize);

            SetLayoutPosition(
                (GetLeadingMargin(mainAxis, ownerWidth) + relativePositionMain),
                YogaArrange.Leading[(int)mainAxis]);
            SetLayoutPosition(
                (GetTrailingMargin(mainAxis, ownerWidth) + relativePositionMain),
                YogaArrange.Trailing[(int)mainAxis]);
            SetLayoutPosition(
                (GetLeadingMargin(crossAxis, ownerWidth) + relativePositionCross),
                YogaArrange.Leading[(int)crossAxis]);
            SetLayoutPosition(
                (GetTrailingMargin(crossAxis, ownerWidth) + relativePositionCross),
                YogaArrange.Trailing[(int)crossAxis]);
        }

        public void MarkDirtyAndPropagateDownwards()
        {
            IsDirty = true;
            foreach (var child in _children)
            {
                child.MarkDirtyAndPropagateDownwards();
            }
        }

        // Other methods
        public YogaValue MarginLeadingValue(FlexDirection axis)
        {
            if (axis.IsRow() && !Style.Margin[Edge.Start].IsUndefined)
                return Style.Margin[Edge.Start];
            return Style.Margin[YogaArrange.Leading[(int)axis]];
        }

        public YogaValue MarginTrailingValue(FlexDirection axis)
        {
            if (axis.IsRow() && !Style.Margin[Edge.End].IsUndefined)
                return Style.Margin[Edge.End];
            return Style.Margin[YogaArrange.Trailing[(int)axis]];
        }

        public YogaValue ResolveFlexBasisPtr()
        {
            YogaValue flexBasis = Style.FlexBasis;
            if (flexBasis.Unit != YogaUnit.Auto && flexBasis.Unit != YogaUnit.Undefined)
            {
                return flexBasis;
            }

            if (Style.Flex.HasValue() && Style.Flex > 0.0f)
                return YogaValue.Zero;
            return YogaValue.Auto;
        }

        public void ResolveDimension()
        {
            YogaStyle style = Style;
            foreach (var dim in new[] {Dimension.Width, Dimension.Height})
            {
                if (!style.MaxDimension(dim).IsUndefined &&
                    style.MaxDimension(dim) == style.MinDimension(dim))
                {
                    _resolvedDimensions[(int)dim] = style.MaxDimension(dim);
                }
                else
                {
                    _resolvedDimensions[(int)dim] = style.Dimension(dim);
                }
            }
        }

        public Direction ResolveDirection(Direction ownerDirection)
        {
            if (Style.Direction == Direction.Inherit)
                return ownerDirection > Direction.Inherit ? ownerDirection : Direction.LTR;

            return Style.Direction;
        }

        /// Replaces the occurrences of oldChild with newChild
        void ReplaceChild(YogaNode oldChild, YogaNode newChild)
        {
            ReplaceChild(newChild, _children.IndexOf(oldChild));
        }

        void ReplaceChild(YogaNode child, int index)
        {
            _children[index] = child;
        }

        void RemoveChild(int index)
        {
            _children.RemoveAt(index);
        }

        public void CloneChildrenIfNeeded(object cloneContext)
        {
            IterChildrenAfterCloningIfNeeded(null, cloneContext);
        }

        public void CopyStyle(YogaNode node)
        {
            Style = node.Style;
        }

        /// <summary>
        /// Mark a node as dirty. Only valid for nodes with a custom measure function
        /// set.
        ///
        /// Yoga knows when to mark all other nodes as dirty but because nodes with
        /// measure functions depend on information not known to Yoga they must perform
        /// this dirty marking manually.
        /// </summary>
        public void MarkDirty()
        {
            Debug.Assert( MeasureFunc != null, "Only leaf nodes with custom measure functions should manually mark themselves as dirty");
            MarkDirtyAndPropagate();
        }

        void MarkDirtyIfDifferent(YogaValue a, YogaValue b)
        {
            if (a != b)
                MarkDirtyAndPropagate();
        }

        public void MarkDirtyAndPropagate()
        {
            if (!IsDirty)
            {
                IsDirty = true;
                SetLayoutComputedFlexBasis(float.NaN);
                Owner?.MarkDirtyAndPropagate();
            }
        }

        public float ResolveFlexGrow()
        {
            // Root nodes flexGrow should always be 0
            if (Owner == null)
                return 0.0f;

            if (Style.FlexGrow.HasValue())
                return Style.FlexGrow;

            if (Style.Flex.HasValue() && Style.Flex > 0.0f)
                return Style.Flex;

            return YogaStyle.DefaultFlexGrow;
        }

        public float ResolveFlexShrink()
        {
            if (Owner == null)
                return 0.0f;

            if (Style.FlexShrink.HasValue())
                return Style.FlexShrink;

            if (Style.Flex.HasValue() && Style.Flex < 0.0f)
                return -Style.Flex;

            return YogaStyle.DefaultFlexShrink;
        }

        public bool IsNodeFlexible()
        {
            return (
                (Style.PositionType == PositionType.Relative) &&
                (ResolveFlexGrow().IsNotZero() || ResolveFlexShrink().IsNotZero()));
        }

        public bool IsLayoutTreeEqualToNode(YogaNode node)
        {
            if (_children.Count != node._children.Count)
                return false;

            if (Layout != node.Layout)
                return false;

            if (_children.Count == 0)
                return true;


            for (var i = 0; i < _children.Count; ++i)
            {
                var otherNodeChildren = node._children[i];
                if (!_children[i].IsLayoutTreeEqualToNode(otherNodeChildren))
                    return false;
            }

            return true;
        }

        public YogaNode Reset()
        {
            Debug.Assert(_children.Count == 0,"Cannot reset a node which still has children attached");
            Debug.Assert(Owner == null,"Cannot reset a node still attached to a owner");

            return new YogaNode(Config);
        }

        public void TraversePreOrder(Action<YogaNode> action)
        {
            action(this);

            foreach (var child in _children)
                child.TraversePreOrder(action);
        }
        
        protected bool Equals(YogaNode other)
        {
            if (ReferenceEquals(this, other))
                return true;

            var isEqual = Equals(Style, other.Style);
            isEqual = isEqual & Equals(Layout, other.Layout);
            isEqual = isEqual & LineIndex == other.LineIndex;
            isEqual = isEqual & Equals(Config, other.Config);
            isEqual = isEqual & HasNewLayout == other.HasNewLayout;
            isEqual = isEqual & IsReferenceBaseline == other.IsReferenceBaseline;
            isEqual = isEqual & IsDirty == other.IsDirty;
            isEqual = isEqual & NodeType == other.NodeType;
            isEqual = isEqual & (_children.Count == other.Children.Count);

            if (isEqual)
            {
                isEqual = _resolvedDimensions[0] == other._resolvedDimensions[0];
                isEqual = isEqual & _resolvedDimensions[1] == other._resolvedDimensions[1];
                for (int i = 0; i < _children.Count && isEqual; i++)
                {
                    isEqual = _children[i] == other._children[i];
                }
            }

            return isEqual;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((YogaNode)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Style != null ? Style.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Layout != null ? Layout.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ LineIndex;
                hashCode = (hashCode * 397) ^ (_children != null ? _children.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Config != null ? Config.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_resolvedDimensions != null ? _resolvedDimensions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ HasNewLayout.GetHashCode();
                hashCode = (hashCode * 397) ^ IsReferenceBaseline.GetHashCode();
                hashCode = (hashCode * 397) ^ IsDirty.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)NodeType;
                return hashCode;
            }
        }

        public static bool operator ==(YogaNode left, YogaNode right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(YogaNode left, YogaNode right)
        {
            return !Equals(left, right);
        }
    }
}
