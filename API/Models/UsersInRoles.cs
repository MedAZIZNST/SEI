using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Entities
{
    public class UsersInRoles
    {      
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
