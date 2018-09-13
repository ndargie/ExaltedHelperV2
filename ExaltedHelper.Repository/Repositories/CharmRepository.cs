using ExaltedHelper.DatabaseFactories.Contracts;
using ExaltedHelper.Domain.Entities;
using ExaltedHelper.Repositories.Repositories;
using NHibernate;

namespace ExaltedHelper.Repository.Repositories
{
    public class CharmRepository : RepositoryBase<Charm, int>, IRepository<Charm, int>
    {
        public CharmRepository(ISession session) : base(session)
        {
        }
    }
}