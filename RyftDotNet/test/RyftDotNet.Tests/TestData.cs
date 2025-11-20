using System;
using System.Collections.Generic;
using System.IO;
using RyftDotNet.AccountLinks;
using RyftDotNet.Accounts;
using RyftDotNet.ApplePay.Sessions;
using RyftDotNet.ApplePay.WebDomains;
using RyftDotNet.Common;
using RyftDotNet.Common.Request;
using RyftDotNet.Customers;
using RyftDotNet.Disputes;
using RyftDotNet.Events;
using RyftDotNet.Files;
using RyftDotNet.Files.Request;
using RyftDotNet.InPerson.Locations;
using RyftDotNet.InPerson.Locations.Request;
using RyftDotNet.InPerson.Orders;
using RyftDotNet.InPerson.Products;
using RyftDotNet.InPerson.Skus;
using RyftDotNet.InPerson.Terminals;
using RyftDotNet.InPerson.Terminals.Request;
using RyftDotNet.PaymentMethods;
using RyftDotNet.PaymentSessions;
using RyftDotNet.PaymentSessions.PaymentTransactions;
using RyftDotNet.PaymentSessions.Request;
using RyftDotNet.PayoutMethods;
using RyftDotNet.PayoutMethods.Request;
using RyftDotNet.Payouts;
using RyftDotNet.Payouts.Request;
using RyftDotNet.Persons;
using RyftDotNet.Persons.Request;
using RyftDotNet.PlatformFees;
using RyftDotNet.Subscriptions;
using RyftDotNet.Subscriptions.Request;
using RyftDotNet.Transfers;
using RyftDotNet.Transfers.Request;
using RyftDotNet.Webhooks;
using File = RyftDotNet.Files.File;

namespace RyftDotNet.Tests
{
    internal static class TestData
    {
        internal const string AccountId = "ac_b83f2653-06d7-44a9-a548-5825e8186004";

        internal const string ClientSecret =
            "ps_01FCTS1XMKH9FF43CAFA4CXT3P_secret_b83f2653-06d7-44a9-a548-5825e8186004";

        internal const string ThreeDsFingerprint =
            "ewogICJ0aHJlZURTU2VydmVyVHJhbnNJRCI6ICI4ZjAxNzdhNC0yY2VkLTQ4NjUtODViNy1iYWQ5YmZhMzk4ZDIiLAogICJ0aHJlZURTQ29tcEluZCI6IlkiCn0=";

        internal static AddressRequest AddressRequest() => new AddressRequest(
            "GB",
            "SP4 7DE"
        );

        private static Address Address() => new Address(
            "Nathan",
            "Drake",
            "Stonehenge",
            "Salisbury",
            "Salisbury",
            "GB",
            "SP4 7DE",
            "Salisbury Plain"
        );

        internal static Customer Customer() => new Customer(
            "cus_01JW5YE0Z28N23C3HHG34JHZ0G",
            "test@ryftpay.com",
            DateTimeOffset.FromUnixTimeSeconds(1716716232)
        );

        internal static PaymentMethod PaymentMethod() => new PaymentMethod(
            "pmt_01G0EYVFR02KBBVE2YWQ8AKMGJ",
            PaymentMethodType.Card,
            new PaymentMethodCard(
                CardScheme.Mastercard,
                "4444",
                "10",
                "2030"
            ),
            Address(),
            new PaymentMethodChecks("Y", "M"),
            "cus_01G0EYVFR02KBBVE2YWQ8AKMGJ",
            DateTimeOffset.FromUnixTimeSeconds(1470989538)
        );

        internal static ApplePayWebSession ApplePayWebSession() => new ApplePayWebSession("...");

        internal static ApplePayWebDomain ApplePayWebDomain() => new ApplePayWebDomain(
            "apwd_01FCTS1XMKH9FF43CAFA4CXT3P",
            "dash.ryftpay.com",
            DateTimeOffset.FromUnixTimeSeconds(1631696701)
        );

        internal static WebhookCreated WebhookCreated() => new WebhookCreated(
            "whs_0f6b1b5a-aef0-4011-978b-19fd4a4d46ea",
            "wh_31fba123-0fef-41d6-92ad-fd7089f49f8a",
            true,
            "https://ryftpay.com",
            new List<EventType> { EventType.PaymentSessionApproved, EventType.PaymentSessionCaptured },
            DateTimeOffset.FromUnixTimeSeconds(1470989538)
        );

        internal static Webhook Webhook() => new Webhook(
            "wh_31fba123-0fef-41d6-92ad-fd7089f49f8a",
            true,
            "https://ryftpay.com",
            new List<EventType> { EventType.PaymentSessionApproved, EventType.PaymentSessionCaptured },
            DateTimeOffset.FromUnixTimeSeconds(1470989538),
            DateTimeOffset.FromUnixTimeSeconds(1470989538)
        );

        internal static Event Event() => new Event(
            "ev_01FGNPAY1DB5TKPB35M1MNT6PN",
            EventType.CustomerCreated,
            new EventData(null),
            new List<EventEndpoint>(),
            null,
            DateTimeOffset.FromUnixTimeSeconds(1470989538)
        );

        internal static AccountLink AccountLink() => new AccountLink(
            DateTimeOffset.FromUnixTimeSeconds(1470989538),
            DateTimeOffset.FromUnixTimeSeconds(1470989738),
            "https://localhost/join"
        );

        internal static PlatformFee PlatformFee() => new PlatformFee(
            "pf_01FCTS1XMKH9FF43CAFA4CXT3P",
            "ps_01JJPPAZTNN38EMDJ72FASHE7R",
            40,
            450L,
            "GBP",
            "ac_b83f2653-06d7-44a9-a548-5825e8186004",
            DateTimeOffset.FromUnixTimeSeconds(1470989538)
        );

        internal static PaymentSession PaymentSession() => new PaymentSession(
            "ps_01JJPPAZTNN38EMDJ72FASHE7R",
            5000,
            "GBP",
            PaymentType.Standard,
            PaymentSessionStatus.PendingPayment,
            new StatementDescriptor("Ryft Ltd", "Manchester"),
            0,
            DateTimeOffset.FromUnixTimeSeconds(1470989538),
            DateTimeOffset.FromUnixTimeSeconds(1470989538)
        );

        internal static PaymentTransaction PaymentTransaction() => new PaymentTransaction(
            "txn_01FM9XMMV1MYDG6NGMHPDE065N_01FM9XNFXDYXAT0BJN5BBN794B",
            "pf_01FM9XMMV1MYDG6NGMHPDE065N",
            7500,
            "GBP",
            PaymentTransactionType.Capture,
            PaymentTransactionStatus.Succeeded,
            DateTimeOffset.FromUnixTimeSeconds(1470989538),
            DateTimeOffset.FromUnixTimeSeconds(1470989538)
        );

        internal static PlatformFeeRefund PlatformFeeRefund() => new PlatformFeeRefund(
            "fr_01FM9XMMV1MYDG6NGMHPDE065N_01FM9XNFXDYXAT0BJN5BBN794B",
            "pf_01FM9XMMV1MYDG6NGMHPDE065N",
            5,
            "GBP",
            "Requested by customer",
            "Succeeded",
            DateTimeOffset.FromUnixTimeSeconds(1470989538),
            DateTimeOffset.FromUnixTimeSeconds(1470989538)
        );

        internal static CardDetailsRequest CardDetailsRequest() => new CardDetailsRequest(
            "5555555555554444",
            "10",
            "2040",
            "222"
        );

        private static AccountCapability AccountCapability() => new AccountCapability(
            AccountCapabilityStatus.Enabled,
            true,
            DateTimeOffset.FromUnixTimeSeconds(1470989538),
            DateTimeOffset.FromUnixTimeSeconds(1470989538)
        );

        internal static Account Account() => new Account(
            AccountId,
            AccountType.Sub,
            OnboardingFlow.NonHosted,
            new AccountVerification(VerificationStatus.NotRequired),
            new AccountSettings(
                payouts: new AccountPayoutSettings(
                    schedule: new AccountPayoutScheduleSettings(PayoutScheduleType.Manual)
                )
            ),
            new AccountCapabilities(
                visaPayments: AccountCapability(),
                mastercardPayments: AccountCapability(),
                amexPayments: AccountCapability()
            ),
            DateTimeOffset.FromUnixTimeSeconds(1470989538)
        );

        internal static Person Person() => new Person(
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
            DateTimeOffset.FromUnixTimeSeconds(1470989538)
        );

        internal static CreatePersonRequest CreatePersonRequest() => new CreatePersonRequest(
            "Fred",
            "Jones",
            "test@ryftpay.com",
            new DateOfEvent(1990, 1, 25),
            Gender.Male,
            new List<string> { "GB", "IE" },
            new AccountAddressRequest(
                "123 Test Street",
                "Manchester",
                "GB",
                "ABC 123"
            ),
            "+447900000000",
            new List<PersonBusinessRole> { PersonBusinessRole.UltimateBeneficialOwner, PersonBusinessRole.Director }
        );

        internal static PayoutMethod PayoutMethod() => new PayoutMethod(
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
        );

        internal static CreatePayoutMethodRequest CreatePayoutMethodRequest() => new CreatePayoutMethodRequest(
            PayoutMethodType.BankAccount,
            "GB",
            "GBP",
            new BankAccountRequest(
                AccountNumberType.UnitedKingdom,
                "00000111"
            )
        );

        internal static Payout Payout() => new Payout(
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
        );

        internal static CreatePayoutRequest CreatePayoutRequest() => new CreatePayoutRequest(
            550000,
            "GBP",
            "pm_01FCTS1XMKH9FF43CAFA4CXT3P"
        );

        internal static Transfer Transfer() => new Transfer(
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
        );

        internal static CreateTransferRequest CreateTransferRequest() => new CreateTransferRequest(50000, "GBP")
        {
            Destination = new TransferLocationRequest("ac_3fe8398f-8cdb-43a3-9be2-806c4f84c327")
        };

        internal static File File() => new File(
            "fl_01G0EYVFR02KBBVE2YWQ8AKMGJ",
            "receipt_2024.png",
            FileType.Png,
            FileCategory.Evidence,
            DateTimeOffset.FromUnixTimeSeconds(1470989538),
            DateTimeOffset.FromUnixTimeSeconds(1470989538),
            new Dictionary<string, string> { ["customerId"] = "1", ["registered"] = "123" },
            2048
        );

        internal static CreateFileRequest CreateFileRequest() => new CreateFileRequest(
            Stream.Null,
            "example.png",
            "image/png",
            FileCategory.Evidence
        );

        internal static Dispute Dispute() => new Dispute(
            "dsp_01G0EYVFR02KBBVE2YWQ8AKMGJ",
            500,
            "GBP",
            DisputeStatus.Open,
            DisputeCategory.Fraudulent,
            new DisputeReason(
                "13.6",
                "Merchandise/Services Not Received"
            ),
            DateTimeOffset.FromUnixTimeSeconds(1685059200),
            new List<DisputeRecommendedEvidence> { DisputeRecommendedEvidence.ProofOfDelivery },
            new DisputePaymentSession(
                "ps_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                PaymentType.Standard,
                new DisputePaymentSessionPaymentMethod(
                    new DisputePaymentSessionPaymentMethodCard(CardScheme.Mastercard, "4444")
                )
            ),
            DateTimeOffset.FromUnixTimeSeconds(1470989538),
            DateTimeOffset.FromUnixTimeSeconds(1470989539)
        );

        internal static Subscription Subscription() => new Subscription(
            "sub_01G0EYVFR02KBBVE2YWQ8AKMGJ",
            SubscriptionStatus.Active,
            new SubscriptionCustomer("cus_01G0EYVFR02KBBVE2YWQ8AKMGJ"),
            new SubscriptionPaymentSessions(
                new SubscriptionPaymentSession(
                    "ps_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                    "ps_01FCTS1XMKH9FF43CAFA4CXT3P_secret_b83f2653-06d7-44a9-a548-5825e8186004",
                    new PaymentSessionRequiredAction(
                        type: PaymentSessionRequiredActionType.Challenge,
                        challenge: new RequiredActionChallenge(
                            "https://acs.sandbox.ryftpay.com/browser/challenge",
                            "eyJ0aHJlZURTU2VydmVyVHJhbnNJRCI6IjA0NDk0MWE3LTMxM2UtNGMxMi1iOTY2LTE1MzNmODBhMzllOSIsImFjc1RyYW5zSUQiOiJhZTI1NzAwNi05ZWRhLTRkZWEtODZlNC0wYjYxYjgwNDcxZTAiLCJtZXNzYWdlVmVyc2lvbiI6IjIuMi4wIiwibWVzc2FnZVR5cGUiOiJDUmVxIiwiY2hhbGxlbmdlV2luZG93U2l6ZSI6IjAxIn0"
                        )
                    )
                ),
                new SubscriptionPaymentSession(
                    "ps_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                    "ps_01FCTS1XMKH9FF43CAFA4CXT3P_secret_b83f2653-06d7-44a9-a548-5825e8186004",
                    new PaymentSessionRequiredAction(
                        type: PaymentSessionRequiredActionType.Challenge,
                        challenge: new RequiredActionChallenge(
                            "https://acs.sandbox.ryftpay.com/browser/challenge",
                            "eyJ0aHJlZURTU2VydmVyVHJhbnNJRCI6IjA0NDk0MWE3LTMxM2UtNGMxMi1iOTY2LTE1MzNmODBhMzllOSIsImFjc1RyYW5zSUQiOiJhZTI1NzAwNi05ZWRhLTRkZWEtODZlNC0wYjYxYjgwNDcxZTAiLCJtZXNzYWdlVmVyc2lvbiI6IjIuMi4wIiwibWVzc2FnZVR5cGUiOiJDUmVxIiwiY2hhbGxlbmdlV2luZG93U2l6ZSI6IjAxIn0"
                        )
                    )
                )
            ),
            new SubscriptionPrice(
                5000,
                "GBP",
                new SubscriptionInterval(
                    IntervalUnit.Months,
                    1,
                    12
                )
            ),
            new SubscriptionBillingDetail(
                12,
                4,
                DateTimeOffset.FromUnixTimeSeconds(1480989538),
                DateTimeOffset.FromUnixTimeSeconds(1480989538),
                DateTimeOffset.FromUnixTimeSeconds(1480989538),
                DateTimeOffset.FromUnixTimeSeconds(1480989538),
                new SubscriptionBillingFailureDetail(2, "insufficient_funds")
            ),
            new SubscriptionBalance(5000),
            DateTimeOffset.FromUnixTimeSeconds(1470989538)
        );

        internal static CreateSubscriptionRequest CreateSubscriptionRequest() => new CreateSubscriptionRequest(
            new CreateSubscriptionCustomerRequest("cus_01G0EYVFR02KBBVE2YWQ8AKMGJ"),
            new CreateSubscriptionPriceRequest(
                7500,
                "GBP",
                new SubscriptionIntervalRequest(IntervalUnit.Months, 12)
            )
        );

        internal static InPersonProduct InPersonProduct() => new InPersonProduct(
            "ippd_01HXYZ123456789ABCDEFGH",
            "Terminal 232",
            InPersonProductStatus.Available,
            "Portable card reader for in-person payments",
            DateTimeOffset.FromUnixTimeSeconds(1470989538),
            DateTimeOffset.FromUnixTimeSeconds(1470989538),
            new Dictionary<string, string> { { "connectivity", "WiFi, Bluetooth" } }
        );

        internal static InPersonProductSku InPersonProductSku() => new InPersonProductSku(
            "ipsku_01HXYZ987654321ABCDEFGH",
            "Terminal 232 - UK Version",
            "GB",
            25000,
            "GBP",
            InPersonProductStatus.Available,
            "ippd_01HXYZ123456789ABCDEFGH",
            DateTimeOffset.FromUnixTimeSeconds(1470989538),
            DateTimeOffset.FromUnixTimeSeconds(1470989538)
        );

        internal static InPersonOrder InPersonOrder() => new InPersonOrder(
            "ipord_01HXYZ789012345ABCDEFGH",
            InPersonOrderStatus.ReadyToShip,
            25000,
            2000,
            "GBP",
            new List<InPersonOrderItem>
            {
                new InPersonOrderItem(
                    "ipsku_01HXYZ987654321ABCDEFGH",
                    "Terminal 232 - UK Version",
                    25000,
                    2000,
                    1
                )
            },
            new InPersonOrderCustomer(
                "john.smith@example.com",
                "John",
                "Smith"
            ),
            DateTimeOffset.FromUnixTimeSeconds(1470989538),
            DateTimeOffset.FromUnixTimeSeconds(1470989538),
            new InPersonOrderShipping(
                new InPersonOrderShippingAddress(
                    "John",
                    "Smith",
                    "123 High Street",
                    "London",
                    "SW1A 1AA",
                    "GB"
                )
                {
                    BusinessName = "Acme Corp",
                    LineTwo = "Floor 2",
                    Region = "Greater London"
                },
                new InPersonOrderShippingContact(
                    "john.smith@example.com",
                    "+447900123456"
                ),
                new InPersonOrderShippingMethod(
                    "ipsm_01HXYZ123456789ABCDEFGH",
                    "Next Business Day",
                    "Delivered next business day",
                    1500,
                    250
                )
            ),
            new InPersonOrderTracking(
                new List<InPersonOrderTrackingItem>
                {
                    new InPersonOrderTrackingItem(
                        "Royal Mail",
                        "RM123456789GB",
                        DateTimeOffset.FromUnixTimeSeconds(1470989538)
                    )
                }
            ),
            new Dictionary<string, string> { { "customerRef", "ORDER-2024-001" } }
        );

        internal static InPersonLocation InPersonLocation() => new InPersonLocation(
            "iploc_01HXYZ456789012ABCDEFGH",
            "Main Store London",
            new InPersonLocationAddress(
                "123 Oxford Street",
                "London",
                "GB",
                "W1D 1BS",
                "Unit 5",
                "Greater London"
            ),
            DateTimeOffset.FromUnixTimeSeconds(1470989538),
            DateTimeOffset.FromUnixTimeSeconds(1470989538),
            new GeoCoordinates(51.5074, -0.1278),
            new Dictionary<string, string> { { "storeCode", "LON-001" } }
        );

        internal static CreateInPersonLocationRequest CreateInPersonLocationRequest()
            => new CreateInPersonLocationRequest(
                "Main Store London",
                new InPersonLocationAddressRequest(
                    "123 Oxford Street",
                    "London",
                    "GB",
                    "W1D 1BS"
                )
                {
                    LineTwo = "Unit 5",
                    Region = "Greater London"
                }
            )
            {
                GeoCoordinates = new GeoCoordinatesRequest(51.5074, -0.1278),
                Metadata = new Dictionary<string, string> { { "storeCode", "LON-001" } }
            };

        internal static Terminal Terminal() => new Terminal(
            "iptrm_01HXYZ789012345ABCDEFGH",
            "Terminal 232",
            new TerminalLocation("iploc_01HXYZ456789012ABCDEFGH"),
            new TerminalDeviceDetail("BBPOS WisePOS E", "SN123456789"),
            DateTimeOffset.FromUnixTimeSeconds(1470989538),
            DateTimeOffset.FromUnixTimeSeconds(1470989538),
            new TerminalAction(
                TerminalActionType.Transaction,
                TerminalActionStatus.Succeeded,
                "ipta_01HXYZ234567890ABCDEFGH",
                DateTimeOffset.FromUnixTimeSeconds(1470989538),
                null,
                new TerminalActionTransaction(
                    TerminalTransactionType.Payment,
                    "ps_01HXYZ012345678ABCDEFGH",
                    new TerminalActionAmounts(1000),
                    "GBP",
                    new TerminalActionTransactionSettings(TerminalReceiptPrintingSource.PointOfSale),
                    new TerminalActionReceiptDetail(
                        new TerminalActionReceipt(TerminalReceiptPrintingStatus.Required),
                        new TerminalActionReceipt(TerminalReceiptPrintingStatus.NotRequired)
                    )
                ),
                DateTimeOffset.FromUnixTimeSeconds(1470989550)
            ),
            new Dictionary<string, string> { { "terminalCode", "TERM-001" } }
        );

        internal static CreateTerminalRequest CreateTerminalRequest()
            => new CreateTerminalRequest("SN123456789", "iploc_01HXYZ456789012ABCDEFGH")
            {
                Name = "Terminal 232",
                Metadata = new Dictionary<string, string> { { "terminalCode", "TERM-001" } }
            };

        internal static TerminalPaymentRequest TerminalPaymentRequest()
            => new TerminalPaymentRequest(
                new TerminalPaymentAmountsRequest(1000),
                "GBP"
            )
            {
                PaymentSession = new TerminalPaymentSessionRequest
                {
                    PlatformFee = 100,
                    Metadata = new Dictionary<string, string> { { "sessionRef", "SES-001" } }
                },
                Settings = new TerminalTransactionSettingsRequest
                {
                    ReceiptPrintingSource = TerminalReceiptPrintingSource.Terminal
                }
            };

        internal static TerminalRefundRequest TerminalRefundRequest()
            => new TerminalRefundRequest(
                new TerminalRefundPaymentSessionRequest("ps_01HXYZ012345678ABCDEFGH")
            )
            {
                Amount = 500,
                RefundPlatformFee = false,
                Settings = new TerminalTransactionSettingsRequest
                {
                    ReceiptPrintingSource = TerminalReceiptPrintingSource.Terminal
                }
            };
    }
}
