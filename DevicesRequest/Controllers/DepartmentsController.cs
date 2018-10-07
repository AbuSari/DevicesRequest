using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DevicesRequest.Models;

namespace DevicesRequest.Controllers
{
    public class DepartmentsController : Controller
    {
        private DevicesRequestDBContext db = new DevicesRequestDBContext();

        // GET: Departments
        public ActionResult Index()
        {
            var departments = db.Departments.Include(d => d.Department2).Include(d => d.User);
            return View(departments.ToList());
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            ViewBag.ManagerId = db.Users.Where(u => u.UserId == department.ManagerId).FirstOrDefault();
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            ViewBag.ParentId = new SelectList(db.Departments, "DepartmentId", "NameEn");
            ViewBag.ManagerId = new SelectList(db.Users, "UserId", "FirstNameEn");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentId,NameEn,NameAr,ParentId,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,ManagerId,Active")] Department department)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Where(u => u.JobNumber == User.Identity.Name).FirstOrDefault();

                department.CreatedBy = user.FirstNameEn + " " + user.LastNameEn;
                department.CreatedDate = DateTime.Now;
                department.LastUpdateBy = user.FirstNameEn + " " + user.LastNameEn;
                department.LastUpdateDate = DateTime.Now;

                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentId = new SelectList(db.Departments, "DepartmentId", "NameEn", department.ParentId);
            ViewBag.ManagerId = new SelectList(db.Users, "UserId", "FirstNameEn", department.ManagerId);
            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentId = new SelectList(db.Departments, "DepartmentId", "NameEn", department.ParentId);
            ViewBag.ManagerId = new SelectList(db.Users.Where(d => d.DepartmentId == department.DepartmentId), "UserId", "FirstNameEn", department.ManagerId);
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentId,NameEn,NameAr,ParentId,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,ManagerId,Active")] Department department)
        {
            if (ModelState.IsValid)
            {

                var user = db.Users.Where(u => u.JobNumber == User.Identity.Name).FirstOrDefault();

                department.LastUpdateBy = user.FirstNameEn + " " + user.LastNameEn;
                department.LastUpdateDate = DateTime.Now;


                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentId = new SelectList(db.Departments, "DepartmentId", "NameEn", department.ParentId);
            ViewBag.ManagerId = new SelectList(db.Users, "UserId", "FirstNameEn", department.ManagerId);
            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
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

        public ActionResult AssignManager(string idUser, string idDep)
        {

            Department department = db.Departments.Find(Convert.ToInt32(idDep));
            department.ManagerId = Convert.ToInt32(idUser);

            var user = db.Users.Where(u => u.JobNumber == User.Identity.Name).FirstOrDefault();

            department.LastUpdateBy = user.FirstNameEn + " " + user.LastNameEn;
            department.LastUpdateDate = DateTime.Now;

            db.Entry(department).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AssignDirector", "Users", null);
        }
    }
}
