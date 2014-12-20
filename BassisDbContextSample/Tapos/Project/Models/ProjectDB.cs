using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class ProjectDB:DbContext
    {
        public ProjectDB() : base("workshopProject")
        {
            
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }

        public System.Data.Entity.DbSet<Project.Models.DepartmentCourse> DepartmentCourses { get; set; }
    }
}