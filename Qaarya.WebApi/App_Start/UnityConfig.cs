using Microsoft.Practices.Unity;
using Qaarya.Services.Interfaces;
using Qaarya.Services.Services;
using Qaarya.Repository.Interfaces;
using Qaarya.Repository.Repository;
using Qaarya.WebApi.Controllers;
using System.Web.Http;
using System.Web.Mvc;
using Unity.WebApi;
using Qaarya.Repository.Repositories;

namespace Qaarya.WebApi
{
    public static class UnityConfig
    {
        public static IUnityContainer Initialise()
        {
            var container = RegisterComponents();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        public static IUnityContainer RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<AccountController>(new InjectionConstructor());
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            ///------------------------------------------------------
            // Services Registerations
            ///------------------------------------------------------
            container.RegisterType<IServiceService, ServiceService>();
            container.RegisterType<IProfileService, ProfileService>();

            ///------------------------------------------------------
            // Repositories Registerations
            ///------------------------------------------------------
            container.RegisterType<IServiceRepository, ServiceRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<ICategoryCollectionRepository, CategoryCollectionRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IProfileRepository, ProfileRepository>();
            container.RegisterType<IGenderRepository, GenderRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            return container;
        }
    }
}