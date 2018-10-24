using ExaltedHelper.Domain.Enterties;
using NHibernate;

namespace ExaltedHelper.Repository.Repositories
{
    public class CasteRepository : RepositoryBase<Caste, int>
    {
        public CasteRepository(ISession session) : base(session)
        {
        }
    }
}