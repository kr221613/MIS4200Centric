using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200CentricTeam4.Models
{
    public class Feedback
    {
        public int feedbackID { get; set; }
                
        [Display(Name = "Employee's Name Recieving Feedback")]
        [Required(ErrorMessage = "Employee's name receiving the feedback is required.")]
        [StringLength(50)]
        public string employeeName { get; set; }

        [Display(Name = "Feedback Provider")]
        [Required(ErrorMessage = "Feedback provider's name is required.")]
        [StringLength(100)]
        public string feedbackName { get; set; }

        public ICollection<EmployeeFeedback> EmployeeFeedback { get; set; }
    }
}