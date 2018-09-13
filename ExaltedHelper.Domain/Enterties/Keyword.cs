using ExaltedHelper.Domain.Base;

namespace ExaltedHelper.Domain.Entities
{
    public class Keyword : EntityBase<int>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

    }
}