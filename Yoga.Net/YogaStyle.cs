using System;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using Newtonsoft.Json;
using static Yoga.Net.YogaMath;

namespace Yoga.Net
{
    public interface YogaStyleReadonly
    {
        Direction Direction { get; }
        FlexDirection FlexDirection { get; }
        Justify JustifyContent { get; }
        YogaAlign AlignContent { get; }
        YogaAlign AlignItems { get; }
        YogaAlign AlignSelf { get; }
        PositionType PositionType { get; }
        Wrap FlexWrap { get; }
        Overflow Overflow { get; }
        Display Display { get; }
        float Flex { get; }
        float FlexGrow { get; }
        float FlexShrink { get; }
        YogaValue FlexBasis { get; }
        Edges Margin { get; }
        Edges Position { get; }
        Edges Padding { get; }
        Edges Border { get; }
        YogaValue Width { get; }
        YogaValue Height { get; }
        YogaValue MinWidth { get; }
        YogaValue MinHeight { get; }
        YogaValue MaxWidth { get; }
        YogaValue MaxHeight { get; }
        float AspectRatio { get; }
    }

    public class YogaStyle : YogaStyleReadonly
    {
        public const float DefaultFlexGrow = 0.0f;
        public const float DefaultFlexShrink = 0.0f;

        YogaNode _owner;
        public YogaNode Owner
        {
            set
            {
                _owner = value;
                _margin.Owner = value;
                _position.Owner = value;
                _padding.Owner = value;
                _border.Owner = value;
            }
        }

        void CheckChanged<T>([NotNull] ref T field, T value)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                _owner?.MarkDirtyAndPropagate();
            }
        }

        public Direction Direction
        {
            get => _direction;
            set => CheckChanged(ref _direction, value);
        }

        public FlexDirection FlexDirection
        {
            get => _flexDirection;
            set => CheckChanged(ref _flexDirection, value);
        }


        public Justify JustifyContent
        {
            get => _justifyContent;
            set => CheckChanged(ref _justifyContent , value);
        }


        public YogaAlign AlignContent
        {
            get => _alignContent;
            set => CheckChanged(ref _alignContent , value);
        }


        public YogaAlign AlignItems
        {
            get => _alignItems;
            set => CheckChanged(ref _alignItems ,value);
        }


        public YogaAlign AlignSelf
        {
            get => _alignSelf;
            set => CheckChanged(ref _alignSelf , value);
        }


        public PositionType PositionType
        {
            get => _positionType;
            set => CheckChanged(ref _positionType , value);
        }


        public Wrap FlexWrap
        {
            get => _flexWrap;
            set => CheckChanged(ref _flexWrap , value);
        }


        public Overflow Overflow
        {
            get => _overflow;
            set => CheckChanged(ref _overflow , value);
        }


        public Display Display
        {
            get => _display;
            set => CheckChanged(ref _display , value);
        }

        public float Flex
        {
            get => _flex.IsUndefined() ? YogaValue.YGUndefined : _flex;
            set => CheckChanged(ref _flex , value);
        }

        public float FlexGrow
        {
            get => _flexGrow.IsUndefined() ? DefaultFlexGrow : _flexGrow;
            set => CheckChanged(ref _flexGrow , value);
        }

        public float FlexShrink
        {
            get => _flexShrink.IsUndefined() ? DefaultFlexShrink : _flexShrink;
            set => CheckChanged(ref _flexShrink , value);
        }


        public YogaValue FlexBasis
        {
            get => _flexBasis;
            set => CheckChanged(ref _flexBasis , value);
        }


        public Edges Margin
        {
            get => _margin;
            set => CheckChanged(ref _margin , value);
        }


        public Edges Position
        {
            get => _position;
            set => CheckChanged(ref _position , value);
        }


        public Edges Padding
        {
            get => _padding;
            set => CheckChanged(ref _padding , value);
        }


        public Edges Border
        {
            get => _border;
            set => CheckChanged(ref _border , value);
        }


        public YogaValue Width
        {
            get => _width;
            set => CheckChanged(ref _width ,value);
        }


        public YogaValue Height
        {
            get => _height;
            set => CheckChanged(ref _height , value);
        }


        public YogaValue MinWidth
        {
            get => _minWidth;
            set => CheckChanged(ref _minWidth , value);
        }


        public YogaValue MinHeight
        {
            get => _minHeight;
            set => CheckChanged(ref _minHeight , value);
        }


        public YogaValue MaxWidth
        {
            get => _maxWidth;
            set => CheckChanged(ref _maxWidth , value);
        }


        public YogaValue MaxHeight
        {
            get => _maxHeight;
            set => CheckChanged(ref _maxHeight , value);
        }

        Direction _direction = Direction.Inherit;
        FlexDirection _flexDirection = FlexDirection.Column;
        Justify _justifyContent = Justify.FlexStart;
        YogaAlign _alignContent = YogaAlign.FlexStart;
        YogaAlign _alignItems = YogaAlign.Stretch;
        YogaAlign _alignSelf = YogaAlign.Auto;
        PositionType _positionType = PositionType.Relative;
        Wrap _flexWrap = Wrap.NoWrap;
        Overflow _overflow = Overflow.Visible;
        Display _display = Display.Flex;
        float _flex = float.NaN;
        float _flexGrow = float.NaN;
        float _flexShrink = float.NaN;
        YogaValue _flexBasis = YogaValue.Auto;
        Edges _margin = new Edges(YogaValue.Undefined);
        Edges _position = new Edges(YogaValue.Undefined);
        Edges _padding = new Edges(YogaValue.Undefined);
        Edges _border = new Edges(YogaValue.Undefined);
        YogaValue _width = YogaValue.Auto;
        YogaValue _height = YogaValue.Auto;
        YogaValue _minWidth = YogaValue.Undefined;
        YogaValue _minHeight = YogaValue.Undefined;
        YogaValue _maxWidth = YogaValue.Undefined;
        YogaValue _maxHeight = YogaValue.Undefined;

        public YogaValue Dimension(Dimension dim)
        {
            switch (dim)
            {
            case Net.Dimension.Width:
                return Width;
            case Net.Dimension.Height:
                return Height;
            default:
                throw new ArgumentException("Unknown dimension", nameof(dim));
            }
        }

        public YogaValue MinDimension(Dimension dim)
        {
            switch (dim)
            {
            case Net.Dimension.Width:
                return MinWidth;
            case Net.Dimension.Height:
                return MinHeight;
            default:
                throw new ArgumentException("Unknown dimension", nameof(dim));
            }
        }

        public YogaValue MaxDimension(Dimension dim)
        {
            switch (dim)
            {
            case Net.Dimension.Width:
                return MaxWidth;
            case Net.Dimension.Height:
                return MaxHeight;
            default:
                throw new ArgumentException("Unknown dimension", nameof(dim));
            }
        }

        // Yoga specific properties, not compatible with flexbox specification
        public float AspectRatio { get; set; } = float.NaN;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [JsonIgnore]
        public YogaValue Left
        {
            get => Position[Edge.Left];
            set => Position[Edge.Left] = value;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [JsonIgnore]
        public YogaValue Top
        {
            get => Position[Edge.Top];
            set => Position[Edge.Top] = value;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [JsonIgnore]
        public YogaValue Right
        {
            get => Position[Edge.Right];
            set => Position[Edge.Right] = value;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [JsonIgnore]
        public YogaValue Bottom
        {
            get => Position[Edge.Bottom];
            set => Position[Edge.Bottom] = value;
        }


        public YogaStyle() { }

        public YogaStyle(YogaStyle other)
        {
            Direction      = other.Direction;
            FlexDirection  = other.FlexDirection;
            JustifyContent = other.JustifyContent;
            AlignContent   = other.AlignContent;
            AlignItems     = other.AlignItems;
            AlignSelf      = other.AlignSelf;
            PositionType   = other.PositionType;
            FlexWrap       = other.FlexWrap;
            Overflow       = other.Overflow;
            Display        = other.Display;

            Flex        = other.Flex;
            FlexGrow    = other.FlexGrow;
            FlexShrink  = other.FlexShrink;
            FlexBasis   = other.FlexBasis;
            Margin      = new Edges(other.Margin);
            Position    = new Edges(other.Position);
            Padding     = new Edges(other.Padding);
            Border      = new Edges(other.Border);
            Width       = other.Width;
            Height      = other.Height;
            MinWidth    = other.MinWidth;
            MinHeight   = other.MinHeight;
            MaxWidth    = other.MaxWidth;
            MaxHeight   = other.MaxHeight;
            AspectRatio = other.AspectRatio;
        }

        protected bool Equals(YogaStyle other)
        {
            bool areNonFloatValuesEqual = Direction == other.Direction &&
                FlexDirection == other.FlexDirection &&
                JustifyContent == other.JustifyContent &&
                AlignContent == other.AlignContent &&
                AlignItems == other.AlignItems &&
                AlignSelf == other.AlignSelf;
            areNonFloatValuesEqual = areNonFloatValuesEqual &&
                PositionType == other.PositionType &&
                FlexWrap == other.FlexWrap &&
                Overflow == other.Overflow &&
                Display == other.Display;
            areNonFloatValuesEqual = areNonFloatValuesEqual &&
                FlexBasis == other.FlexBasis &&
                Margin == other.Margin &&
                Position == other.Position &&
                Padding == other.Padding &&
                Border == other.Border;
            areNonFloatValuesEqual = areNonFloatValuesEqual && 
                Width == other.Width &&
                Height == other.Height &&
                MinWidth == other.MinWidth &&
                MinHeight == other.MinHeight &&
                MaxWidth == other.MaxWidth &&
                MaxHeight == other.MaxHeight;

            areNonFloatValuesEqual = areNonFloatValuesEqual && Flex.IsUndefined() == other.Flex.IsUndefined();
            if (areNonFloatValuesEqual && Flex.HasValue() && other.Flex.HasValue())
            {
                areNonFloatValuesEqual = FloatsEqual(Flex, other.Flex);
            }

            areNonFloatValuesEqual = areNonFloatValuesEqual && FlexGrow.IsUndefined() == other.FlexGrow.IsUndefined();
            if (areNonFloatValuesEqual && FlexGrow.HasValue())
            {
                areNonFloatValuesEqual = FloatsEqual(FlexGrow, other.FlexGrow);
            }

            areNonFloatValuesEqual = areNonFloatValuesEqual && FlexShrink.IsUndefined() == other.FlexShrink.IsUndefined();
            if (areNonFloatValuesEqual && other.FlexShrink.HasValue())
            {
                areNonFloatValuesEqual = FloatsEqual(FlexShrink, other.FlexShrink);
            }

            if (!(AspectRatio.IsUndefined() && other.AspectRatio.IsUndefined()))
            {
                areNonFloatValuesEqual = areNonFloatValuesEqual && FloatsEqual(AspectRatio, other.AspectRatio);
            }

            return areNonFloatValuesEqual;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((YogaStyle)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)Direction;
                hashCode = (hashCode * 397) ^ (int)FlexDirection;
                hashCode = (hashCode * 397) ^ (int)JustifyContent;
                hashCode = (hashCode * 397) ^ (int)AlignContent;
                hashCode = (hashCode * 397) ^ (int)AlignItems;
                hashCode = (hashCode * 397) ^ (int)AlignSelf;
                hashCode = (hashCode * 397) ^ (int)PositionType;
                hashCode = (hashCode * 397) ^ (int)FlexWrap;
                hashCode = (hashCode * 397) ^ (int)Overflow;
                hashCode = (hashCode * 397) ^ (int)Display;
                hashCode = (hashCode * 397) ^ Flex.GetHashCode();
                hashCode = (hashCode * 397) ^ FlexGrow.GetHashCode();
                hashCode = (hashCode * 397) ^ FlexShrink.GetHashCode();
                hashCode = (hashCode * 397) ^ FlexBasis?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (Margin != null ? Margin.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Position != null ? Position.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Padding != null ? Padding.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Border != null ? Border.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Width?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ Height?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ MinWidth?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ MinHeight?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ MaxWidth?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ MaxHeight?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ AspectRatio.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(YogaStyle left, YogaStyle right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(YogaStyle left, YogaStyle right)
        {
            return !Equals(left, right);
        }
    }
}
