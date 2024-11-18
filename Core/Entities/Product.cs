using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        
        public int EntityId { get; set; }

        public Entidad Entity { get; set; } = null!;
        //public Product Entity { get; set; } = null!;

    }
}
