﻿using Iatec.EMS.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Iatec.EMS.APi.ViewModels
{
    public class CreateEventViewModel
    {
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
