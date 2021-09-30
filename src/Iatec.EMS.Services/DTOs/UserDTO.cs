using Iatec.EMS.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Iatec.EMS.Services.DTOs
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public GenderEnum Gender { get; set; }

        public UserDTO() { }

        public UserDTO(long id, string name, string email, string password, DateTime birthday, GenderEnum gender)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Birthday = birthday;
            Gender = gender;
        }
    }
}
