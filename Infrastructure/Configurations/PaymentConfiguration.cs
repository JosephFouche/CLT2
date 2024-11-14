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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> entity)
        {
            // Definir la clave primaria
            entity.HasKey(x => x.PaymentId);
            // Definir la clave primaria

            entity.HasKey(x => x.Amount);

            entity
                .Property(x => x.PaymentMethod)
                .IsRequired();

            entity
                .Property(x => x.Date)
                .IsRequired();

            


            // Relación con Card
            entity
                .HasOne(x => x.Cards)  // Relación con la sentidad Cards
                .WithMany(x => x.Payments)  // Card tiene muchos paymnets
                .HasForeignKey(x => x.CardId); // La clave foránea CardId en Charg
        }
    }
}
