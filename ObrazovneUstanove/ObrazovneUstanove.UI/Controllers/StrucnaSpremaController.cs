using System.Linq;
using System.Web.Mvc;
using ObrazovneUstanove.Service;

namespace ObrazovneUstanove.UI.Controllers
{
    public class StrucnaSpremaController : Controller
    {
        private readonly IServiceContainer ServiceContainer;

        public StrucnaSpremaController(IServiceContainer ServiceContainer)
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
            var data = ServiceContainer.StrucnaSpremaService.GetAll().OrderBy(o => o.Naziv)
                        .Select(o => new
                        {
                            Value = o.StrucnaSpremaId,
                            DisplayText = o.Naziv,
                        }).ToList();

            return Json(new { Result = "OK", Options = data });
        }
    }
}