using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class DepartmentCourseController : Controller
    {
        private ProjectDB db = new ProjectDB();

        // GET: DepartmentCourse
        public ActionResult Index()
        {
            return View(db.DepartmentCourses.ToList());
        }

        // GET: DepartmentCourse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentCourse departmentCourse = db.DepartmentCourses.Find(id);
            if (departmentCourse == null)
            {
                return HttpNotFound();
            }
            return View(departmentCourse);
        }

        // GET: DepartmentCourse/Create
        public ActionResult Create()
        {
            ViewBag.Course = new SelectList(db.Courses, "CourseID", "Code");
            return View();
        }

        // POST: DepartmentCourse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentCourseID,CourseID")] DepartmentCourse departmentCourse)
        {
            if (ModelState.IsValid)
            {
                db.DepartmentCourses.Add(departmentCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departmentCourse);
        }

        // GET: DepartmentCourse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentCourse departmentCourse = db.DepartmentCourses.Find(id);
            if (departmentCourse == null)
            {
                return HttpNotFound();
            }
            return View(departmentCourse);
        }

        // POST: DepartmentCourse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentCourseID,CourseID")] DepartmentCourse departmentCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departmentCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departmentCourse);
        }

        // GET: DepartmentCourse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentCourse departmentCourse = db.DepartmentCourses.Find(id);
            if (departmentCourse == null)
            {
                return HttpNotFound();
            }
            return View(departmentCourse);
        }

        // POST: DepartmentCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepartmentCourse departmentCourse = db.DepartmentCourses.Find(id);
            db.DepartmentCourses.Remove(departmentCourse);
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

        public ActionResult GetCourseInfo(int courseId)
        {
            var courseInfo = db.Courses.Where(x => x.CourseID == courseId).FirstOrDefault();
            return Json(courseInfo, JsonRequestBehavior.AllowGet);

        }
    }
}
