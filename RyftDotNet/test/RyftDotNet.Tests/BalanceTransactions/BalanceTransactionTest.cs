using System;
using System.IO;
using RyftDotNet.BalanceTransactions;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.BalanceTransactions
{
    public sealed class BalanceTransactionTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue()
        {
            string json = File.ReadAllText("assets/balance-transactions/response-full.json");
            JsonUtility.Deserialize<BalanceTransaction>(json).ShouldBe(new BalanceTransaction(
               "bltxn_01FCTS1XMKH9FF43CAFA4CXT3P",
               BalanceTransactionType.TransactionCapture,
               575,
               "GBP",
               BalanceTransactionStatus.Available,
               new BalanceTransactionOrigin(
                   "txn_01FCTS1XMKH9FF43CAFA4CXT3P_01FCTS1XMKH9FF43CAFA4CXT3P",
                   575,
                   "ac_b83f2653-06d7-44a9-a548-5825e8186004"
                   ),
               DateTimeOffset.FromUnixTimeSeconds(1631696801),
               DateTimeOffset.FromUnixTimeSeconds(1631696701),
               DateTimeOffset.FromUnixTimeSeconds(1631696800),
               "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
               5,
               572
            ));
        }
    }
}
