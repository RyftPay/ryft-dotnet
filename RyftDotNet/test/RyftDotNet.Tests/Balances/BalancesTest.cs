using System;
using System.Collections.Generic;
using System.IO;
using RyftDotNet.Balances;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Balances
{
    public sealed class BalancesTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue()
        {
            string json = File.ReadAllText("assets/balances/response.json");
            JsonUtility.Deserialize<RyftDotNet.Balances.Balances>(json).ShouldBe(new RyftDotNet.Balances.Balances(
                new List<Balance>
                {
                    new Balance(
                        "GBP",
                        new BalanceAmount(500),
                        new BalanceAmount(500),
                        new BalanceAmount(500),
                        DateTimeOffset.FromUnixTimeSeconds(1470989538)
                    ),
                    new Balance(
                        "EUR",
                        new BalanceAmount(250),
                        new BalanceAmount(1500),
                        new BalanceAmount(2500),
                        DateTimeOffset.FromUnixTimeSeconds(1470989540)
                    )
                }
            ));
        }
    }
}
