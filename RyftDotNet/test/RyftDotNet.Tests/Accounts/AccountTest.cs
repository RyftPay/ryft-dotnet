using System;
using System.Collections.Generic;
using System.IO;
using RyftDotNet.Accounts;
using RyftDotNet.Common;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Accounts
{
    public sealed class AccountTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenGivenBusinessAccount()
        {
            string json = File.ReadAllText("assets/accounts/business-account.json");
            JsonUtility.Deserialize<Account>(json).ShouldBe(new Account(
                    "ac_b83f2653-06d7-44a9-a548-5825e8186004",
                    AccountType.Sub,
                    OnboardingFlow.NonHosted,
                    new AccountVerification(
                        VerificationStatus.Required,
                        new List<RequiredField>
                        {
                            new RequiredField("business.registrationDate")
                        },
                        new List<VerificationRequiredDocument>
                        {
                            new VerificationRequiredDocument(
                                AccountDocumentCategory.ProofOfIdentity,
                                new List<AccountDocumentType> { AccountDocumentType.BankStatement },
                                1
                            )
                        },
                        new List<VerificationError> {new VerificationError(
                            "InvalidDocument",
                            "fl_01FCTS1XMKH9FF43CAFA4CXT3P",
                            "File corrupted or unclear"
                        )},
                        new AccountVerificationPersons(
                            "Required",
                            new List<AccountVerificationRequiredPerson>
                            {
                                new AccountVerificationRequiredPerson("Director", 1)
                            }
                        )
                    ),
                    new AccountSettings(
                        new AccountPayoutSettings(new AccountPayoutScheduleSettings(PayoutScheduleType.Automatic))
                    ),
                    new AccountCapabilities(
                        new AccountCapability(
                            AccountCapabilityStatus.Disabled,
                            true,
                            DateTimeOffset.FromUnixTimeSeconds(1470989538),
                            DateTimeOffset.FromUnixTimeSeconds(1470989538),
                            new List<RequiredField> { new RequiredField("entityType") },
                            "Non compliant with scheme mandates"
                        ),
                        new AccountCapability(
                            AccountCapabilityStatus.Enabled,
                            true,
                            DateTimeOffset.FromUnixTimeSeconds(1470989538),
                            DateTimeOffset.FromUnixTimeSeconds(1470989538),
                            new List<RequiredField> { new RequiredField("entityType") },
                            "Non compliant with scheme mandates"
                        ),
                        new AccountCapability(
                            AccountCapabilityStatus.Enabled,
                            true,
                            DateTimeOffset.FromUnixTimeSeconds(1470989538),
                            DateTimeOffset.FromUnixTimeSeconds(1470989538)
                        )
                    ),
                    DateTimeOffset.FromUnixTimeSeconds(1470989538),
                    email: "test@ryftpay.com",
                    entityType: EntityType.Business,
                    business: new AccountBusiness(
                        "Ryft LTD",
                        BusinessType.Corporation,
                        new AccountAddress(
                            "GB",
                            "SP4 7DE",
                            "123 Test Street",
                            city: "Manchester"
                        ),
                        "contact@test.com",
                        registrationNumber: "12345678",
                        phoneNumber: "+447900000000",
                        tradingName: "Ryft Computer Parts Ltd",
                        tradingAddress: new AccountAddress(
                            "GB",
                            "SP4 7DE",
                            "123 Test Street",
                            city: "Manchester"
                        ),
                        tradingCountries: new List<string> { "GB", "IE" },
                        websiteUrl: "https://ryftpay.com",
                        documents: new List<AccountDocument>
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
                        registrationDate: new DateOfEvent(1982, 2, 12)
                    ),
                    metadata: new Dictionary<string, string> { ["accountId"] = "1" },
                    termsOfService: new AccountTermsOfService(
                        new AccountTermsOfServiceAcceptance(
                            "127.0.0.1",
                            DateTimeOffset.FromUnixTimeSeconds(1697557453),
                            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36"
                        )
                    )
                )
            );
        }

        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenGivenIndividualAccount()
        {
            string json = File.ReadAllText("assets/accounts/individual-account.json");
            JsonUtility.Deserialize<Account>(json).ShouldBe(new Account(
                    "ac_b83f2653-06d7-44a9-a548-5825e8186004",
                    AccountType.Sub,
                    OnboardingFlow.NonHosted,
                    new AccountVerification(
                        VerificationStatus.Required,
                        new List<RequiredField> { new RequiredField("individual.phoneNumber") },
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
                                "fl_01FCTS1XMKH9FF43CAFA4CXT3P",
                                "File corrupted or unclear"
                            )
                        }
                    ),
                    new AccountSettings(
                        new AccountPayoutSettings(new AccountPayoutScheduleSettings(PayoutScheduleType.Manual))
                    ),
                    new AccountCapabilities(
                        new AccountCapability(
                            AccountCapabilityStatus.Disabled,
                            true,
                            DateTimeOffset.FromUnixTimeSeconds(1470989538),
                            DateTimeOffset.FromUnixTimeSeconds(1470989538),
                            new List<RequiredField> { new RequiredField("entityType") },
                            "Non compliant with scheme mandates"
                        ),
                        new AccountCapability(
                            AccountCapabilityStatus.Enabled,
                            true,
                            DateTimeOffset.FromUnixTimeSeconds(1470989538),
                            DateTimeOffset.FromUnixTimeSeconds(1470989538),
                            new List<RequiredField> { new RequiredField("entityType") },
                            "Non compliant with scheme mandates"
                        ),
                        new AccountCapability(
                            AccountCapabilityStatus.Enabled,
                            true,
                            DateTimeOffset.FromUnixTimeSeconds(1470989538),
                            DateTimeOffset.FromUnixTimeSeconds(1470989538)
                        )
                    ),
                    DateTimeOffset.FromUnixTimeSeconds(1470989538),
                    email: "test@ryftpay.com",
                    entityType: EntityType.Individual,
                    individual: new AccountIndividual(
                        "Fred",
                        "Jones",
                        "fred.jones@example.com",
                        new DateOfEvent(1990, 01, 20),
                        Gender.Male,
                        new List<string> { "GB" },
                        new AccountAddress(
                            "GB",
                            "SP4 7DE",
                            "123 Test Street",
                            city: "Manchester"
                        ),
                        "David",
                        "GB",
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
                        }
                    ),
                    metadata: new Dictionary<string, string> { ["accountId"] = "1" },
                    termsOfService: new AccountTermsOfService(
                        new AccountTermsOfServiceAcceptance(
                            "127.0.0.1",
                            DateTimeOffset.FromUnixTimeSeconds(1697557453),
                            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36"
                        )
                    )
                )
            );
        }
    }
}
