using ExaltedHelper.Domain.Entities;
using NHibernate;

namespace ExaltedHelper.Repository.Repositories
{
    public class ExaltedTypeRepository : RepositoryBase<ExaltedType, int>
    {
        public ExaltedTypeRepository(ISession session) : base(session)
        {
        }
    }
}