
using ChallengeBeClever.Application.UseCases.Payment.Get;
using ChallengeBeClever.Domain.DataTranferObject;

namespace ChallengeBeClever.Application.Interfaces
{
    public interface IPaymentRepository
    {
        public Task<bool> AddPayment(PaymentPostRequestDTO data);
        public Task<PaymentGetResponse> ReportPayment(PaymentGetRequestDTO request);
    }
}
