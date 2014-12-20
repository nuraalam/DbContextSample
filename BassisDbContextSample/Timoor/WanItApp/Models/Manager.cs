using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WanItApp.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public string ManagerName { set; get; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}