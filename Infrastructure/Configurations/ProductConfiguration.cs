using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public  class ProductConfiguration: IEntityTypeConfiguration<Product>
    {
        

        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(x => x.Id);
            entity
                .Property(x => x.Name)
                .IsRequired();
            entity
                .Property(x => x.Description)
                .IsRequired();
            entity
               .Property(x => x.Status)
               .IsRequired();


            entity
                .HasOne(x => x.Entity)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.EntityId);
            //entity.HasMany(x => x.Entity).WithMany(x => x.Products).HasForeignKey(x => x.Entity);
        }
    }
    }

