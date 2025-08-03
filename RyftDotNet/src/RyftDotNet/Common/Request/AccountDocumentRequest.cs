using System.Text.Json.Serialization;

namespace RyftDotNet.Common.Request
{
    public sealed class AccountDocumentRequest
    {
        [property: JsonPropertyName("type")]
        public AccountDocumentType Type { get; }

        [property: JsonPropertyName("front")]
        public string Front { get; }

        [property: JsonPropertyName("back")]
        public string? Back { get; set; }

        [property: JsonPropertyName("country")]
        public string? Country { get; set; }

        public AccountDocumentRequest(AccountDocumentType type, string front)
        {
            Type = type;
            Front = front;
        }
    }
}
