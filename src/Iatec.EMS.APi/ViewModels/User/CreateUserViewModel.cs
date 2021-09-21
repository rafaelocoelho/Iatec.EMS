using Iatec.EMS.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Iatec.EMS.Api.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "O nome não pode ser vazio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email não pode ser vazia")]
        public string Email { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage = "A senha não pode ser vazia")]
        public string Password { get; set; }

        [DataType(DataType.Date), Required(ErrorMessage = "A data de nascimento não pode ser vazia")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "O gênero não pode ser vazio")]
        public GenderEnum Gender { get; set; }
    }
}
