using System;
using ExaltedHelper.Repositories.Contracts;
using NHibernate;

namespace ExaltedHelper.Repositories.DatabaseFactories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        private ITransaction _transaction;
        private bool _isDisposed;

        public UnitOfWork(ISession session)
        {
            _session = session;
            _session.FlushMode = FlushMode.Always;
            _transaction = _session.BeginTransaction();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void CloseSession()
        {
            _session.Flush();
            _session.Clear();
            _session.Close();
        }

        public void Rollback()
        {
            if (_transaction.IsActive)
            {
                _transaction.Rollback();
                _transaction = null;
            }
        }

        public void SaveChanges()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Unit is already saved");
            }

            _transaction.Commit();
            _session.Flush();
            _session.Clear();
            _session.Close();

            _transaction = null;
        }

        public void SaveChangesKeepSessionOpen()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Unit is already saved");
            }

            _transaction.Commit();
            _transaction = null;
        }

        public void StartTransactionIfNeeded()
        {
            if (_transaction == null)
            {
                _transaction = _session.BeginTransaction();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            // If you need thread safety, use a lock around these  
            // operations, as well as in your methods that use the resource. 
            if (_isDisposed)
            {
                return;
            }

            if (disposing)
            {
                if (_transaction != null && _transaction.IsActive)
                {
                    _transaction.Rollback();
                }
                _session.Dispose();
            }

            // Indicate that the instance has been disposed.
            _transaction = null;
            _isDisposed = true;
        }
    }
}