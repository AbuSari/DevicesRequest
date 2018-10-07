using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DevicesRequest.Models;

namespace DevicesRequest.Controllers
{
    public class UsersController : Controller
    {
        private DevicesRequestDBContext db = new DevicesRequestDBContext();

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
            ViewBag.Roles = db.Roles.ToList();
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
        public ActionResult Create([Bind(Include = "UserId,FirstNameAr,LastNameAr,FirstNameEn,LastNameEn,JobNumber,LevelId,DepartmentId,PositionId,RoomNo,Telephon,Mobile,UserEmail,CereatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,ImageJobNo,Comment")] User user)
        {
            if (ModelState.IsValid)
            {

                user.CreatedDate = DateTime.Now;
                user.LastUpdateBy = user.FirstNameEn + " " + user.LastNameEn;
                user.LastUpdateDate = DateTime.Now;

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
        [AllowAnonymous]
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
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstNameAr,LastNameAr,FirstNameEn,LastNameEn,JobNumber,LevelId,DepartmentId,PositionId,RoomNo,Telephon,Mobile,UserEmail,CereatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,ImageJobNo,Comment")] User user, HttpPostedFileBase UploadFile)
        {
            if (ModelState.IsValid)
            {
               
                if (UploadFile != null)
                {
                    if (UploadFile.ContentType.ToLower() != "image/jpg" &&
                   UploadFile.ContentType.ToLower() != "image/jpeg" &&
                   UploadFile.ContentType.ToLower() != "image/pjpeg" &&
                   UploadFile.ContentType.ToLower() != "image/gif" &&
                   UploadFile.ContentType.ToLower() != "image/x-png" &&
                   UploadFile.ContentType.ToLower() != "image/png")
                    {
                        ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "NameEn", user.DepartmentId);
                        ViewBag.LevelId = new SelectList(db.Levels, "LevelId", "NameEn", user.LevelId);
                        ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "NameEn", user.PositionId);
                        return View(user);
                    }
                    string path = Path.Combine(Server.MapPath("~/JobCards"), UploadFile.FileName);
                    user.ImageJobNo = UploadFile.FileName;
                    UploadFile.SaveAs(path);
                }

                user.LastUpdateBy = user.FirstNameEn + " " + user.LastNameEn;
                user.LastUpdateDate = DateTime.Now;

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

        public ActionResult AssignDirector()
        {
            var departments = db.Departments.Where(d => d.ManagerId == null).ToList();
            var Managers = db.Users.Where(u => u.Position.NameEn == "Director" && u.Department.ManagerId == null);
            return View(Managers.ToList());
        }

        public ActionResult Download(string id)
        {
            try
            {
                if (User.IsInRole("Supervisor"))
                {
                    int uId = Convert.ToInt32(id);
                    var user = db.Users.Where(u => u.UserId == uId).FirstOrDefault();
                    string file = user.ImageJobNo;
                    return File("~/JobCards/" + file, System.Net.Mime.MediaTypeNames.Application.Octet, file);
                }
            }
            catch
            {
                return RedirectToAction("AssignDirector");
            }
            return RedirectToAction("AssignDirector");

        }

    }
}
