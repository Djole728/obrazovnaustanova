using System.Web.Mvc;
using ObrazovneUstanove.Service;
using System.Linq;
using ObrazovneUstanove.UI.Models;
using System.Linq.Dynamic;
using ObrazovneUstanove.Domain;
using ObrazovneUstanove.UI.Custom.Extensions;
using System;

namespace ObrazovneUstanove.UI.Controllers
{
    public class KorisnikController : Controller
    {
        private readonly IServiceContainer ServiceContainer;

        public KorisnikController(IServiceContainer ServiceContainer)
        {
            this.ServiceContainer = ServiceContainer;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult List(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            var data = ServiceContainer.KorisnikService.GetAll();

            var list = data.Select(o => new KorisnikViewModel
            {
                KorisnikId = o.KorisnikId,
                Ime = o.Ime,
                Prezime = o.Prezime,
                ImeJednogRoditelja = o.ImeJednogRoditelja,
                Jmb = o.Jmb,
                Pol = o.Pol,
                DatumRodjenja = o.DatumRodjenja,
                MjestoRodjenjaOpstinaId = o.MjestoRodjenjaOpstinaId,
                PrebivalisteNaseljenoMjestoId = o.PrebivalisteNaseljenoMjestoId,
                StrucnaSpremaId = o.StrucnaSpremaId,
                Zanimanje = o.Zanimanje
            }).OrderBy(jtSorting).Skip(jtStartIndex).Take(jtPageSize).ToList();

            return Json(new { Result = "OK", Records = list, TotalRecordCount = data.Count() });
        }

        [HttpPost]
        public JsonResult Create(KorisnikViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Result = "ERROR", Message = ModelState.UserFriendlyErrors() });
            }

            var model = new Korisnik
            {
                Ime = viewModel.Ime,
                Prezime = viewModel.Prezime,
                ImeJednogRoditelja = viewModel.ImeJednogRoditelja,
                Jmb = viewModel.Jmb,
                Pol = viewModel.Pol,
                DatumRodjenja = viewModel.DatumRodjenja,
                MjestoRodjenjaOpstinaId = viewModel.MjestoRodjenjaOpstinaId,
                PrebivalisteNaseljenoMjestoId = viewModel.PrebivalisteNaseljenoMjestoId,
                StrucnaSpremaId = viewModel.StrucnaSpremaId,
                Zanimanje = viewModel.Zanimanje
            };

            viewModel.KorisnikId = ServiceContainer.KorisnikService.AddGetId(model);

            return Json(new { Result = "OK", Record = viewModel });
        }

        [HttpPost]
        public JsonResult Update(KorisnikViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Result = "ERROR", Message = ModelState.UserFriendlyErrors() });
            }

            var model = ServiceContainer.KorisnikService.Get(viewModel.KorisnikId);

            if (model != null)
            {
                model.Ime = viewModel.Ime;
                model.Prezime = viewModel.Prezime;
                model.ImeJednogRoditelja = viewModel.ImeJednogRoditelja;
                model.Jmb = viewModel.Jmb;
                model.Pol = viewModel.Pol;
                model.DatumRodjenja = viewModel.DatumRodjenja;
                model.MjestoRodjenjaOpstinaId = viewModel.MjestoRodjenjaOpstinaId;
                model.PrebivalisteNaseljenoMjestoId = viewModel.PrebivalisteNaseljenoMjestoId;
                model.StrucnaSpremaId = viewModel.StrucnaSpremaId;
                model.Zanimanje = viewModel.Zanimanje;

                ServiceContainer.KorisnikService.Update(model);
            }

            return Json(new { Result = "OK", Record = viewModel });
        }

        [HttpPost]
        public JsonResult Delete(int KorisnikId)
        {
            try
            {
                ServiceContainer.KorisnikService.Delete(KorisnikId);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}