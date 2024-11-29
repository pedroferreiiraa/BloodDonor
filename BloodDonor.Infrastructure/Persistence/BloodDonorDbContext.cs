using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;




namespace BloodDonor.Infrastructure.Persistence;

public class BloodDonorDbContext : DbContext
{
    public BloodDonorDbContext(DbContextOptions<BloodDonorDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<Donor> Donors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Donor>()
            .HasOne(d => d.Address)
            .WithOne(a => a.Donor)
            .HasForeignKey<Donor>(d => d.AddressId)
            .OnDelete(DeleteBehavior.Cascade); // Ajuste conforme a regra de exclusão desejada


    }
}