using RyftDotNet.Payouts;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Payouts
{
    public sealed class PayoutStatusTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(PayoutStatus actual, PayoutStatus expected)
            => actual.ShouldBe(expected);

        public static TheoryData<PayoutStatus, PayoutStatus> ExpectedValues() =>
            new TheoryData<PayoutStatus, PayoutStatus>
            {
                { PayoutStatus.Completed, new PayoutStatus("Completed") },
                { PayoutStatus.Failed, new PayoutStatus("Failed") },
                { PayoutStatus.Pending, new PayoutStatus("Pending") },
                { PayoutStatus.PendingAccountVerification, new PayoutStatus("PendingAccountVerification") },
                { PayoutStatus.PendingTransactionVerification, new PayoutStatus("PendingTransactionVerification") },
                { PayoutStatus.PendingPayoutMethodAction, new PayoutStatus("PendingPayoutMethodAction") },
                { PayoutStatus.PendingAccountAction, new PayoutStatus("PendingAccountAction") },
                { PayoutStatus.InProgress, new PayoutStatus("InProgress") },
                { PayoutStatus.Cancelled, new PayoutStatus("Cancelled") },
                { PayoutStatus.Expired, new PayoutStatus("Expired") },
                { PayoutStatus.Recalled, new PayoutStatus("Recalled") },
                { PayoutStatus.Returned, new PayoutStatus("Returned") },
            };
    }
}
