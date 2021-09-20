using Iatec.EMS.Core.Exceptions;
using Iatec.EMS.Domain.Enums;
using Iatec.EMS.Domain.Validators;
using System;
using System.Collections.Generic;

namespace Iatec.EMS.Domain.Entities
{
    public class User : Base
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime Birthday { get; private set; }
        public GenderEnum Gender { get; private set; }

        public virtual ICollection<EventParticipant> EventParticipants { get; }

        public User() { }

        public User(string name, string email, string password, DateTime birthday, GenderEnum gender)
        {
            Name = name;
            Email = email;
            Password = password;
            Birthday = birthday;
            Gender = gender;
            _errors = new List<string>();
        }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }

        public void ChangeBirthday(DateTime birthday)
        {
            Birthday = birthday;
            Validate();
        }

        public void ChangeGender(GenderEnum gender)
        {
            Gender = gender;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new UserValidator();
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
