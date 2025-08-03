using System.Text.Json.Serialization;

namespace RyftDotNet.Accounts.Request
{
    public sealed class AccountSettingsRequest
    {
        [property: JsonPropertyName("payouts")]
        public AccountPayoutSettingsRequest Payouts { get; }

        public AccountSettingsRequest(AccountPayoutSettingsRequest payouts)
        {
            Payouts = payouts;
        }
    }
}
