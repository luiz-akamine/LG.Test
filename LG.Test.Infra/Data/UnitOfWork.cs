using LG.Test.Domain.Interfaces.Infra;
using NHibernate;
using System;
using System.Collections.Generic;

namespace LG.Test.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory _sessionFactory;   
        private ITransaction _transaction;

        private static Dictionary<Type, object> _services;
        private static Dictionary<Type, object> _repositories;

        public ISession Session { get; set; }        

        static UnitOfWork()
        {
            _sessionFactory = NHibernateHelper.GetSessionFactory();
            _services = new Dictionary<Type, object>();
            _repositories = new Dictionary<Type, object>();
        }

        public UnitOfWork()
        {
            Session = _sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();

                throw;
            }
            finally
            {
                Session.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                Session.Dispose();
            }
        }        
    }
}
