﻿

namespace Core.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;//obligatorio

        public decimal Balance { get; set; }

        public DateTime OpeningDate { get; set; }

        //relations 
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
    }
}
