using LG.Test.Domain.Interfaces.Services;
using LG.Test.Infra.Data;
using LG.Test.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LG.Test.Services
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private UnitOfWork _uow;
        private Dictionary<Type, object> _services;
        private Dictionary<Type, object> _repositories;

        public UnitOfWorkService()
        {
            _uow = new UnitOfWork();
            _services = new Dictionary<Type, object>();
            _repositories = new Dictionary<Type, object>();
        }        

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.Commit();
        }

        public void RollBack()
        {
            _uow.Rollback();
        }

        public T Service<T>() where T : class
        {
            if (_services.Keys.Contains(typeof(T)))
                return _services[typeof(T)] as T;

            var iType = typeof(T);
            var sType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(el => !el.IsInterface && iType.IsAssignableFrom(el));
            var service = (T)Activator.CreateInstance(sType, this);
            _services.Add(typeof(T), service);
            return service;
        }

        public T Repository<T>() where T : class
        {
            if (_repositories.Keys.Contains(typeof(T)))
                return _repositories[typeof(T)] as T;

            var iType = typeof(T);
            var sType = typeof(RepositoryBase<>).Assembly.GetTypes().FirstOrDefault(el => !el.IsInterface && iType.IsAssignableFrom(el));
            var repo = (T)Activator.CreateInstance(sType, _uow);
            _repositories.Add(typeof(T), repo);
            return repo;
        }

        public void Dispose()
        {
            
        }
    }
}
