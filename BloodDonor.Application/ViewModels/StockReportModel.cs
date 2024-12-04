using BloodDonor.Core.Entities;
using BloodDonor.Core.Enums;

namespace BloodDonor.Application.ViewModels;

public class StockReportModel
{
    public StockReportModel(EBloodType bloodType, ERhFactor rhFactor, int donationsQty, decimal mlQty, DateTime lastDonation)
    {
        BloodType = bloodType;
        RhFactor = rhFactor;
        DonationsQty = donationsQty;
        MlQty = mlQty;
        LastDonation = lastDonation;
    }

    public StockReportModel() {}
    public EBloodType BloodType { get; set; }
    public ERhFactor RhFactor { get; set; }
    public int DonationsQty { get; set; }
    public decimal MlQty { get; set; }
    public DateTime LastDonation { get; set; }
}