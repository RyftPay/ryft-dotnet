using RyftDotNet.BalanceTransactions;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.BalanceTransactions
{
    public sealed class BalanceTransactionStatusTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(BalanceTransactionStatus actual, BalanceTransactionStatus expected)
            => actual.ShouldBe(expected);

        public static TheoryData<BalanceTransactionStatus, BalanceTransactionStatus> ExpectedValues() =>
            new TheoryData<BalanceTransactionStatus, BalanceTransactionStatus>
            {
                { BalanceTransactionStatus.Pending, new BalanceTransactionStatus("Pending") },
                { BalanceTransactionStatus.Cleared, new BalanceTransactionStatus("Cleared") },
                { BalanceTransactionStatus.Available, new BalanceTransactionStatus("Available")}
            };
    }
}
