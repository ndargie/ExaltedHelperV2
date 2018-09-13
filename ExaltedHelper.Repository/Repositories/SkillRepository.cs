using ExaltedHelper.DatabaseFactories.Contracts;
using ExaltedHelper.Domain.Enterties;
using ExaltedHelper.Domain.Entities;
using ExaltedHelper.Repositories.Repositories;
using NHibernate;

namespace ExaltedHelper.Repository.Repositories
{
    public class SkillRepository : RepositoryBase<Skill, int>, IRepository<Skill, int>
    {
        public SkillRepository(ISession session) : base(session)
        {
        }
    }
}