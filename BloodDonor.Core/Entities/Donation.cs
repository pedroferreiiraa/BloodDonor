namespace BloodDonor.Core.Entities;

public class Donation : BaseEntity
{
    
    private Donation() {}
    public Donation(int donorId, int quantityMl)
    {
        DonorId = donorId;
        DonationDateTime = DateTime.Now;
        QuantityML = quantityMl;

    }


    public int DonorId { get; private set; }
    public DateTime DonationDateTime { get; private set; }
    public int QuantityML { get; private set; }
    public Donor Donor { get; private set; }
}