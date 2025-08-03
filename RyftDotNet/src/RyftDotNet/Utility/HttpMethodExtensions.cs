using System.Net.Http;

namespace RyftDotNet.Utility
{
    internal static class HttpMethodExtensions
    {
        internal static readonly HttpMethod Patch = new HttpMethod("PATCH");
    }
}
