using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBeClever.Application.UseCases.Payment.Get
{
    public class PaymentGetResponse
    {
        public int TotalPayments { get; set; }
        public DateTime Max { get; set; }
        public DateTime Min { get; set; }
        public decimal AVGPayments { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Error { get; set; }
    }
}
