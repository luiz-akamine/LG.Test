using LG.Test.Domain.Interfaces.Applications;
using LG.Test.Domain.Interfaces.Infra;
using LG.Test.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace LG.Test.Application
{
    public class ApplicationBase<TEntity> : IApplicationBase, IDBApplicationBase<TEntity> where TEntity : class
    {
        private readonly IDBServiceBase<TEntity> _serviceBase;
        private readonly IUnitOfWorkService _uow;

        public ApplicationBase(IUnitOfWorkService uow)
        {
            _uow = uow;
            _serviceBase = _uow.Service<IDBServiceBase<TEntity>>();
        }

        public void Add(TEntity obj)
        {            
            _serviceBase.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _serviceBase.Delete(obj);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }


        public IEnumerable<TEntity> Find(Func<TEntity, bool> expr)
        {
            return _serviceBase.Find(expr);
        }

        public TEntity Get(Func<TEntity, bool> expr)
        {
            return _serviceBase.Get(expr);
        }
    }
}
