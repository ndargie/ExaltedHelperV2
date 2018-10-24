using ExaltedHelper.Domain.Entities;
using NHibernate;

namespace ExaltedHelper.Repository.Repositories
{
    public class KeywordRepository : RepositoryBase<Keyword, int>
    {
        public KeywordRepository(ISession session) : base(session)
        {
        }
    }
}