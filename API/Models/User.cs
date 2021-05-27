using API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Entities
{
    public class User
    {
        public User()
        {
            UsersInRoles = new HashSet<UsersInRoles>();
            UsersInProjects = new HashSet<UsersInProjects>();
            RealiserObjectif = new HashSet<RealiserObjectif>();
            Demande = new HashSet<Demande>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
        public string grade { get; set; }
        public DateTime? BirthDate { get; set; }
        public string cin { get; set; }

        public string PhoneNumber { get; set; }
        public string address { get; set; }


        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? LastActivityDate { get; set; }

        public virtual ICollection<UsersInRoles> UsersInRoles { get; set; }
        public virtual ICollection<UsersInProjects> UsersInProjects { get; set; }
        public virtual ICollection<RealiserObjectif> RealiserObjectif { get; set; }
        public virtual ICollection<Demande> Demande { get; set; }

    }

}
