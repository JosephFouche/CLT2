using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ResponsePaymentDTO

    {
        public int PaymentId { get; set; }
        public int CardId { get; set; }
        public int Amount { get; set; }

        public int AvailableCredit { get; set; }
        public DateTime DateTime { get; set; }
    }
}
