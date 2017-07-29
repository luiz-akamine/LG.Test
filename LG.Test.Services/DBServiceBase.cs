using LG.Test.Domain.Interfaces.Infra;
using LG.Test.Domain.Interfaces.Repositories;
using LG.Test.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG.Test.Services
{
    public class DBServiceBase<TEntity> : ServiceBase, IDBServiceBase<TEntity> where TEntity : class
    {
        protected readonly IRepositoryBase<TEntity> _repository;
        private readonly IUnitOfWorkService _uow;

        public DBServiceBase(IUnitOfWorkService uow)
            : base(uow)
        {
            _uow = uow;
            _repository = uow.Repository<IRepositoryBase<TEntity>>();
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Delete(TEntity obj)
        {
            _repository.Delete(obj);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> expr)
        {
            return _repository.Find(expr);
        }

        public TEntity Get(Func<TEntity, bool> expr)
        {
            return _repository.Get(expr);
        }
    }
}
