using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class PaymentDTO
    {
        public int PaymentID { get; set; }
        public int CardId { get; set; }
        public int Amount { get; set; }
        public DateTime DateTime { get; set; }
    }
}
