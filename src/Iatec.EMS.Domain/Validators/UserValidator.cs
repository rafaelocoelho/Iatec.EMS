using FluentValidation;
using Iatec.EMS.Domain.Entities;

namespace Iatec.EMS.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .MinimumLength(3)
                .WithMessage("O nome precisa ter no mínimo 3 caracteres.")

                .MaximumLength(150)
                .WithMessage("O nome não pode ultrapassar 150 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O email não pode ser vazio.")

                .NotNull()
                .WithMessage("O email não pode ser nulo.")

                .EmailAddress()
                .WithMessage("O email não é válido.")

                .MaximumLength(150)
                .WithMessage("O email não pode ultrapassar 180 caracteres.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("A senha não pode ser vazia.")

                .NotNull()
                .WithMessage("A senha não pode ser nula.")

                .NotEqual(x => x.Name)
                .WithMessage("A senha não pode ser igual ao nome.");

            RuleFor(x => x.Birthday)
                .NotEmpty()
                .WithMessage("A data de nascimento não pode ser vazia.")

                .NotNull()
                .WithMessage("A data de nascimento não pode ser nula.");

            RuleFor(x => x.Gender)
                .NotEmpty()
                .WithMessage("O gênero não pode ser vazio.")

                .NotNull()
                .WithMessage("O gênero não pode ser nulo.");
        }
    }
}
