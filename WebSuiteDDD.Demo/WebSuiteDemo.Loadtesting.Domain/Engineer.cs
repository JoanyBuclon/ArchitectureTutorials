using System;
using WebSuiteDDD.SharedKernel.Domain;

namespace WebSuiteDemo.Loadtesting.Domain
{
    /// <summary>
    /// The Engineer Entity of the LoadTest, if asked for by the Customer.
    /// </summary>
    public class Engineer : EntityBase<Guid>
    {
        /// <summary>
        /// The name of the Engineer.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Private parameterless constructor required by EntityFramework.
        /// </summary>
        private Engineer() : base(Guid.NewGuid()) { }

        /// <summary>
        /// The constructor of the Engineer Entity.
        /// </summary>
        /// <param name="guid">The <see cref="Guid"/> unique identifier of this Entity.</param>
        /// <param name="name">The name of the Engineer.</param>
        public Engineer(Guid guid, string name) : base(guid)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            Name = name;
        }
    }
}
