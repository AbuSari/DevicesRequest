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
    public class RequestItemsController : Controller
    {
        private DevicesRequestContext db = new DevicesRequestContext();

        // GET: RequestItems
        public ActionResult Index()
        {
            var requestItems = db.RequestItems.Include(r => r.Item).Include(r => r.RequestStatu).Include(r => r.TypeOfRequest).Include(r => r.User);
            return View(requestItems.ToList());
        }

        // GET: RequestItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestItem requestItem = db.RequestItems.Find(id);
            if (requestItem == null)
            {
                return HttpNotFound();
            }
            return View(requestItem);
        }

        // GET: RequestItems/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "NameEn");
            ViewBag.StutusId = new SelectList(db.RequestStatus, "RequestStatusId", "NameEn");
            ViewBag.TypeOfRequestId = new SelectList(db.TypeOfRequests, "TypeOfRequestId", "NameEn");
           // ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstNameAr");
            return View();
        }

        // POST: RequestItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,UserId,Quantity,RequestDate,StutusId,TypeOfRequestId,LastUpdateBy,LastUpdateDate,DirectorRecommondation")] RequestItem requestItem)
        {
            if (ModelState.IsValid)
            {
                string username = User.Identity.Name;
               // User user = db.Users.Find(username);
                //if(user.Position.NameEn == "Employee")
                //{
                //    requestItem.StutusId = db.RequestStatus.Find("NDA").RequestStatusId;
                //}
                requestItem.RequestDate = DateTime.Today; 
                db.RequestItems.Add(requestItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "NameEn", requestItem.ItemId);
            ViewBag.StutusId = new SelectList(db.RequestStatus, "RequestStatusId", "NameEn", requestItem.StutusId);
            ViewBag.TypeOfRequestId = new SelectList(db.TypeOfRequests, "TypeOfRequestId", "NameEn", requestItem.TypeOfRequestId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstNameAr", requestItem.UserId);
            return View(requestItem);
        }

        // GET: RequestItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestItem requestItem = db.RequestItems.Find(id);
            if (requestItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "NameEn", requestItem.ItemId);
            ViewBag.StutusId = new SelectList(db.RequestStatus, "RequestStatusId", "NameEn", requestItem.StutusId);
            ViewBag.TypeOfRequestId = new SelectList(db.TypeOfRequests, "TypeOfRequestId", "NameEn", requestItem.TypeOfRequestId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstNameAr", requestItem.UserId);
            return View(requestItem);
        }

        // POST: RequestItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,UserId,Quantity,RequestDate,StutusId,TypeOfRequestId,LastUpdateBy,LastUpdateDate,DirectorRecommondation")] RequestItem requestItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requestItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "NameEn", requestItem.ItemId);
            ViewBag.StutusId = new SelectList(db.RequestStatus, "RequestStatusId", "NameEn", requestItem.StutusId);
            ViewBag.TypeOfRequestId = new SelectList(db.TypeOfRequests, "TypeOfRequestId", "NameEn", requestItem.TypeOfRequestId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstNameAr", requestItem.UserId);
            return View(requestItem);
        }

        // GET: RequestItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestItem requestItem = db.RequestItems.Find(id);
            if (requestItem == null)
            {
                return HttpNotFound();
            }
            return View(requestItem);
        }

        // POST: RequestItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequestItem requestItem = db.RequestItems.Find(id);
            db.RequestItems.Remove(requestItem);
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
