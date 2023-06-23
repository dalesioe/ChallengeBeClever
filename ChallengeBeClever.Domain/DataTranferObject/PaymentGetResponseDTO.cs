using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBeClever.Domain.DataTranferObject
{
    public class PaymentGetResponseDTO
    {
        public int TotalPayments { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public decimal AVGPayments { get; set; }
    }
}
