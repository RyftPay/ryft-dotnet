using System;
using System.Collections.Generic;
using RyftDotNet.Files;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;
using File = System.IO.File;

namespace RyftDotNet.Tests.Files
{
    public sealed class FileTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenGivenFullResponse()
        {
            string json = File.ReadAllText("assets/files/response-full.json");
            JsonUtility.Deserialize<RyftDotNet.Files.File>(json).ShouldBe(new RyftDotNet.Files.File(
                "fl_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                "receipt_2024.png",
                FileType.Png,
                FileCategory.Evidence,
                DateTimeOffset.FromUnixTimeSeconds(1470989538),
                DateTimeOffset.FromUnixTimeSeconds(1470989538),
                new Dictionary<string, string> { ["customerId"] = "1", ["registered"] = "123" },
                2048
            ));
        }
    }
}
