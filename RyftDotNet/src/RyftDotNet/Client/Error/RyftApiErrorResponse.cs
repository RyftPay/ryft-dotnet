using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Utility;

namespace RyftDotNet.Client.Error
{
    public sealed class RyftApiErrorResponse : IEquatable<RyftApiErrorResponse>
    {
        [property: JsonPropertyName("requestId")]
        public string RequestId { get; }
        [property: JsonPropertyName("code")]
        public string Code { get; }
        [property: JsonPropertyName("errors")]
        public IEnumerable<RyftApiErrorResponseElement> Errors { get; }

        public RyftApiErrorResponse(
            string requestId,
            string code,
            IEnumerable<RyftApiErrorResponseElement> errors)
        {
            RequestId = requestId;
            Code = code;
            Errors = errors;
        }

        public bool Equals(RyftApiErrorResponse? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || RequestId == other.RequestId
                   && Code == other.Code
                   && Utilities.SequenceEqual(Errors, other.Errors));

        public override bool Equals(object? obj)
            => obj is RyftApiErrorResponse other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(
            RequestId,
            Code,
            Errors
        ).GetHashCode();
    }
}
