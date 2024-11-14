using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class AddChargeDTO
    {
        
       
        public int Amount { get; set; }

        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public decimal Balance { get; set; }

    }
}
