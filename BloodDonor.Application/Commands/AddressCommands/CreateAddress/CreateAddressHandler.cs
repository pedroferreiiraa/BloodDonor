using BloodDonor.Application.ViewModels;
using BloodDonor.Core.Entities;
using BloodDonor.Core.Interfaces;
using BloodDonor.Core.Repositories;
using MediatR;

namespace BloodDonor.Application.Commands.AddressCommands.CreateAddress;

public class CreateAddressHandler : IRequestHandler<CreateAddressCommand, ResultViewModel<int>>
{
    private readonly ICepService _cepService;
    private readonly IAddressRepository _addressRepository;

    public CreateAddressHandler(ICepService cepService, IAddressRepository addressRepository)
    {
        _cepService = cepService;
        _addressRepository = addressRepository;
    }
    
    
    public async Task<ResultViewModel<int>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var address = await _cepService.GetAddressByCepAsync(request.ZipCode);

        if (address == null)
        {
            throw new Exception("Cep não encontrado");
        }

        var newAddress = request.ToEntity();
        await _addressRepository.SaveChangesAsync();



        return ResultViewModel<int>.Success(newAddress.Id);
    }
}