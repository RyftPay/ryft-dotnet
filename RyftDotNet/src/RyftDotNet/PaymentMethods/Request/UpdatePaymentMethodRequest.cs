using System.Text.Json.Serialization;
using RyftDotNet.Common.Request;

namespace RyftDotNet.PaymentMethods.Request
{
    public sealed class UpdatePaymentMethodRequest
    {
        [property: JsonPropertyName("billingAddress")]
        public AddressRequest? BillingAddress { get; set; }
    }
}
