using RyftDotNet.Client;
using RyftDotNet.PaymentSessions;
using RyftDotNet.PaymentSessions.PaymentTransactions;
using RyftDotNet.PaymentSessions.Request;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class PaymentSessionsApiClientTest
{
    private readonly PaymentSessionsApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    [Fact]
    public async Task Client_ShouldBeAbleToCreateAndUpdatePayment()
    {
        var result = await apiClient.CreateAsync(
            new CreatePaymentSessionRequest(500, "GBP")
            {
                EntryMode = EntryMode.Moto,
                CaptureFlow = CaptureFlow.Manual
            }
        );
        result.ShouldSatisfyAllConditions(
            r => r.Amount.ShouldBe(500),
            r => r.Currency.ShouldBe("GBP")
        );
        var fetched = await apiClient.GetAsync(result.Id);
        fetched.Amount.ShouldBe(500);
        var updated = await apiClient.UpdateAsync(
            result.Id,
            new UpdatePaymentSessionRequest
            {
                Amount = 1000,
                CustomerEmail = $"{TestUtility.ResourcePrefix()}@ryftpay.com"
            }
        );
        updated.ShouldSatisfyAllConditions(u => u.Amount.ShouldBe(1000));
        var paymentAttempt = await apiClient.AttemptPaymentAsync(
            new AttemptPaymentRequest(fetched.ClientSecret!)
            {
                CardDetails = new CardDetailsRequest(
                    "5555555555554444",
                    "10",
                    "2040",
                    "222"
                )
            }
        );
        paymentAttempt.ShouldSatisfyAllConditions(
            p => p.Status.ShouldBe(PaymentSessionStatus.Approved),
            p => p.Amount.ShouldBe(1000)
        );
    }

    [Fact]
    public async Task Client_ShouldBeAbleToApproveThenVoidPayment()
    {
        var result = await apiClient.CreateAsync(
            new CreatePaymentSessionRequest(500, "GBP")
            {
                EntryMode = EntryMode.Moto,
                CaptureFlow = CaptureFlow.Manual,
                CustomerEmail = $"{TestUtility.ResourcePrefix()}@ryftpay.com"
            }
        );
        result.ShouldSatisfyAllConditions(
            r => r.Amount.ShouldBe(500),
            r => r.Currency.ShouldBe("GBP")
        );
        var paymentAttempt = await apiClient.AttemptPaymentAsync(
            new AttemptPaymentRequest(result.ClientSecret!)
            {
                CardDetails = new CardDetailsRequest(
                    "5555555555554444",
                    "10",
                    "2040",
                    "222"
                )
            }
        );
        paymentAttempt.Status.ShouldBe(PaymentSessionStatus.Approved);
        var voided = await apiClient.VoidAsync(result.Id);
        voided.Status.ShouldBe(PaymentTransactionStatus.Succeeded);
    }

    [Fact]
    public async Task Client_ShouldBeAbleToApproveThenCaptureAndRefundPayment()
    {
        var result = await apiClient.CreateAsync(
            new CreatePaymentSessionRequest(500, "GBP")
            {
                EntryMode = EntryMode.Moto,
                CaptureFlow = CaptureFlow.Manual,
                CustomerEmail = $"{TestUtility.ResourcePrefix()}@ryftpay.com"
            }
        );
        result.ShouldSatisfyAllConditions(
            r => r.Amount.ShouldBe(500),
            r => r.Currency.ShouldBe("GBP")
        );
        var paymentAttempt = await apiClient.AttemptPaymentAsync(
            new AttemptPaymentRequest(result.ClientSecret!)
            {
                CardDetails = new CardDetailsRequest(
                    "5555555555554444",
                    "10",
                    "2040",
                    "222"
                )
            }
        );
        paymentAttempt.Status.ShouldBe(PaymentSessionStatus.Approved);
        var captured = await apiClient.CaptureAsync(result.Id);
        captured.Status.ShouldBe(PaymentTransactionStatus.Succeeded);
        var refunded = await apiClient.RefundAsync(result.Id);
        refunded.Status.ShouldBe(PaymentTransactionStatus.Succeeded);
    }
}
