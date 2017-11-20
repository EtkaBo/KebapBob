using KebapBobModels.ViewModels;
using KebapBobService.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Routing;
using KebapBob.Filters;
using EcommerceService.Services;

namespace KebapBob.Controllers
{
    public class BaseApiController : ApiController {
        public BasicAuthenticationIdentity CurrentIdentity => System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
    
    }
    [ApiAuthenticationFilter]
    [RoutePrefix("Api/Order")]
    public class OrderController : BaseApiController
    {
       private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service; 
        }

        [HttpGet]
        [Route("getOrders")]
        public List<OrderViewModel> getOrders()
        {
            var userid = CurrentIdentity.UserId;
            return _service.GetOrders(userid);
        }

        [HttpPost]
        [Route("updateOrder")]
        public void updateOrder(OrderViewModel order)
        {
            _service.UpdateOrder(order);
        }

        [HttpPost]
        [Route("createOrder")]
        public void createOrder(OrderViewModel newOrder)
        {
            newOrder.UserId = CurrentIdentity.UserId;
            _service.CreateOrder(newOrder);
        }

       
        [HttpPost]
        [Route("deleteOrder")]
        public void deleteOrder(OrderViewModel orderId)
        {
            _service.DeleteOrder(orderId);
        }

    }
}
