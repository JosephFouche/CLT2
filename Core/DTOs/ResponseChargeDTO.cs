using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ResponseChargeDTO
    {
        public int ChargeId { get; set; }
        public int CardId { get; set; }
        public int Amount { get; set; }
        public int AvailableLimit { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
