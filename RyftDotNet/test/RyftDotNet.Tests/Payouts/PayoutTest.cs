using System;
using System.IO;
using RyftDotNet.Common;
using RyftDotNet.PayoutMethods;
using RyftDotNet.Payouts;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Payouts
{
    public sealed class PayoutTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenMinimumRequiredFieldsReturned()
        {
            string json = File.ReadAllText("assets/payouts/response-full.json");
            JsonUtility.Deserialize<Payout>(json).ShouldBe(new Payout(
                    "po_01FJ1H0023R1AHM77YQ75RMKE7",
                    9750,
                    "GBP",
                    PayoutStatus.InProgress,
                    PayoutScheduleType.Automatic,
                    DateTimeOffset.FromUnixTimeSeconds(1631696701),
                    DateTimeOffset.FromUnixTimeSeconds(1631696702),
                    DateTimeOffset.FromUnixTimeSeconds(1631696703),
                    new PayoutPayoutMethod(
                        "pm_01FCTS1XMKH9FF43CAFA4CXT3P",
                        new PayoutBankAccount(
                            AccountNumberType.UnitedKingdom,
                            "0001",
                            BankIdType.SortCode,
                            "123456",
                            "Ryft Bank Ltd"
                        )
                    ),
                    "InvalidPayoutMethod",
                    PayoutScheme.Fps
                )
            );
        }
    }
}
