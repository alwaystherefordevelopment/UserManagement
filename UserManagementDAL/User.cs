using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementDAL
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Column(TypeName ="Varchar(20)")]
        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName ="Varchar(20)")]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName ="Varchar(20)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName ="Varchar(20)")]
        public string Contact { get; set; }

        [Required]
        [Column(TypeName ="Varchar(20)")]
        public string Country { get; set; }

        [Required]
        [Column(TypeName ="Varchar(20)")]
        public string City { get; set; }

        [Required]
        [Column(TypeName = "Varchar(10)")]
        public string Gender { get; set; }

        [Required]
        [Column(TypeName ="Bit")]
        public bool Terms { get; set; }

    }
}
