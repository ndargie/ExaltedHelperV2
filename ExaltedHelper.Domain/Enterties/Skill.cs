using ExaltedHelper.Domain.Base;
using ExaltedHelper.Domain.Entities;

namespace ExaltedHelper.Domain.Enterties
{
    public class Skill : EntityBase<int>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual Caste Caste { get; set; }
    }
}