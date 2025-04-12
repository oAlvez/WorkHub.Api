using FluentValidation;
using WorkHub.Application.DTOs.Updates;

namespace WorkHub.Application.Validators.Updates;
public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeDTO>
{
    public UpdateEmployeeValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("O ID da empresa é obrigatório.");

        RuleFor(e => e.FullName)
            .NotEmpty().WithMessage("O nome completo é obrigatório.")
            .MaximumLength(100).WithMessage("O nome completo deve ter no máximo 100 caracteres.");

        RuleFor(e => e.FirstName)
            .NotEmpty().WithMessage("O primeiro nome é obrigatório.")
            .MaximumLength(50).WithMessage("O primeiro nome deve ter no máximo 50 caracteres.");

        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("O e-mail é obrigatório.")
            .EmailAddress().WithMessage("O e-mail informado não é válido.");

        RuleFor(e => e.JobPositionId)
            .NotEmpty().WithMessage("O cargo é obrigatório.");

        RuleFor(e => e.CompanyId)
            .NotEmpty().WithMessage("A empresa é obrigatória.");
    }
}