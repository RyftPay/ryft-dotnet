using RyftDotNet.Disputes;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Disputes
{
    public sealed class DisputeStatusTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(DisputeStatus actual, DisputeStatus expected)
            => actual.ShouldBe(expected);

        public static TheoryData<DisputeStatus, DisputeStatus> ExpectedValues() =>
            new TheoryData<DisputeStatus, DisputeStatus>
            {
                { DisputeStatus.Open, new DisputeStatus("Open") },
                { DisputeStatus.Cancelled, new DisputeStatus("Cancelled") },
                { DisputeStatus.Accepted, new DisputeStatus("Accepted") },
                { DisputeStatus.Challenged, new DisputeStatus("Challenged") },
                { DisputeStatus.Lost, new DisputeStatus("Lost") },
                { DisputeStatus.Won, new DisputeStatus("Won") },
                { DisputeStatus.Expired, new DisputeStatus("Expired") }
            };
    }
}
