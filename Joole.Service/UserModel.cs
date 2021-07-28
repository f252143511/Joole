using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Joole.Service
{
    public class UserModel
    {
        [Display(Name = "Login ID: ")]
        public int User_ID { get; set; }

        [Display(Name = "Username: ")]
        public string Username { get; set; }

        public string Password { get; set; }
        [Display(Name = "Email: ")]
        public string Email { get; set; }
        public string Image { get; set; }



    }
}
