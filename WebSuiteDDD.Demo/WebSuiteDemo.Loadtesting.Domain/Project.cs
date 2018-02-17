using System;
using WebSuiteDDD.SharedKernel.Domain;

namespace WebSuiteDemo.Loadtesting.Domain
{
    /// <summary>
    /// A Project is a specific LoadTest and contains it result.
    /// </summary>
    public class Project : EntityBase<Guid>
    {
        /// <summary>
        /// The description of the Project.
        /// </summary>
        public Description Description { get; private set; }

        /// <summary>
        /// Private parameterless constructor required by EntityFramework.
        /// </summary>
        private Project() : base(Guid.NewGuid()) { }

        /// <summary>
        /// The constructor of the project Entity.
        /// </summary>
        /// <param name="id">The <see cref="Guid"/> unique identifier of this entity.</param>
        /// <param name="shortDescription">The short description of the project.</param>
        /// <param name="longDescription">The long description of the project.</param>
        public Project(Guid id, string shortDescription, string longDescription) : base(id)
        {
            Description = new Description(shortDescription, longDescription);
        }
    }
}
