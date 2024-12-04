using System.Reflection;
using BloodDonor.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodDonor.Infrastructure.Persistence;

public class BloodDonorDbContext : DbContext
{
    public BloodDonorDbContext(DbContextOptions<BloodDonorDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<Donor> Donors { get; set; }
    public DbSet<Donation> Donations { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Stock> BloodStock { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
}