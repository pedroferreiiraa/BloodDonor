namespace BloodDonor.Core.Entities;

public class Address : BaseEntity
{
    public Address(string street, int cityId, string state, string zipCode, int donorId)
    {
        Street = street;
        CityId = cityId;
        State = state;
        ZipCode = zipCode;
        DonorId = donorId;
    }

    public string Street { get; private set; }
    public int CityId { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public int DonorId { get; private set; }

    public void Update(string street, int cityId, string zipcode)
    {
        Street = street;
        CityId = cityId;
        ZipCode = zipcode;
    }
}