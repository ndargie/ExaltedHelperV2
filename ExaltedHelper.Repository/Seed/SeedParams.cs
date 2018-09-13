using ExaltedHelper.DatabaseFactories.Contracts;
using ExaltedHelper.Domain.Enterties;
using ExaltedHelper.Domain.Entities;
using ExaltedHelper.Repository.Seed.Interface;
using NHibernate;

namespace ExaltedHelper.Repository.Seed
{
    public class SeedParams : ISeedParams
    {
        public ISession Session { get; set; }
        public IRepository<Duration, int> DurationRepsitory { get; set; }
        public IRepository<CraftType, int> CraftTypeRepository { get; set; }
        public IRepository<Charm, int> CharmRepository { get; set; }
        public IRepository<CharmType, int> CharmTypeRepository { get; set; }
        public IRepository<Keyword, int> KeywordRepository { get; set; }
        public IRepository<Skill, int> SkillRepository { get; set; }
        public IRepository<ExaltedType, int> ExaltedTypeRepsitory { get; set; }
        public IRepository<Caste, int> CasteRepository { get; set; }

        public SeedParams(ISession session, IRepository<Duration, int> durationRepsitory,
            IRepository<CraftType, int> craftTypeRepository, IRepository<Charm, int> charmRepository,
            IRepository<CharmType, int> charmTypeRepository, IRepository<Keyword, int> keywordRepository,
            IRepository<Skill, int> skillRepository, IRepository<ExaltedType, int> exaltedTypeRepsitory,
            IRepository<Caste, int> casteRepository)
        {
            Session = session;
            DurationRepsitory = durationRepsitory;
            CraftTypeRepository = craftTypeRepository;
            CharmRepository = charmRepository;
            CharmTypeRepository = charmTypeRepository;
            KeywordRepository = keywordRepository;
            SkillRepository = skillRepository;
            ExaltedTypeRepsitory = exaltedTypeRepsitory;
            CasteRepository = casteRepository;
        }
    }
}