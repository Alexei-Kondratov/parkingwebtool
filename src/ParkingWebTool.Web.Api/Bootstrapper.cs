using System.Web.Mvc;
using ParkingWebTool.Data;
using ParkingWebTool.Data.MongoDB;
using ParkingWebTool.Web.Api.TypeMappers;
using System.Web.Http;
using ParkingWebTool.Web.Common;
using Microsoft.Practices.Unity;
using System.Web.Http.Dispatcher;
using ParkingWebTool.Common;

namespace ParkingWebTool.Web.Api
{
  public class Bootstrapper
  {
      //IUnityContainer _container;

    public void Initialise()
    {
        var container = BuildUnityContainer();

        GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
    }

    //public IUnityContainer Container 
    //{
    //    get { return _container; }
    //}

    private IUnityContainer BuildUnityContainer()
    {
        var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers
        ConfigureMongoMappings();

        ConfigureLogger(container);
      // e.g. container.RegisterType<ITestService, TestService>();    
        RegisterTypes(container);

        return container;
    }

    private void ConfigureMongoMappings()
    {
        MongoClassMapper.InitClassMappings();
    }

    private void RegisterTypes(IUnityContainer container)
    {
        container.RegisterType<ILogService, TextLogger>();
        container.RegisterInstance<IHttpControllerActivator>(new HttpControllerActivator(container));
        container.RegisterType<IParkingUserMapper, ParkingUserMapper>();
        container.RegisterType<IParkingRepository, ParkingRepository>(new ContainerControlledLifetimeManager());
    }

    /// <summary>
    /// Set up log4net for this application, including putting it in the 
    /// given container.
    /// </summary>
    private void ConfigureLogger(IUnityContainer container)
    {
       //TODO:Select which logger to use (Nlog / Log4net)
    }
  }
}