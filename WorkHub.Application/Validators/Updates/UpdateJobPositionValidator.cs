using FluentValidation;
using WorkHub.Application.DTOs.Updates;

namespace WorkHub.Application.Validators.Updates;
public class UpdateJobPositionValidator : AbstractValidator<UpdateJobPositionDTO>
{
    public UpdateJobPositionValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("O ID da empresa é obrigatório.");

        RuleFor(e => e.Title)
                   .NotEmpty().WithMessage("O título do cargo é obrigatório.")
                   .MaximumLength(100).WithMessage("O título deve ter no máximo 100 caracteres.");

        RuleFor(e => e.Description)
            .NotEmpty().WithMessage("A descrição é obrigatória.")
            .MaximumLength(255).WithMessage("A descrição deve ter no máximo 255 caracteres.");

        RuleFor(e => e.SalaryRange)
            .NotEmpty().WithMessage("A faixa salarial é obrigatória.");

        RuleFor(e => e.CompanyId)
            .NotEmpty().WithMessage("A empresa é obrigatória.");
    }
}