using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WanItApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public int? ManagerId { get; set; }
        public virtual Manager Manager { get; set; }
    }
}