using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class CardResponseDTO
    {
        public int CardId { get; set; }
        public int CustomerId { get; set; }
        public string CardNumber { get; set; } = null!;
        public DateTime? ExpirationDate { get; set; }
        public string Status { get; set; } = null!;
    }
}
