using DevicesRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace DevicesRequest.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private DevicesRequestDBContext db = new DevicesRequestDBContext();
        // GET: /auth/login

        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Utilities.KSUHSDomainUser UserLoginData = new Utilities.KSUHSDomainUser(model.UserID, model.Password);

            if (UserLoginData.IsValid)

            {
                var identity = new ClaimsIdentity("DevicesRequestCookie");
                var user = db.Users.SingleOrDefault(e => "kk" + e.JobNumber == model.UserID);
                if (db.Users.SingleOrDefault(e => "kk" + e.JobNumber == model.UserID) != null)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, user.UserRoles.First().Role.NameEn));
                    identity.AddClaim(new Claim(ClaimTypes.Name, model.UserID));
                    identity.AddClaim(new Claim("UserId", user.UserId.ToString()));
                }

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;
                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }
            // user authN failed
            ModelState.AddModelError("", "Invalid email or password");
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
    }
}