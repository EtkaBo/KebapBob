using System.Web.Mvc;

namespace KebapBob.Controllers
{
    public class HomeController : Controller
    {
     
        // GET: Home
  
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