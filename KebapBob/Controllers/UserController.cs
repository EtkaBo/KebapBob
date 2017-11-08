using EcommerceService.UnitOfWork;
using KebapBobModels.ViewModels;
using KebapBobService.Services;
using System.Web.Http;
using System.Web.Routing;


namespace KebapBob.Controllers
{
    public class UserController : ApiController
    {
        UserService service;

        public UserController()
        {
            service = new UserService();
        }

        [Route("Home/Api/User/Register")]
        [HttpPost]
        public void register(UserViewModel user)
        {
            service.Register(user);
        }
    }
}
