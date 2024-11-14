using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public  class Payment
    {
        public int PaymentId { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public int CardId { get; set; }
        public int Amount {  get; set; }
        public string Description { get; set; } = string.Empty;
        
        public DateTime Date { get; set; }

        public Card Cards { get; set; } = null!;


    }
}
