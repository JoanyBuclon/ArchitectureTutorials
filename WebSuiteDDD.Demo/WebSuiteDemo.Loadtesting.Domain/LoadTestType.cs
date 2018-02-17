using System;
using WebSuiteDDD.SharedKernel.Domain;

namespace WebSuiteDemo.Loadtesting.Domain
{
    /// <summary>
    /// The type Entity of the LoadTest
    /// </summary>
    public class LoadTestType : EntityBase<Guid>
    {
        /// <summary>
        /// The description for the type of test.
        /// </summary>
        public Description Description { get; private set; }

        /// <summary>
        /// Private parameterless constructor required by EntityFramework.
        /// </summary>
        private LoadTestType() : base(Guid.NewGuid()) { }

        /// <summary>
        /// The constructor for the type of test.
        /// </summary>
        /// <param name="guid">The <see cref="Guid"/> unique identifier for this loadTestType entity.</param>
        /// <param name="shortDescription">A short description of the type.</param>
        /// <param name="longDescription">A long description of the type.</param>
        public LoadTestType(Guid guid, string shortDescription, string longDescription) : base(guid)
        {
            Description = new Description(shortDescription, longDescription);
        }
    }
}
