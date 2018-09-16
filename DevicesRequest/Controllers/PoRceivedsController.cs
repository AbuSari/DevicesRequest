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
    public class PoRceivedsController : Controller
    {
        private DevicesRequestDBContext db = new DevicesRequestDBContext();

        // GET: PoRceiveds
        public ActionResult Index()
        {
            return View(db.PoRceiveds.ToList());
        }

        // GET: PoRceiveds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoRceived poRceived = db.PoRceiveds.Find(id);
            if (poRceived == null)
            {
                return HttpNotFound();
            }
            return View(poRceived);
        }

        // GET: PoRceiveds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PoRceiveds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PoRceivedId,CompanyNameEn,CompanyNameAr,PoCode,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,Active")] PoRceived poRceived)
        {
            if (ModelState.IsValid)
            {
                db.PoRceiveds.Add(poRceived);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(poRceived);
        }

        // GET: PoRceiveds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoRceived poRceived = db.PoRceiveds.Find(id);
            if (poRceived == null)
            {
                return HttpNotFound();
            }
            return View(poRceived);
        }

        // POST: PoRceiveds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PoRceivedId,CompanyNameEn,CompanyNameAr,PoCode,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,Active")] PoRceived poRceived)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poRceived).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(poRceived);
        }

        // GET: PoRceiveds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoRceived poRceived = db.PoRceiveds.Find(id);
            if (poRceived == null)
            {
                return HttpNotFound();
            }
            return View(poRceived);
        }

        // POST: PoRceiveds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PoRceived poRceived = db.PoRceiveds.Find(id);
            db.PoRceiveds.Remove(poRceived);
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
