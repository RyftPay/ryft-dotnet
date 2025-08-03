using System;
using System.Collections.Generic;
using RyftDotNet.Subscriptions.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Subscriptions.Request
{
    public sealed class ListSubscriptionsRequestTest
    {
        [Theory, MemberData(nameof(ExpectedQueryStrings))]
        public void ToQueryString_ShouldReturnExpectedValue(ListSubscriptionsRequest request, string expected)
            => request.ToQueryString().ShouldBe(expected);

        public static IEnumerable<object[]> ExpectedQueryStrings()
        {
            yield return new object[] { new ListSubscriptionsRequest(), string.Empty };
            yield return new object[] { new ListSubscriptionsRequest { Limit = 5 }, "?limit=5" };
            yield return new object[] { new ListSubscriptionsRequest { Ascending = true }, "?ascending=true" };
            yield return new object[]
            {
                new ListSubscriptionsRequest { Limit = 2, Ascending = false }, "?ascending=false&limit=2"
            };
            yield return new object[]
            {
                new ListSubscriptionsRequest
                {
                    Limit = 2, Ascending = false, StartsAfter = "sub_01G0EYVFR02KBBVE2YWQ8AKMGJ"
                },
                "?ascending=false&limit=2&startsAfter=sub_01G0EYVFR02KBBVE2YWQ8AKMGJ"
            };
            yield return new object[]
            {
                new ListSubscriptionsRequest
                {
                    Limit = 2,
                    Ascending = false,
                    StartTimestamp = DateTimeOffset.FromUnixTimeSeconds(1631696701),
                    EndTimestamp = DateTimeOffset.FromUnixTimeSeconds(1631696705)
                },
                "?ascending=false&limit=2&startTimestamp=1631696701&endTimestamp=1631696705"
            };
        }
    }
}
