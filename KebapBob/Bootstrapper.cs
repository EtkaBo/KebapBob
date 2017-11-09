using EcommerceService.Services;
using EcommerceService.UnitOfWork;
using KebapBobService.Services;
using Microsoft.Practices.Unity;
using System.Web.Http;
using System.Web.Mvc;
using Unity.Mvc3;

namespace KebapBob
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // register dependency resolver for WebAPI RC
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();        
            container.RegisterType<IUserService, UserService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<ITokenService, TokenService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IOrderService, OrderService>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());


            return container;
        }
    }
}