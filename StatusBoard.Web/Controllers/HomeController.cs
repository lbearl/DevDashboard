using System.Web.Mvc;
using StatusBoard.Core;

namespace StatusBoard.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToActionPermanent(Constants.Controller.Actions.Index, Constants.Controller.Dashboard);
        }
    }
}