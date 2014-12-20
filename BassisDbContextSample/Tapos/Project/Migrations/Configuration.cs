using System.Collections.Generic;
using Project.Models;

namespace Project.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Project.Models.ProjectDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Project.Models.ProjectDB context)
        {
            //var courses = new List<Course>
            //{
            //    new Course() { Name = "algorithm", Code = "CSE-001",Credit =3 },
            //    new Course() { Name = "c+ ",   Code = "CSE-002",Credit = 4},
            //    new Course() { Name = "java",   Code = "CSE-002",Credit = 5}
                       
               
            //};
            //courses.ForEach(s => context.Courses.AddOrUpdate(s));
            //context.SaveChanges();
        }
    }
}
