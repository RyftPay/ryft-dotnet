using System;

namespace RyftDotNet.Client.Error
{
    [Serializable]
    public sealed class RyftArgumentException : RyftDotNetException
    {
        public RyftArgumentException(string message) : base(message) { }

        public RyftArgumentException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
