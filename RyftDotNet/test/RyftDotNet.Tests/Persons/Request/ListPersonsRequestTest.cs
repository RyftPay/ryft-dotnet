using System.Collections.Generic;
using RyftDotNet.Persons.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Persons.Request
{
    public sealed class ListPersonsRequestTest
    {
        [Theory, MemberData(nameof(ExpectedQueryStrings))]
        public void ToQueryString_ShouldReturnExpectedValue(ListPersonsRequest request, string expected)
            => request.ToQueryString().ShouldBe(expected);

        public static IEnumerable<object[]> ExpectedQueryStrings()
        {
            yield return
                new object[] { new ListPersonsRequest(), string.Empty };
            yield return
                new object[] { new ListPersonsRequest { Limit = 5 }, "?limit=5" };
            yield return
                new object[] { new ListPersonsRequest { Ascending = true }, "?ascending=true" };
            yield return
                new object[] { new ListPersonsRequest { Limit = 2, Ascending = false }, "?ascending=false&limit=2" };
            yield return
                new object[]
                {
                    new ListPersonsRequest
                    {
                        Limit = 2, Ascending = false, StartsAfter = "per_01G0EYVFR02KBBVE2YWQ8AKMGJ"
                    },
                    "?ascending=false&limit=2&startsAfter=per_01G0EYVFR02KBBVE2YWQ8AKMGJ"
                };
        }
    }
}
