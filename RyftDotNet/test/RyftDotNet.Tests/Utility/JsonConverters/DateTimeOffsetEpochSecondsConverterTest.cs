using System;
using System.IO;
using System.Text;
using System.Text.Json;
using RyftDotNet.Utility.JsonConverters;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Utility.JsonConverters
{
    public sealed class DateTimeOffsetEpochSecondsConverterTest
    {
        private readonly DateTimeOffsetEpochSecondsConverter converter = new DateTimeOffsetEpochSecondsConverter();

        private static readonly DateTimeOffset DateTimeOffset =
            new DateTimeOffset(2025, 05, 26, 7, 43, 41, TimeSpan.Zero);

        [Fact]
        public void Read_ShouldReturnExpectedValue()
        {
            const string json = "1748245421";
            var jsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));
            jsonReader.Read();
            var value = converter.Read(ref jsonReader, typeof(DateTimeOffset), new JsonSerializerOptions());
            value.ShouldBe(DateTimeOffset);
        }

        [Fact]
        public void Write_ShouldReturnExpectedValue()
        {
            const string expected = "1748245421";
            using var stream = new MemoryStream();
            var jsonWriter = new Utf8JsonWriter(stream);
            converter.Write(jsonWriter, DateTimeOffset, new JsonSerializerOptions());
            jsonWriter.Flush();
            string result = Encoding.UTF8.GetString(stream.ToArray());
            result.ShouldBe(expected);
        }
    }
}
