using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentSessionOrderDetailsItem : IEquatable<PaymentSessionOrderDetailsItem>
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
        public long? DiscountAmount { get; }

        [property: JsonPropertyName("productUrl")]
        public string? ProductUrl { get; }

        [property: JsonPropertyName("imageUrl")]
        public string? ImageUrl { get; }

        public PaymentSessionOrderDetailsItem(
            string reference,
            string name,
            int quantity,
            long unitPrice,
            long taxAmount,
            long totalAmount,
            long? discountAmount = null,
            string? productUrl = null,
            string? imageUrl = null)
        {
            Reference = reference;
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TaxAmount = taxAmount;
            TotalAmount = totalAmount;
            DiscountAmount = discountAmount;
            ProductUrl = productUrl;
            ImageUrl = imageUrl;
        }

        public bool Equals(PaymentSessionOrderDetailsItem? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Reference == other.Reference
                   && Name == other.Name
                   && Quantity == other.Quantity
                   && UnitPrice == other.UnitPrice
                   && TaxAmount == other.TaxAmount
                   && TotalAmount == other.TotalAmount
                   && DiscountAmount == other.DiscountAmount
                   && ProductUrl == other.ProductUrl
                   && ImageUrl == other.ImageUrl);

        public override bool Equals(object? obj)
            => obj is PaymentSessionOrderDetailsItem other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Reference);
            hashCode.Add(Name);
            hashCode.Add(Quantity);
            hashCode.Add(UnitPrice);
            hashCode.Add(TaxAmount);
            hashCode.Add(TotalAmount);
            hashCode.Add(DiscountAmount);
            hashCode.Add(ProductUrl);
            hashCode.Add(ImageUrl);
            return hashCode.ToHashCode();
        }
    }
}
