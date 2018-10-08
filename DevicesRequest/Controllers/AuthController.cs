using DevicesRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace DevicesRequest.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private DevicesRequestDBContext db = new DevicesRequestDBContext();
        private int id;

        // GET: /auth/login

        [AllowAnonymous]
        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult LogIn(LogInModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    Utilities.KSUHSDomainUser UserLoginData = new Utilities.KSUHSDomainUser(model.UserID, model.Password);

        //    if (UserLoginData.IsValid)

        //    {
        //        if (db.Users.Where(u => "kk" + u.JobNumber == model.UserID).Count() == 0)
        //        {
        //            User userNew = new User();
        //            //userNew.JobNumber = Regex.Replace(model.UserID, "[kk]", "");
        //            userNew.JobNumber = (Regex.Replace(model.UserID, "[kk]", ""));
        //            userNew.CreatedDate = DateTime.Today;
        //            userNew.CereatedBy = "System";
        //            userNew.UserEmail = UserLoginData.emailID;
        //            userNew.Mobile = UserLoginData.MobileNo;
        //            UserRole UserRole = new UserRole
        //            {
        //                RoleId = db.Roles.Where(r => r.NameEn == "End User").First().RoleId,
        //                UserId = userNew.UserId,
        //                CreatedBy = "System",
        //                CreatedDate = DateTime.Today.ToString(),
        //                Active = true,
        //            };

        //            db.Users.Add(userNew);
        //            db.UserRoles.Add(UserRole);
        //            db.SaveChanges();

        //        }

        //        var user = db.Users.SingleOrDefault(e =>"kk"+ e.JobNumber == model.UserID);
        //        string role = user.UserRoles.FirstOrDefault().Role.NameEn;
        //        if (db.Users.SingleOrDefault(e => "kk"+e.JobNumber == model.UserID) != null)
        //        {
        //            var identity = new ClaimsIdentity("DevicesRequestCookie");
        //            identity.AddClaim(new Claim(ClaimTypes.Name, model.UserID));
        //            identity.AddClaim(new Claim(ClaimTypes.Role, role));
        //            identity.AddClaim(new Claim("UserId", user.UserId.ToString()));
        //            var ctx = Request.GetOwinContext();
        //            var authManager = ctx.Authentication;
        //            authManager.SignIn(identity);
        //            if(user.FirstNameAr == null)
        //            {
        //                return RedirectToAction("Edit", "Users", new { id = user.UserId });

        //            }
        //            return Redirect(GetRedirectUrl(model.ReturnUrl));
        //        }

        //    }
        //    // user authN failed
        //    ModelState.AddModelError("", "Invalid email or password");
        //    return View();
        //}



        ///////////////////
        ///Sample Login

        public ActionResult LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (db.Users.Where(u => u.JobNumber == model.UserID).Count() == 0)
            {
                User userNew = new User();
                //userNew.JobNumber = Regex.Replace(model.UserID, "[kk]", "");
                userNew.JobNumber = (Regex.Replace(model.UserID, "[kk]", ""));
                userNew.CreatedDate = DateTime.Today;
                userNew.CereatedBy = "System";
                userNew.FirstNameEn = model.UserID;
                userNew.LastNameEn = model.UserID;
                userNew.UserEmail = model.UserID + "@" + model.UserID + ".com";
                UserRole UserRole = new UserRole
                {
                    RoleId = db.Roles.Where(r => r.NameEn == "End User").First().RoleId,
                    UserId = userNew.UserId,
                    CreatedBy = "System",
                    CreatedDate = DateTime.Today.ToString(),
                    Active = true,
                };

                db.Users.Add(userNew);
                db.UserRoles.Add(UserRole);
                db.SaveChanges();

            }

            var user = db.Users.SingleOrDefault(e => e.JobNumber == model.UserID);
            string role = user.UserRoles.FirstOrDefault().Role.NameEn;
            if (db.Users.SingleOrDefault(e => e.JobNumber == model.UserID) != null)
            {
                var identity = new ClaimsIdentity("DevicesRequestCookie");
                identity.AddClaim(new Claim(ClaimTypes.Name, model.UserID));
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
                identity.AddClaim(new Claim("UserId", user.UserId.ToString()));
                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;
                authManager.SignIn(identity);
                if (user.FirstNameAr == null)
                {
                    return RedirectToAction("Edit", "Users", new { id = user.UserId });

                }
                return RedirectToAction("Index", "RequestItems");
            }
            return View();
        }


        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }

        [AllowAnonymous]

        public ActionResult LogOff()

        {

            var ctx = Request.GetOwinContext();

            var authManager = ctx.Authentication;



            authManager.SignOut("DevicesRequestCookie");

            return RedirectToAction("index", "home");

        }
    }
}