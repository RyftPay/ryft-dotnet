using System;
using System.IO;
using RyftDotNet.Common;
using RyftDotNet.PayoutMethods;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PayoutMethods
{
    public sealed class PayoutMethodTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenGivenFullResponse()
        {
            string json = File.ReadAllText("assets/payout-methods/response-full.json");
            JsonUtility.Deserialize<PayoutMethod>(json).ShouldBe(new PayoutMethod(
                "pm_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                PayoutMethodType.BankAccount,
                PayoutMethodStatus.Invalid,
                "GBP",
                "GB",
                DateTimeOffset.FromUnixTimeSeconds(1470989538),
                DateTimeOffset.FromUnixTimeSeconds(1470989538),
                "Primary GBP Account",
                "Account is closed",
                new PayoutMethodBankAccount(
                    AccountNumberType.UnitedKingdom,
                    "0001",
                    BankIdType.SortCode,
                    "0123",
                    "Ryft Bank Ltd",
                    new AccountAddress(
                        "GB",
                        "SP4 7DE",
                        "123 Test Street",
                        city: "Manchester"
                    )
                )
            ));
        }
    }
}
