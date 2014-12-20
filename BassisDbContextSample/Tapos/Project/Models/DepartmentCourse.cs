using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class DepartmentCourse
    {
        public int DepartmentCourseID { set; get; }
        public int CourseID { get; set; }

        public virtual ICollection<Course> Courses{ get; set; }
    }
}