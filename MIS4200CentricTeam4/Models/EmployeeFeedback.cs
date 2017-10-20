using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200CentricTeam4.Models
{
    public class EmployeeFeedback
    {
        public int employeeFeedbackID { get; set; }

        [Display(Name = "Feedback Description")]
        [Required(ErrorMessage = "Feedback description is required.")]
        [StringLength(240)]
        public string feedbackDescription { get; set; }

        [Display(Name = "Date of Feedback")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime time { get; set; }

        [Display (Name = "Feedback Provider")]
        [Required(ErrorMessage = "Feedback provider is required.")]
        [StringLength(20)]
        public string feedbackProvider { get; set; }

        public int employeeID { get; set; }
        public virtual Employee Employee { get; set; }

        public int feedbackID { get; set; }
        public virtual Feedback Feedback { get; set; }
    }
}