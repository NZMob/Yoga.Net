using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Yoga.Net
{
    public interface EdgesReadonly
    {
        YogaValue this[Edge edge] { get; }
        YogaValue ComputedEdgeValue(Edge edge, YogaValue defaultValue = null);
    }

    public class Edges : EdgesReadonly
    {
        YogaValue _bottom = YogaValue.Undefined;
        YogaValue _left = YogaValue.Undefined;
        YogaValue _right = YogaValue.Undefined;
        YogaValue _top = YogaValue.Undefined;
        YogaValue _start = YogaValue.Undefined;
        YogaValue _end = YogaValue.Undefined;
        YogaValue _all = YogaValue.Undefined;

        public Edges(YogaValue defaultValue)
        {
            _left = _top = _right = _bottom = _start = _end = _all = defaultValue;
        }

        public Edges(
            YogaValue left = null,
            YogaValue top = null,
            YogaValue right = null,
            YogaValue bottom = null,
            YogaValue start = null,
            YogaValue end = null,
            YogaValue horizontal = null,
            YogaValue vertical = null,
            YogaValue all = null)
        {
            if (all != null)        All = all;
            if (horizontal != null) Left = Right  = horizontal;
            if (vertical != null)   Top  = Bottom = vertical;
            if (start != null)      Start = start;
            if (end != null)        End   = end;
            if (left != null)       Left   = left;
            if (top != null)        Top    = top;
            if (right != null)      Right  = right;
            if (bottom != null)     Bottom = bottom;
        }

        public Edges(Edges other)
        {
            Left   = other.Left;
            Top    = other.Top;
            Right  = other.Right;
            Bottom = other.Bottom;
            Start  = other.Start;
            End    = other.End;
            All = other.All;
        }

        public YogaValue All
        {
            get => _all;
            set => CheckChanged(ref _all, value);
        }

        public YogaValue Bottom
        {
            get => _bottom;
            set => CheckChanged(ref _bottom, value);
        }

        public YogaValue End
        {
            get => _end;
            set => CheckChanged(ref _end, value);
        }

        public YogaValue Left
        {
            get => _left;
            set => CheckChanged(ref _left, value);
        }

        public YogaNode Owner { get; set; }

        public YogaValue Right
        {
            get => _right;
            set => CheckChanged(ref _right, value);
        }

        public YogaValue Start
        {
            get => _start;
            set => CheckChanged(ref _start, value);
        }

        public YogaValue Top
        {
            get => _top;
            set => CheckChanged(ref _top, value);
        }

        public YogaValue this[Edge edge]
        {
            get
            {
                switch (edge)
                {
                case Edge.Left:       return Left;
                case Edge.Top:        return Top;
                case Edge.Right:      return Right;
                case Edge.Bottom:     return Bottom;
                case Edge.Horizontal: return Left == Right ? Left : YogaValue.Undefined;
                case Edge.Vertical:   return Top == Bottom ? Top : YogaValue.Undefined;
                case Edge.All:        return All;
                case Edge.Start: return Start;
                case Edge.End: return End;
                default:
                    throw new ArgumentException("Unknown edge", nameof(edge));
                }
            }
            set
            {
                switch (edge)
                {
                case Edge.Left:
                    Left = value;
                    break;
                case Edge.Top:
                    Top = value;
                    break;
                case Edge.Right:
                    Right = value;
                    break;
                case Edge.Bottom:
                    Bottom = value;
                    break;
                case Edge.Horizontal:
                    Left = Right = value;
                    break;
                case Edge.Vertical:
                    Top = Bottom = value;
                    break;
                case Edge.All:
                    All = value;
                    break;
                case Edge.Start:
                    Start = value;
                    break;
                case Edge.End:
                    End = value;
                    break;
                default:
                    throw new ArgumentException("Unknown edge", nameof(edge));
                }
            }
        }

        public YogaValue ComputedEdgeValue(Edge edge, YogaValue defaultValue = null)
        {
            if (this[edge].HasValue)
                return this[edge];

            if ((edge == Edge.Top || edge == Edge.Bottom) && this[Edge.Vertical].HasValue)
                return this[Edge.Vertical];

            if ((edge == Edge.Left || edge == Edge.Right || edge == Edge.Start || edge == Edge.End) && this[Edge.Horizontal].HasValue)
                return this[Edge.Horizontal];

            if (!this[Edge.All].IsUndefined)
                return this[Edge.All];

            if (edge == Edge.Start || edge == Edge.End)
                return YogaValue.Undefined;

            return defaultValue ?? YogaValue.Undefined;
        }


        /// <inheritdoc />
        public override string ToString()
        {
            if (_all.HasValue)
                return $"(all:{All})";
            if (_start.HasValue || _end.HasValue)
            {
                return $"({_start}:{_end} - {Left},{Top},{Right},{Bottom})";
            }
            return $"({_left},{_top},{_right},{_bottom})";
        }

        void CheckChanged<T>([NotNull] ref T field, T value)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                Owner?.MarkDirtyAndPropagate();
            }
        }

        protected bool Equals(Edges other)
        {
            return 
                Equals(_bottom, other._bottom) &&
                Equals(_left, other._left) &&
                Equals(_right, other._right) &&
                Equals(_top, other._top) &&
                Equals(_start, other._start) &&
                Equals(_end, other._end) &&
                Equals(_all, other._all);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Edges)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_bottom != null ? _bottom.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_left != null ? _left.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_right != null ? _right.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_top != null ? _top.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_start != null ? _start.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_end != null ? _end.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_all != null ? _all.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Edges left, Edges right) => Equals(left, right);

        public static bool operator !=(Edges left, Edges right) => !Equals(left, right);
    }
}
