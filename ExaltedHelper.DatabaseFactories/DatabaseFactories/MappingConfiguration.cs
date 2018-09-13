using System;
using System.Collections.Generic;
using ExaltedHelper.Domain.Base;
using FluentNHibernate;
using FluentNHibernate.Automapping;

namespace ExaltedHelper.Repositories.DatabaseFactories
{
    public class MappingConfiguration : DefaultAutomappingConfiguration
    {
        private static readonly IList<string> IgnoredMembers = new List<string> {"IsTransient", "EventPublisher"};


        public override bool ShouldMap(Type type)
        {
            return type.Namespace != null && (type == typeof(EntityBase) || type.IsSubclassOf(typeof(EntityBase)));
        }

        public override bool ShouldMap(Member member)
        {
            var result = !IgnoredMembers.Contains(member.Name);

            if (result)
            {
                result = base.ShouldMap(member);
            }
            return result;
        }
    }
}