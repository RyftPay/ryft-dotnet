using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Common
{
    public sealed class RequiredField : IEquatable<RequiredField>
    {
        [property: JsonPropertyName("name")]
        public string Name { get; }

        public RequiredField(string name)
        {
            Name = name;
        }

        public bool Equals(RequiredField? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Name == other.Name);

        public override bool Equals(object? obj)
            => obj is RequiredField other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Name).GetHashCode();
    }
}
