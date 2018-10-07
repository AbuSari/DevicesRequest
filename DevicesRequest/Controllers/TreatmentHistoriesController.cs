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
    public class TreatmentHistoriesController : Controller
    {
        private DevicesRequestDBContext db = new DevicesRequestDBContext();

        // GET: TreatmentHistories
        public ActionResult Index()
        {
            var user = db.Users.Where(u => u.JobNumber == User.Identity.Name).FirstOrDefault();
            var treatmentHistories = db.TreatmentHistories.Include(t => t.User).Include(t => t.RequestItem).Include(t => t.RequestStatu);
            treatmentHistories = treatmentHistories.Where(t => t.UserId == user.UserId);
            return View(treatmentHistories.ToList());
        }

        // GET: TreatmentHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentHistory treatmentHistory = db.TreatmentHistories.Find(id);
            if (treatmentHistory == null)
            {
                return HttpNotFound();
            }
            return View(treatmentHistory);
        }

        // GET: TreatmentHistories/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstNameAr");
            return View();
        }

        // POST: TreatmentHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TreatmentHistoryId,UserId,StutusId,RequestId,LastUpdateBy,LastUpdateDate")] TreatmentHistory treatmentHistory)
        {
            if (ModelState.IsValid)
            {
                db.TreatmentHistories.Add(treatmentHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstNameAr", treatmentHistory.UserId);
            return View(treatmentHistory);
        }

        // GET: TreatmentHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentHistory treatmentHistory = db.TreatmentHistories.Find(id);
            if (treatmentHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstNameAr", treatmentHistory.UserId);
            return View(treatmentHistory);
        }

        // POST: TreatmentHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TreatmentHistoryId,UserId,StutusId,RequestId,LastUpdateBy,LastUpdateDate")] TreatmentHistory treatmentHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treatmentHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstNameAr", treatmentHistory.UserId);
            return View(treatmentHistory);
        }

        // GET: TreatmentHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentHistory treatmentHistory = db.TreatmentHistories.Find(id);
            if (treatmentHistory == null)
            {
                return HttpNotFound();
            }
            return View(treatmentHistory);
        }

        // POST: TreatmentHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TreatmentHistory treatmentHistory = db.TreatmentHistories.Find(id);
            db.TreatmentHistories.Remove(treatmentHistory);
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
