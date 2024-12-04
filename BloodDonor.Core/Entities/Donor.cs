using BloodDonor.Core.Enums;

namespace BloodDonor.Core.Entities;

public class Donor : BaseEntity
{
    public Donor(string fullName, string email, DateTime birthdate, EGender gender, double weight, EBloodType bloodType, ERhFactor rhFactor)
    {
        FullName = fullName;
        Email = email;
        Age = CalculateAge(birthdate);
        Birthdate = birthdate;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        RhFactor = rhFactor;
        Donations = new List<Donation>();
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public int Age { get; private set; }
    public DateTime Birthdate { get; private set; }
    public EGender Gender { get; private set; }
    public double Weight { get; private set; }
    public EBloodType BloodType { get; private set; }
    public ERhFactor RhFactor { get; private set; }
    public List<Donation> Donations { get; private set; }
    public Address? Address { get; private set; }
    public int? AddressId { get; private set; }

    public int CalculateAge(DateTime birthdate)
    {
        var today = DateTime.Now;
        var age = today.Year - birthdate.Year;
        
        if (today.Month < birthdate.Month || (today.Month == birthdate.Month && today.Day < birthdate.Day))
        {
            age--;
        }

        return age;
    }
}