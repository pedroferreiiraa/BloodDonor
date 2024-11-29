using ClassLibrary1.Entities;

namespace BloodDonor.Core.Repositories;

public interface IDonorRepository
{
    Task<Donor> GetByIdAsync(int id);
    Task AddAsync(Donor donor);
    Task<List<Donor>> GetAllAsync();
    // Task UpdateAsync(Donor donor);
    Task SaveChangesAsync();
    // Task<int> DeleteAsync();
}