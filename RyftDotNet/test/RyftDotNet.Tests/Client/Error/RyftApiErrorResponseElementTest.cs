using System.Collections.Generic;
using RyftDotNet.Client.Error;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Client.Error
{
    public sealed class RyftApiErrorResponseElementTest
    {
        [Theory, MemberData(nameof(EqualityTestData))]
        public void Equals_SameType_ReturnsExpectedResult(
            RyftApiErrorResponseElement left,
            RyftApiErrorResponseElement right,
            bool expected)
            => left.Equals(right).ShouldBe(expected);

        [Theory, MemberData(nameof(EqualityTestData))]
        public void Equals_Object_ReturnsExpectedResult(
            RyftApiErrorResponseElement left,
            RyftApiErrorResponseElement right,
            bool expected)
            => left.Equals((object)right).ShouldBe(expected);

        public static IEnumerable<object[]> EqualityTestData()
        {
            yield return new object[]
            {
                new RyftApiErrorResponseElement("400", "uh oh"),
                new RyftApiErrorResponseElement("500", "uh oh"),
                false
            };
            yield return new object[]
            {
                new RyftApiErrorResponseElement("400", "uh oh"),
                new RyftApiErrorResponseElement("400", "oops"),
                false
            };
            yield return new object[]
            {
                new RyftApiErrorResponseElement("400", "uh oh"),
                new RyftApiErrorResponseElement("400", "uh oh"),
                true
            };
        }
    }
}
