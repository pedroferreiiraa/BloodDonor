using BloodDonor.Core.Entities;

namespace BloodDonor.Core.Repositories;

public interface IAddressRepository
{
    Task<int> AddAsync(Address address);
    Task<List<Address>> GetAllAsync();
    Task SaveChangesAsync();
    Task<int> GetByCodIbgeAsync(string codIbge);
    Task<int> GetByNameAsync(string name);
}