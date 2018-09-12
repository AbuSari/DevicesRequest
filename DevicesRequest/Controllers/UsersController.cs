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
    public class UsersController : Controller
    {
        private DevicesRequestContext db = new DevicesRequestContext();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Department).Include(u => u.Level).Include(u => u.Position);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "NameEn");
            ViewBag.LevelId = new SelectList(db.Levels, "LevelId", "NameEn");
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "NameEn");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,FirstNameAr,LastNameAr,FirstNameEn,LastNameEn,JobNumber,LevelId,DepartmentId,PositionId,RoomNo,Telephon,Mobile,UserEmail,DirectorEmail,CereatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,Comment")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "NameEn", user.DepartmentId);
            ViewBag.LevelId = new SelectList(db.Levels, "LevelId", "NameEn", user.LevelId);
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "NameEn", user.PositionId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "NameEn", user.DepartmentId);
            ViewBag.LevelId = new SelectList(db.Levels, "LevelId", "NameEn", user.LevelId);
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "NameEn", user.PositionId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstNameAr,LastNameAr,FirstNameEn,LastNameEn,JobNumber,LevelId,DepartmentId,PositionId,RoomNo,Telephon,Mobile,UserEmail,DirectorEmail,CereatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,Comment")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "NameEn", user.DepartmentId);
            ViewBag.LevelId = new SelectList(db.Levels, "LevelId", "NameEn", user.LevelId);
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "NameEn", user.PositionId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
