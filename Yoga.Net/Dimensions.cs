using System;

namespace Yoga.Net
{
    public interface DimensionsReadonly 
    {
        YogaValue this[Dimension i] { get; }
    }

    /*
    public class Dimensions : DimensionsReadonly
    {
        public YogaValue Width { get; set; }
        public YogaValue Height { get; set; }

        public Dimensions(YogaValue width = null, YogaValue height = null)
        {
            Width = width ?? YogaValue.Undefined;
            Height = height ?? YogaValue.Undefined;
        }

        public Dimensions(Dimensions other)
        {
            Width = other.Width;
            Height = other.Height;
        }

        public YogaValue this[Dimension dim]
        {
            get
            {
                switch (dim)
                {
                case Dimension.Width:  return Width;
                case Dimension.Height: return Height;
                }

                throw new ArgumentException("Unknown dimension", nameof(dim));
            }
            set
            {
                switch (dim)
                {
                case Dimension.Width:  
                    Width = value;
                    return;
                case Dimension.Height: 
                    Height = value;
                    return;
                default:
                    throw new ArgumentException("Unknown dimension", nameof(dim));
                }
            }
        }

        /// <inheritdoc />
        public override string ToString() => $"({Width}, {Height})";
    }
    */

    public class DimensionsFloat
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public DimensionsFloat(float width = float.NaN, float height = float.NaN)
        {
            Width = width;
            Height = height;
        }

        public DimensionsFloat(DimensionsFloat other)
        {
            Width = other.Width;
            Height = other.Height;
        }

        public float this[Dimension dim]
        {
            get
            {
                switch (dim)
                {
                    case Dimension.Width: return Width;
                    case Dimension.Height: return Height;
                }

                throw new ArgumentException("Unknown dimension", nameof(dim));
            }
            set
            {
                switch (dim)
                {
                case Dimension.Width:  
                    Width = value;
                    return;
                case Dimension.Height: 
                    Height = value;
                    return;
                default:
                    throw new ArgumentException("Unknown dimension", nameof(dim));
                }
            }
        }

        /// <inheritdoc />
        public override string ToString() => $"({Width}, {Height})";
    }

}
