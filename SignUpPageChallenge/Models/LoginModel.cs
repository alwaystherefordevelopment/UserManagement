using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.UI.Models
{
    public class LoginModel 
    { 
    
        [Required(ErrorMessage="Please enter a valid Email!")]
        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Email is not valid.")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Please enter a password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Invalid Password")]
        public string Password { get; set; }
    }
}
