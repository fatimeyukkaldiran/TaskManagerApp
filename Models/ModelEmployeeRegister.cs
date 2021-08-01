using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerApp.Models
{
    public class ModelEmployeeRegister
    {
        [Key]
        public int EmployeeId { get; set; }

        [StringLength(200)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(200)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        [Required]
        [Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string Password { get; set; }


    }
}
