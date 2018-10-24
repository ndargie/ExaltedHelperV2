using ExaltedHelper.Domain.Enterties;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace ExaltedHelper.Repository.MappingOverrides
{
    public class FunctionalityMappingOverride : IAutoMappingOverride<Functionality>
    {
        public void Override(AutoMapping<Functionality> mapping)
        {
            mapping.Map(x => x.Name).Length(30).Not.Nullable();
            mapping.Map(x => x.Description).Length(200).Not.Nullable();
        }
    }
}