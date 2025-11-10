using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using RyftDotNet.Accounts;
using RyftDotNet.BalanceTransactions;
using RyftDotNet.Common;
using RyftDotNet.Disputes;
using RyftDotNet.Files;
using RyftDotNet.InPerson.Orders;
using RyftDotNet.InPerson.Products;
using RyftDotNet.PaymentSessions;
using RyftDotNet.PaymentSessions.PaymentTransactions;
using RyftDotNet.PayoutMethods;
using RyftDotNet.Payouts;
using RyftDotNet.Persons;
using RyftDotNet.Subscriptions;
using RyftDotNet.Transfers;

namespace RyftDotNet.Utility.JsonConverters
{
    public sealed class ConstantValueJsonConverterFactory : JsonConverterFactory
    {
        private static readonly HashSet<Type> SupportedTypes = new HashSet<Type>
        {
            typeof(PersonBusinessRole),
            typeof(SubscriptionStatus),
            typeof(IntervalUnit),
            typeof(DisputeEvidenceTextIdentifier),
            typeof(DisputeEvidenceFileIdentifier),
            typeof(AccountDocumentType),
            typeof(Gender),
            typeof(PayoutMethodType),
            typeof(WalletType),
            typeof(BusinessType),
            typeof(BankIdType),
            typeof(CaptureType),
            typeof(OnboardingFlow),
            typeof(DeviceChannel),
            typeof(AccountNumberType),
            typeof(PaymentType),
            typeof(PayoutScheduleType),
            typeof(EntityType),
            typeof(PaymentMethodType),
            typeof(EntryMode),
            typeof(CaptureFlow),
            typeof(VerificationStatus),
            typeof(AccountCapabilityStatus),
            typeof(AccountDocumentCategory),
            typeof(AccountType),
            typeof(AccountDocumentStatus),
            typeof(PaymentSessionStatus),
            typeof(PaymentSessionRequiredActionType),
            typeof(AuthorizationType),
            typeof(PaymentTransactionStatus),
            typeof(PaymentTransactionType),
            typeof(CardScheme),
            typeof(BalanceTransactionType),
            typeof(BalanceTransactionStatus),
            typeof(DisputeStatus),
            typeof(DisputeCategory),
            typeof(DisputeRecommendedEvidence),
            typeof(EventType),
            typeof(FileType),
            typeof(FileCategory),
            typeof(PayoutMethodStatus),
            typeof(PayoutStatus),
            typeof(PayoutScheme),
            typeof(TransferStatus),
            typeof(AmountVariance),
            typeof(InPersonProductStatus),
            typeof(InPersonOrderStatus)
        };


        public override bool CanConvert(Type typeToConvert)
            => SupportedTypes.Contains(typeToConvert);

        public override JsonConverter CreateConverter(
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (typeToConvert == typeof(PersonBusinessRole))
            {
                return new ConstantValueJsonConverter<PersonBusinessRole>(
                    value => new PersonBusinessRole(value)
                );
            }
            if (typeToConvert == typeof(SubscriptionStatus))
            {
                return new ConstantValueJsonConverter<SubscriptionStatus>(
                    value => new SubscriptionStatus(value)
                );
            }
            if (typeToConvert == typeof(IntervalUnit))
            {
                return new ConstantValueJsonConverter<IntervalUnit>(
                    value => new IntervalUnit(value)
                );
            }
            if (typeToConvert == typeof(DisputeEvidenceTextIdentifier))
            {
                return new ConstantValueJsonConverter<DisputeEvidenceTextIdentifier>(
                    value => new DisputeEvidenceTextIdentifier(value)
                );
            }
            if (typeToConvert == typeof(DisputeEvidenceFileIdentifier))
            {
                return new ConstantValueJsonConverter<DisputeEvidenceFileIdentifier>(
                    value => new DisputeEvidenceFileIdentifier(value)
                );
            }
            if (typeToConvert == typeof(AccountDocumentType))
            {
                return new ConstantValueJsonConverter<AccountDocumentType>(
                    value => new AccountDocumentType(value)
                );
            }
            if (typeToConvert == typeof(Gender))
            {
                return new ConstantValueJsonConverter<Gender>(
                    value => new Gender(value)
                );
            }
            if (typeToConvert == typeof(PayoutMethodType))
            {
                return new ConstantValueJsonConverter<PayoutMethodType>(
                    value => new PayoutMethodType(value)
                );
            }
            if (typeToConvert == typeof(WalletType))
            {
                return new ConstantValueJsonConverter<WalletType>(
                    value => new WalletType(value)
                );
            }
            if (typeToConvert == typeof(BusinessType))
            {
                return new ConstantValueJsonConverter<BusinessType>(
                    value => new BusinessType(value)
                );
            }
            if (typeToConvert == typeof(BankIdType))
            {
                return new ConstantValueJsonConverter<BankIdType>(
                    value => new BankIdType(value)
                );
            }
            if (typeToConvert == typeof(CaptureType))
            {
                return new ConstantValueJsonConverter<CaptureType>(
                    value => new CaptureType(value)
                );
            }
            if (typeToConvert == typeof(OnboardingFlow))
            {
                return new ConstantValueJsonConverter<OnboardingFlow>(
                    value => new OnboardingFlow(value)
                );
            }
            if (typeToConvert == typeof(DeviceChannel))
            {
                return new ConstantValueJsonConverter<DeviceChannel>(
                    value => new DeviceChannel(value)
                );
            }
            if (typeToConvert == typeof(AccountNumberType))
            {
                return new ConstantValueJsonConverter<AccountNumberType>(
                    value => new AccountNumberType(value)
                );
            }
            if (typeToConvert == typeof(PaymentType))
            {
                return new ConstantValueJsonConverter<PaymentType>(
                    value => new PaymentType(value)
                );
            }
            if (typeToConvert == typeof(PayoutScheduleType))
            {
                return new ConstantValueJsonConverter<PayoutScheduleType>(
                    value => new PayoutScheduleType(value)
                );
            }
            if (typeToConvert == typeof(EntityType))
            {
                return new ConstantValueJsonConverter<EntityType>(
                    value => new EntityType(value)
                );
            }
            if (typeToConvert == typeof(PaymentMethodType))
            {
                return new ConstantValueJsonConverter<PaymentMethodType>(
                    value => new PaymentMethodType(value)
                );
            }
            if (typeToConvert == typeof(EntryMode))
            {
                return new ConstantValueJsonConverter<EntryMode>(
                    value => new EntryMode(value)
                );
            }
            if (typeToConvert == typeof(CaptureFlow))
            {
                return new ConstantValueJsonConverter<CaptureFlow>(
                    value => new CaptureFlow(value)
                );
            }
            if (typeToConvert == typeof(VerificationStatus))
            {
                return new ConstantValueJsonConverter<VerificationStatus>(
                    value => new VerificationStatus(value)
                );
            }
            if (typeToConvert == typeof(AccountCapabilityStatus))
            {
                return new ConstantValueJsonConverter<AccountCapabilityStatus>(
                    value => new AccountCapabilityStatus(value)
                );
            }
            if (typeToConvert == typeof(AccountDocumentCategory))
            {
                return new ConstantValueJsonConverter<AccountDocumentCategory>(
                    value => new AccountDocumentCategory(value)
                );
            }
            if (typeToConvert == typeof(AccountType))
            {
                return new ConstantValueJsonConverter<AccountType>(
                    value => new AccountType(value)
                );
            }
            if (typeToConvert == typeof(AccountDocumentStatus))
            {
                return new ConstantValueJsonConverter<AccountDocumentStatus>(
                    value => new AccountDocumentStatus(value)
                );
            }
            if (typeToConvert == typeof(PaymentSessionStatus))
            {
                return new ConstantValueJsonConverter<PaymentSessionStatus>(
                    value => new PaymentSessionStatus(value)
                );
            }
            if (typeToConvert == typeof(PaymentSessionRequiredActionType))
            {
                return new ConstantValueJsonConverter<PaymentSessionRequiredActionType>(
                    value => new PaymentSessionRequiredActionType(value)
                );
            }
            if (typeToConvert == typeof(AuthorizationType))
            {
                return new ConstantValueJsonConverter<AuthorizationType>(
                    value => new AuthorizationType(value)
                );
            }
            if (typeToConvert == typeof(PaymentTransactionStatus))
            {
                return new ConstantValueJsonConverter<PaymentTransactionStatus>(
                    value => new PaymentTransactionStatus(value)
                );
            }
            if (typeToConvert == typeof(PaymentTransactionType))
            {
                return new ConstantValueJsonConverter<PaymentTransactionType>(
                    value => new PaymentTransactionType(value)
                );
            }
            if (typeToConvert == typeof(CardScheme))
            {
                return new ConstantValueJsonConverter<CardScheme>(
                    value => new CardScheme(value)
                );
            }
            if (typeToConvert == typeof(BalanceTransactionType))
            {
                return new ConstantValueJsonConverter<BalanceTransactionType>(
                    value => new BalanceTransactionType(value)
                );
            }
            if (typeToConvert == typeof(BalanceTransactionStatus))
            {
                return new ConstantValueJsonConverter<BalanceTransactionStatus>(
                    value => new BalanceTransactionStatus(value)
                );
            }
            if (typeToConvert == typeof(DisputeStatus))
            {
                return new ConstantValueJsonConverter<DisputeStatus>(
                    value => new DisputeStatus(value)
                );
            }
            if (typeToConvert == typeof(DisputeCategory))
            {
                return new ConstantValueJsonConverter<DisputeCategory>(
                    value => new DisputeCategory(value)
                );
            }
            if (typeToConvert == typeof(DisputeRecommendedEvidence))
            {
                return new ConstantValueJsonConverter<DisputeRecommendedEvidence>(
                    value => new DisputeRecommendedEvidence(value)
                );
            }
            if (typeToConvert == typeof(EventType))
            {
                return new ConstantValueJsonConverter<EventType>(
                    value => new EventType(value)
                );
            }
            if (typeToConvert == typeof(FileType))
            {
                return new ConstantValueJsonConverter<FileType>(
                    value => new FileType(value)
                );
            }
            if (typeToConvert == typeof(FileCategory))
            {
                return new ConstantValueJsonConverter<FileCategory>(
                    value => new FileCategory(value)
                );
            }
            if (typeToConvert == typeof(PayoutMethodStatus))
            {
                return new ConstantValueJsonConverter<PayoutMethodStatus>(
                    value => new PayoutMethodStatus(value)
                );
            }
            if (typeToConvert == typeof(PayoutStatus))
            {
                return new ConstantValueJsonConverter<PayoutStatus>(
                    value => new PayoutStatus(value)
                );
            }
            if (typeToConvert == typeof(PayoutScheme))
            {
                return new ConstantValueJsonConverter<PayoutScheme>(
                    value => new PayoutScheme(value)
                );
            }
            if (typeToConvert == typeof(TransferStatus))
            {
                return new ConstantValueJsonConverter<TransferStatus>(
                    value => new TransferStatus(value)
                );
            }
            if (typeToConvert == typeof(AmountVariance))
            {
                return new ConstantValueJsonConverter<AmountVariance>(
                    value => new AmountVariance(value)
                );
            }
            if (typeToConvert == typeof(InPersonProductStatus))
            {
                return new ConstantValueJsonConverter<InPersonProductStatus>(
                    value => new InPersonProductStatus(value)
                );
            }
            if (typeToConvert == typeof(InPersonOrderStatus))
            {
                return new ConstantValueJsonConverter<InPersonOrderStatus>(
                    value => new InPersonOrderStatus(value)
                );
            }
            throw new NotSupportedException(
                $"CreateConverter invoked called on type '{typeToConvert}', however this converter factory doesn't support it."
            );
        }
    }
}
