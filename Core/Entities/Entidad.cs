using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Entidad

    {
        public int  Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int CustomerId { get; set; } //??
        public Customer Customer { get; set; } = null!; //??

        public List<Product> Products { get; set; } = []; //??

    }
}
