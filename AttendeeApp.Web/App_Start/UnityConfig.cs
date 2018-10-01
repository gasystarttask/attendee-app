using System.Web.Mvc;
using AttendeeApp.Core.Interface;
using AttendeeApp.Infrastructure.Repository;
using Unity;
using Unity.Mvc5;

namespace AttendeeApp.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}