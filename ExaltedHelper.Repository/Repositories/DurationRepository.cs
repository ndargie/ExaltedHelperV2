using ExaltedHelper.Domain.Entities;
using NHibernate;

namespace ExaltedHelper.Repository.Repositories
{
    public class DurationRepository : RepositoryBase<Duration, int>
    {
        public DurationRepository(ISession session) : base(session)
        {
        }
    }
}