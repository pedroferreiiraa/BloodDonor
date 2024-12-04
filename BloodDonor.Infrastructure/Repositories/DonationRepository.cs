using BloodDonor.Core.Entities;
using BloodDonor.Core.Repositories;
using BloodDonor.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BloodDonor.Infrastructure.Repositories;

public class DonationRepository : IDonationRepository
{
    
    private readonly BloodDonorDbContext _dbContext;
    private readonly string _connectionString;

    public DonationRepository(BloodDonorDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    
    public async Task AddAsync(Donation donation)
    {
        await _dbContext.AddAsync(donation);
    }
    public async Task<List<Donation>> GetAllByPeriod(DateTime initialDate, DateTime finishDate)
    {
        return await _dbContext.Donations
            .Include(d => d.Donor)
            .Where(d => d.DonationDateTime.Date >= initialDate.Date && d.DonationDateTime.Date <= finishDate.Date)
            .OrderBy(d => d.Donor.BloodType)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Donation>> GetAllDonationByDonor(int idDonor)
    {
        return await _dbContext.Donations
            .Include(d => d.Donor)
            .Where(d => d.DonorId == idDonor)
            .AsNoTracking()
            .OrderByDescending(d => d.DonationDateTime)
            .ToListAsync();
    }

    public async Task<Donation?> GetById(int id)
    {
        return await _dbContext.Donations
            .Include(d => d.Donor)
            .AsNoTracking()
            .SingleOrDefaultAsync(d => d.Id == id);
    }


    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}