using System.ComponentModel.DataAnnotations;

namespace Iatec.EMS.Domain.Enums
{
    public enum GenderEnum
    {
        [Display(Name = "Masculino")]
        Male = 1,

        [Display(Name = "Feminino")]
        Famale = 2
    }
}
