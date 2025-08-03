using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Utility;

namespace RyftDotNet.Persons
{
    public sealed class PersonVerification : IEquatable<PersonVerification>
    {
        [property: JsonPropertyName("status")]
        public VerificationStatus Status { get; }

        [property: JsonPropertyName("requiredFields")]
        public IEnumerable<RequiredField>? RequiredFields { get; }

        [property: JsonPropertyName("requiredDocuments")]
        public IEnumerable<VerificationRequiredDocument>? RequiredDocuments { get; }

        [property: JsonPropertyName("errors")]
        public IEnumerable<VerificationError>? Errors { get; }

        public PersonVerification(
            VerificationStatus status,
            IEnumerable<RequiredField>? requiredFields = null,
            IEnumerable<VerificationRequiredDocument>? requiredDocuments = null,
            IEnumerable<VerificationError>? errors = null)
        {
            Status = status;
            RequiredFields = requiredFields;
            RequiredDocuments = requiredDocuments;
            Errors = errors;
        }

        public bool Equals(PersonVerification? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Status == other.Status
                   && Utilities.SequenceEqual(RequiredFields, other.RequiredFields)
                   && Utilities.SequenceEqual(RequiredDocuments, other.RequiredDocuments)
                   && Utilities.SequenceEqual(Errors, other.Errors));

        public override bool Equals(object? obj)
            => obj is PersonVerification other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                Status,
                RequiredFields,
                RequiredDocuments,
                Errors
            ).GetHashCode();
    }
}
