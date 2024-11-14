using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ChargeConfiguration : IEntityTypeConfiguration<Charge>
    {
        public void Configure(EntityTypeBuilder<Charge> entity)
        {
            // Definir la clave primaria
            entity.HasKey(x => x.ChargeId);
            // Definir la clave primaria
            entity.HasKey(x => x.Amount); // Asegúrate de que `ChargeId` sea la clave primaria

            // Configuración de la propiedad CardNumber
            entity
                .Property(x => x.Description)
                .IsRequired() // Se asegura de que la propiedad no sea nula
                .HasMaxLength(16); // Si es necesario, añade una longitud máxima para CardNumber (ajustar según el modelo)
            entity
                .Property(x => x.Date)
                .IsRequired();

            // Relación con Card
            entity
                .HasOne(x => x.Cards)  // Relación con la sentidad Card
                .WithMany(x => x.Charges)  // Card tiene muchos Charges
                .HasForeignKey(x => x.CardId); // La clave foránea CardId en Charge
                

            // Opcionalmente, puedes configurar otras relaciones o restricciones
        }
    }
}
