using EcommerceService.Services;
using EcommerceService.UnitOfWork;
using KebapBobModels.ViewModels;
using KebapBobService.Services;
using System.Web.Http;
using System.Web.Routing;


namespace KebapBob.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
       private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [Route("register")]
        [HttpPost]
        public void register(UserViewModel viewModel)
        {
            _service.Register(viewModel);
        }

        [Route("login")]
        [HttpPost]
        public void login()
        {

        }
    }
}
