using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Card
    {

        public int CardId { get; set; }
        public string CardNumber { get; set; } = null!;

        public string CardType { get; set; } = string.Empty;//obligatorio
        public DateTime? ExpirationDate { get; set; }


        public string Status { get; set; } = null!;

        public int CreditLimit { get; set; }
        public int AvailableLimit { get; set; }
        public decimal InterestRate { get; set; }
       // public decimal Balance { get; set; }


        //relations 
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        // Relación con Charge (un Card puede tener muchos Charges)
        public List<Charge> Charges {get;set;}= [];

        //Relacion con Payments (Una tarjeta puede tener muchos pagos)
        public List<Payment> Payments {get;set;}= [];
    }
}
