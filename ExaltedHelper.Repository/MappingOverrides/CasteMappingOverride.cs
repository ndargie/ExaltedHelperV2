using ExaltedHelper.Domain.Enterties;
using ExaltedHelper.Domain.Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace ExaltedHelper.Repository.MappingOverrides
{
    public class CasteMappingOverride : IAutoMappingOverride<Caste>
    {
        public void Override(AutoMapping<Caste> mapping)
        {
            mapping.Map(x => x.Name).Length(30).Not.Nullable();
            mapping.Map(x => x.Description).Length(200).Not.Nullable();
            mapping.References(x => x.ExaltedType).Not.Nullable().Index("Idx_Caste_ExaltedType");
        }
    }
}