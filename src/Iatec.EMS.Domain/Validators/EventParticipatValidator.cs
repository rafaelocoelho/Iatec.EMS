using FluentValidation;
using Iatec.EMS.Domain.Entities;

namespace Iatec.EMS.Domain.Validators
{
    public class EventParticipatValidator : AbstractValidator<EventParticipant>
    {
        public EventParticipatValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.EventId)
                .NotEmpty()
                .WithMessage("O evento não pode ser vazio.")

                .NotNull()
                .WithMessage("O nome evento pode ser nulo.");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("O usuário não pode ser vazio.")

                .NotNull()
                .WithMessage("O usuário não pode ser nulo.");
        }
    }
}
