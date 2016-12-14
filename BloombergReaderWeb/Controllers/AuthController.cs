using BloombergReaderWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;

namespace BloombergReaderWeb.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid) //Checks if input fields have the correct format
            {
                return View(model); //Returns the view with the input values so that the user doesn't have to retype again
            }
            
            // as for now we don't care who tries to login
            if (model.Email == "SomeEmail" && model.Password == "SomePassword" || true)
            {
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, "Andrii"),
                    new Claim(ClaimTypes.Email, "andreytkach85@gmail.com"),
                    new Claim(ClaimTypes.Country, "PlanetEarth")
                    }, "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;
                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            ModelState.AddModelError(string.Empty, "Invalid email or password");
            return View(model); 
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }
            return returnUrl;
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Auth");
        }
    }
}