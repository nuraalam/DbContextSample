using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WanItApp.Models
{
    public class EmployeeDbContext:DbContext
    {
        public DbSet<Manager> Departments { set; get; }
        public DbSet<Employee> Sections { set; get; }
    }
}