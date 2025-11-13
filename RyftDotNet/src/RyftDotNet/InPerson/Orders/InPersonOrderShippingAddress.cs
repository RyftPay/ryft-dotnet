using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Orders
{
    public sealed class InPersonOrderShippingAddress
    {
        [JsonPropertyName("businessName")]
        public string? BusinessName { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; }

        [JsonPropertyName("lastName")]
        public string LastName { get; }

        [JsonPropertyName("lineOne")]
        public string LineOne { get; }

        [JsonPropertyName("lineTwo")]
        public string? LineTwo { get; set; }

        [JsonPropertyName("city")]
        public string City { get; }

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; }

        [JsonPropertyName("country")]
        public string Country { get; }

        [JsonPropertyName("region")]
        public string? Region { get; set; }

        [JsonPropertyName("deliveryInstructions")]
        public string? DeliveryInstructions { get; set; }

        public InPersonOrderShippingAddress(
            string firstName,
            string lastName,
            string lineOne,
            string city,
            string postalCode,
            string country)
        {
            FirstName = firstName;
            LastName = lastName;
            LineOne = lineOne;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }
    }
}
