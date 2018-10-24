using ExaltedHelper.Domain.Entities;
using NHibernate;

namespace ExaltedHelper.Repository.Repositories
{
    public class CraftTypeRepository : RepositoryBase<CraftType, int>
    {
        public CraftTypeRepository(ISession session) : base(session)
        {
        }
    }
}