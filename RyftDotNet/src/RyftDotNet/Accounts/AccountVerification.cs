using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Utility;

namespace RyftDotNet.Accounts
{
    public sealed class AccountVerification : IEquatable<AccountVerification>
    {
        [property: JsonPropertyName("status")]
        public VerificationStatus Status { get; }

        [property: JsonPropertyName("requiredFields")]
        public IEnumerable<RequiredField>? RequiredFields { get; }

        [property: JsonPropertyName("requiredDocuments")]
        public IEnumerable<VerificationRequiredDocument>? RequiredDocuments { get; }

        [property: JsonPropertyName("errors")]
        public IEnumerable<VerificationError>? Errors { get; }

        [property: JsonPropertyName("persons")]
        public AccountVerificationPersons? Persons { get; }

        public AccountVerification(
            VerificationStatus status,
            IEnumerable<RequiredField>? requiredFields = null,
            IEnumerable<VerificationRequiredDocument>? requiredDocuments = null,
            IEnumerable<VerificationError>? errors = null,
            AccountVerificationPersons? persons = null)
        {
            Status = status;
            RequiredFields = requiredFields;
            RequiredDocuments = requiredDocuments;
            Errors = errors;
            Persons = persons;
        }

        public bool Equals(AccountVerification? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Status == other.Status
                   && Utilities.SequenceEqual(RequiredFields, other.RequiredFields)
                   && Utilities.SequenceEqual(RequiredDocuments, other.RequiredDocuments)
                   && Utilities.SequenceEqual(Errors, other.Errors)
                   && Equals(Persons, other.Persons));

        public override bool Equals(object? obj)
            => obj is AccountVerification other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                Status,
                RequiredFields,
                RequiredDocuments,
                Errors,
                Persons
            ).GetHashCode();
    }
}
