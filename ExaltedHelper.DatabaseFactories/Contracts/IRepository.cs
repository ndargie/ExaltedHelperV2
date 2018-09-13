using System;
using System.Linq;
using System.Linq.Expressions;
using ExaltedHelper.Domain.Base;
using FluentValidation;

namespace ExaltedHelper.DatabaseFactories.Contracts
{
    public interface IRepository<T, Tkey> where T : EntityBase<Tkey>
    {
        AbstractValidator<T> Validator { get; set; }

        IQueryable<T> GetAll();
        T GetById(Tkey key);
        T Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetFilteredList(Expression<Func<T, bool>> predicate);
        T Save(T domainObject);
        T SaveOrUpdate(T domainObject);
        void Delete(T domainObject);
        void ClearCache();
        long CountTableRecords<TS>() where TS : class;
        int DeleteAdo(string tableName);

    }
}