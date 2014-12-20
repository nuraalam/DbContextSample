using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Credit { get; set; }
        public virtual DepartmentCourse DepartmentCourse { get; set; }

    }
}