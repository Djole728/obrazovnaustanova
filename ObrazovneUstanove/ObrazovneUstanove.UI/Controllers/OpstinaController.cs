using System.Linq;
using System.Web.Mvc;
using ObrazovneUstanove.Service;

namespace ObrazovneUstanove.UI.Controllers
{
    public class OpstinaController : Controller
    {
        private readonly IServiceContainer ServiceContainer;

        public OpstinaController(IServiceContainer ServiceContainer)
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
            var data = ServiceContainer.OpstinaService.GetAll().OrderBy(o => o.Naziv)
                        .Select(o => new
                        {
                            Value = o.OpstinaId,
                            DisplayText = o.Naziv,
                        }).ToList();

            return Json(new { Result = "OK", Options = data });
        }
    }
}