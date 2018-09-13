using System;

namespace ExaltedHelper.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void CloseSession();
        void Rollback();
        void SaveChanges();
        void SaveChangesKeepSessionOpen();
        void StartTransactionIfNeeded();
    }
}