using System;
using System.ComponentModel.DataAnnotations;

namespace Solution.ViewModel
{
    public class PaysDto
    {
        [Required]
        public string Libelle { get; set; }
    }

}
