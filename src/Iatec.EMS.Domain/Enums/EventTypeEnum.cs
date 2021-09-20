using System.ComponentModel.DataAnnotations;

namespace Iatec.EMS.Domain.Enums
{
    public enum EventTypeEnum
    {
        [Display(Name = "Exclusivo")]
        Exclusive = 1,

        [Display(Name = "Compartilhado")]
        Shared = 2
    }
}
