using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Charge
    {
        public int ChargeId { get; set; }
        public int CardId {  get; set; }
        public int Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date {  get; set; }
        public Card Cards { get; set; } = null!;
        public int AvailableLimit { get; set; }
        public int Balance { get; set; }


        

    }
    }

