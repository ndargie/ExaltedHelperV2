using ExaltedHelper.Domain.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace ExaltedHelper.Repository.MappingOverrides
{
    public class CharmTypeMappingOverride : IAutoMappingOverride<CharmType>
    {
        public void Override(AutoMapping<CharmType> mapping)
        {
            mapping.Map(x => x.Name).Length(30).Not.Nullable().Unique();
            mapping.Map(x => x.Description).Length(200).Not.Nullable();
        }
    }
}