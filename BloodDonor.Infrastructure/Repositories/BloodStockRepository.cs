using BloodDonor.Core.Entities;
using BloodDonor.Core.Enums;
using BloodDonor.Core.Repositories;
using BloodDonor.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BloodDonor.Infrastructure.Repositories;

public class BloodStockRepository : IBloodStockRepository
{
    private readonly BloodDonorDbContext _context;
    private readonly string _connecionString;

    public BloodStockRepository(BloodDonorDbContext context, IConfiguration configuration)
    {
        _context = context;
        _connecionString = configuration.GetConnectionString("DefaultConnection");
    }
    
    public async Task AddAsync(Stock stockBlood)
    {
        await _context.AddAsync(stockBlood);
    }

    public async Task<List<Stock>> GetAllAsync()
    {
        return await _context.BloodStock.ToListAsync();
    }

    public async Task<List<Stock>> GetAllByType(EBloodType bloodType)
    {
        return await _context.BloodStock
            .AsNoTracking()
            .Where(sb => sb.BloodType == bloodType)
            .ToListAsync();
    }

    public async Task<Stock?> GetStockBloodBy(EBloodType bloodType, ERhFactor rHFactor)
    {
        return await _context.BloodStock
            .SingleOrDefaultAsync(b => b.BloodType == bloodType && b.RhFactor == rHFactor)!;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}