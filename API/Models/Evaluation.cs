using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Entities
{
    public class Evaluation
    {
        public Evaluation()
        {
        }

        public Boolean Status { get; set; }
        public String Commentaire { get; set; }

        public ICollection<User> Users { get; set; }

    }

}
