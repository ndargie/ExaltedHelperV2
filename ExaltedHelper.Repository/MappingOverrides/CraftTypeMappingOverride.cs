using ExaltedHelper.Domain.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace ExaltedHelper.Repository.MappingOverrides
{
    public class CraftTypeMappingOverride : IAutoMappingOverride<CraftType>
    {
        public void Override(AutoMapping<CraftType> mapping)
        {
            mapping.Map(x => x.Name).Length(30).Not.Nullable().Unique();
            mapping.Map(x => x.Description).Length(200).Not.Nullable();
            mapping.Map(x => x.Mundane).Default("1").Not.Nullable();
        }
    }
}