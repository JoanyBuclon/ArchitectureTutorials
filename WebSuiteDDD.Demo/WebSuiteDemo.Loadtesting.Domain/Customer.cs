using System;
using WebSuiteDDD.SharedKernel.Domain;

namespace WebSuiteDemo.Loadtesting.Domain
{
    /// <summary>
    /// The Customer Entity of the LoadTest
    /// </summary>
    public class Customer : EntityBase<Guid>
    {
        /// <summary>
        /// The name of the customer.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Private parameterless constructor required by EntityFramework.
        /// </summary>
        private Customer() : base(Guid.NewGuid()) { }

        /// <summary>
        /// The constructor of the Customer Entity.
        /// </summary>
        /// <param name="guid">The <see cref="Guid"/> unique identifier of this Entity.</param>
        /// <param name="name">The name of the Customer.</param>
        public Customer(Guid guid, string name) : base(guid)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            Name = name;
        }
    }
}
