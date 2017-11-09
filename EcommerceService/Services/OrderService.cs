using DatabaseModel;
using KebapBobModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using EcommerceService.Services;
using System.Web.Http.Controllers;
using System.Threading;
using EcommerceService.Filters;

namespace KebapBobService.Services
{
    public class OrderService : IOrderService
    {
        public List<OrderViewModel> GetOrders()
        {

            using (var context = new KebapBobEntities())
            {

                return context.Order.Select(x => new OrderViewModel
                {
                    Id = x.Id,
                    RecipientName = x.Address.RecipientName,
                    StreetName = x.Address.StreetAddress,
                    City = x.Address.City,
                    State = x.Address.State,
                    ZipCode = x.Address.ZipCode,
                    TrackingNumber = x.TrackingNumber,

                    OrderItems = x.OrderItems.Select(y => new OrderItemViewModel
                    {
                        Quantity = y.Quantity,
                        Product = new ProductViewModel
                        {
                            Id = y.Product.Id,
                            ItemName = y.Product.Name
                        }
                    })
                }).ToList();
            }
        }

        public void UpdateOrder(OrderViewModel vvm)
        {
            using (var context = new KebapBobEntities())
            {
                var thisorder = context.Order
                    .Include(d => d.Address)
                    .FirstOrDefault(x => x.Id == vvm.Id);
                if (thisorder == null)
                {
                    throw new Exception("Record could not found!");
                }

                thisorder.Address.RecipientName = vvm.RecipientName;
                thisorder.Address.StreetAddress = vvm.StreetName;
                thisorder.Address.City = vvm.City;
                thisorder.Address.State = vvm.State;
                thisorder.Address.ZipCode = vvm.ZipCode;

                context.SaveChanges();
            }
        }

        protected int OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            var provider = actionContext.ControllerContext.Configuration
                               .DependencyResolver.GetService(typeof(IUserService)) as IUserService;
                var userId = provider.Authenticate(username, password);
                    var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                    if (basicAuthenticationIdentity != null)
                        basicAuthenticationIdentity.UserId = userId;
                    return userId;
        }


        public string CreateOrder(OrderViewModel vm)
        {

            using (var context = new KebapBobEntities())
            {

                var newOrder = new Order
                {
                TrackingNumber = Guid.NewGuid().ToString(),
                    Address = new Address
                    {

                        StreetAddress = vm.StreetName,
                        City = vm.City,
                        State = vm.State,
                        ZipCode = vm.ZipCode,
                        RecipientName = vm.RecipientName
                    },
                    UserID = vm.UserId
                };

                context.Order.Add(newOrder);
                context.SaveChanges();

                return newOrder.TrackingNumber;
            }

        }



        public void DeleteOrder(OrderViewModel vm)
        {
            using (var context = new KebapBobEntities())
            {

                var thisorder = context.Order.FirstOrDefault(x => x.Id == vm.Id);

                if (thisorder == null)
                {
                    throw new Exception("Record could not found!");
                }
                else
                {
                    thisorder.Id = vm.Id;
                    thisorder.TrackingNumber = vm.TrackingNumber;
                    thisorder.Address = new Address
                    {
                        Id = vm.AddressId,
                        StreetAddress = vm.StreetName,
                        City = vm.City,
                        State = vm.State,
                        ZipCode = vm.ZipCode,
                        RecipientName = vm.RecipientName

                    };
                    context.Order.Attach(thisorder);
                    context.Order.Remove(thisorder);
                    context.SaveChanges();
                }
            }
        }
    }
}


