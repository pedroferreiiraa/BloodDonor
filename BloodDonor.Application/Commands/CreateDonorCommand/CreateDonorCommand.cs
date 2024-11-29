using BloodDonor.Application.ViewModels;
using BloodDonor.Core.Enums;
using MediatR;

namespace BloodDonor.Application.Commands.CreateDonorCommand;

public class CreateDonorCommand : IRequest<ResultViewModel<int>>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public EGender Gender { get; set; }
    public double Weight { get; set; }
    public EBloodType BloodType { get; set; }
    public ERhFactor RhFactor { get; set; }
}