using ChallengeBeClever.Domain.Entities.Auth;

namespace ChallengeBeClever.Application.UseCases.Payment.Post
{
    public class PaymentPostRequest
    {
        public int EmployeeId { get; set; } = default!;
        public DateTime Date { get; set; } = default!;
        public string RegisterType { get; set; } = default!;
        public string BusinessLocation { get; set; } = default!;
        public decimal Amount { get; set; } = default!;
        public decimal IVA { get; set; } = default!;
        public decimal? Interes { get; set; } = default!;
        public int? Mora { get; set; }
    }
}
