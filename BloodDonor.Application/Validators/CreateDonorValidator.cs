using BloodDonor.Application.Commands.CreateDonorCommand;
using FluentValidation;

namespace BloodDonor.Application.Validators;

public class CreateDonorValidator : AbstractValidator<CreateDonorCommand>
{
    public CreateDonorValidator()
    {
        RuleFor(x => x.Weight)
            .GreaterThanOrEqualTo(50).WithMessage("Doador precisa pesar pelomenos 50kg");
        RuleFor(x => x.Gender).IsInEnum().WithMessage("Gênero inválido");
        RuleFor(x => x.BloodType).IsInEnum().WithMessage("Tipo sanguíneo inválido");
        RuleFor(x => x.RhFactor).IsInEnum().WithMessage("Fator inválido");
    }

}