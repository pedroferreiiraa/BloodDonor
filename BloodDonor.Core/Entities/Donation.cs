namespace ClassLibrary1.Entities;

public class Donation : BaseEntity
{
    public int DonorId { get; private set; }
    public DateTime DonationDateTime { get; private set; }
    public int QuantityML { get; private set; }
    public Donor Donor { get; private set; }
}