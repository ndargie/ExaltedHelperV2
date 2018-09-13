using ExaltedHelper.DatabaseFactories.Contracts;
using ExaltedHelper.Domain.Enterties;
using ExaltedHelper.Domain.Entities;
using NHibernate;

namespace ExaltedHelper.Repository.Seed.Interface
{
    public interface ISeedParams
    {
        ISession Session { get; set; }
        IRepository<Duration, int> DurationRepsitory { get; set; }
        IRepository<CraftType, int> CraftTypeRepository { get; set; }
        IRepository<Charm, int> CharmRepository { get; set; }
        IRepository<CharmType, int> CharmTypeRepository { get; set; }
        IRepository<Keyword, int> KeywordRepository { get; set; }
        IRepository<Skill, int> SkillRepository { get; set; }
        IRepository<ExaltedType, int> ExaltedTypeRepsitory { get; set; }
        IRepository<Caste, int> CasteRepository { get; set; }
    }
}