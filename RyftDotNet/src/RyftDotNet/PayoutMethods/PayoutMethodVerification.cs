using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.PayoutMethods
{
    public sealed class PayoutMethodVerification : IEquatable<PayoutMethodVerification>
    {
        [property: JsonPropertyName("status")]
        public PayoutMethodVerificationStatus Status { get; }

        [property: JsonPropertyName("nameOnAccount")]
        public string? NameOnAccount { get; }

        [property: JsonPropertyName("rejectionReason")]
        public PayoutMethodVerificationRejectionReason? RejectionReason { get; }

        public PayoutMethodVerification(
            PayoutMethodVerificationStatus status,
            string? nameOnAccount = null,
            PayoutMethodVerificationRejectionReason? rejectionReason = null)
        {
            Status = status;
            NameOnAccount = nameOnAccount;
            RejectionReason = rejectionReason;
        }

        public bool Equals(PayoutMethodVerification? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Status == other.Status
                   && NameOnAccount == other.NameOnAccount
                   && RejectionReason == other.RejectionReason);

        public override bool Equals(object? obj)
            => obj is PayoutMethodVerification other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Status, NameOnAccount, RejectionReason);
    }
}
