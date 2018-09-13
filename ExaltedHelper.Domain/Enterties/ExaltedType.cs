using System.Collections.Generic;
using ExaltedHelper.Domain.Base;
using ExaltedHelper.Domain.Enterties;

namespace ExaltedHelper.Domain.Entities
{
    public class ExaltedType : EntityBase<int>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual ICollection<Caste> Castes { get; set; }
    }
}