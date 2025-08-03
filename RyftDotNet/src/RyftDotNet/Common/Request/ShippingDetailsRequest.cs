using System.Text.Json.Serialization;

namespace RyftDotNet.Common.Request
{
    public sealed class ShippingDetailsRequest
    {
        [property: JsonPropertyName("address")]
        public AddressRequest Address { get; }

        [property: JsonPropertyName("phoneNumber")]
        public string? PhoneNumber { get; set; }

        public ShippingDetailsRequest(AddressRequest address)
        {
            Address = address;
        }
    }
}
