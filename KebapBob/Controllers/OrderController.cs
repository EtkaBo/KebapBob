using KebapBobModels.ViewModels;
using KebapBobService.Services;
using System.Collections.Generic;
using System.Web.Http;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Routing;
using KebapBob.Filters;

namespace KebapBob.Controllers
{
    public class BaseApiController : ApiController {
        public BasicAuthenticationIdentity CurrentIdentity => System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
    
    }
    [ApiAuthenticationFilter]
    [RoutePrefix("Api/Order")]
    public class OrderController : BaseApiController
    {
       OrderService service;

        public OrderController()
        {
            service = new OrderService();
        }

        [HttpGet]
        [Route("getOrders")]
        public List<OrderViewModel> getOrders()
        {
            return service.GetOrders();
        }

        [HttpPost]
        [Route("updateOrder")]
        public void updateOrder(OrderViewModel order)
        {
            service.UpdateOrder(order);
        }

        [HttpPost]
        [Route("createOrder")]
        public string createOrder(OrderViewModel newOrder)
        {
            newOrder.UserId = CurrentIdentity.UserId;
            return service.CreateOrder(newOrder);
        }

       
        [HttpPost]
        [Route("deleteOrder")]
        public void deleteOrder(OrderViewModel orderId)
        {
            service.DeleteOrder(orderId);
        }

    }
}
