using System.Diagnostics;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

// ReSharper disable RedundantCaseLabel

namespace Yoga.Net
{
    /// <summary>
    /// Immutable value class representing a value in Points, Percentage, Auto or Undefined.
    /// </summary>
    public class YogaValue
    {
        public const float YGUndefined = float.NaN;

        public static readonly YogaValue Auto = new YogaValue(0f, YogaUnit.Auto);
        public static readonly YogaValue Undefined = new YogaValue(0f, YogaUnit.Undefined);
        public static readonly YogaValue Zero = new YogaValue(0f, YogaUnit.Point);

        public readonly float Value;
        public readonly YogaUnit Unit;

        public YogaValue(float value, YogaUnit unit)
        {
            Unit = unit;
            Value = (unit == YogaUnit.Auto || unit == YogaUnit.Undefined) ? YGUndefined : value;
        }

        public bool IsNaN => float.IsNaN(Value) || float.IsInfinity(Value);

        public bool IsAuto => Unit == YogaUnit.Auto;

        public bool IsUndefined =>
            Unit == YogaUnit.Undefined ||
            (IsNaN && (Unit == YogaUnit.Point || Unit == YogaUnit.Percent));

        public bool HasValue => !IsUndefined;

        public bool Equals(YogaValue other)
        {
            if (Unit != other.Unit)
                return false;

            switch (Unit)
            {
            case YogaUnit.Undefined:
            case YogaUnit.Auto:
                return true;
            case YogaUnit.Point:
            case YogaUnit.Percent:
                return
                    Value.Equals(other.Value);
            }

            return false;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            switch (Unit)
            {
            case YogaUnit.Auto:
                return $"auto";
            case YogaUnit.Percent:
                return $"{Value}%";
            case YogaUnit.Point:
                return $"{Value}px";
            case YogaUnit.Undefined:
            default:
                return string.Empty;
            }
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is YogaValue other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode() * 397) ^ (int)Unit;
            }
        }

        public static bool operator ==(YogaValue left, YogaValue right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (ReferenceEquals(null, left) || ReferenceEquals(null, right)) return false;
            return left.Equals(right);
        }

        public static bool operator !=(YogaValue left, YogaValue right)
        {
            if (ReferenceEquals(left, right)) return false;
            if (ReferenceEquals(null, left) || ReferenceEquals(null, right)) return true;
            return !left.Equals(right);
        }

        public static YogaValue operator -([NotNull] YogaValue left)
        {
            return new YogaValue(-left.Value, left.Unit);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator YogaValue(int i)
        {
            return new YogaValue(i, YogaUnit.Point);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator YogaValue(short s)
        {
            return new YogaValue(s, YogaUnit.Point);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator YogaValue(float f)
        {
            if (f.IsUndefined())
                return YogaValue.Undefined;
            return new YogaValue(f, YogaUnit.Point);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator YogaValue(double d)
        {
            return new YogaValue((float)d, YogaUnit.Point);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static YogaValue Percent(float f)
        {
            return new YogaValue(f, YogaUnit.Percent);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static YogaValue Point(float f)
        {
            return new YogaValue(f, YogaUnit.Point);
        }

        public static YogaValue Sanitized(float value, YogaUnit unit)
        {
            if (float.IsNaN(value))
                return new YogaValue(0f, YogaUnit.Undefined);
            return new YogaValue(value, unit);
        }
    }
}
