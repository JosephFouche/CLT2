using Core.Entities;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public partial class ApplicationDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Account> Accounts { get; set; }//DBSet para entidad tabla
    //se crea tabla tarjeta de credito
    public DbSet<Card> Cards { get; set; }//tarjeta de credito
    //hacer tabla cargar
    //payments
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Charge> Charges { get; set; }

    //Entidad
    public DbSet<Entidad> Entities { get; set; }
    public DbSet<Product> Products { get; set; }

    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
