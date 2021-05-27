using Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class RealiserObjectif
    {
        public int UserId { get; set; }
        public int ObjectifId { get; set; }
        public DateTime dateDebut { get; set; }
        public DateTime dateFin { get; set; }
        public virtual User User { get; set; }
        public virtual Objectif Objectif { get; set; }
    }
}
