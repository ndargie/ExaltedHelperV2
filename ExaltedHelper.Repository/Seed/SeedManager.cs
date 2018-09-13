using System.Linq;
using ExaltedHelper.Repository.Seed.Interface;
using FluentNHibernate.Conventions;
using Tamarack.Pipeline;

namespace ExaltedHelper.Repository.Seed
{
    public class SeedManager : ISeedManager
    {

        private Pipeline<DatabaseInitializer, bool> _chainOfResponsability;
        private DatabaseInitializer _seedContext;

        public SeedManager(ISeedParams seedParams)
        {
            InicializeChainAndContext(seedParams);
        }

        private void InicializeChainAndContext(ISeedParams seedParams)
        {
            _seedContext = new DatabaseInitializer(seedParams);

            _chainOfResponsability = new Pipeline<DatabaseInitializer, bool>();
            foreach (var seed in SeedFactory.CreateStepDefinitions())
            {
                _chainOfResponsability.Add(seed);
            }
            _chainOfResponsability.Finally(p => p.EndedProcess);
        }

        public void Seed()
        {
            if(!_seedContext.SkillRepository.GetAll().Any())
                _chainOfResponsability.Execute(_seedContext);
        }
    }
}