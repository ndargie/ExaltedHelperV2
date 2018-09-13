using System.Collections.Generic;
using ExaltedHelper.Domain.Entities;
using NHibernate.Mapping;

namespace ExaltedHelper.Repository.Seed.Steps
{
    public class SeedCharmTypes : SeedStepDefinition
    {
        protected override void ExecuteStep(ref DatabaseInitializer context)
        {
            List<CharmType> charmTypes = new List<CharmType>()
            {
                new CharmType() { Name = "Supplemental", Description = "Enhances an action"},
                new CharmType() {Name = "Extra Action", Description = "Provides extra actions"},
                new CharmType() {Name = "Permanent", Description = "Activated as soon as you learn the charm"},
                new CharmType() {Name = "Simple", Description = "Simple charm"},
                new CharmType() {Name = "Reflexive", Description = "Can use to react to another action"}
            };

            foreach (var charmType in charmTypes)
            {
                context.CharmTypeRepository.Save(charmType);
            }
        }
    }
}