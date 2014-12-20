using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WanItApp.Models;

namespace WanItApp.Controllers
{
    public class EmplyeeController : Controller
    {
        private EmployeeDbContext db = new EmployeeDbContext();

        // GET: /Emplyee/
        public ActionResult Index(int? managerId)
        {
            ViewBag.ManagerId = new SelectList(db.Departments, "ManagerId", "ManagerName");
            var sections = db.Sections.Include(e => e.Manager);
            if (managerId!=null)
            {
                sections= sections.Where(x => x.ManagerId == managerId);
            }

            return View(sections.ToList());
        }

        // GET: /Emplyee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Sections.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: /Emplyee/Create
        public ActionResult Create()
        {
            ViewBag.ManagerId = new SelectList(db.Departments, "ManagerId", "ManagerName");
            return View();
        }

        // POST: /Emplyee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EmployeeId,EmployeeName,Designation,ManagerId")] Employee employee)
        {

            if (employee.Designation=="Manager"||employee.Designation=="manager")
            {
                if (employee.ManagerId > 0)
                {
                    ViewBag.Notification = "Managers dont have any manager . Please leave the manager field empty ";
                    ViewBag.ManagerId = new SelectList(db.Departments, "ManagerId", "ManagerName", employee.ManagerId);
                    return View(employee);
                }
                else
                {
                    employee.ManagerId = null;
                    db.Sections.Add(employee);
                    db.SaveChanges();
                    return RedirectToAction("Index"); 
                }
               
            }  
            if (ModelState.IsValid)
            {
                
                db.Sections.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManagerId = new SelectList(db.Departments, "ManagerId", "ManagerName", employee.ManagerId);
            return View(employee);
        }

        // GET: /Emplyee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Sections.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerId = new SelectList(db.Departments, "ManagerId", "ManagerName", employee.ManagerId);
            return View(employee);
        }

        // POST: /Emplyee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EmployeeId,EmployeeName,Designation,ManagerId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManagerId = new SelectList(db.Departments, "ManagerId", "ManagerName", employee.ManagerId);
            return View(employee);
        }

        // GET: /Emplyee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Sections.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: /Emplyee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Sections.Find(id);
            db.Sections.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
