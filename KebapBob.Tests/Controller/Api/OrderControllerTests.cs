using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Principal;
using Moq;
using EcommerceService.Services;
using KebapBob.Controllers;
using System.Collections.Generic;

namespace KebapBob.Tests.Controller.Api
{
    [TestClass]
    public class OrderControllerTests
    {
        private OrderController _controller;

        public OrderControllerTests()
        {
            var identity = new GenericIdentity("test1");
            identity.AddClaim(
                new System.Security.Claims.Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "test1"));
            identity.AddClaim(
                new System.Security.Claims.Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "4003"));

            var principal = new GenericPrincipal(identity, null);
            var userid = 4003;

            var mockOS = new Mock<IOrderService>();
            _controller = new OrderController(mockOS.Object);
            _controller.CurrentIdentity.UserId = userid;
        }

        [TestMethod]
        public void GetOrders()
        {
            
        }
    }
}
