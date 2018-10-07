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
    public class ShipmentsController : Controller
    {
        private DevicesRequestDBContext db = new DevicesRequestDBContext();

        // GET: Shipments
        public ActionResult Index()
        {
            var shipments = db.Shipments.Include(s => s.Item).Include(s => s.PoRceived);
            return View(shipments.ToList());
        }

        // GET: Shipments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // GET: Shipments/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "NameEn");
            ViewBag.PoRceivedId = new SelectList(db.PoRceiveds, "PoRceivedId", "CompanyNameEn");
            return View();
        }

        // POST: Shipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShipmentId,PoRceivedId,ItemId,Quantity,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate")] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Where(u => u.JobNumber == User.Identity.Name).FirstOrDefault();

                Item item = db.Items.Find(shipment.ItemId);

                int? NewItems = shipment.Quantity;

                if (item.UnitsInStock != null && shipment.Quantity != null)
                {
                    NewItems = item.UnitsInStock + shipment.Quantity;
                }
                if(item.UnitsOnOrder == null)
                {
                    item.UnitsOnOrder = 0;
                }

                item.UnitsInStock = NewItems;

                item.LastUpdateBy = user.FirstNameEn + " " + user.LastNameEn;
                item.LastUpdateDate = DateTime.Now;
                db.Entry(item).State = EntityState.Modified;

                shipment.CreatedBy = user.FirstNameEn + " " + user.LastNameEn;
                shipment.CreatedDate = DateTime.Now;
                shipment.LastUpdateBy = user.FirstNameEn + " " + user.LastNameEn;
                shipment.LastUpdateDate = DateTime.Now;

                db.Shipments.Add(shipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "NameEn", shipment.ItemId);
            ViewBag.PoRceivedId = new SelectList(db.PoRceiveds, "PoRceivedId", "CompanyNameEn", shipment.PoRceivedId);
            return View(shipment);
        }

        // GET: Shipments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "NameEn", shipment.ItemId);
            ViewBag.PoRceivedId = new SelectList(db.PoRceiveds, "PoRceivedId", "CompanyNameEn", shipment.PoRceivedId);
            return View(shipment);
        }

        // POST: Shipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShipmentId,PoRceivedId,ItemId,Quantity,CreatedBy,CreatedDate,LastUpdateBy,LastUpdateDate")] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Where(u => u.JobNumber == User.Identity.Name).FirstOrDefault();

                shipment.LastUpdateBy = user.FirstNameEn + " " + user.LastNameEn;
                shipment.LastUpdateDate = DateTime.Now;

                db.Entry(shipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "NameEn", shipment.ItemId);
            ViewBag.PoRceivedId = new SelectList(db.PoRceiveds, "PoRceivedId", "CompanyNameEn", shipment.PoRceivedId);
            return View(shipment);
        }

        // GET: Shipments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // POST: Shipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shipment shipment = db.Shipments.Find(id);
            db.Shipments.Remove(shipment);
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
