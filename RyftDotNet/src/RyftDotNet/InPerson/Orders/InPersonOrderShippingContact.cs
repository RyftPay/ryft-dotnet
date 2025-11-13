using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Orders
{
    public sealed class InPersonOrderShippingContact
    {
        [JsonPropertyName("email")]
        public string Email { get; }

        [JsonPropertyName("mobilePhoneNumber")]
        public string MobilePhoneNumber { get; }

        public InPersonOrderShippingContact(
            string email,
            string mobilePhoneNumber)
        {
            Email = email;
            MobilePhoneNumber = mobilePhoneNumber;
        }
    }
}
