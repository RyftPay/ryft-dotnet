using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class StatementDescriptorRequest
    {
        [property: JsonPropertyName("descriptor")]
        public string Descriptor { get; }

        [property: JsonPropertyName("city")]
        public string City { get; }

        public StatementDescriptorRequest(string descriptor, string city)
        {
            Descriptor = descriptor;
            City = city;
        }
    }
}
