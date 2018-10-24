using ExaltedHelper.DatabaseFactories.Contracts;
using ExaltedHelper.Domain.Enterties;
using NHibernate;

namespace ExaltedHelper.Repository.Repositories
{
    public class FunctionalityRepository : RepositoryBase<Functionality, int>
    {
        public FunctionalityRepository(ISession session) : base(session)
        {
            
        }
    }
}