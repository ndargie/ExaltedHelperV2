using ExaltedHelper.DatabaseFactories.Contracts;
using ExaltedHelper.Domain.Entities;
using ExaltedHelper.Repositories.Repositories;
using NHibernate;

namespace ExaltedHelper.Repository.Repositories
{
    public class CharmTypeRepository : RepositoryBase<CharmType, int>, IRepository<CharmType, int>
    {
        public CharmTypeRepository(ISession session) : base(session)
        {
        }
    }
}