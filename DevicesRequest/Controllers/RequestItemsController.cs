using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using DevicesRequest.Models;

namespace DevicesRequest.Controllers
{
    public class RequestItemsController : Controller
    {
        private DevicesRequestDBContext db = new DevicesRequestDBContext();

        // GET: RequestItems
        public ActionResult Index()
        {
            var user = db.Users.Where(u => u.JobNumber == User.Identity.Name).FirstOrDefault();
            var requestItems = db.RequestItems.Include(r => r.Item).Include(r => r.RequestStatu).Include(r => r.TypeOfRequest).Include(r => r.User);

            requestItems = requestItems.Where(r => r.UserId == user.UserId);

            requestItems = requestItems.Where(r => r.UserId == user.UserId && r.RequestStatu.StatusCode == "NDA"
            || r.UserId == user.UserId && r.RequestStatu.StatusCode == "NITA"
            || r.UserId == user.UserId && r.RequestStatu.StatusCode == "NTR"
            || r.UserId == user.UserId && r.RequestStatu.StatusCode == "ABD"
            || r.UserId == user.UserId && r.RequestStatu.StatusCode == "AIT"
            || r.UserId == user.UserId && r.RequestStatu.StatusCode == "RWH"
            || r.UserId == user.UserId && r.RequestStatu.StatusCode == "ITS");

            ViewBag.user = db.Users.Where(u => u.JobNumber == User.Identity.Name).FirstOrDefault(); 

            return View(requestItems.ToList());
        }

        public ActionResult Completed()
        {
            var user = db.Users.Where(u => u.JobNumber == User.Identity.Name).FirstOrDefault();
            var requestItems = db.RequestItems.Include(r => r.Item).Include(r => r.RequestStatu).Include(r => r.TypeOfRequest).Include(r => r.User);

            requestItems = requestItems.Where(r => r.UserId == user.UserId && r.RequestStatu.StatusCode == "DONE"
            || r.UserId == user.UserId && r.RequestStatu.StatusCode == "CANCEL"
            || r.UserId == user.UserId && r.RequestStatu.StatusCode == "RIT"
            || r.UserId == user.UserId && r.RequestStatu.StatusCode == "RBD");
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
            var AllItems = db.RequestItems.Where(a => a.UserId == requestItem.UserId).ToList();

            ViewBag.depManager = db.Users.Where(u => u.JobNumber == User.Identity.Name).FirstOrDefault().UserId;
            ViewBag.Manager = db.Users.Where(u => u.UserId == requestItem.User.Department.ManagerId).FirstOrDefault();

            var Technician = (from User in db.UserRoles
                              where User.Role.NameEn == "Technician"
                              select User.User);
            ViewBag.TechnicianList = Technician.ToList();
            ViewBag.TechnicianCount = Technician.Count();

            var IdTechnician = db.TechnicianReports.Where(u => u.RequestItem.RequestItemsId == requestItem.RequestItemsId).FirstOrDefault();
            if (IdTechnician != null)
            {
                ViewBag.Technician = db.Users.Where(u => u.UserId == IdTechnician.UserId).FirstOrDefault();
            }

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
            // ViewBag.StutusId = new SelectList(db.RequestStatus, "RequestStatusId", "NameEn");
            ViewBag.TypeOfRequestId = new SelectList(db.TypeOfRequests, "TypeOfRequestId", "NameEn");
            //ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstNameAr");
            return View();
        }

        // POST: RequestItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestItemsId,ItemId,UserId,Quantity,RequestDate,StutusId,TypeOfRequestId,LastUpdateBy,LastUpdateDate,DirectorRecommondation")] RequestItem requestItem)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Where(u => u.JobNumber == User.Identity.Name).FirstOrDefault();
                var oldRequest = db.RequestItems.Where(r => r.UserId == user.UserId && r.ItemId == requestItem.ItemId);
                oldRequest = oldRequest.Where(o => o.RequestStatu.StatusCode != "NDA"
                     || o.RequestStatu.StatusCode != "NITA"
                     || o.RequestStatu.StatusCode != "ITS"
                     || o.RequestStatu.StatusCode != "PEND"
                     || o.RequestStatu.StatusCode != "RWH");

                if (oldRequest.Count() != 0)
                {
                    int? lastId =oldRequest.FirstOrDefault().RequestItemsId;
                    TempData["typeAlert"] = "warning";
                    TempData["message"] = "This request is Active";
                    return RedirectToAction("Details", new { id = lastId });
                }

                requestItem.StutusId = db.RequestStatus.Where(s => s.StatusCode == "NDA").First().RequestStatusId;

                if (user.Position.NeedApproved == false)
                {
                    requestItem.StutusId = db.RequestStatus.Where(s => s.StatusCode == "ITS").First().RequestStatusId;
                }
                else
                {
                    requestItem.StutusId = db.RequestStatus.Where(s => s.StatusCode == "NDA").First().RequestStatusId;
                }

                requestItem.UserId = user.UserId;
                requestItem.RequestDate = DateTime.Today.Date;
                requestItem.LastUpdateDate = DateTime.Today;
                requestItem.LastUpdateBy = user.FirstNameEn + " " + user.LastNameEn;

                db.RequestItems.Add(requestItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "NameEn", requestItem.ItemId);
            ViewBag.StutusId = new SelectList(db.RequestStatus, "RequestStatusId", "NameEn", requestItem.StutusId);
            ViewBag.TypeOfRequestId = new SelectList(db.TypeOfRequests, "TypeOfRequestId", "NameEn", requestItem.TypeOfRequestId);
            // ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstNameAr", requestItem.UserId);
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
            // ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstNameAr", requestItem.UserId);
            return View(requestItem);
        }

        // POST: RequestItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestItemsId,ItemId,UserId,Quantity,RequestDate,StutusId,TypeOfRequestId,LastUpdateBy,LastUpdateDate,DirectorRecommondation")] RequestItem requestItem)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Where(u => "kk" + u.JobNumber == User.Identity.Name).FirstOrDefault();

                requestItem.LastUpdateDate = DateTime.Today;
                requestItem.LastUpdateBy = user.FirstNameEn + " " + user.LastNameEn;

                db.Entry(requestItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "NameEn", requestItem.ItemId);
            ViewBag.StutusId = new SelectList(db.RequestStatus, "RequestStatusId", "NameEn", requestItem.StutusId);
            ViewBag.TypeOfRequestId = new SelectList(db.TypeOfRequests, "TypeOfRequestId", "NameEn", requestItem.TypeOfRequestId);
            //ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstNameAr", requestItem.UserId);
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

        public ActionResult status(string approv, int id, string details)
        {
            //var user = db.Users.Where(u => "kk" + u.JobNumber == User.Identity.Name).FirstOrDefault();
            var user = db.Users.Where(u => u.JobNumber == User.Identity.Name).FirstOrDefault();
            RequestItem request = db.RequestItems.Where(r => r.RequestItemsId == id).FirstOrDefault();
            TreatmentHistory treatmentHistory = new TreatmentHistory();

            if (user.Position.NameEn == "Director" && user.UserId == request.User.Department.ManagerId || user.Position.NameEn == "Director" && user.UserRoles.FirstOrDefault().Role.NameEn == "IT Manager")
            {
                switch (Convert.ToInt32(approv))
                {
                    case 1:
                        request.StutusId = db.RequestStatus.Where(s => s.StatusCode == "ITS").First().RequestStatusId;
                        break;
                    case 2:
                        request.StutusId = db.RequestStatus.Where(s => s.StatusCode == "RBD").First().RequestStatusId;
                        request.DirectorRecommondation = details;
                        break;
                    case 3:
                        request.StutusId = db.RequestStatus.Where(s => s.StatusCode == "RWH").First().RequestStatusId;
                        Item item = db.Items.Where(i => i.ItemId == request.ItemId).FirstOrDefault();

                        int? UnitsOnOrder = request.Quantity;
                        int? UnitsInStock = request.Quantity;
                        if (item.UnitsInStock != null && item.UnitsOnOrder != null)
                        {
                            UnitsOnOrder = item.UnitsOnOrder + UnitsOnOrder;
                            UnitsInStock = item.UnitsInStock - UnitsInStock;
                        }


                        item.UnitsOnOrder = UnitsOnOrder;
                        item.UnitsInStock = UnitsInStock;
                        db.Entry(item).State = EntityState.Modified;
                        break;
                    case 4:
                        request.StutusId = db.RequestStatus.Where(s => s.StatusCode == "RIT").First().RequestStatusId;
                        break;
                    default:
                        break;
                }
            }
            if (User.IsInRole("Supervisor"))
            {
                switch (Convert.ToInt32(approv))
                {
                    case 4:
                        request.StutusId = db.RequestStatus.Where(s => s.StatusCode == "RIT").First().RequestStatusId;
                        break;
                    case 5:
                        request.StutusId = db.RequestStatus.Where(s => s.StatusCode == "NITA").First().RequestStatusId;
                        break;
                    case 6:
                        request.StutusId = db.RequestStatus.Where(s => s.StatusCode == "RWH").First().RequestStatusId;
                        Item item = db.Items.Where(i => i.ItemId == request.ItemId).FirstOrDefault();

                        int? UnitsOnOrder = request.Quantity;
                        int? UnitsInStock = request.Quantity;
                        if (item.UnitsInStock != null && item.UnitsOnOrder != null)
                        {
                            UnitsOnOrder = item.UnitsOnOrder + UnitsOnOrder;
                            UnitsInStock = item.UnitsInStock - UnitsInStock;
                        }
                        item.UnitsOnOrder = UnitsOnOrder;
                        item.UnitsInStock = UnitsInStock;
                        db.Entry(item).State = EntityState.Modified;

                        break;
                    case 7:
                        request.StutusId = db.RequestStatus.Where(s => s.StatusCode == "NTR").First().RequestStatusId;
                        break;
                    case 8:
                        request.StutusId = db.RequestStatus.Where(s => s.StatusCode == "PEND").First().RequestStatusId;
                        break;
                    case 10:
                        request.StutusId = db.RequestStatus.Where(s => s.StatusCode == "ITS").First().RequestStatusId;
                        break;
                    default:
                        break;
                }
            }

            if (User.IsInRole("Warehouse Admin"))
            {
                switch (Convert.ToInt32(approv))
                {
                    case 9:
                        request.StutusId = db.RequestStatus.Where(s => s.StatusCode == "DONE").First().RequestStatusId;

                        Item item = db.Items.Where(i => i.ItemId == request.ItemId).FirstOrDefault();

                        int? UnitsOnOrder = request.Quantity;

                        if (UnitsOnOrder != null)
                        {
                            UnitsOnOrder = item.UnitsOnOrder - UnitsOnOrder;
                        }

                        item.UnitsOnOrder = UnitsOnOrder;
                        db.Entry(item).State = EntityState.Modified;

                        break;
                    default:
                        break;
                }
            }

            if (User.IsInRole("Technician"))
            {
                switch (Convert.ToInt32(approv))
                {
                    case 10:
                        request.StutusId = db.RequestStatus.Where(s => s.StatusCode == "ITS").First().RequestStatusId;
                        break;
                    default:
                        break;
                }

            }
            //// History Action
            treatmentHistory.User = user;
            treatmentHistory.RequestItem = request;
            treatmentHistory.RequestStatu = db.RequestStatus.Where(s => s.RequestStatusId == request.StutusId).First();
            treatmentHistory.LastUpdateBy = user.FirstNameEn + " " + user.LastNameEn;
            treatmentHistory.LastUpdateDate = DateTime.Today;
            db.TreatmentHistories.Add(treatmentHistory);

            request.LastUpdateBy = user.FirstNameEn + " " + user.LastNameEn;
            request.LastUpdateDate = DateTime.Today;
            db.Entry(request).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details/" + id);
        }
        public ActionResult NeedTreatment()
        {
            var user = db.Users.Where(u => u.JobNumber == User.Identity.Name).FirstOrDefault();
            var requestItems = db.RequestItems.Include(r => r.Item).Include(r => r.RequestStatu).Include(r => r.TypeOfRequest).Include(r => r.User);

            if (User.IsInRole("End User") && user.Position.NameEn == "Director")
            {
                requestItems = requestItems.Where(r => r.User.DepartmentId == user.DepartmentId && r.User.Department.ManagerId == r.UserId && r.RequestStatu.StatusCode == "NDA");
            }
            if (User.IsInRole("IT Manager"))
            {
                requestItems = requestItems.Where(r => r.RequestStatu.StatusCode == "NITA" || r.RequestStatu.StatusCode == "NDA" && r.User.DepartmentId == user.DepartmentId);
            }

            if (User.IsInRole("Technician"))
            {
                requestItems = requestItems.Where(r => r.RequestStatu.StatusCode == "NTR");
            }

            if (User.IsInRole("Warehouse Admin"))
            {
                requestItems = requestItems.Where(r => r.RequestStatu.StatusCode == "RWH");
            }

            if (User.IsInRole("Supervisor"))
            {
                requestItems = requestItems.Where(r => r.RequestStatu.StatusCode == "ITS" || r.RequestStatu.StatusCode == "PEND");
            }

            return View(requestItems.ToList());
        }

        public ActionResult AddRecommendation(string idRequest, string details)
        {
            var user = db.Users.Where(u => u.JobNumber == User.Identity.Name).FirstOrDefault();
            RequestItem request = db.RequestItems.Find(Convert.ToInt32(idRequest));

            request.DirectorRecommondation = details;
            request.LastUpdateBy = user.FirstNameEn + " " + user.LastNameEn;
            request.LastUpdateDate = DateTime.Today;

            db.Entry(request).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("status", "RequestItems", new { id = idRequest });
        }


    }
}
