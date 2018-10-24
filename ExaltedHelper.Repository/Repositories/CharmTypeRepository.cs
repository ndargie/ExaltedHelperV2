using ExaltedHelper.DatabaseFactories.Contracts;
using ExaltedHelper.Domain.Entities;
using NHibernate;

namespace ExaltedHelper.Repository.Repositories
{
    public class CharmTypeRepository : RepositoryBase<CharmType, int>
    {
        public CharmTypeRepository(ISession session) : base(session)
        {
        }
    }
}