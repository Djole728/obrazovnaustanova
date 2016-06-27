using ObrazovneUstanove.UI.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ObrazovneUstanove.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Wizard()
        {
            var koraci = new List<KorakViewModel>()
            {
                new KorakViewModel
                {
                    KorakId = 1,
                    Naziv = "Prvi korak",
                    RedniBroj = 1,
                    Url = Url.Action("About"),
                    SkipPost = false
                },
                new KorakViewModel
                {
                    KorakId = 2,
                    Naziv = "Prvi korak",
                    RedniBroj = 2,
                    Url = Url.Action("Contact"),
                    SkipPost = true
                },
                new KorakViewModel
                {
                    KorakId = 3,
                    Naziv = "Prvi korak",
                    RedniBroj = 3,
                    Url = Url.Action("Test"),
                    SkipPost = true
                },
                new KorakViewModel
                {
                    KorakId = 4,
                    Naziv = "Prvi korak",
                    RedniBroj = 4,
                    Url = Url.Action("Radi"),
                    SkipPost = true
                },
            };

            var viewModel = new PrijavaIndexViewModel
            {
                PredmetId = 5,
                KorakViewModels = koraci,
                ReadOnly = false,
                HideKrajButton = false,
            };

            return View(viewModel);
        }
    }
}