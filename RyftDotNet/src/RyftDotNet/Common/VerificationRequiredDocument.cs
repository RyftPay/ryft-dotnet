using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Utility;

namespace RyftDotNet.Common
{
    public sealed class VerificationRequiredDocument : IEquatable<VerificationRequiredDocument>
    {
        [property: JsonPropertyName("category")]
        public AccountDocumentCategory Category { get; }

        [property: JsonPropertyName("types")]
        public IEnumerable<AccountDocumentType> Types { get; }

        [property: JsonPropertyName("quantity")]
        public int Quantity { get; }

        public VerificationRequiredDocument(
            AccountDocumentCategory category,
            IEnumerable<AccountDocumentType> types,
            int quantity)
        {
            Category = category;
            Types = types;
            Quantity = quantity;
        }

        public bool Equals(VerificationRequiredDocument? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Category == other.Category
                   && Utilities.SequenceEqual(Types, other.Types)
                   && Quantity == other.Quantity);

        public override bool Equals(object? obj)
            => obj is VerificationRequiredDocument other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Category, Types, Quantity).GetHashCode();
    }
}
