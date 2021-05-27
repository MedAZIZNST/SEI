using System;
using System.Collections.Generic;

namespace Solution.ViewModel {

    public class ProjetVm
    {
        public int Id { get; set; }
        public string ProjetName { get; set; }
        public string description { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public IEnumerable<UserVm> Users { get; set; }
    }

    
}