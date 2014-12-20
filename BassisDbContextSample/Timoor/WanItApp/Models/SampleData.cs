using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WanItApp.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<EmployeeDbContext>
    {
        protected override void Seed(EmployeeDbContext context)
        {
            var managers = new List<Manager>
                                  {
                                      new Manager {ManagerName = "Hafiz"},
                                      new Manager {ManagerName = "Jamal"},
                                      new Manager {ManagerName = "Kamal"},
                                  };

            new List<Employee>
                               {
                                   new Employee {EmployeeName = "Bony",Designation = "Soft.Engg",Manager=managers[0]},
                                   new Employee {EmployeeName = "Rony",Designation = "Sales",Manager=managers[0]},
                                   new Employee {EmployeeName = "Pony",Designation = "T.Soft.Engg",Manager=managers[2]},
                                   new Employee {EmployeeName = "Jony",Designation = "M.Soft.Engg",Manager=managers[1]},
                                   new Employee {EmployeeName = "Nany",Designation = "P.Soft.Engg",Manager=managers[2]},
                                   new Employee {EmployeeName = "Hory",Designation = "KSoft.Engg",Manager=managers[2]},
                                   new Employee {EmployeeName = "Pial",Designation = "J.Soft.Engg",Manager=managers[0]},
                               }.ForEach(section => context.Sections.Add(section));


        }
    }
}