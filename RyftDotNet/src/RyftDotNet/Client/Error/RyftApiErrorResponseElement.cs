using System;

namespace RyftDotNet.Client.Error
{
    public sealed class RyftApiErrorResponseElement : IEquatable<RyftApiErrorResponseElement>
    {
        public string Code { get; }
        public string Message { get; }

        public RyftApiErrorResponseElement(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public bool Equals(RyftApiErrorResponseElement? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Code == other.Code
                   && Message == other.Message);

        public override bool Equals(object? obj)
            => obj is RyftApiErrorResponseElement other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Code, Message).GetHashCode();
    }
}
