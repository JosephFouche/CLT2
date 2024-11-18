using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Request
{
    public class CreateChargeRequest
    {
        public int Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public int CardId { get; set; }
        //public decimal Balance { get; set; }
    }
}
