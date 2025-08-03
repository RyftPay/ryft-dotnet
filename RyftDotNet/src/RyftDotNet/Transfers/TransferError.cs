using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Transfers
{
    public sealed class TransferError : IEquatable<TransferError>
    {
        [property: JsonPropertyName("code")]
        public string Code { get; }

        [property: JsonPropertyName("description")]
        public string Description { get; }

        public TransferError(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public bool Equals(TransferError? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Code == other.Code && Description == other.Description);

        public override bool Equals(object? obj)
            => obj is TransferError other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Code, Description);
    }
}
