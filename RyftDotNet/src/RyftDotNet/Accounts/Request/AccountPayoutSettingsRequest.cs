using System.Text.Json.Serialization;

namespace RyftDotNet.Accounts.Request
{
    public sealed class AccountPayoutSettingsRequest
    {
        [property: JsonPropertyName("schedule")]
        public AccountPayoutScheduleSettingsRequest Schedule { get; }

        public AccountPayoutSettingsRequest(AccountPayoutScheduleSettingsRequest schedule)
        {
            Schedule = schedule;
        }
    }
}
