using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Orders
{
    public sealed class InPersonOrderShippingMethod
    {
        [JsonPropertyName("id")]
        public string? Id { get; }

        [JsonPropertyName("name")]
        public string? Name { get; }

        [JsonPropertyName("description")]
        public string? Description { get; }

        [JsonPropertyName("totalAmount")]
        public long? TotalAmount { get; }

        [JsonPropertyName("taxAmount")]
        public long? TaxAmount { get; }

        public InPersonOrderShippingMethod(
            string? id,
            string? name,
            string? description,
            long? totalAmount,
            long? taxAmount)
        {
            Id = id;
            Name = name;
            Description = description;
            TotalAmount = totalAmount;
            TaxAmount = taxAmount;
        }
    }
}
