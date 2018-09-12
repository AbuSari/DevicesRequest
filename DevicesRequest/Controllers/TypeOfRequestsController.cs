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
    public class TypeOfRequestsController : Controller
    {
        private DevicesRequestContext db = new DevicesRequestContext();

        // GET: TypeOfRequests
        public ActionResult Index()
        {
            return View(db.TypeOfRequests.ToList());
        }

        // GET: TypeOfRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfRequest typeOfRequest = db.TypeOfRequests.Find(id);
            if (typeOfRequest == null)
            {
                return HttpNotFound();
            }
            return View(typeOfRequest);
        }

        // GET: TypeOfRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeOfRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeOfRequestId,NameEn,NameAr,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,Active")] TypeOfRequest typeOfRequest)
        {
            if (ModelState.IsValid)
            {
                db.TypeOfRequests.Add(typeOfRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeOfRequest);
        }

        // GET: TypeOfRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfRequest typeOfRequest = db.TypeOfRequests.Find(id);
            if (typeOfRequest == null)
            {
                return HttpNotFound();
            }
            return View(typeOfRequest);
        }

        // POST: TypeOfRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeOfRequestId,NameEn,NameAr,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate,Active")] TypeOfRequest typeOfRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeOfRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeOfRequest);
        }

        // GET: TypeOfRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfRequest typeOfRequest = db.TypeOfRequests.Find(id);
            if (typeOfRequest == null)
            {
                return HttpNotFound();
            }
            return View(typeOfRequest);
        }

        // POST: TypeOfRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeOfRequest typeOfRequest = db.TypeOfRequests.Find(id);
            db.TypeOfRequests.Remove(typeOfRequest);
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
