using System.ComponentModel.DataAnnotations;

namespace Iatec.EMS.Api.ViewModels
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "O email não pode ser vazia."), EmailAddress(ErrorMessage = "O email não é válido.")]
        public string Email { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage = "A senha não pode ser vazia.")]
        public string Password { get; set; }
    }
}
