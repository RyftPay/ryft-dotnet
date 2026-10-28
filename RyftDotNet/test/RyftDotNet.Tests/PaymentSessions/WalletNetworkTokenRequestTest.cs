using RyftDotNet.PaymentSessions;
using RyftDotNet.PaymentSessions.Request;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentSessions
{
    public sealed class WalletNetworkTokenRequestTest
    {
        [Fact]
        public void ToJson_ShouldOmitName_WhenNotProvided()
            => JsonUtility.Serialize(new WalletNetworkTokenRequest("4242424242424242", "10", "2040", WalletType.GooglePay))
                .ShouldBe(
                    "{\"number\":\"4242424242424242\",\"expiryMonth\":\"10\"," +
                    "\"expiryYear\":\"2040\",\"walletType\":\"GooglePay\"}");

        [Fact]
        public void ToJson_ShouldIncludeAllFields_WhenAllProvided()
            => JsonUtility.Serialize(new WalletNetworkTokenRequest("4242424242424242", "10", "2040", WalletType.ApplePay)
            {
                Name = "Fred Jones"
            }).ShouldBe(
                "{\"number\":\"4242424242424242\",\"expiryMonth\":\"10\",\"expiryYear\":\"2040\"," +
                "\"name\":\"Fred Jones\",\"walletType\":\"ApplePay\"}");

        [Fact]
        public void ToJson_ShouldIncludeWalletNetworkTokenAndAuthenticationParameters_OnAttemptPaymentRequest()
            => JsonUtility.Serialize(new AttemptPaymentRequest("ps_01FCTS1XMKH9FF43CAFA4CXT3P_secret_b83f2653-06d7-44a9-a548-5825e8186004")
            {
                WalletNetworkToken = new WalletNetworkTokenRequest("4242424242424242", "10", "2040", WalletType.ApplePay)
                {
                    Name = "Fred Jones"
                },
                AuthenticationParameters = new AuthenticationParametersRequest
                {
                    AuthenticationValue = "AAABBEg0VhI0VniQEjRWAAAAAAA="
                }
            }).ShouldBe(
                "{\"clientSecret\":\"ps_01FCTS1XMKH9FF43CAFA4CXT3P_secret_b83f2653-06d7-44a9-a548-5825e8186004\",\"paymentMethodType\":\"Card\"," +
                "\"walletNetworkToken\":{\"number\":\"4242424242424242\",\"expiryMonth\":\"10\",\"expiryYear\":\"2040\"," +
                "\"name\":\"Fred Jones\",\"walletType\":\"ApplePay\"}," +
                "\"authenticationParameters\":{\"authenticationValue\":\"AAABBEg0VhI0VniQEjRWAAAAAAA=\"}}");

        [Fact]
        public void ToJson_ShouldIncludeAuthenticationParameters_OnAttemptPaymentRequestWithCardDetails()
            => JsonUtility.Serialize(new AttemptPaymentRequest("ps_01FCTS1XMKH9FF43CAFA4CXT3P_secret_b83f2653-06d7-44a9-a548-5825e8186004")
            {
                CardDetails = TestData.CardDetailsRequest(),
                AuthenticationParameters = new AuthenticationParametersRequest("05")
                {
                    AuthenticationValue = "AAABBEg0VhI0VniQEjRWAAAAAAA=",
                    ProtocolVersion = "2.2.0",
                    DsTransactionId = "f25084f0-5b16-4c0a-ae5d-b24808a95e4b"
                }
            }).ShouldBe(
                "{\"clientSecret\":\"ps_01FCTS1XMKH9FF43CAFA4CXT3P_secret_b83f2653-06d7-44a9-a548-5825e8186004\",\"paymentMethodType\":\"Card\"," +
                "\"cardDetails\":{\"number\":\"5555555555554444\",\"expiryMonth\":\"10\",\"expiryYear\":\"2040\",\"cvc\":\"222\"}," +
                "\"authenticationParameters\":{\"eci\":\"05\",\"authenticationValue\":\"AAABBEg0VhI0VniQEjRWAAAAAAA=\"," +
                "\"protocolVersion\":\"2.2.0\",\"dsTransactionId\":\"f25084f0-5b16-4c0a-ae5d-b24808a95e4b\"}}");

        [Fact]
        public void ToJson_ShouldIncludeWalletNetworkToken_OnCreatePaymentSessionAttemptPaymentRequest()
            => JsonUtility.Serialize(new CreatePaymentSessionRequest(500, "GBP")
            {
                AttemptPayment = new CreatePaymentSessionAttemptPaymentRequest
                {
                    WalletNetworkToken = new WalletNetworkTokenRequest("4242424242424242", "10", "2040", WalletType.GooglePay)
                },
                AuthenticationParameters = new AuthenticationParametersRequest
                {
                    AuthenticationValue = "AAABBEg0VhI0VniQEjRWAAAAAAA="
                }
            }).ShouldBe(
                "{\"amount\":500,\"currency\":\"GBP\"," +
                "\"attemptPayment\":{\"walletNetworkToken\":{\"number\":\"4242424242424242\",\"expiryMonth\":\"10\"," +
                "\"expiryYear\":\"2040\",\"walletType\":\"GooglePay\"}}," +
                "\"authenticationParameters\":{\"authenticationValue\":\"AAABBEg0VhI0VniQEjRWAAAAAAA=\"}}");
    }
}
