using System;

namespace ExaltedHelper.Domain.Base
{

    public abstract class EntityBase
    {

    }

    public abstract class EntityBase<TKey> : EntityBase
    {
        public virtual TKey Id { get; set; }

        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateModified { get; set; }

        public virtual bool Equals(EntityBase<TKey> other)
        {
            bool result = false;
            if (other != null)
            {
                if (ReferenceEquals(this, other))
                {
                    result = true;
                }
                else
                {
                    if (!IsTransient(this) && !IsTransient(other) && Equals(Id, other.Id))
                    {
                        Type otherType = other.GetUnproxiedType();
                        Type thisType = GetUnproxiedType();
                        result = thisType.IsAssignableFrom(otherType) || otherType.IsAssignableFrom(thisType);
                    }
                }
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as EntityBase<TKey>);
        }

        public override int GetHashCode()
        {
            return Equals(Id, default(TKey)) ? base.GetHashCode() : Id.GetHashCode();
        }

        public static bool IsTransient(EntityBase<TKey> obj)
        {
            return obj != null && Equals(obj.Id, default(TKey));
        }

        private Type GetUnproxiedType()
        {
            return GetType();
        }
    }
}