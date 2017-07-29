using System;

namespace LG.Test.Domain.Interfaces.Services
{
    public interface IUnitOfWorkService : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void RollBack();
        T Service<T>() where T : class;
        T Repository<T>() where T : class;
    }
}
