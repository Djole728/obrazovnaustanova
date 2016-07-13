using ObrazovneUstanove.Domain;
using ObrazovneUstanove.Service;
using ObrazovneUstanove.UI.Custom.Extensions;
using ObrazovneUstanove.UI.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace ObrazovneUstanove.UI.Controllers
{
    public class PolaznikController : Controller
    {
        private readonly IServiceContainer ServiceContainer;

        public PolaznikController(IServiceContainer ServiceContainer)
        {
            this.ServiceContainer = ServiceContainer;
        }
        // GET: Polaznik
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult List(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            var data = ServiceContainer.PolaznikService.GetAll();

            var list = data.Select(o => new PolaznikViewModel
            {
                PolaznikId = o.PolaznikId,
                Ime = o.Ime,
                Prezime = o.Prezime,
                ImeJednogRoditelja = o.ImeJednogRoditelja,
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
        public JsonResult Create(PolaznikViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Result = "ERROR", Message = ModelState.UserFriendlyErrors() });
            }

            var model = new Polaznik
            {
                Ime = viewModel.Ime,
                Prezime = viewModel.Prezime,
                ImeJednogRoditelja = viewModel.ImeJednogRoditelja,
                Pol = viewModel.Pol,
                DatumRodjenja = viewModel.DatumRodjenja,
                MjestoRodjenjaOpstinaId = viewModel.MjestoRodjenjaOpstinaId,
                PrebivalisteNaseljenoMjestoId = viewModel.PrebivalisteNaseljenoMjestoId,
                StrucnaSpremaId = viewModel.StrucnaSpremaId,
                Zanimanje = viewModel.Zanimanje
            };
            model.SkolaId = 1;
            viewModel.PolaznikId = ServiceContainer.PolaznikService.AddGetId(model);

            return Json(new { Result = "OK", Record = viewModel });
        }

        [HttpPost]
        public JsonResult Update(PolaznikViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Result = "ERROR", Message = ModelState.UserFriendlyErrors() });
            }

            var model = ServiceContainer.PolaznikService.Get(viewModel.PolaznikId);

            if (model != null)
            {
                model.Ime = viewModel.Ime;
                model.Prezime = viewModel.Prezime;
                model.ImeJednogRoditelja = viewModel.ImeJednogRoditelja;
                model.Pol = viewModel.Pol;
                model.DatumRodjenja = viewModel.DatumRodjenja;
                model.MjestoRodjenjaOpstinaId = viewModel.MjestoRodjenjaOpstinaId;
                model.PrebivalisteNaseljenoMjestoId = viewModel.PrebivalisteNaseljenoMjestoId;
                model.StrucnaSpremaId = viewModel.StrucnaSpremaId;
                model.Zanimanje = viewModel.Zanimanje;

                ServiceContainer.PolaznikService.Update(model);
            }

            return Json(new { Result = "OK", Record = viewModel });
        }

        [HttpPost]
        public JsonResult Delete(int PolaznikId)
        {
            try
            {
                ServiceContainer.PolaznikService.Delete(PolaznikId);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}