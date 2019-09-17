using static Yoga.Net.YogaMath;

namespace Yoga.Net
{
    public class YogaCachedMeasurement
    {
        public float AvailableWidth { get; set; }
        public float AvailableHeight { get; set; }
        public MeasureMode WidthMeasureMode { get; set; }
        public MeasureMode HeightMeasureMode { get; set; }
        public float ComputedWidth { get; set; }
        public float ComputedHeight { get; set; }

        public YogaCachedMeasurement()
        {
            AvailableWidth    = 0;
            AvailableHeight   = 0;
            WidthMeasureMode  = MeasureMode.Undefined;
            HeightMeasureMode = MeasureMode.Undefined;
            ComputedWidth     = -1;
            ComputedHeight    = -1;
        }

        public YogaCachedMeasurement(YogaCachedMeasurement other)
        {
            AvailableWidth    = other.AvailableWidth;
            AvailableHeight   = other.AvailableHeight;
            WidthMeasureMode  = other.WidthMeasureMode;
            HeightMeasureMode = other.HeightMeasureMode;
            ComputedWidth     = other.ComputedWidth;
            ComputedHeight    = other.ComputedHeight;
        }

        protected bool Equals(YogaCachedMeasurement other)
        {
            bool isEqual = WidthMeasureMode == other.WidthMeasureMode &&
                HeightMeasureMode == other.HeightMeasureMode;

            if (AvailableWidth.HasValue() || other.AvailableWidth.HasValue())
            {
                isEqual = isEqual && FloatsEqual(AvailableWidth, other.AvailableWidth);
            }

            if (AvailableHeight.HasValue() || other.AvailableHeight.HasValue())
            {
                isEqual = isEqual && FloatsEqual(AvailableHeight, other.AvailableHeight);
            }

            if (ComputedWidth.HasValue() || other.ComputedWidth.HasValue())
            {
                isEqual = isEqual && FloatsEqual(ComputedWidth, other.ComputedWidth);
            }

            if (ComputedHeight.HasValue() || other.ComputedHeight.HasValue())
            {
                isEqual = isEqual && FloatsEqual(ComputedHeight, other.ComputedHeight);
            }

            return isEqual;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((YogaCachedMeasurement)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = AvailableWidth.GetHashCode();
                hashCode = (hashCode * 397) ^ AvailableHeight.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)WidthMeasureMode;
                hashCode = (hashCode * 397) ^ (int)HeightMeasureMode;
                hashCode = (hashCode * 397) ^ ComputedWidth.GetHashCode();
                hashCode = (hashCode * 397) ^ ComputedHeight.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(YogaCachedMeasurement left, YogaCachedMeasurement right) => Equals(left, right);

        public static bool operator !=(YogaCachedMeasurement left, YogaCachedMeasurement right) => !Equals(left, right);
    }
}
