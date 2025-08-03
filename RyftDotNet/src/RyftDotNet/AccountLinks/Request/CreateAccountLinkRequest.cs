using System.Text.Json.Serialization;

namespace RyftDotNet.AccountLinks.Request
{
    public sealed class CreateAccountLinkRequest
    {
        [property: JsonPropertyName("accountId")]
        public string AccountId { get; }

        [property: JsonPropertyName("redirectUrl")]
        public string RedirectUrl { get; }

        public CreateAccountLinkRequest(
            string accountId,
            string redirectUrl)
        {
            AccountId = accountId;
            RedirectUrl = redirectUrl;
        }
    }
}
