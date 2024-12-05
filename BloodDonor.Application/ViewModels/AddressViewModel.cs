namespace BloodDonor.Application.ViewModels;

public class AddressViewModel
{
    public AddressViewModel(string name, string street, string city, string state, string zipCode, int donorId)
    {
        Name = name;
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
        DonorId = donorId;
    }

    public string Name { get; private set; }
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public int DonorId { get; private set; }
}