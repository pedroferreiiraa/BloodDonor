using BloodDonor.Core.Entities;

namespace BloodDonor.Core.Repositories;

public interface IDonorRepository
{
    Task<List<Donor>> GetAllAsync();
    Task<Donor> GetByIdAsync(int id);
    Task AddAsync(Donor donor);
    Task AddAddressAsync(Address address);
    Task SaveChangesAsync();
    // Task<int> DeleteAsync();
}