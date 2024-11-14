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
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> entity)
        {
            entity.HasKey(x => x.CardId);
            entity
                .Property(x => x.CardNumber)
                .IsRequired();

            entity
                .Property(x => x.CardType)
                .IsRequired();
            entity
                .Property(x => x.ExpirationDate)
                .IsRequired();

            entity.Property(x => x.Status)
                .IsRequired();

            entity.Property (x => x.CreditLimit)
                .IsRequired();
            entity .Property(x => x.AvailableLimit)
                .IsRequired();
            entity.Property(x => x.InterestRate)
                .IsRequired();

            entity
                .HasOne(x => x.Customer)
                .WithMany(x => x.Cards)
                .HasForeignKey(x => x.CustomerId);
        }
    }
    }

