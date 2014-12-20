using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Enter Department Name")]
        [Remote("NameExits","Departments",ErrorMessage = "Name already in database")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Department Code")]
        [Remote("CodeExits", "Departments", ErrorMessage = "Name already in database")]
        public string Code { get; set; }
    }
}