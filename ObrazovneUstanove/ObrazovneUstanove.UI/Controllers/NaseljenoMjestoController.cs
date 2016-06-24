using System.Linq;
using System.Web.Mvc;
using ObrazovneUstanove.Service;

namespace ObrazovneUstanove.UI.Controllers
{
    public class NaseljenoMjestoController : Controller
    {
        private readonly IServiceContainer ServiceContainer;

        public NaseljenoMjestoController(IServiceContainer ServiceContainer)
        {
            this.ServiceContainer = ServiceContainer;
        }
        // GET: Opstina
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Options()
        {
            var data = ServiceContainer.NaseljenoMjestoService.GetAll().OrderBy(o => o.Naziv)
                        .Select(o => new
                        {
                            Value = o.NaseljenoMjestoId,
                            DisplayText = o.Naziv,
                        }).ToList();

            return Json(new { Result = "OK", Options = data });
        }
    }
}