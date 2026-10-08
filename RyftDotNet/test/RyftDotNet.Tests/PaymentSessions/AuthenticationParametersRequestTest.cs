using RyftDotNet.PaymentSessions.Request;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentSessions
{
    public sealed class AuthenticationParametersRequestTest
    {
        [Fact]
        public void ToJson_ShouldOnlyIncludeEci_WhenNoOtherFieldsProvided()
            => JsonUtility.Serialize(new AuthenticationParametersRequest("07"))
                .ShouldBe("{\"eci\":\"07\"}");

        [Fact]
        public void ToJson_ShouldIncludeAllFields_WhenAllProvided()
            => JsonUtility.Serialize(new AuthenticationParametersRequest("05")
            {
                AuthenticationValue = "AAABBEg0VhI0VniQEjRWAAAAAAA=",
                ProtocolVersion = "2.2.0",
                ThreeDsServerTransactionId = "8a880dc0-d2d2-4067-bcb1-b08d1690b26e",
                AcsTransactionId = "13c701a3-5a88-4c45-89e9-ef65e50a8bf9",
                DsTransactionId = "f25084f0-5b16-4c0a-ae5d-b24808a95e4b"
            }).ShouldBe(
                "{\"eci\":\"05\"," +
                "\"authenticationValue\":\"AAABBEg0VhI0VniQEjRWAAAAAAA=\"," +
                "\"protocolVersion\":\"2.2.0\"," +
                "\"threeDsServerTransactionId\":\"8a880dc0-d2d2-4067-bcb1-b08d1690b26e\"," +
                "\"acsTransactionId\":\"13c701a3-5a88-4c45-89e9-ef65e50a8bf9\"," +
                "\"dsTransactionId\":\"f25084f0-5b16-4c0a-ae5d-b24808a95e4b\"}");

        [Fact]
        public void ToJson_ShouldIncludeAuthenticationParameters_OnCreatePaymentSessionRequest()
            => JsonUtility.Serialize(new CreatePaymentSessionRequest(500, "GBP")
            {
                AttemptPayment = new CreatePaymentSessionAttemptPaymentRequest(
                    new PaymentRequestPaymentMethod("pmt_01G0EYVFR02KBBVE2YWQ8AKMGJ")),
                AuthenticationParameters = new AuthenticationParametersRequest("05")
                {
                    AuthenticationValue = "AAABBEg0VhI0VniQEjRWAAAAAAA="
                }
            }).ShouldBe(
                "{\"amount\":500,\"currency\":\"GBP\"," +
                "\"attemptPayment\":{\"paymentMethod\":{\"id\":\"pmt_01G0EYVFR02KBBVE2YWQ8AKMGJ\"}}," +
                "\"authenticationParameters\":{\"eci\":\"05\",\"authenticationValue\":\"AAABBEg0VhI0VniQEjRWAAAAAAA=\"}}");
    }
}
