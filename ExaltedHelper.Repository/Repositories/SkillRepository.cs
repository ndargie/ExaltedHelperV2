using ExaltedHelper.Domain.Enterties;
using NHibernate;

namespace ExaltedHelper.Repository.Repositories
{
    public class SkillRepository : RepositoryBase<Skill, int>
    {
        public SkillRepository(ISession session) : base(session)
        {
        }
    }
}