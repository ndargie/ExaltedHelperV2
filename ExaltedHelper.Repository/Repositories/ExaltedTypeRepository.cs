using ExaltedHelper.DatabaseFactories.Contracts;
using ExaltedHelper.Domain.Entities;
using ExaltedHelper.Repositories.Repositories;
using NHibernate;

namespace ExaltedHelper.Repository.Repositories
{
    public class ExaltedTypeRepository : RepositoryBase<ExaltedType, int>, IRepository<ExaltedType, int>
    {
        public ExaltedTypeRepository(ISession session) : base(session)
        {
        }
    }
}