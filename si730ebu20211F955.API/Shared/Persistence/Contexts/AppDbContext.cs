using Microsoft.EntityFrameworkCore;
using si730ebu20211F955.API.Inventory.Domain.Models.Aggregates;
using si730ebu20211F955.API.Shared.Extensions;

namespace si730ebu20211F955.API.Shared.Persistence.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<Product>().HasKey(p => p.Id);
        modelBuilder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Product>().Property(p => p.Model).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.Brand).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.Status).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.SerialNumber).IsRequired();
        
        modelBuilder.UseSnakeCaseNamingConvention();
    }
}