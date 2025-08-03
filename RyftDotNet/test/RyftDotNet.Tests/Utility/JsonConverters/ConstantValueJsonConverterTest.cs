using System.IO;
using System.Text;
using System.Text.Json;
using RyftDotNet.Subscriptions;
using RyftDotNet.Utility.JsonConverters;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Utility.JsonConverters
{
    public sealed class ConstantValueJsonConverterTest
    {
        private readonly ConstantValueJsonConverter<SubscriptionStatus> converter =
            new ConstantValueJsonConverter<SubscriptionStatus>(value => new SubscriptionStatus(value));

        [Fact]
        public void Read_ShouldReturnExpectedValue()
        {
            const string json = "\"PastDue\"";
            var jsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));
            jsonReader.Read();
            var value = converter.Read(ref jsonReader, typeof(SubscriptionStatus), new JsonSerializerOptions());
            value.ShouldBe(SubscriptionStatus.PastDue);
        }

        [Fact]
        public void Write_ShouldReturnExpectedValue()
        {
            const string expected = "\"Cancelled\"";
            using var stream = new MemoryStream();
            var jsonWriter = new Utf8JsonWriter(stream);
            converter.Write(jsonWriter, SubscriptionStatus.Cancelled, new JsonSerializerOptions());
            jsonWriter.Flush();
            string result = Encoding.UTF8.GetString(stream.ToArray());
            result.ShouldBe(expected);
        }
    }
}
