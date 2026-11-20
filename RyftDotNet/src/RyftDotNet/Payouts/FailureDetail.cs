using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Payouts
{
    public sealed class FailureDetail : IEquatable<FailureDetail>
    {
        [property: JsonPropertyName("code")]
        public string Code { get; }

        [property: JsonPropertyName("description")]
        public string Description { get; }

        public FailureDetail(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public bool Equals(FailureDetail? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Code == other.Code &&
                   Description == other.Description);

        public override bool Equals(object? obj)
            => obj is FailureDetail other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Code, Description);
    }
}
