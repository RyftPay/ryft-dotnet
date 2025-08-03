using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Utility;

namespace RyftDotNet.Balances
{
    public sealed class Balances : IEquatable<Balances>
    {
        [property: JsonPropertyName("items")]
        public IEnumerable<Balance> Items { get; }

        public Balances(IEnumerable<Balance> items)
        {
            Items = items;
        }

        public bool Equals(Balances? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Utilities.SequenceEqual(Items, other.Items));

        public override bool Equals(object? obj)
            => obj is Balances other && Equals(other);

        public override int GetHashCode() => Items.GetHashCode();
    }
}
