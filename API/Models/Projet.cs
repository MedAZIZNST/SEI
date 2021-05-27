using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Entities
{
    public class Projet
    {
        public Projet()
        {
            UsersInProjects = new HashSet<UsersInProjects>();

        }

        public int Id { get; set; }
        public string ProjetName { get; set; }
        public string description { get; set; }


        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public virtual ICollection<UsersInProjects> UsersInProjects { get; set; }



    }

}