using Iatec.EMS.Core.Exceptions;
using Iatec.EMS.Domain.Enums;
using Iatec.EMS.Domain.Validators;
using System;
using System.Collections.Generic;

namespace Iatec.EMS.Domain.Entities
{
    public class EventParticipant : Base
    {
        public long EventId { get; private set; }
        public long UserId { get; private set; }

        public virtual Event Event { get; set; }
        public virtual User User { get; set; }

        public EventParticipant() { }

        public EventParticipant(long eventId, long userId)
        {
            EventId = eventId;
            UserId = userId;
            _errors = new List<string>();
        }

        public override bool Validate()
        {
            var validator = new EventParticipatValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainException("Alguns campos estão inválidos!", _errors);
            }
            return true;
        }
    }
}
