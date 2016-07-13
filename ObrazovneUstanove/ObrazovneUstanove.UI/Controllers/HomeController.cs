using ObrazovneUstanove.UI.Custom.Extensions;
using ObrazovneUstanove.UI.Models;
using System;
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
                    Url = Url.Action("StepOne"),
                    SkipPost = true
                },
                new KorakViewModel
                {
                    KorakId = 2,
                    Naziv = "Drugi korak",
                    RedniBroj = 2,
                    Url = Url.Action("StepTwo"),
                    SkipPost = true
                },
                new KorakViewModel
                {
                    KorakId = 3,
                    Naziv = "Treci korak",
                    RedniBroj = 3,
                    Url = Url.Action("StepOne"),
                    SkipPost = false
                },
                new KorakViewModel
                {
                    KorakId = 4,
                    Naziv = "Cetvrti korak",
                    RedniBroj = 4,
                    Url = Url.Action("StepTwo"),
                    SkipPost = false
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

        public ActionResult StepOne()
        {
            return View();
        }

        [HttpPost]
        public JsonResult StepOne(StepOneViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Result = "ERROR", Message = ModelState.UserFriendlyErrors() });
            }
            return Json(new { Result = "OK" });
        }

        public ActionResult StepTwo()
        {
            return View();
        }

        [HttpPost]
        public JsonResult StepTwo(StepTwoViewModel viewModel)
        {
            return Json(new { Result = "OK" });
        }

        [HttpGet]
        public ActionResult Test()
        {
            var viewModel = new TestViewModel
            {
                TestId = 1,
                TestName = "Djole",
                TestKorisnik = new List<KorisnikViewModel>
                {
                    new KorisnikViewModel
                    {
                        KorisnikId = 1,
                        Ime = "Momo",
                        Prezime = "Todorovic",
                        DatumRodjenja = DateTime.Now,
                        Zanimanje = "Test",
                        MjestoRodjenjaOpstinaId = 1,
                        ImeJednogRoditelja = "Brada",
                        Pol = "M",
                        StrucnaSpremaId = 1,
                       Jmb = "1111111111111",
                       PrebivalisteNaseljenoMjestoId = 1
                    },
                    new KorisnikViewModel
                    {
                        KorisnikId = 1,
                        Ime = "Bobo",
                        Prezime = "Buha",
                        DatumRodjenja = DateTime.Now,
                        Zanimanje = "Test",
                        MjestoRodjenjaOpstinaId = 1,
                        ImeJednogRoditelja = "Brada",
                        Pol = "M",
                        StrucnaSpremaId = 1,
                       Jmb = "1111111111111",
                       PrebivalisteNaseljenoMjestoId = 1
                    },
                }
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Test(TestViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}