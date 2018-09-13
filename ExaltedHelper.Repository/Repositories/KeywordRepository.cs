using ExaltedHelper.DatabaseFactories.Contracts;
using ExaltedHelper.Domain.Entities;
using ExaltedHelper.Repositories.Repositories;
using NHibernate;

namespace ExaltedHelper.Repository.Repositories
{
    public class KeywordRepository : RepositoryBase<Keyword, int>, IRepository<Keyword, int>
    {
        public KeywordRepository(ISession session) : base(session)
        {
        }
    }
}