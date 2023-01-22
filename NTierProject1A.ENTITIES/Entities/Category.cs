﻿using NTierProject1A.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierProject1A.ENTITIES.Entities
{
    public class Category : CoreEntity
    {
        public string? Name { get; set; }
        public virtual List<Product>? Products { get; set; } 
    }
}
