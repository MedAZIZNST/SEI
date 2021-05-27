using System;
using System.ComponentModel.DataAnnotations;

namespace Solution.ViewModel
{
    public class UserDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string pwd { get; set; }
        [Required]
        public string grade { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string cin { get; set; }

        public string PhoneNumber { get; set; }
        public string address { get; set; }





    }


public class LoginDto
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string pwd { get; set; }
    }
}
