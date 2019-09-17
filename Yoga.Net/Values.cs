using System;
using System.Linq;
using JetBrains.Annotations;

namespace Yoga.Net
{
    public class Values<TKey, TValue> where TKey : struct, IConvertible
    {
        protected readonly TValue[] _values;

        public Values([NotNull] TValue defaultValue)
        {
            if (!typeof(TKey).IsEnum)
                throw new ArgumentException("T must be an enum");

            var size = Enum.GetValues(typeof(TKey)).Length;
            _values = new TValue[size];
            _values.Fill(defaultValue);
        }

        public TValue this[int i]
        {
            get => _values[i];
            set => _values[i] = value;
        }

        public TValue this[TKey i]
        {
            get => _values[Convert.ToInt32(i)];
            set => _values[Convert.ToInt32(i)] = value;
        }

        protected bool Equals(Values<TKey, TValue> other)
        {
            return _values.SequenceEqual(other._values);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Values<TKey, TValue>)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return (_values != null ? _values.GetHashCode() : 0);
        }

        public static bool operator ==(Values<TKey, TValue> left, Values<TKey, TValue> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Values<TKey, TValue> left, Values<TKey, TValue> right)
        {
            return !Equals(left, right);
        }
    }
}
