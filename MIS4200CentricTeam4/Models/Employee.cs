using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200CentricTeam4.Models
{
    public class Employee
    {
        public int employeeID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Employee first name is required.")]
        [StringLength(20)]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Employee last name is required.")]
        [StringLength(20)]
        public string lastName { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\(\d{3}\) |\d{3}-)\d{3}-\d{4}$",
            ErrorMessage = "Phone numbers must be in the format (xxx) xxx-xxxx or xxx-xxx-xxxx")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [Required]
        [EmailAddress(ErrorMessage = "Email address is required.")]
        public string email { get; set; }

        [Display(Name = "Office Location")]
        [Required]
        [StringLength(20)]
        public string officeLocation { get; set; }

        [Display(Name = "Job Title")]
        [Required]
        [StringLength(20)]
        public string jobTitle { get; set; }

        public ICollection<EmployeeFeedback> EmployeeFeedback { get; set; }
    }
}