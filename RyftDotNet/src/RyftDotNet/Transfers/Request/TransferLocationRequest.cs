using System.Text.Json.Serialization;

namespace RyftDotNet.Transfers.Request
{
    public sealed class TransferLocationRequest
    {
        [property: JsonPropertyName("accountId")]
        public string AccountId { get; }

        public TransferLocationRequest(string accountId)
        {
            AccountId = accountId;
        }
    }
}
