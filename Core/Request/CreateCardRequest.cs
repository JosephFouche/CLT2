using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Request
{
    public class CreateCardRequest
    {
        //public int Id { get; set; }
        public int CustomerId{ get; set; } 
        public string CardType { get; set; } = string.Empty;
        public int CreditLimit { get; set; }
        public DateTime ExpirationDatetime { get; set; }
        public decimal InterestRate { get; set; }

        public int CardNumber { get; set; }
        public string Status { get; set; } = null!;


    }
}
