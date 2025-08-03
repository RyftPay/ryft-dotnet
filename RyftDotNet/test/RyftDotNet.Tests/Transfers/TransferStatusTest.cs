using RyftDotNet.Transfers;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Transfers
{
    public sealed class TransferStatusTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(TransferStatus actual, TransferStatus expected)
            => actual.ShouldBe(expected);

        public static TheoryData<TransferStatus, TransferStatus> ExpectedValues() =>
            new TheoryData<TransferStatus, TransferStatus>
            {
                { TransferStatus.Pending, new TransferStatus("Pending") },
                { TransferStatus.Declined, new TransferStatus("Declined") },
                { TransferStatus.Completed, new TransferStatus("Completed") }
            };
    }
}
