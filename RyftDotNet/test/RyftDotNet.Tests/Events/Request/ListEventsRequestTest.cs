using System.Collections.Generic;
using RyftDotNet.Events.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Events.Request
{
    public sealed class ListEventsRequestTest
    {
        [Theory, MemberData(nameof(ExpectedQueryStrings))]
        public void ToQueryString_ShouldReturnExpectedValue(ListEventsRequest request, string expected)
            => request.ToQueryString().ShouldBe(expected);

        public static IEnumerable<object[]> ExpectedQueryStrings()
        {
            yield return
                new object[] { new ListEventsRequest(), string.Empty };
            yield return
                new object[] { new ListEventsRequest { Limit = 5 }, "?limit=5" };
            yield return
                new object[] { new ListEventsRequest { Ascending = true }, "?ascending=true" };
            yield return
                new object[] { new ListEventsRequest { Limit = 2, Ascending = false }, "?ascending=false&limit=2" };
        }
    }
}
