using System;
using System.ComponentModel.DataAnnotations;

namespace Iatec.EMS.Api.ViewModels
{
    public class SearchEventViewModel
    {
        public string Name { get; set; }

        public DateTime InitialDate { get; set; }

        public DateTime FinalDate { get; set; }
    }
}
