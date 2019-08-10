using LibraryManagementSystem_A2.App_Start;
using LibraryManagementSystem_A2.Models;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace LibraryManagementSystem_A2
{
    public static class UnityConfig
    {

        private static void RegisterTypes(UnityContainer container)
        {
            container.RegisterType<IBookDAL, BookDAL>(); //map the IAlbumBL interface to use AlbumBL by default
        }

        public static void RegisterWebApiComponents(HttpConfiguration config)
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            config.DependencyResolver = new UnityResolver(container);
        }
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            RegisterTypes(container);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }

}