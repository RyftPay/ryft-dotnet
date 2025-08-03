using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Common
{
    public sealed class DeletedResource : IEquatable<DeletedResource>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        public DeletedResource(string id)
        {
            Id = id;
        }

        public bool Equals(DeletedResource? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other) || Id == other.Id);

        public override bool Equals(object? obj)
            => obj is DeletedResource other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Id).GetHashCode();
    }
}
