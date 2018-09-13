using ExaltedHelper.Domain.Base;

namespace ExaltedHelper.Domain.Entities
{
    public class CraftType : EntityBase<int>
    {
        public virtual  string Name { get; set; }
        public virtual bool Mundane { get; set; }
        public virtual string Description { get; set; }
    }
}