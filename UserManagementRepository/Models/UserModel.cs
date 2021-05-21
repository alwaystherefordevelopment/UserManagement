using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementRepository.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        public string  Name { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public string Gender { get; set; }

        public string Contact { get; set; }

        public int CityId { get; set; }

        public int CountryId { get; set; }

        public bool Terms { get; set; }

        [Display(Name="City")]
        public string CityName { get; set; }

        [Display(Name="Country")]
        public string CountryName { get; set; }
    }
}
