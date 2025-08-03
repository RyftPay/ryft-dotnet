using System.Text.Json.Serialization;
using RyftDotNet.Common;

namespace RyftDotNet.Accounts.Request
{
    public sealed class AccountPayoutScheduleSettingsRequest
    {
        [property: JsonPropertyName("type")]
        public PayoutScheduleType Type { get; }

        public AccountPayoutScheduleSettingsRequest(PayoutScheduleType type)
        {
            Type = type;
        }
    }
}
