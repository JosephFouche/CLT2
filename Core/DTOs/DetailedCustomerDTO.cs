using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    internal class DetailedCustomerDTO
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string OpeningDate { get; set; } = string.Empty;
        
        //public CustomerDTO Customer { get; set; } = null!;
    }
}
