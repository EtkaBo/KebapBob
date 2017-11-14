using KebapBob.Filters;
using System.Web.Mvc;

namespace KebapBob.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        [ApiAuthenticationFilter]
        public ActionResult Index()
        {

            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

      

        
    }
}