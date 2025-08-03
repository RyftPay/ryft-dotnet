using System;

namespace RyftDotNet.Common
{
    public class ConstantValue : IEquatable<ConstantValue>
    {
        public string Value { get; }

        internal ConstantValue(string value)
        {
            Value = value;
        }

        public static implicit operator string(ConstantValue value) => value.Value;

        public bool Equals(ConstantValue? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Value == other.Value);

        public override bool Equals(object? obj)
            => obj is ConstantValue other && Equals(other);

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value;

        public static bool operator ==(ConstantValue? left, ConstantValue? right)
            => Equals(left, right);

        public static bool operator !=(ConstantValue? left, ConstantValue? right)
            => !Equals(left, right);

        public static bool operator ==(ConstantValue? left, string? right)
            => Equals(left?.Value, right);

        public static bool operator !=(ConstantValue? left, string? right)
            => !Equals(left?.Value, right);
    }
}
