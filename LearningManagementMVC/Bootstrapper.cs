using System.Web.Mvc;
using ClientModules.ServiceImplementation;
using Microsoft.Practices.Unity;
using ServiceModules.ServiceModules;
using Unity.Mvc3;

namespace DAL
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IStudentManagementRepository, StudentManagementRepository>();
            // e.g. container.RegisterType<ITestService, TestService>();            

            return container;
        }
    }
}