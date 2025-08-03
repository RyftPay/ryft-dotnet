using System;

namespace RyftDotNet.Client.Error
{
    [Serializable]
    public class RyftDotNetException : Exception
    {
        public RyftDotNetException(string message) : base(message) { }

        public RyftDotNetException(
            string message,
            Exception innerException) : base(message, innerException) { }
    }
}
