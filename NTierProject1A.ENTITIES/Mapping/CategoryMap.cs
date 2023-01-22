using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierProject1A.CORE.Mapping;
using NTierProject1A.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierProject1A.ENTITIES.Mapping
{
    public class CategoryMap : CoreMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories");
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            builder.HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
            base.Configure(builder);
        }
    }
}
