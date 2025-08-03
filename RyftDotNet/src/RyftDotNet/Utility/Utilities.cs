using System;
using System.Collections.Generic;
using System.Linq;
using RyftDotNet.Client;

namespace RyftDotNet.Utility
{
    internal static class Utilities
    {
        private const string SandboxSecretApiKeyPrefix = "sk_sandbox";

        internal static Uri DetermineBaseUri(
            ClientRequestSettings? requestSettings,
            ClientRequestSettings? perRequestSettings,
            string secretApiKey)
        {
            var settings = perRequestSettings ?? requestSettings;
            return settings?.BaseUri
                   ?? new Uri(DetermineBaseUrlFromApiKey(secretApiKey));
        }

        public static string DetermineApiVersion(
            ClientRequestSettings? requestSettings,
            ClientRequestSettings? perRequestSettings)
        {
            var settings = perRequestSettings ?? requestSettings;
            return settings?.Version ?? Constants.ApiVersions.One;
        }

        private static string DetermineBaseUrlFromApiKey(string apiKey)
            => apiKey.StartsWith(SandboxSecretApiKeyPrefix)
                ? Constants.SandboxApiUrl
                : Constants.ProductionApiUrl;

        internal static bool DictionaryEquals<T1, T2>(
            IDictionary<T1, T2>? left,
            IDictionary<T1, T2>? right) where T1 : notnull
            => left == null && right == null ||
               left?.Count == right?.Count && (!left?.Except(right!).Any() ?? true);

        internal static bool SequenceEqual<T>(
            IEnumerable<T>? left,
            IEnumerable<T>? right) => (left, right) switch
            {
                (null, null) => true,
                (left: { }, right: { }) => left.SequenceEqual(right),
                _ => false
            };
    }
}
