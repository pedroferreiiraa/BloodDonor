using BloodDonor.Application.ViewModels;
using BloodDonor.Core.Entities;
using BloodDonor.Core.Repositories;
using MediatR;

namespace BloodDonor.Application.Commands.DonationCommands.CreateDonation;

public class CreateDonationHandler : IRequestHandler<CreateDonationCommand, ResultViewModel<int>>
{
    private readonly IDonationRepository _donationRepository;
    private readonly IBloodStockRepository _stockRepository;
    private readonly IDonorRepository _donorRepository;

    public CreateDonationHandler(IDonationRepository donationRepository, IBloodStockRepository stockRepository, IDonorRepository donorRepository)
    {
        _donationRepository = donationRepository;
        _stockRepository = stockRepository;
        _donorRepository = donorRepository;
    }

    
    public async Task<ResultViewModel<int>> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
    {
        var donation = new Donation(request.DonorId, request.QuantityML);

        await _donationRepository.AddAsync(donation);
        await _donationRepository.SaveChangesAsync();

        var donor = await _donorRepository.GetByIdAsync(request.DonorId);

        var stock = await _stockRepository.GetStockBloodBy(donor.BloodType, donor.RhFactor);

        if (stock is null)
        {
            var bloodStock = new Stock(donation.QuantityML, donor.BloodType, donor.RhFactor );
            await _stockRepository.AddAsync(bloodStock);
        }
        else
        {
            stock.InputBloodStock(request.QuantityML);
        }

        await _stockRepository.SaveChangesAsync();
        return ResultViewModel<int>.Success(donation.Id);

    }
}