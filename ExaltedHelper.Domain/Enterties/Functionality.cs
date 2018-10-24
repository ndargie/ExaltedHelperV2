using ExaltedHelper.Domain.Base;

namespace ExaltedHelper.Domain.Enterties
{
    public class Functionality : EntityBase<int>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}