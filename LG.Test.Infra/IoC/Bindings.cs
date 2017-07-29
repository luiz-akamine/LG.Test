using CommonServiceLocator.SimpleInjectorAdapter;
using LG.Test.Application;
using LG.Test.Domain.Interfaces.Applications;
using LG.Test.Domain.Interfaces.Infra;
using LG.Test.Domain.Interfaces.Repositories;
using LG.Test.Domain.Interfaces.Services;
using LG.Test.Infra.Data;
using LG.Test.Infra.Repositories;
using Microsoft.Practices.ServiceLocation;
using SimpleInjector;

namespace LG.Test.Infra.IoC
{
    /*
    public static class Bindings
    {
        public static void Start(Container container)
        {
            //Infra
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Scoped);
            container.Register<ICategoryRepository, CategoryRepository>(Lifestyle.Scoped);
            container.Register<IProductRepository, ProductRepository>(Lifestyle.Scoped);
            container.Register<IStockRepository, StockRepository>(Lifestyle.Scoped);
            container.Register<IStockMovRepository, StockMovRepository>(Lifestyle.Scoped);
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);

            //Services
            //container.Register<IUnitOfWorkService, UnitOfWorkService>(Lifestyle.Scoped);

            //Application
            container.Register(typeof(IDBApplicationBase<>), typeof(ApplicationBase<>), Lifestyle.Scoped);
            container.Register<ICategoryApplication, CategoryApplication>(Lifestyle.Scoped);
            container.Register<IProductApplication, ProductApplication>(Lifestyle.Scoped);
            container.Register<IStockApplication, StockApplication>(Lifestyle.Scoped);
            container.Register<IStockMovApplication, StockMovApplication>(Lifestyle.Scoped);
            container.Register<IUserApplication, UserApplication>(Lifestyle.Scoped);

            //ServiceLocator
            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));
        }
    }
    */
}
