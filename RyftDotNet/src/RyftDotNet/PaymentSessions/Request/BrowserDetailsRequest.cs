using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class BrowserDetailsRequest
    {
        [property: JsonPropertyName("acceptHeader")]
        public string AcceptHeader { get; }

        [property: JsonPropertyName("colorDepth")]
        public int ColorDepth { get; }

        [property: JsonPropertyName("javaEnabled")]
        public bool JavaEnabled { get; }

        [property: JsonPropertyName("language")]
        public string Language { get; }

        [property: JsonPropertyName("screenHeight")]
        public string ScreenHeight { get; }

        [property: JsonPropertyName("screenWidth")]
        public string ScreenWidth { get; }

        [property: JsonPropertyName("timeZoneOffset")]
        public int TimeZoneOffset { get; }

        [property: JsonPropertyName("userAgent")]
        public string UserAgent { get; }

        public BrowserDetailsRequest(
            string acceptHeader,
            int colorDepth,
            bool javaEnabled,
            string language,
            string screenHeight,
            string screenWidth,
            int timeZoneOffset,
            string userAgent)
        {
            AcceptHeader = acceptHeader;
            ColorDepth = colorDepth;
            JavaEnabled = javaEnabled;
            Language = language;
            ScreenHeight = screenHeight;
            ScreenWidth = screenWidth;
            TimeZoneOffset = timeZoneOffset;
            UserAgent = userAgent;
        }
    }
}
