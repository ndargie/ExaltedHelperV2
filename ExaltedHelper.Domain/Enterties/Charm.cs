using System.Collections.Generic;
using ExaltedHelper.Domain.Base;
using ExaltedHelper.Domain.Enterties;

namespace ExaltedHelper.Domain.Entities
{
    public class Charm : EntityBase<int>
    {
        public virtual string Name { get; set; }
        public virtual int Motes { get; set; }
        public virtual int Health { get; set; }
        public virtual int Willpower { get; set; }
        public virtual ICollection<Keyword> Keywords { get; set; }
        public virtual Duration Duration { get; set; }
        public virtual string Description { get; set; }
        public virtual CharmType CharmType { get; set; }
        public virtual Skill Skill { get; set; }
        public virtual ICollection<Charm> Prerequisites { get; set; }
        public virtual int? Speed { get; set; }
        public virtual int? DV { get; set; }
    }
}