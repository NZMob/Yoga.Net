using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Yoga.Net
{
    public static class YogaMath
    {
        public static bool HasValue(this float value) => !float.IsNaN(value) && !float.IsInfinity(value);

        public static bool IsUndefined(this float value) => float.IsNaN(value) || float.IsInfinity(value);

        public static bool IsZero(this float value) => Math.Abs(value) < 0.0001f;

        public static bool IsNotZero(this float value) => Math.Abs(value) > 0.0001f;

        // This custom float equality function returns true if either absolute
        // difference between two floats is less than 0.0001f or both are undefined.
        public static bool FloatsEqual(float a, float b)
        {
            if (a.HasValue() && b.HasValue())
                return Math.Abs(a - b) < 0.0001f;

            return a.IsUndefined() && b.IsUndefined();
        }

        public static float FloatMax(float a, float b)
        {
            if (a.HasValue() && b.HasValue())
                return Math.Max(a, b);

            return a.IsUndefined() ? b : a;
        }

        public static float FloatMod(float x, float y) => (float)Math.IEEERemainder(x, y);

        public static float FloatMin(float a, float b)
        {
            if (a.HasValue() && b.HasValue())
                return Math.Min(a, b);

            return a.IsUndefined() ? b : a;
        }

        // This custom float comparison function compares the array of float with
        // FloatsEqual, as the default float comparison operator will not work(Look
        // at the comments of FloatsEqual function).
        public static bool FloatArrayEqual(float[] val1, float[] val2) => val1.SequenceEqual(val2);

        // This function returns 0 if YGFloatIsUndefined(val) is true and val otherwise
        public static float FloatSanitize(float val) => val.IsUndefined() ? 0 : val;

        public static float RoundValueToPixelGrid(float value,float pointScaleFactor,bool forceCeil,bool forceFloor)
        {
            var scaledValue = value * pointScaleFactor;
            // We want to calculate `fractial` such that `floor(scaledValue) = scaledValue
            // - fractial`.
            //float f = 0.0000019f;
            var fractial = FloatMod(scaledValue, 1.0f);
            if (fractial < 0)
            {
                // This branch is for handling negative numbers for `value`.
                //
                // Regarding `floor` and `ceil`. Note that for a number x, `floor(x) <= x <=
                // ceil(x)` even for negative numbers. Here are a couple of examples:
                //   - x =  2.2: floor( 2.2) =  2, ceil( 2.2) =  3
                //   - x = -2.2: floor(-2.2) = -3, ceil(-2.2) = -2
                //
                // Regarding `fmodf`. For fractional negative numbers, `fmodf` returns a
                // negative number. For example, `fmodf(-2.2) = -0.2`. However, we want
                // `fractial` to be the number such that subtracting it from `value` will
                // give us `floor(value)`. In the case of negative numbers, adding 1 to
                // `fmodf(value)` gives us this. Let's continue the example from above:
                //   - fractial = fmodf(-2.2) = -0.2
                //   - Add 1 to the fraction: fractial2 = fractial + 1 = -0.2 + 1 = 0.8
                //   - Finding the `floor`: -2.2 - fractial2 = -2.2 - 0.8 = -3
                ++fractial;
            }

            if (FloatsEqual(fractial, 0))
            {
                // First we check if the value is already rounded
                scaledValue = scaledValue - fractial;
            }
            else if (FloatsEqual(fractial, 1.0f))
            {
                scaledValue = (scaledValue - fractial) + 1.0f;
            }
            else if (forceCeil)
            {
                var d = Math.Ceiling(scaledValue);
                // Next we check if we need to use forced rounding
                scaledValue = (scaledValue - fractial) + 1.0f;
            }
            else if (forceFloor)
            {
                scaledValue = scaledValue - fractial;
            }
            else
            {
                // Finally we just round the value
                scaledValue = (scaledValue - fractial) +
                    (fractial.HasValue() &&
                        (fractial > 0.5f || FloatsEqual(fractial, 0.5f))
                            ? 1.0f
                            : 0.0f);
            }

            return scaledValue.IsUndefined() || pointScaleFactor.IsUndefined()
                    ? YogaValue.YGUndefined
                    : scaledValue / pointScaleFactor;
        }
    }

    public static class Extensions
    {
        public static void Fill<T>(this T[] originalArray, T with)
        {
            for (int i = 0; i < originalArray.Length; i++)
                originalArray[i] = with;
        }

        public static void Fill<T>(this T[] originalArray, Func<T> action)
        {
            for (int i = 0; i < originalArray.Length; i++)
                originalArray[i] = action();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsRow(this FlexDirection flexDirection)
        {
            return flexDirection == FlexDirection.Row || flexDirection == FlexDirection.RowReverse;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Resolve(this YogaValue value, float ownerSize)
        {
            switch (value.Unit)
            {
            case YogaUnit.Point:
                return value.Value;
            case YogaUnit.Percent:
                return (value.Value * ownerSize * 0.01f);
            default:
                return float.NaN;
            }
        }

        public static FlexDirection CrossAxis(this FlexDirection flexDirection, Direction direction)
        {
            return flexDirection.IsColumn()
                ? FlexDirection.Row.Resolve(direction)
                : FlexDirection.Column;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsColumn(this FlexDirection flexDirection)
        {
            return flexDirection == FlexDirection.Column ||
                flexDirection == FlexDirection.ColumnReverse;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FlexDirection Resolve(this FlexDirection flexDirection, Direction direction)
        {
            if (direction == Direction.RTL)
            {
                if (flexDirection == FlexDirection.Row)
                    return FlexDirection.RowReverse;

                if (flexDirection == FlexDirection.RowReverse)
                    return FlexDirection.Row;
            }

            return flexDirection;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ResolveValueMargin(this YogaValue value, in float ownerSize)
        {
            return value.IsAuto ? 0f : value.Resolve(ownerSize);
        }

        public static YogaValue Point(this float value) => new YogaValue(value, YogaUnit.Point);
        public static YogaValue Percent(this float value) => new YogaValue(value, YogaUnit.Percent);
        public static YogaValue Point(this int value) => new YogaValue(value, YogaUnit.Point);
        public static YogaValue Percent(this int value) => new YogaValue(value, YogaUnit.Percent);

    }
}
