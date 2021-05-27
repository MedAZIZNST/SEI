using System;
using System.Collections.Generic;

namespace Solution.ViewModel
{
    public class UserVm
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string email { get; set; }
        public DateTime? LastActivityDate { get; set; }  
        public IEnumerable<RoleVm> Roles { get; set; }
    } 


    public class RoleVm
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

    }

}
