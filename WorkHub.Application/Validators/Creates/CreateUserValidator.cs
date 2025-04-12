using FluentValidation;
using WorkHub.Domain.Entities;

namespace WorkHub.Application.Validators.Creates;
public class CreateUserValidator : AbstractValidator<CreateUserDTO>
{
    public CreateUserValidator()
    {
        RuleFor(e => e.FullName)
            .NotEmpty().WithMessage("O nome completo é obrigatório.")
            .MaximumLength(100).WithMessage("O nome completo deve ter no máximo 100 caracteres.");

        RuleFor(e => e.ShortName)
            .NotEmpty().WithMessage("O apelido é obrigatório.")
            .MaximumLength(50).WithMessage("O apelido deve ter no máximo 50 caracteres.");

        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("O e-mail é obrigatório.")
            .EmailAddress().WithMessage("O e-mail informado não é válido.");

        RuleFor(e => e.Password)
           .NotEmpty().WithMessage("A senha é obrigatória.")
           .MinimumLength(6).WithMessage("A senha deve possuir no mínimo 6 caracteres.");
    }
}