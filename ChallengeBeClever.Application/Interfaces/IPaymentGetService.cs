using ChallengeBeClever.Application.UseCases.Payment.Get;

namespace ChallengeBeClever.Application.Interfaces
{
    public interface IPaymentGetService
    {
        public Task<PaymentGetResponse> ReportPayment(PaymentGetRequest request);
    }
}
