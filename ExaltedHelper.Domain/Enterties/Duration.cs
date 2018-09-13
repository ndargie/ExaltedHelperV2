using ExaltedHelper.Domain.Base;

namespace ExaltedHelper.Domain.Entities
{
    public class Duration : EntityBase<int>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}