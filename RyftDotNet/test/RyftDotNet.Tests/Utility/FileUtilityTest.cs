using System;
using RyftDotNet.Client.Error;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Utility
{
    public sealed class FileUtilityTest
    {
        [Fact]
        public void GetContentType_ShouldThrow_WhenGivenUnsupportedFileExtension()
        {
            Func<string> action = () => FileUtility.GetContentType("image/tiff");
            var exception = action.ShouldThrow<RyftArgumentException>();
            exception.Message.ShouldContain("Unsupported file extension: image/tiff");
        }

        [Theory, MemberData(nameof(ExpectedContentTypes))]
        public void GetContentType_ShouldReturnExpectedValue(string fileExtension, string expectedContentType)
            => FileUtility.GetContentType(fileExtension).ShouldBe(expectedContentType);

        public static TheoryData<string, string> ExpectedContentTypes() =>
            new TheoryData<string, string>
            {
                { ".csv", "text/csv" },
                { ".png", "image/png" },
                { ".jpg", "image/jpeg" },
                { ".jpeg", "image/jpeg" },
                { ".pdf", "application/pdf" }
            };
    }
}
