using System;
using System.Collections.Generic;
using System.Net;
using RyftDotNet.Customers.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Customers.Request
{
    public sealed class ListCustomersRequestTest
    {
        [Theory, MemberData(nameof(ExpectedQueryStrings))]
        public void ToQueryString_ShouldReturnExpectedValue(ListCustomersRequest request, string expected)
            => request.ToQueryString().ShouldBe(expected);

        public static IEnumerable<object[]> ExpectedQueryStrings()
        {
            yield return
                new object[] { new ListCustomersRequest(), string.Empty };
            yield return
                new object[]
                {
                    new ListCustomersRequest { Email = "test@ryftpay.com" },
                    $"?email={WebUtility.UrlEncode("test@ryftpay.com")}"
                };
            yield return
                new object[] { new ListCustomersRequest { Limit = 5 }, "?limit=5" };
            yield return
                new object[] { new ListCustomersRequest { Ascending = true }, "?ascending=true" };
            yield return
                new object[] { new ListCustomersRequest { Limit = 2, Ascending = false }, "?ascending=false&limit=2" };
            yield return
                new object[]
                {
                    new ListCustomersRequest
                    {
                        Limit = 2, Ascending = false, StartsAfter = "cus_01G0EYVFR02KBBVE2YWQ8AKMGJ"
                    },
                    "?ascending=false&limit=2&startsAfter=cus_01G0EYVFR02KBBVE2YWQ8AKMGJ"
                };
            yield return
                new object[]
                {
                    new ListCustomersRequest
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
