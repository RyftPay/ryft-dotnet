using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Common
{
    public sealed class VerificationError : IEquatable<VerificationError>
    {
        [property: JsonPropertyName("code")]
        public string Code { get; }

        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("description")]
        public string Description { get; }

        public VerificationError(string code, string id, string description)
        {
            Code = code;
            Id = id;
            Description = description;
        }

        public bool Equals(VerificationError? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Code == other.Code
                   && Id == other.Id
                   && Description == other.Description);

        public override bool Equals(object? obj)
            => obj is VerificationError other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Code, Id, Description).GetHashCode();
    }
}
