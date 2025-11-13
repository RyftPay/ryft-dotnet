using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Locations
{
    public sealed class InPersonLocationDeleted : IEquatable<InPersonLocationDeleted>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        public InPersonLocationDeleted(string id)
        {
            Id = id;
        }

        public bool Equals(InPersonLocationDeleted? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other) || Id == other.Id);

        public override bool Equals(object? obj)
            => obj is InPersonLocationDeleted other && Equals(other);

        public override int GetHashCode()
            => Id.GetHashCode();
    }
}
