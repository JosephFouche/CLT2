﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class GetDetailedEntityProductDTO
    {
        public string Name { get; set; } = string.Empty;
        public int CustumerId { get; set; }
    }
}
