using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class ContinuePaymentRequest
    {
        [property: JsonPropertyName("clientSecret")]
        public string ClientSecret { get; }

        [property: JsonPropertyName("threeDs")]
        public ContinuePaymentThreeDsRequest ThreeDs { get; }

        public ContinuePaymentRequest(
            string clientSecret,
            ContinuePaymentThreeDsRequest threeDs)
        {
            ClientSecret = clientSecret;
            ThreeDs = threeDs;
        }
    }
}
