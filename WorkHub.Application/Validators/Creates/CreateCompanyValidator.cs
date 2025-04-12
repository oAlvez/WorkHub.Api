using FluentValidation;
using WorkHub.Application.DTOs.Creates;
using WorkHub.Application.DTOs.Updates;

namespace WorkHub.Application.Validators.Creates;
public class CreateCompanyValidator : AbstractValidator<CreateCompanyDTO>
{
    public CreateCompanyValidator()
    {
        RuleFor(e => e.CompanyName)
            .NotEmpty().WithMessage("O nome da empresa é obrigatório.")
            .MaximumLength(100).WithMessage("O nome da empresa deve ter no máximo 100 caracteres.");

        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("O e-mail é obrigatório.")
            .EmailAddress().WithMessage("O e-mail informado não é válido.");

        RuleFor(e => e.PhoneNumber)
            .NotEmpty().WithMessage("O número de telefone é obrigatório.")
            .Matches(@"^\(?\d{2}\)?[\s-]?\d{4,5}-?\d{4}$")
            .WithMessage("O telefone informado não é válido.");

        RuleFor(e => e.Cnpj)
            .NotEmpty().WithMessage("O CNPJ é obrigatório.")
            .Length(14).WithMessage("O CNPJ deve conter 14 dígitos.")
            .Must(IsValidCnpj).WithMessage("O CNPJ informado é inválido.");
    }

    private bool IsValidCnpj(string cnpj)
    {
        return !string.IsNullOrWhiteSpace(cnpj);
    }
}
