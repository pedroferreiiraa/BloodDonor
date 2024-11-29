using BloodDonor.Application.Validators;
using BloodDonor.Application.ViewModels;
using BloodDonor.Core.Repositories;
using ClassLibrary1.Entities;
using MediatR;

namespace BloodDonor.Application.Commands.CreateDonorCommand;

public class CreateDonorHandler : IRequestHandler<CreateDonorCommand, ResultViewModel<int>>
{
    private readonly IDonorRepository _donorRepository;

    public CreateDonorHandler(IDonorRepository donorRepository)
    {
        _donorRepository = donorRepository;
    }
    
    public async Task<ResultViewModel<int>> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateDonorValidator();
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            var erros = validationResult.Errors
                .Select(error => new ValidationError
            {
                PropertyName = error.PropertyName,
                ErrorMessage = error.ErrorMessage    
            })
            .ToList();
            return ResultViewModel<int>.Error($"{erros}");
        }

        var Donor = new Donor(request.FullName, request.Email, request.BirthDate, request.Gender, request.Weight,
            request.BloodType, request.RhFactor);
        await _donorRepository.AddAsync(Donor);

        return ResultViewModel<int>.Success(Donor.Id);
    }
}