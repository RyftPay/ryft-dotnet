using System;
using System.Collections.Generic;
using System.IO;
using RyftDotNet.Transfers;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Transfers
{
    public sealed class TransferTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenMinimumRequiredFieldsReturned()
        {
            string json = File.ReadAllText("assets/transfers/response-full.json");
            JsonUtility.Deserialize<Transfer>(json).ShouldBe(new Transfer(
                    "tfr_01FCTS1XMKH9FF43CAFA4CXT3P",
                    TransferStatus.Completed,
                    75000,
                    "GBP",
                    DateTimeOffset.FromUnixTimeSeconds(1470989538),
                    DateTimeOffset.FromUnixTimeSeconds(1470989539),
                    "Covering dispute fees from 25th October",
                    new TransferLocation("ac_3fe8398f-8cdb-43a3-9be2-806c4f84c327"),
                    new TransferLocation("ac_3fe8398f-8cdb-43a3-9be2-806c4f84c326"),
                    new List<TransferError>
                    {
                        new TransferError(
                            "InsufficientSourceBalance",
                            "The account did not have sufficient funds available to cover this transfer"
                        )
                    },
                    new Dictionary<string, string> { ["orderId"] = "1", ["customerId"] = "123" }
                )
            );
        }
    }
}
