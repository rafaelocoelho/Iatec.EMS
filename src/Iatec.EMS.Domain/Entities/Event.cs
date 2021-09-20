using Iatec.EMS.Core.Exceptions;
using Iatec.EMS.Domain.Enums;
using Iatec.EMS.Domain.Validators;
using System;
using System.Collections.Generic;

namespace Iatec.EMS.Domain.Entities
{
    public class Event : Base
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public string Local { get; private set; }
        public EventTypeEnum Type { get; private set; }

        public virtual ICollection<EventParticipant> EventParticipants { get; }

        public Event() { }

        public Event(string name, string description, DateTime date, string local)
        {
            Name = name;
            Description = description;
            Date = date;
            Local = local;
            _errors = new List<string>();
        }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangeDescription(string description)
        {
            Description = description;
            Validate();
        }

        public void ChangeDate(DateTime date)
        {
            Date = date;
            Validate();
        }

        public void ChangeLocal(string local)
        {
            Local = local;
            Validate();
        }

        public void ChangeType(EventTypeEnum type)
        {
            Type = type;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new EventValidator();
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
