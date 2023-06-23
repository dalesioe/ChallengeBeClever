using ChallengeBeClever.Application.UseCases.Payment.Post;

namespace ChallengeBeClever.Application.Interfaces
{
    public interface IPaymentPostService
    {
        public Task<bool> AddPayment(PaymentPostRequest data);
    }
}
