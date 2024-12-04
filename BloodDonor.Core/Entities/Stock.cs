using BloodDonor.Core.Enums;

namespace BloodDonor.Core.Entities;

public class Stock : BaseEntity
{
    public Stock() {}
    public Stock(decimal quantityMl, EBloodType bloodType, ERhFactor rhFactor)
    {
        QuantityML = quantityMl;
        BloodType = bloodType;
        RhFactor = rhFactor;
    }
    public decimal QuantityML { get;  set; }
    public EBloodType BloodType { get;  set; }
    public ERhFactor RhFactor { get;  set; }
    

    public void InputBloodStock(int quantity)
    {
        QuantityML += quantity;
    }

    public void OutputBloodStock(int quantity)
    {
        QuantityML -= quantity;
    }
}