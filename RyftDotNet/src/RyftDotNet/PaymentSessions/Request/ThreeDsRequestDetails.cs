using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class ThreeDsRequestDetails
    {
        [property: JsonPropertyName("deviceChannel")]
        public DeviceChannel DeviceChannel { get; }

        [property: JsonPropertyName("browserDetails")]
        public BrowserDetailsRequest? BrowserDetails { get; set; }

        public ThreeDsRequestDetails(DeviceChannel deviceChannel)
        {
            DeviceChannel = deviceChannel;
        }
    }
}
