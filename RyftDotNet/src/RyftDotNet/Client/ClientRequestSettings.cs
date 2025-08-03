using System;

namespace RyftDotNet.Client
{
    public sealed class ClientRequestSettings
    {
        public string? ApiKey { get; set; }
        public string? AccountId { get; set; }
        public Uri? BaseUri { get; set; }
        public string? Version { get; set; }
    }
}
