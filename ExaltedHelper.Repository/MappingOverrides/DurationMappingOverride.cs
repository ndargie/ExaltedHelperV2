using ExaltedHelper.Domain.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace ExaltedHelper.Repository.MappingOverrides
{
    public class DurationMappingOverride : IAutoMappingOverride<Duration>
    {
        public void Override(AutoMapping<Duration> mapping)
        {
            mapping.Map(x => x.Name).Length(30).Not.Nullable().Unique();
            mapping.Map(x => x.Description).Length(200).Not.Nullable();
            mapping.Map(x => x.Status).Length(20).Not.Nullable();
        }
    }
}