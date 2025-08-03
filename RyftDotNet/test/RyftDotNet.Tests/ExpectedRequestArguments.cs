using System;
using System.Net;
using System.Net.Http;

namespace RyftDotNet.Tests
{
    public sealed class ExpectedRequestArguments : IEquatable<ExpectedRequestArguments>
    {
        private string Path { get; }
        private HttpMethod Method { get; }
        private HttpStatusCode StatusCode { get; }
        private object? Body { get; }

        public ExpectedRequestArguments(
            string path,
            HttpMethod method,
            HttpStatusCode statusCode,
            object? body)
        {
            Path = path;
            Method = method;
            StatusCode = statusCode;
            Body = body;
        }

        public bool Equals(ExpectedRequestArguments? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Path == other.Path
                   && Method.Equals(other.Method)
                   && StatusCode == other.StatusCode
                   && Nullable.Equals(Body, other.Body));

        public override bool Equals(object? obj)
            => obj is ExpectedRequestArguments other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Path, Method, (int)StatusCode, Body);
    }
}
