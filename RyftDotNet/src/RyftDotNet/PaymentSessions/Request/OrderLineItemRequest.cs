using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class OrderLineItemRequest
    {
        [property: JsonPropertyName("reference")]
        public string Reference { get; }

        [property: JsonPropertyName("name")]
        public string Name { get; }

        [property: JsonPropertyName("quantity")]
        public int Quantity { get; }

        [property: JsonPropertyName("unitPrice")]
        public long UnitPrice { get; }

        [property: JsonPropertyName("taxAmount")]
        public long TaxAmount { get; }

        [property: JsonPropertyName("totalAmount")]
        public long TotalAmount { get; }

        [property: JsonPropertyName("discountAmount")]
        public long? DiscountAmount { get; set; }

        [property: JsonPropertyName("productUrl")]
        public string? ProductUrl { get; set; }

        [property: JsonPropertyName("imageUrl")]
        public string? ImageUrl { get; set; }

        public OrderLineItemRequest(
            string reference,
            string name,
            int quantity,
            long unitPrice,
            long taxAmount,
            long totalAmount)
        {
            Reference = reference;
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TaxAmount = taxAmount;
            TotalAmount = totalAmount;
        }
    }
}
