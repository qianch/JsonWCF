using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCWService.Domain.SeedWork
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract partial class Entity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public int ID { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity);
        }

        private static bool IsTransient(Entity obj)
        {
            return obj != null && Equals(obj.ID, default(int));
        }

        private Type GetUnproxiedType()
        {
            return GetType();
        }

        public virtual bool Equals(Entity other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (!IsTransient(this) &&
                !IsTransient(other) &&
                Equals(ID, other.ID))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                        otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        public override int GetHashCode()
        {
            if (Equals(ID, default(int)))
                return base.GetHashCode();
            return ID.GetHashCode();
        }

        public static bool operator ==(Entity x, Entity y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(Entity x, Entity y)
        {
            return !(x == y);
        }
    }
}
