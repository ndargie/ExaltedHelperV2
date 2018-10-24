using ExaltedHelper.Domain.Entities;
using NHibernate;

namespace ExaltedHelper.Repository.Repositories
{
    public class CharmRepository : RepositoryBase<Charm, int>
    {
        public CharmRepository(ISession session) : base(session)
        {
        }
    }
}