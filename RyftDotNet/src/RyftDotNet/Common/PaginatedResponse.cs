using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Utility;

namespace RyftDotNet.Common
{
    public sealed class PaginatedResponse<T> : IEquatable<PaginatedResponse<T>>
    {
        [JsonPropertyName("items")]
        public IEnumerable<T> Items { get; }

        [JsonPropertyName("paginationToken")]
        public string? PaginationToken { get; }

        public PaginatedResponse(
            IEnumerable<T> items,
            string? paginationToken = null)
        {
            Items = items;
            PaginationToken = paginationToken;
        }

        public bool Equals(PaginatedResponse<T>? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Utilities.SequenceEqual(Items, other.Items)
                   && PaginationToken == other.PaginationToken);

        public override bool Equals(object? obj)
            => obj is PaginatedResponse<T> other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Items, PaginationToken).GetHashCode();
    }
}
