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
    public class UserRolesController : Controller
    {
        private DevicesRequestDBContext db = new DevicesRequestDBContext();

        // GET: UserRoles
        public ActionResult Index()
        {
            var userRoles = db.UserRoles.Include(u => u.Role).Include(u => u.User);
            return View(userRoles.ToList());
        }

        // GET: UserRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = db.UserRoles.Find(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(userRole);
        }

        // GET: UserRoles/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "NameEn");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstNameAr");
            return View();
        }

        // POST: UserRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,RoleId,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,Active")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
              
                db.UserRoles.Add(userRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "NameEn", userRole.RoleId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstNameAr", userRole.UserId);
            return View(userRole);
        }

        // GET: UserRoles/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = db.UserRoles.Where(u => u.UserId == id).First();
            if (userRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "NameEn", userRole.RoleId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstNameEn", userRole.UserId);
            return View(userRole);
        }

        // POST: UserRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,RoleId,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,Active")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                UserRole OldUserRole = db.UserRoles.Where(u => u.UserId == userRole.UserId).First();
                var user = db.Users.Where(u => u.JobNumber == User.Identity.Name).FirstOrDefault();

                userRole.CreatedBy = OldUserRole.CreatedBy;
                userRole.CreatedDate = OldUserRole.CreatedDate;
                userRole.LastUpdateBy = user.FirstNameEn + " " + user.LastNameEn;
                userRole.LastUpdateDate = DateTime.Now.ToString();
                userRole.Active = OldUserRole.Active;

                db.UserRoles.Remove(OldUserRole);
                db.UserRoles.Add(userRole);
                //db.Entry(userRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "NameEn", userRole.RoleId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstNameEn", userRole.UserId);
            return View(userRole);
        }

        // GET: UserRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = db.UserRoles.Find(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(userRole);
        }

        // POST: UserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRole userRole = db.UserRoles.Find(id);
            db.UserRoles.Remove(userRole);
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

        public ActionResult AssignRole(int idRole , int idUser)
        {

            var userIn = db.Users.Where(u => u.JobNumber == User.Identity.Name).FirstOrDefault();

            User user = db.Users.Find(idUser);
            Role role = db.Roles.Find(idRole);

            UserRole OlduserRole = db.UserRoles.Where(ur => ur.UserId == idUser).FirstOrDefault();
            db.UserRoles.Remove(OlduserRole);
            db.SaveChanges();

            UserRole userRole = new UserRole();
            userRole.User = user;
            userRole.UserId = user.UserId;
            userRole.Role = role;
            userRole.RoleId = role.RoleId;
            userRole.CreatedBy = userIn.FirstNameEn + " " + userIn.LastNameEn;
            userRole.CreatedDate =  DateTime.Now.ToString();
            userRole.LastUpdateBy = userIn.FirstNameEn + " " + userIn.LastNameEn;
            userRole.LastUpdateDate =  DateTime.Now.ToString();
            userRole.Active = true;
           
            db.UserRoles.Add(userRole);
            db.SaveChanges();
            return RedirectToAction("Index", "Users");
        }
    }
}
