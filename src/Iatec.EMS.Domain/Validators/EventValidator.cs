using FluentValidation;
using Iatec.EMS.Domain.Entities;

namespace Iatec.EMS.Domain.Validators
{
    public class EventValidator : AbstractValidator<Event>
    {
        public EventValidator()
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
                
                .MinimumLength(5)
                .WithMessage("O nome precisa ter no mínimo 5 caracteres.")
                
                .MaximumLength(150)
                .WithMessage("O nome não pode ultrapassar 150 caracteres.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("O descrição não pode ser vazia.")

                .NotNull()
                .WithMessage("O descrição não pode ser nula.")

                .MinimumLength(10)
                .WithMessage("O descrição precisa ter no mínimo 10 caracteres.")

                .MaximumLength(240)
                .WithMessage("O nome não pode ultrapassar 240 caracteres.");

            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage("A data não pode ser vazia.")

                .NotNull()
                .WithMessage("A data não pode ser nula.");

            RuleFor(x => x.Type)
                .NotEmpty()
                .WithMessage("O tipo não pode ser vazio.")

                .NotNull()
                .WithMessage("O tipo não pode ser nulo.");

            RuleFor(x => x.Local)
                .NotEmpty()
                .WithMessage("O local não pode ser vazio.")

                .NotNull()
                .WithMessage("O local não pode ser nulo.")

                .MinimumLength(5)
                .WithMessage("O local precisa ter no mínimo 10 caracteres.")

                .MaximumLength(150)
                .WithMessage("O local não pode ultrapassar 150 caracteres.");
        }
    }
}
