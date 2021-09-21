using Iatec.EMS.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Iatec.EMS.Api.ViewModels
{
    public class UpdateEventViewModel
    {
        [Required(ErrorMessage = "O id não pode ser vazio")]
        [Range(1, int.MaxValue, ErrorMessage = "o id não pode ser menor que 1.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome não pode ser vazio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A descrição não pode ser vazia")]
        public string Description { get; set; }

        [DataType(DataType.Date), Required(ErrorMessage = "A data não pode ser vazia")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "O local não pode ser vazio")]
        public string Local { get; set; }

        [Required(ErrorMessage = "O tipo não pode ser vazio")]
        public EventTypeEnum Type { get; set; }
    }
}
