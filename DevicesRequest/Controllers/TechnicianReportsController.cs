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
    public class TechnicianReportsController : Controller
    {
        private DevicesRequestDBContext db = new DevicesRequestDBContext();

        // GET: TechnicianReports
        public ActionResult Index()
        {
            var technicianReports = db.TechnicianReports.Include(t => t.RequestItem);
            return View(technicianReports.ToList());
        }

        // GET: TechnicianReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicianReport technicianReport = db.TechnicianReports.Find(id);
            if (technicianReport == null)
            {
                return HttpNotFound();
            }
            return View(technicianReport);
        }

        // GET: TechnicianReports/Create
        public ActionResult Create()
        {
            ViewBag.ReportItem = new SelectList(db.RequestItems, "RequestItemsId", "LastUpdateBy");
            return View();
        }

        // POST: TechnicianReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReportId,Details,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,Active,ReportItem,UserId")] TechnicianReport technicianReport)
        {
            if (ModelState.IsValid)
            {
                db.TechnicianReports.Add(technicianReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReportItem = new SelectList(db.RequestItems, "RequestItemsId", "LastUpdateBy", technicianReport.ReportItem);
            return View(technicianReport);
        }

        // GET: TechnicianReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicianReport technicianReport = db.TechnicianReports.Find(id);
            if (technicianReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReportItem = new SelectList(db.RequestItems, "RequestItemsId", "LastUpdateBy", technicianReport.ReportItem);
            return View(technicianReport);
        }

        // POST: TechnicianReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReportId,Details,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,Active,ReportItem,UserId")] TechnicianReport technicianReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technicianReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReportItem = new SelectList(db.RequestItems, "RequestItemsId", "LastUpdateBy", technicianReport.ReportItem);
            return View(technicianReport);
        }

        // GET: TechnicianReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicianReport technicianReport = db.TechnicianReports.Find(id);
            if (technicianReport == null)
            {
                return HttpNotFound();
            }
            return View(technicianReport);
        }

        // POST: TechnicianReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TechnicianReport technicianReport = db.TechnicianReports.Find(id);
            db.TechnicianReports.Remove(technicianReport);
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
