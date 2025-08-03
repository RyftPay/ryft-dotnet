using System.Text.Json.Serialization;

namespace RyftDotNet.Accounts.Request
{
    public sealed class CreateAccountAuthorizeLinkRequest
    {
        [property: JsonPropertyName("email")]
        public string Email { get; }

        [property: JsonPropertyName("redirectUrl")]
        public string RedirectUrl { get; }

        public CreateAccountAuthorizeLinkRequest(string email, string redirectUrl)
        {
            Email = email;
            RedirectUrl = redirectUrl;
        }
    }
}
