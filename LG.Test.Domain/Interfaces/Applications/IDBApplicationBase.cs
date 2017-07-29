using System;
using System.Collections.Generic;

namespace LG.Test.Domain.Interfaces.Applications
{
    public interface IDBApplicationBase<TEntity> : IApplicationBase where TEntity : class
    {
        void Add(TEntity obj);
        IEnumerable<TEntity> Find(Func<TEntity, bool> expr);
        TEntity Get(Func<TEntity, bool> expr);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
