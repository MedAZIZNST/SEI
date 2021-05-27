using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Entities
{
    public class Role
    {
        public Role() {
            UsersInRoles = new HashSet<UsersInRoles>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<UsersInRoles> UsersInRoles { get; set; }

    }
}
