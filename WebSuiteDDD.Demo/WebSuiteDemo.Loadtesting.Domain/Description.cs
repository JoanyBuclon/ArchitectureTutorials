using System;
using WebSuiteDDD.SharedKernel.Domain;

namespace WebSuiteDemo.Loadtesting.Domain
{
    /// <summary>
    /// Short and Long description for the Project Entity.
    /// </summary>
    public class Description : ValueObjectBase<Description>
    {
        /// <summary>
        /// The short description string of the Project.
        /// </summary>
        public string ShortDescription { get; private set; }

        /// <summary>
        /// The long description string of the Project.
        /// </summary>
        public string LongDescription { get; private set; }

        /// <summary>
        /// Private parameterless constructor required by EntityFramework.
        /// </summary>
        private Description() { }

        /// <summary>
        /// The Description constructor.
        /// </summary>
        /// <param name="shortDescription">A short description for the project.</param>
        /// <param name="longDescription">A long description for the project.</param>
        public Description(string shortDescription, string longDescription)
        {
            if (string.IsNullOrEmpty(shortDescription)) throw new ArgumentNullException("shortDescription");
            if (string.IsNullOrEmpty(longDescription)) throw new ArgumentNullException("longDescription");
            ShortDescription = shortDescription;
            LongDescription = longDescription;
        }

        /// <summary>
        /// Sets a new Description using only the short description.
        /// </summary>
        /// <param name="shortDescription">A short description for the project.</param>
        /// <returns>A new description.</returns>
        public Description WithShortDescription(string shortDescription)
        {
            return new Description(shortDescription, this.LongDescription);
        }

        /// <summary>
        /// Sets a new Description using only the long description.
        /// </summary>
        /// <param name="longDescription">A long description for the project.</param>
        /// <returns>A new description.</returns>
        public Description WithLongDescription(string longDescription)
        {
            return new Description(this.ShortDescription, longDescription);
        }

        /// <summary>
        /// The comparision between 2 Description object.
        /// </summary>
        /// <param name="other">The second Description object.</param>
        /// <returns>
        ///     <c>True</c> if they are identical ; otherwise, <c>False</c>.
        /// </returns>
        public override bool Equals(Description other)
        {
            return this.ShortDescription.Equals(other.ShortDescription, StringComparison.InvariantCultureIgnoreCase)
                && this.LongDescription.Equals(other.LongDescription, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// The comparision between the Description and another object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>
        ///     <c>True</c> if they are identical ; otherwise, <c>False</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Description)) return false;
            return this.Equals((Description)obj);
        }

        /// <summary>
        /// The HashCode of the descriptions.
        /// </summary>
        /// <returns>The long and short descriptions hashcode concatenated.</returns>
        public override int GetHashCode()
        {
            return this.LongDescription.GetHashCode() + this.ShortDescription.GetHashCode();
        }
    }
}
