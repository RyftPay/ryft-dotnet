using System.Text.Json.Serialization;

namespace RyftDotNet.Accounts.Request
{
    public sealed class AccountCapabilityRequestItem
    {
        [property: JsonPropertyName("requested")]
        public bool Requested { get; }

        public AccountCapabilityRequestItem(bool requested)
        {
            Requested = requested;
        }
    }
}
