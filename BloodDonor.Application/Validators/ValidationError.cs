using BloodDonor.Application.Commands.CreateDonorCommand;
using FluentValidation;

namespace BloodDonor.Application.Validators;

public class ValidationError
{
    public string PropertyName { get; set; }
    public string ErrorMessage { get; set; }

    public override string ToString() => $"({PropertyName}, '{ErrorMessage}')";
}