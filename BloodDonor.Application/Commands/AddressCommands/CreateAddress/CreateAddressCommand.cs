using BloodDonor.Application.ViewModels;
using BloodDonor.Core.Entities;
using MediatR;

namespace BloodDonor.Application.Commands.AddressCommands.CreateAddress;

public class CreateAddressCommand : IRequest<ResultViewModel<int>>
{
   
    public string Street { get;  set; }
    public string City { get;  set; }
    public string State { get;  set; }
    public string ZipCode { get;  set; }
    public int DonorId { get;  set; }

    public Address ToEntity()
        => new( Street, City, State, ZipCode, DonorId);
}