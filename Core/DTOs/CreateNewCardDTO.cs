using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class CreateNewCardDTO

    {
        public int CustomerId { get; set; }
        public string CardType { get; set; } = string.Empty;//obligatorio
        public int CreditLimit { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public decimal InterestRate { get; set; }
    }
}
