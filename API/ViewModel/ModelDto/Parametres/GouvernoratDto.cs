using System;
using System.ComponentModel.DataAnnotations;

namespace Solution.ViewModel
{
    public class GouvernoratDto
    {
        public string GouvernoratNom { get; set; }
        public string Nbre { get; set; }
        public string Delegations { get; set; }
        public int? PaysId { get; set; }
    }

}
