using System;

namespace WebSuiteDDD.SharedKernel.Domain
{
    /// <summary>
    /// Base class for all ValueObject. Those objects doesn't have any Id property and are identified by their properties.
    /// </summary>
    /// <typeparam name="T">The type of the ValueObject</typeparam>
    public abstract class ValueObjectBase<T> : IEquatable<T> where T : ValueObjectBase<T>
    {
        /// <summary>
        /// A ValueObject must define it's own Equality.
        /// </summary>
        /// <param name="other">The compared ValueObject.</param>
        /// <returns>
        ///     <c>True</c> if they are the same ; otherwise, <c>False</c>.
        /// </returns>
        public abstract bool Equals(T other);

        /// <summary>
        /// A ValueObject must define it's own Equality.
        /// </summary>
        /// <param name="obj">The compared object.</param>
        /// <returns>
        ///     <c>True</c> if they are the same ; otherwise, <c>False</c>.
        /// </returns>
        public abstract override bool Equals(object obj);

        /// <summary>
        /// A ValueObject must define it's own GetHashCode.
        /// </summary>
        /// <returns>The ValueObject's HashCode.</returns>
        public abstract override int GetHashCode();
    }
}
