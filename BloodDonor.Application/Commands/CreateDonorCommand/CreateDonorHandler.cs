using BloodDonor.Application.ViewModels;
using BloodDonor.Core.Repositories;
using MediatR;

namespace BloodDonor.Application.Commands.CreateDonorCommand;

public class CreateDonorHandler : IRequestHandler<CreateDonorCommand, ResultViewModel<Guid>>
{
    private readonly IDonorRepository _donorRepository;

    public CreateDonorHandler(IDonorRepository donorRepository)
    {
        _donorRepository = donorRepository;
    }
    
    public Task<ResultViewModel<Guid>> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateDonorValidator();
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            var erros = validationResult.Errors
                .Select(error => new ValidationError)
            {
                PropertyName = error.PropertyName,
                ErrorMessage = error.ErrorMessage    
            })
            .ToList();
            return ResultViewModel<Guid>.Error($"{erros}")
        }
    }
}