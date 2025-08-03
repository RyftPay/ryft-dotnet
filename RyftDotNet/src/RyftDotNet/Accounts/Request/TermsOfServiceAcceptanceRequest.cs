using System;
using System.Text.Json.Serialization;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Accounts.Request
{
    public sealed class TermsOfServiceAcceptanceRequest
    {
        [property: JsonPropertyName("ipAddress")]
        public string IpAddress { get; }

        [property: JsonPropertyName("userAgent")]
        public string? UserAgent { get; set; }

        [property:
            JsonPropertyName("when"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset? When { get; set; }

        public TermsOfServiceAcceptanceRequest(string ipAddress)
        {
            IpAddress = ipAddress;
        }
    }
}
