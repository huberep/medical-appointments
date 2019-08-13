using System.Web.Mvc;

namespace MedicalAppointments.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}