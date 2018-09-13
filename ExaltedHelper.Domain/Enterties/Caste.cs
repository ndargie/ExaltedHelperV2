using ExaltedHelper.Domain.Base;
using ExaltedHelper.Domain.Entities;

namespace ExaltedHelper.Domain.Enterties
{
    public class Caste : EntityBase<int>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual ExaltedType ExaltedType { get; set; }
    }
}