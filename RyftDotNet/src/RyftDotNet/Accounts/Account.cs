using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Utility;
using RyftDotNet.Utility.JsonConverters;

namespace RyftDotNet.Accounts
{
    public sealed class Account : IEquatable<Account>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("type")]
        public AccountType Type { get; }

        [property: JsonPropertyName("onboardingFlow")]
        public OnboardingFlow OnboardingFlow { get; }

        [property: JsonPropertyName("verification")]
        public AccountVerification Verification { get; }

        [property: JsonPropertyName("settings")]
        public AccountSettings Settings { get; }

        [property: JsonPropertyName("capabilities")]
        public AccountCapabilities Capabilities { get; }

        [property:
            JsonPropertyName("createdTimestamp"),
            JsonConverter(typeof(DateTimeOffsetEpochSecondsConverter))]
        public DateTimeOffset CreatedTimestamp { get; }

        [property: JsonPropertyName("email")]
        public string? Email { get; }

        [property: JsonPropertyName("entityType")]
        public EntityType? EntityType { get; }

        [property: JsonPropertyName("business")]
        public AccountBusiness? Business { get; }

        [property: JsonPropertyName("individual")]
        public AccountIndividual? Individual { get; }

        [property: JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; }

        [property: JsonPropertyName("termsOfService")]
        public AccountTermsOfService? TermsOfService { get; }

        public Account(
            string id,
            AccountType type,
            OnboardingFlow onboardingFlow,
            AccountVerification verification,
            AccountSettings settings,
            AccountCapabilities capabilities,
            DateTimeOffset createdTimestamp,
            string? email = null,
            EntityType? entityType = null,
            AccountBusiness? business = null,
            AccountIndividual? individual = null,
            IDictionary<string, string>? metadata = null,
            AccountTermsOfService? termsOfService = null)
        {
            Id = id;
            Type = type;
            OnboardingFlow = onboardingFlow;
            Verification = verification;
            Settings = settings;
            Capabilities = capabilities;
            CreatedTimestamp = createdTimestamp;
            Email = email;
            EntityType = entityType;
            Business = business;
            Individual = individual;
            Metadata = metadata;
            TermsOfService = termsOfService;
        }

        public bool Equals(Account? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && Type == other.Type
                   && OnboardingFlow == other.OnboardingFlow
                   && Verification.Equals(other.Verification)
                   && Settings.Equals(other.Settings)
                   && Capabilities.Equals(other.Capabilities)
                   && CreatedTimestamp.Equals(other.CreatedTimestamp)
                   && Email == other.Email
                   && EntityType == other.EntityType
                   && Equals(Business, other.Business)
                   && Equals(Individual, other.Individual)
                   && Utilities.DictionaryEquals(Metadata, other.Metadata)
                   && Equals(TermsOfService, other.TermsOfService));

        public override bool Equals(object? obj)
            => obj is Account other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Type);
            hashCode.Add(OnboardingFlow);
            hashCode.Add(Verification);
            hashCode.Add(Settings);
            hashCode.Add(Capabilities);
            hashCode.Add(CreatedTimestamp);
            hashCode.Add(Email);
            hashCode.Add(EntityType);
            hashCode.Add(Business);
            hashCode.Add(Individual);
            hashCode.Add(Metadata);
            hashCode.Add(TermsOfService);
            return hashCode.ToHashCode();
        }
    }
}
