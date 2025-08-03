using System.IO;
using System.Text;
using System.Text.Json;
using RyftDotNet.Common;
using RyftDotNet.Utility.JsonConverters;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Utility.JsonConverters
{
    public sealed class DateOfEventJsonConverterTest
    {
        private readonly DateOfEventJsonConverter converter = new DateOfEventJsonConverter();

        private static readonly DateOfEvent DateOfEvent = new DateOfEvent(1990, 05, 26);

        [Fact]
        public void Read_ShouldReturnExpectedValue()
        {
            const string json = "\"1990-05-26\"";
            var jsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));
            jsonReader.Read();
            var value = converter.Read(ref jsonReader, typeof(DateOfEvent), new JsonSerializerOptions());
            value.ShouldBe(DateOfEvent);
        }

        [Fact]
        public void Write_ShouldReturnExpectedValue()
        {
            const string expected = "\"1990-05-26\"";
            using var stream = new MemoryStream();
            var jsonWriter = new Utf8JsonWriter(stream);
            converter.Write(jsonWriter, DateOfEvent, new JsonSerializerOptions());
            jsonWriter.Flush();
            string result = Encoding.UTF8.GetString(stream.ToArray());
            result.ShouldBe(expected);
        }
    }
}
