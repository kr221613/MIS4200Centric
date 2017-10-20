using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MIS4200CentricTeam4.Models;

namespace MIS4200CentricTeam4.DAL
{
    public class Context : DbContext
    {
        public Context() : base("name=cs4200")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeFeedback> EmployeeFeedbacks { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}