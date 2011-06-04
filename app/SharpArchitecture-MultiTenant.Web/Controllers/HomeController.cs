using System.Web.Mvc;

namespace SharpArchitecture.MultiTenant.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
