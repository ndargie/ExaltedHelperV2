using ExaltedHelper.Domain.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace ExaltedHelper.Repository.MappingOverrides
{
    public class ChramMappingOverride : IAutoMappingOverride<Charm>
    {
        public void Override(AutoMapping<Charm> mapping)
        {
            mapping.HasMany(item => item.Prerequisites).AsSet().Cascade.None();
            mapping.HasMany(item => item.Keywords).AsSet().Cascade.None();
            mapping.Map(x => x.Name).Length(80).Not.Nullable().Index("Idx_Charm_Name");
            mapping.Map(x => x.CharmType).Not.Nullable().Index("Idx_Charm_CharmType");
            mapping.Map(x => x.Description).Length(3000).Not.Nullable();
            mapping.Map(x => x.Duration).Not.Nullable().Index("Idx_Charm_Duration");
            mapping.Map(x => x.Health).Not.Nullable();
            mapping.Map(x => x.Keywords).Not.Nullable();
            mapping.Map(x => x.Motes).Not.Nullable();
            mapping.Map(x => x.Skill).Not.Nullable().Index("Idx_Charm_Skill");
            mapping.Map(x => x.Willpower).Not.Nullable();
            mapping.Map(x => x.Speed).Nullable();
            mapping.Map(x => x.DV).Nullable();
        }
    }
}