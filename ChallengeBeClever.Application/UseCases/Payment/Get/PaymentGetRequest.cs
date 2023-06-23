using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBeClever.Application.UseCases.Payment.Get
{
    public class PaymentGetRequest
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
