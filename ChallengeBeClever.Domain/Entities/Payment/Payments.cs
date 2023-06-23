using ChallengeBeClever.Domain.Entities.Auth;

namespace ChallengeBeClever.Domain.Entities.Payment
{
    public class Payments
    {
        public int Id { get; set; } = default!;
        public int EmployeeId { get; set; } = default!;
        public Users User { get; set; } = default!;
        public DateTime Date { get; set; } = default!;
        public string RegisterType { get; set; } = default!;
        public string BusinessLocation { get; set; } = default!;
        public decimal Amount { get; set; } = default!;
        public decimal IVA { get; set; } = default!;
        public decimal? Interes { get; set; } = default!;
        public int? Mora { get; set; }
    }
}
