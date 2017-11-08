using KebapBobModels.ViewModels;
using KebapBobService.Services;
using System.Collections.Generic;
using System.Web.Http;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Routing;
using EcommerceService.Filters;

namespace KebapBob.Controllers
{
    public class BaseApiController : ApiController {
        public BasicAuthenticationIdentity CurrentIdentity => System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
    
    }
    [ApiAuthenticationFilter]
    public class OrderController : BaseApiController
    {
       OrderService service;

        public OrderController()
        {
            service = new OrderService();
        }


        [HttpGet]
        [Route("Api/Order/getOrders")]
        public List<OrderViewModel> getOrders()
        {
            return service.GetOrders();
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("Api/Order/updateOrder")]
        public void updateOrder(OrderViewModel order)
        {
            service.UpdateOrder(order);
        }

        [HttpPost]
        [Route("Api/Order/createOrder")]
        public string createOrder(OrderViewModel newOrder)
        {
            newOrder.UserId = CurrentIdentity.UserId;
            return service.CreateOrder(newOrder);
        }

       
        [HttpPost]
        [Route("Api/Order/deleteOrder")]
        public void deleteOrder(OrderViewModel orderId)
        {
            service.DeleteOrder(orderId);
        }

    }
}
