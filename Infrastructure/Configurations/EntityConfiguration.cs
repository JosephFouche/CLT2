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
        public class EntityConfiguration : IEntityTypeConfiguration<Entidad>
        {
            public void Configure(EntityTypeBuilder<Entidad> entity)
            {
                entity.HasKey(x => x.Id);
                entity
                    .Property(x => x.Name)
                    .IsRequired();
            


                entity
                    .HasOne(x => x.Customer)
                    .WithMany(x => x.Entities)
                    .HasForeignKey(x => x.CustomerId);
            }

        
    }
    }



