using ExaltedHelper.DatabaseFactories.Contracts;
using ExaltedHelper.Domain.Entities;
using ExaltedHelper.Repositories.Repositories;
using NHibernate;

namespace ExaltedHelper.Repository.Repositories
{
    public class CraftTypeRepository : RepositoryBase<CraftType, int>, IRepository<CraftType, int>
    {
        public CraftTypeRepository(ISession session) : base(session)
        {
        }
    }
}