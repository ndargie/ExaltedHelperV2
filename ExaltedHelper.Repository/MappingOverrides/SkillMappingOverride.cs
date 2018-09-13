using ExaltedHelper.Domain.Enterties;
using ExaltedHelper.Domain.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace ExaltedHelper.Repository.MappingOverrides
{
    public class SkillMappingOverride : IAutoMappingOverride<Skill>
    {
        public void Override(AutoMapping<Skill> mapping)
        {
            mapping.Map(x => x.Name).Length(30).Not.Nullable();
            mapping.Map(x => x.Description).Length(200).Not.Nullable();
            mapping.References(x => x.Caste).Index("Idx_Skill_Caste");
        }
    }
}