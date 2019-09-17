using System;
using System.Collections.Generic;
using static Yoga.Net.YogaMath;

namespace Yoga.Net 
{
    public interface LTRBEdgeReadonly 
    {
        float this[Edge i] { get; }

        bool IsZero { get; }
        float Left { get; }
        float Top { get; }
        float Right { get; }
        float Bottom { get; }
    }

    /// <summary>
    /// Left Top Right Bottom edges
    /// </summary>
    public class LTRBEdge : LTRBEdgeReadonly
    {
        float _bottom;
        float _left;
        float _right;
        float _top;

        public LTRBEdge(float defaultValue = default)
        {
            _bottom = _left = _right = _top = defaultValue;
        }

        public LTRBEdge(float left, float top, float right, float bottom)
        {
            _left = left;
            _top = top;
            _right = right;
            _bottom = bottom;
        }

        public LTRBEdge(LTRBEdge other)
        {
            _bottom = other._bottom;
            _left = other._left;
            _right = other._right;
            _top = other._top;
        }

        public bool IsZero =>
            _left.IsZero() &&
            FloatsEqual(_left, _top) &&
            FloatsEqual(_left, _right) &&
            FloatsEqual(_left, _bottom);

        public YogaNode Owner { get; set; }

        public float Left
        {
            get => _left;
            set => CheckChanged(ref _left, value);
        }

        public float Top
        {
            get => _top;
            set => CheckChanged(ref _top, value);
        }

        public float Right
        {
            get => _right;
            set => CheckChanged(ref _right, value);
        }

        public float Bottom
        {
            get => _bottom;
            set => CheckChanged(ref _bottom, value);
        }

        public float this[Edge edge]
        {
            get
            {
                switch (edge)
                {
                case Edge.Left:       return Left;
                case Edge.Top:        return Top;
                case Edge.Right:      return Right;
                case Edge.Bottom:     return Bottom;
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
                default:
                    throw new ArgumentException("Unknown edge", nameof(edge));
                }
            }
        }

        /// <inheritdoc />
        public override string ToString() => $"({_left}, {_top}, {_right}, {_bottom})";

        void CheckChanged(ref float field, float value)
        {
            if (!EqualityComparer<float>.Default.Equals(field, value))
            {
                field = value;
                Owner?.MarkDirtyAndPropagate();
            }
        }

        protected bool Equals(LTRBEdge other) => 
            _bottom.Equals(other._bottom) && 
            _left.Equals(other._left) && 
            _right.Equals(other._right) && 
            _top.Equals(other._top);

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LTRBEdge)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _bottom.GetHashCode();
                hashCode = (hashCode * 397) ^ _left.GetHashCode();
                hashCode = (hashCode * 397) ^ _right.GetHashCode();
                hashCode = (hashCode * 397) ^ _top.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(LTRBEdge left, LTRBEdge right) => Equals(left, right);

        public static bool operator !=(LTRBEdge left, LTRBEdge right) => !Equals(left, right);
    }
}
