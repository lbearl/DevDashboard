using System.Web.Mvc;

namespace StatusBoard.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}