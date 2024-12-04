using BloodDonor.Core.Entities;
using BloodDonor.Core.Enums;

namespace BloodDonor.Core.Repositories;

public interface IBloodStockRepository
{
    
        Task AddAsync(Stock stockBlood);        
        Task<List<Stock>> GetAllAsync();
        Task<List<Stock>> GetAllByType(EBloodType bloodType);
        Task<Stock?> GetStockBloodBy(EBloodType bloodType, ERhFactor rHFactor);
        Task SaveChangesAsync();
        // Task<List<StockReportModel>> GetStockReportAsync();
}