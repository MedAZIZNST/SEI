using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Objectif
    {
        public Objectif()
        {
            RealiserObjectif = new HashSet<RealiserObjectif>();
        }
        public int Id { get; set; }
        public string ObjectifName { get; set; }
        public string description { get; set; }
        public string etat { get; set; }
        public ICollection<RealiserObjectif> RealiserObjectif { get; set; }
    }
}
