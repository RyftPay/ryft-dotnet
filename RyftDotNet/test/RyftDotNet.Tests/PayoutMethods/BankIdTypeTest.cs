using RyftDotNet.PayoutMethods;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PayoutMethods
{
    public sealed class BankIdTypeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(BankIdType actual, BankIdType expected)
            => actual.ShouldBe(expected);

        public static TheoryData<BankIdType, BankIdType> ExpectedValues() =>
            new TheoryData<BankIdType, BankIdType>
            {
                { BankIdType.RoutingNumber, new BankIdType("RoutingNumber") },
                { BankIdType.SortCode, new BankIdType("SortCode") }
            };
    }
}
