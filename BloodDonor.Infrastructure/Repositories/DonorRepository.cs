using BloodDonor.Core.Entities;
using BloodDonor.Core.Repositories;
using BloodDonor.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodDonor.Infrastructure.Repositories;

public class DonorRepository : IDonorRepository
{
    private readonly BloodDonorDbContext _context;

    public DonorRepository(BloodDonorDbContext context)
    {
        _context = context;
    }
    
    public async Task<Donor> GetByIdAsync(int id)
    {
        return await _context.Donors
            .SingleOrDefaultAsync(u => u.Id == id && !u.IsDeleted);
    }

    public async Task AddAsync(Donor donor)
    {
        await _context.Donors.AddAsync(donor);

        await _context.SaveChangesAsync();
    }

    public Task AddAddressAsync(Address address)
    {
        throw new NotImplementedException();
    }

    public Task<List<Donor>> GetAllAsync()
    {
        return null;
    }

    // public Task UpdateAsync(Donor donor)
    // {
    //     throw new NotImplementedException();
    // }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    // public Task<int> DeleteAsync()
    // {
    //     throw new NotImplementedException();
    // }
}