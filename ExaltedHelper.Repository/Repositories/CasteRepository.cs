using ExaltedHelper.DatabaseFactories.Contracts;
using ExaltedHelper.Domain.Enterties;
using ExaltedHelper.Domain.Entities;
using ExaltedHelper.Repositories.Repositories;
using NHibernate;

namespace ExaltedHelper.Repository.Repositories
{
    public class CasteRepository : RepositoryBase<Caste, int>, IRepository<Caste, int>
    {
        public CasteRepository(ISession session) : base(session)
        {
        }
    }
}