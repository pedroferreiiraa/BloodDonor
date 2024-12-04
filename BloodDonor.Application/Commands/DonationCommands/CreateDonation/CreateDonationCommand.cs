using BloodDonor.Application.ViewModels;
using MediatR;

namespace BloodDonor.Application.Commands.DonationCommands.CreateDonation;

public class CreateDonationCommand : IRequest<ResultViewModel<int>>
{
    public int DonorId { get; set; }
    public int QuantityML { get; set; }
}