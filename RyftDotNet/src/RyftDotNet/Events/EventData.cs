using System;

namespace RyftDotNet.Events
{
    public sealed class EventData : IEquatable<EventData>
    {
        public object? Object { get; }

        public EventData(object? apiObject)
        {
            Object = apiObject;
        }

        public bool Equals(EventData? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Equals(Object, other.Object));

        public override bool Equals(object? obj)
            => obj is EventData other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Object);
    }
}
