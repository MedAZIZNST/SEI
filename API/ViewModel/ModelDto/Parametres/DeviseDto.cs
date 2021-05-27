using System;
using System.ComponentModel.DataAnnotations;

namespace Solution.ViewModel
{
    public class DeviseDto
    {
        [Required]
        public string Libelle { get; set; }
        [Required]
        public double? Valeur { get; set; }

    }

}
