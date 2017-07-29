using LG.Test.Domain.Entities;
using LG.Test.Domain.Interfaces.Infra;
using LG.Test.Domain.Interfaces.Repositories;
using LG.Test.Infra.Data;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LG.Test.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private UnitOfWork _unitOfWork;
        protected ISession _session { get { return _unitOfWork.Session; } }

        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public void Add(TEntity obj)
        {
            _session.Save(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {                        
            return _session.Query<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            _session.Update(obj, (obj as EntityBase).Id);
            _session.Flush();
        }

        public void Delete(TEntity obj)
        {
            _session.Delete(obj);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> expr)
        {
            return _session.Query<TEntity>().Where(expr);
        }

        public TEntity Get(Func<TEntity, bool> expr)
        {
            return _session.Query<TEntity>().FirstOrDefault(expr);
        }
    }
}
