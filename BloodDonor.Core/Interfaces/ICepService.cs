using BloodDonor.Core.Entities;

namespace BloodDonor.Core.Interfaces;

public interface ICepService
{
    Task<Address?> GetAddressByCepAsync(string cep);
}