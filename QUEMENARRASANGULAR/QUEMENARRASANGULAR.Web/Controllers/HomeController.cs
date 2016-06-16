using System.Web.Mvc;

namespace QUEMENARRASANGULAR.Web.Controllers
{
    public class HomeController : QUEMENARRASANGULARControllerBase
    {
        public ActionResult Index()
        {

           // var location = this.Request.UserHostAddress;

          //  ViewBag["LocationByIP"] = location;
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }




    }
}