using System;

namespace LG.Test.Domain.Interfaces.Infra
{
    public interface IUnitOfWork 
    {
        void BeginTransaction();
        void Commit();
        void Rollback();        
    }
}
