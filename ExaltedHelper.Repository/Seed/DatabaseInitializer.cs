using ExaltedHelper.DatabaseFactories.Contracts;
using ExaltedHelper.Domain.Enterties;
using ExaltedHelper.Domain.Entities;
using ExaltedHelper.Repository.Seed.Interface;
using NHibernate;

namespace ExaltedHelper.Repository.Seed
{
    public class DatabaseInitializer
    {
        internal bool EndedProcess;
        internal ISession Session;
        internal IRepository<Duration, int> DurationRepository;
        internal IRepository<CraftType, int> CraftTypeRepository;
        internal IRepository<Charm, int> CharmRepository;
        internal IRepository<CharmType, int> CharmTypeRepository;
        internal IRepository<Keyword, int> KeywordRepository;
        internal IRepository<Skill, int> SkillRepository;
        internal IRepository<ExaltedType, int> ExaltedTypeRepository;
        internal IRepository<Caste, int> CasteRepository;
        public DatabaseInitializer(ISeedParams seedParams)
        {
            Session = seedParams.Session;
            DurationRepository = seedParams.DurationRepsitory;
            CraftTypeRepository = seedParams.CraftTypeRepository;
            CharmRepository = seedParams.CharmRepository;
            CharmTypeRepository = seedParams.CharmTypeRepository;
            KeywordRepository = seedParams.KeywordRepository;
            SkillRepository = seedParams.SkillRepository;
            ExaltedTypeRepository = seedParams.ExaltedTypeRepsitory;
            CasteRepository = seedParams.CasteRepository;
        }
    }
}