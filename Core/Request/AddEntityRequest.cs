using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Request
{
    public class AddEntityRequest
    {
        public string Name { get; set; } = string.Empty;
        public int CustomerID { get; set; }
    }
}
