using System.Collections.Generic;
using RyftDotNet.Files;
using RyftDotNet.Files.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Files.Request
{
    public sealed class ListFilesRequestTest
    {
        [Theory, MemberData(nameof(ExpectedQueryStrings))]
        public void ToQueryString_ShouldReturnExpectedValue(ListFilesRequest request, string expected)
            => request.ToQueryString().ShouldBe(expected);

        public static IEnumerable<object[]> ExpectedQueryStrings()
        {
            yield return
                new object[] { new ListFilesRequest(), string.Empty };
            yield return
                new object[] { new ListFilesRequest { Limit = 5 }, "?limit=5" };
            yield return
                new object[] { new ListFilesRequest { Ascending = true }, "?ascending=true" };
            yield return
                new object[] { new ListFilesRequest { Limit = 2, Ascending = false }, "?ascending=false&limit=2" };
            yield return
                new object[]
                {
                    new ListFilesRequest
                    {
                        Limit = 2, Ascending = false, StartsAfter = "fl_01G0EYVFR02KBBVE2YWQ8AKMGJ"
                    },
                    "?ascending=false&limit=2&startsAfter=fl_01G0EYVFR02KBBVE2YWQ8AKMGJ"
                };
            yield return
                new object[]
                {
                    new ListFilesRequest { Category = FileCategory.Evidence, Limit = 2, Ascending = false },
                    "?category=Evidence&ascending=false&limit=2"
                };
        }
    }
}
