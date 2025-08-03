using System;
using System.Collections.Generic;
using System.IO;
using RyftDotNet.Common;
using RyftDotNet.Persons;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Persons
{
    public sealed class PersonTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenGivenFullResponse()
        {
            string json = File.ReadAllText("assets/persons/response-full.json");
            JsonUtility.Deserialize<Person>(json).ShouldBe(new Person(
                "per_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                "Fred",
                "Jones",
                new DateOfEvent(1990, 1, 20),
                new List<string> { "GB" },
                new AccountAddress(
                    "GB",
                    "SP4 7DE",
                    "123 Test Street",
                    city: "Manchester"
                ),
                new List<PersonBusinessRole> { PersonBusinessRole.BusinessContact, PersonBusinessRole.Director },
                new PersonVerification(
                    VerificationStatus.Required,
                    new List<RequiredField> { new RequiredField("phoneNumber") },
                    new List<VerificationRequiredDocument>
                    {
                        new VerificationRequiredDocument(
                            AccountDocumentCategory.ProofOfIdentity,
                            new List<AccountDocumentType> { AccountDocumentType.BankStatement },
                            1
                        )
                    },
                    new List<VerificationError>
                    {
                        new VerificationError(
                            "InvalidDocument",
                            "fl_01HAAHFQKEF4V7S6H3BTA3H85G",
                            "File corrupted or image not clear"
                        )
                    }
                ),
                DateTimeOffset.FromUnixTimeSeconds(1470989538),
                DateTimeOffset.FromUnixTimeSeconds(1470989538),
                "David",
                "fred.jones@example.com",
                "GB",
                Gender.Male,
                "+447900000000",
                new List<AccountDocument>
                {
                    new AccountDocument(
                        AccountDocumentType.BankStatement,
                        AccountDocumentCategory.ProofOfIdentity,
                        "fl_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                        AccountDocumentStatus.Pending,
                        DateTimeOffset.FromUnixTimeSeconds(1470989538),
                        DateTimeOffset.FromUnixTimeSeconds(1470989538),
                        "fl_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                        "Document has expired",
                        "GB"
                    )
                },
                new Dictionary<string, string> { ["accountId"] = "1" }
            ));
        }
    }
}
