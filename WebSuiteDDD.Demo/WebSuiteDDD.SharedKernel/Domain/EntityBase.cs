using System;

namespace WebSuiteDDD.SharedKernel.Domain
{
    /// <summary>
    /// Base class for all Entity.
    /// </summary>
    /// <typeparam name="IdType">All Entity possess an unique identifier that can be string, int or any other kind of identifiable element.</typeparam>
    public abstract class EntityBase<IdType> : IEquatable<EntityBase<IdType>>
    {
        /// <summary>
        /// The unique identifier property.
        /// </summary>
        public IdType Id { get; private set; }

        /// <summary>
        /// Constructor for the entities.
        /// </summary>
        /// <param name="id">The unique identifier to use.</param>
        public EntityBase(IdType id)
        {
            Id = id;
        }

        /// <summary>
        /// The Equals operator is verifying if the second object is also an Entity, then it compare the Id.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>
        ///     <c>True</c> if the Entity are the same ; Otherwise <c>False</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj != null
                && obj is EntityBase<IdType>
                && this == (EntityBase<IdType>)obj;
        }

        /// <summary>
        /// Entity are identified by their Id property so the Entity's HashCode come from the Id.
        /// </summary>
        /// <returns>the identifier's Hashcode</returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        /// <summary>
        /// Comparing 2 Entities is as simple as comparing only their respective Id.
        /// </summary>
        /// <param name="entity1">The first Entity to compare.</param>
        /// <param name="entity2">The second Entity to compare.</param>
        /// <returns>
        ///     <c>True</c> if the Id are identical ; otherwise, <c>False</c>.
        /// </returns>
        public static bool operator ==(EntityBase<IdType> entity1, EntityBase<IdType> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
                return true;

            if ((object)entity1 == null || (object)entity2 == null)
                return false;

            if (entity1.Id.ToString() == entity2.Id.ToString())
                return true;

            return false;
        }

        /// <summary>
        /// The inequality between two entity is just checking if their Id is different.
        /// </summary>
        /// <param name="entity1">The first Entity to compare.</param>
        /// <param name="entity2">The second Entity to compare.</param>
        /// <returns>
        ///     <c>True</c> if the Id are different ; otherwise, <c>False</c>.
        /// </returns>
        public static bool operator !=(EntityBase<IdType> entity1, EntityBase<IdType> entity2)
        {
            return (!(entity1 == entity2));
        }

        /// <summary>
        /// The Equals operator is only comparing the Id.
        /// </summary>
        /// <param name="other">The Entity with which we are comparing.</param>
        /// <returns>
        ///     <c>True</c> if the Entity are the same ; Otherwise <c>False</c>.
        /// </returns>
        public bool Equals(EntityBase<IdType> other)
        {
            if (other == null)
                return false;

            return this.Id.Equals(other.Id);
        }
    }
}
