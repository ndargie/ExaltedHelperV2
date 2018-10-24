using System;
using System.Linq;
using System.Linq.Expressions;
using ExaltedHelper.DatabaseFactories.Contracts;
using ExaltedHelper.Domain.Base;
using FluentValidation;
using NHibernate;
using NHibernate.Criterion;

namespace ExaltedHelper.Repository.Repositories
{
    public abstract class RepositoryBase<T, TKey> : IRepository<T, TKey> where T : EntityBase<TKey>
    {
        protected ISession Session { get; private set; }
        public AbstractValidator<T> Validator { get; set; }

        protected RepositoryBase(ISession session)
        {
            Session = session;
        }

        public IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public T GetById(TKey key)
        {
            return (T)Session.Get(typeof(T), key);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
           return  Session.Query<T>().Where(predicate).Take(1).FirstOrDefault();
        }

        public IQueryable<T> GetFilteredList(Expression<Func<T, bool>> predicate)
        {
            return Session.Query<T>().Where(predicate);
        }

        public T Save(T domainObject)
        {
            if (this.Validator != null)
            {
                var result = this.Validator.Validate(domainObject);
                if (!result.IsValid)
                {
                    throw new ValidationException(result.Errors);
                }
            }

            var isNewObject = EntityBase<TKey>.IsTransient(domainObject);

            if (isNewObject)
            {
                domainObject.DateCreated = DateTime.Now;
                domainObject.DateModified = DateTime.Now;

                Session.Save(domainObject);
            }
            else
            {
                domainObject.DateModified = DateTime.Now;
                Session.Update(domainObject);
            }
            return domainObject;
        }

        public T SaveOrUpdate(T domainObject)
        {
            Session.SaveOrUpdate(domainObject);

            return domainObject;
        }

        public void Delete(T domainObject)
        {
            Session.Delete(domainObject);
        }

        public void ClearCache()
        {
            Session.Clear();
        }

        public long CountTableRecords<TS>() where TS : class
        {
            var numRecords = Session.CreateCriteria<T>()
                .SetProjection(Projections.RowCountInt64())
                .UniqueResult<long>();
            return numRecords;
        }

        public int DeleteAdo(string tableName)
        {
            var sqlQuery = string.Format("DELETE FROM {0}", tableName);
            var query = Session.CreateSQLQuery(sqlQuery);
            var result = query.UniqueResult();
            return Convert.ToInt32(result);
        }
    }
}