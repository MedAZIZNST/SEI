using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Entities
{
    public class UsersInProjects
    {
        public int ProjetId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Projet Projet { get; set; }
    }

}
