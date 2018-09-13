using ExaltedHelper.DatabaseFactories.Contracts;
using ExaltedHelper.Domain.Entities;
using ExaltedHelper.Repositories.Repositories;
using NHibernate;

namespace ExaltedHelper.Repository.Repositories
{
    public class DurationRepository : RepositoryBase<Duration, int>, IRepository<Duration, int>
    {
        public DurationRepository(ISession session) : base(session)
        {
        }
    }
}