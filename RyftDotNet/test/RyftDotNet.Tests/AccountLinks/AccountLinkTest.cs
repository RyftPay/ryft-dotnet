using System;
using System.IO;
using RyftDotNet.AccountLinks;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.AccountLinks
{
    public sealed class AccountLinkTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenMinimumRequiredFieldsReturned()
        {
            string json = File.ReadAllText("assets/account-links/response.json");
            JsonUtility.Deserialize<AccountLink>(json).ShouldBe(new AccountLink(
                DateTimeOffset.FromUnixTimeSeconds(1631696701),
                DateTimeOffset.FromUnixTimeSeconds(1631703901),
                "https://sandbox-dash.ryftpay.com/join?l=al_NzEwYzUxOTA1NWQ0YmIwMGMwYzAxMzQyMGM3YzNkNmRkY2VhYzM3MQ"
            ));
        }
    }
}
