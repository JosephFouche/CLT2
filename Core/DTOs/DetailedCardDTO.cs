using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class DetailedCardDTO
    {
        public int CardId { get; set; }
        public string CardNumber { get; set; } = null!;
        public DateTime? ExpirationDate { get; set; }
        public int CreditLimit { get; set; }
        public int AvailableLimit { get; set; }

    }
}
