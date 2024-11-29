

namespace BloodDonor.Application.ViewModels;

public class DonorViewModel
{
    public DonorViewModel(string fullName, string email, int age, DateTime birthdate, string gender, double weight, string bloodType, string rhFactor)
    {
        FullName = fullName;
        Email = email;
        Age = age;
        Birthdate = birthdate;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        RhFactor = rhFactor;
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public int Age { get; private set; }
    public DateTime Birthdate { get; private set; }
    public string Gender { get; private set; }
    public double Weight { get; private set; }
    public string BloodType { get; private set; }
    public string RhFactor { get; private set; }
}