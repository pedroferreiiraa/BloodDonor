using BloodDonor.Core.Entities;
using BloodDonor.Core.Repositories;
using BloodDonor.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodDonor.Infrastructure.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly BloodDonorDbContext _dbContext;

    public AddressRepository(BloodDonorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> AddAsync(Address address)
    {
        await _dbContext.Cities.AddAsync(address);
        await _dbContext.SaveChangesAsync();
        return address.Id;
    }

    public async Task<List<Address>> GetAllAsync()
    {
        return await _dbContext.Cities.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task<int> GetByCodIbgeAsync(string codIbge)
    {
        var city = await _dbContext.Cities
            .Where(c => c.ZipCode == codIbge)
            .Select(c => c.Id)
            .FirstOrDefaultAsync();

        return city;
    }

    public async Task<int> GetByNameAsync(string name)
    {
        var city = await _dbContext.Cities
            .Where(c => c.City == name)
            .Select(c => c.Id)
            .FirstOrDefaultAsync();

        return city;
    }
}