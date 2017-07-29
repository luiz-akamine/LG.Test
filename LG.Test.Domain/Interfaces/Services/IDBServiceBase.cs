using System;
using System.Collections.Generic;

namespace LG.Test.Domain.Interfaces.Services
{
    public interface IDBServiceBase<TEntity> : IServiceBase where TEntity : class
    {
        void Add(TEntity obj);
        IEnumerable<TEntity> Find(Func<TEntity, bool> expr);
        TEntity Get(Func<TEntity, bool> expr);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Delete(TEntity obj);
    }
}
