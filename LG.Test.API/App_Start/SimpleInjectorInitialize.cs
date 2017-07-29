using CommonServiceLocator.SimpleInjectorAdapter;
using LG.Test.API.App_Start;
using LG.Test.Application;
using LG.Test.Domain.Interfaces.Applications;
using LG.Test.Domain.Interfaces.Infra;
using LG.Test.Domain.Interfaces.Repositories;
using LG.Test.Domain.Interfaces.Services;
using LG.Test.Infra.Data;
using LG.Test.Infra.Repositories;
using LG.Test.Services;
using Microsoft.Practices.ServiceLocation;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;
using WebActivator;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]
namespace LG.Test.API.App_Start
{
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            Bindings.Start(container);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }

    public static class Bindings
    {
        public static void Start(Container container)
        {
            //Infra
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Scoped);
            container.Register(typeof(ICategoryRepository), typeof(CategoryRepository), Lifestyle.Scoped);
            container.Register(typeof(IProductRepository), typeof(ProductRepository), Lifestyle.Scoped);
            container.Register(typeof(IStockRepository), typeof(StockRepository), Lifestyle.Scoped);
            container.Register(typeof(IStockMovRepository), typeof(StockMovRepository), Lifestyle.Scoped);
            container.Register(typeof(IUserRepository), typeof(UserRepository), Lifestyle.Scoped);
            
            //Services
            container.Register<IUnitOfWorkService, UnitOfWorkService>(Lifestyle.Scoped);

            //Application
            container.Register(typeof(IDBApplicationBase<>), typeof(ApplicationBase<>), Lifestyle.Scoped);
            container.Register(typeof(ICategoryApplication), typeof(CategoryApplication), Lifestyle.Scoped);
            container.Register(typeof(IProductApplication), typeof(ProductApplication), Lifestyle.Scoped);
            container.Register(typeof(IStockApplication), typeof(StockApplication), Lifestyle.Scoped);
            container.Register(typeof(IStockMovApplication), typeof(StockMovApplication), Lifestyle.Scoped);
            container.Register(typeof(IUserApplication), typeof(UserApplication), Lifestyle.Scoped);
            
            //ServiceLocator
            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));
        }
    }
}