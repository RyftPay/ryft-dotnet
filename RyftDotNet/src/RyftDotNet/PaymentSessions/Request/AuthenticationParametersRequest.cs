using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class AuthenticationParametersRequest
    {
        [property: JsonPropertyName("eci")]
        public string Eci { get; }

        [property: JsonPropertyName("authenticationValue")]
        public string? AuthenticationValue { get; set; }

        [property: JsonPropertyName("protocolVersion")]
        public string? ProtocolVersion { get; set; }

        [property: JsonPropertyName("threeDsServerTransactionId")]
        public string? ThreeDsServerTransactionId { get; set; }

        [property: JsonPropertyName("acsTransactionId")]
        public string? AcsTransactionId { get; set; }

        [property: JsonPropertyName("dsTransactionId")]
        public string? DsTransactionId { get; set; }

        public AuthenticationParametersRequest(string eci)
        {
            Eci = eci;
        }
    }
}
