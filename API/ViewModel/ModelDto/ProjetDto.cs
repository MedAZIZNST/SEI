using System;
using System.ComponentModel.DataAnnotations;

namespace Solution.ViewModel
{

        public class ProjetDto
        {
            [Required]
            public string ProjetName { get; set; }
            [Required]
            public string description { get; set; }


        }
    
}