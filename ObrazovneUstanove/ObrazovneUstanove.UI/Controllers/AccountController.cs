using ObrazovneUstanove.Service;
using ObrazovneUstanove.UI.Custom.Auth;
using ObrazovneUstanove.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ObrazovneUstanove.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IServiceContainer ServiceContainer;
        private ICookieResolver _cookieResolver;
        public AccountController(IServiceContainer ServiceContainer, ICookieResolver cookieResolver)
        {
            this.ServiceContainer = ServiceContainer;
            this._cookieResolver = cookieResolver;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ObrazovneUstanoveLoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var korisnik = ServiceContainer.KorisnikService.GetByUserNameUndPassword(model.UserName, model.Password);

                if (korisnik != null)
                {
                    _cookieResolver.Set(model.UserName, korisnik);
                    return RedirectToAction("Index", "Home");
                }
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "Korisničko ime ili lozinka su neispravni.");
            return View(model);
        }
    }
}