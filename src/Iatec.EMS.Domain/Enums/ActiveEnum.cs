using System.ComponentModel.DataAnnotations;

namespace Iatec.EMS.Domain.Enums
{
    public enum ActiveEnum
    {
        [Display(Name = "Sim")]
        Yes = 1,

        [Display(Name = "Não")]
        No = 2
    }
}
