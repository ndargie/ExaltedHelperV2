using ExaltedHelper.Domain.Base;

namespace ExaltedHelper.Domain.Entities
{
    public class CharmType : EntityBase<int>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}