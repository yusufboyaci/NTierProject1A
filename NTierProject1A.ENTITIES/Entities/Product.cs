using NTierProject1A.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierProject1A.ENTITIES.Entities
{
    public class Product : CoreEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; } = 0;
        public Guid CategoryId { get; set; }//FK
        public virtual Category? Category { get; set; }
    }
}
