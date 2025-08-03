using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class FeeAllocationRequestItem
    {
        [property: JsonPropertyName("bookTo")]
        public string BookTo { get; }

        public FeeAllocationRequestItem(string bookTo)
        {
            BookTo = bookTo;
        }
    }
}
