using UserManagement.UI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.UI.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage ="Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage ="User name is required.")]
        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage ="Email is not valid.")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Password is needed")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Invalid Password")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Please Confirm passwored")]
        [Compare("Password",ErrorMessage ="Confirm password should match password")]
               
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Please enter your contact number.")]
        [RegularExpression("^[6,7,8,9]\\d{9}$", ErrorMessage = "Please Enter Correct Mobile No.")]
        public string Contact { get; set; }

        [Required(ErrorMessage ="Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage ="Please select a country.")]
        public int CountryId { get; set; }

        [Required(ErrorMessage ="Please select a city.")]
        public int CityId { get; set; }

        [CheckBoxValidator(ErrorMessage = "Please Accept Terms")]
        public bool Terms { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
