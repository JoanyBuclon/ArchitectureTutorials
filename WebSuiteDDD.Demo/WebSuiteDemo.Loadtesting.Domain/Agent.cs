using System;
using WebSuiteDDD.SharedKernel.Domain;

namespace WebSuiteDemo.Loadtesting.Domain
{
    /// <summary>
    /// The agent that launches a LoadTest.
    /// </summary>
    public class Agent : EntityBase<Guid>
    {
        /// <summary>
        /// The location of the agent.
        /// </summary>
        public Location Location { get; private set; }

        /// <summary>
        /// Private constructor with new Guid. Required by EntityFramework.
        /// </summary>
        private Agent() : base(Guid.NewGuid()) { }

        /// <summary>
        /// The constructor of the agent.
        /// </summary>
        /// <param name="id">The <see cref="Guid"/> unique identifier of the agent entity.</param>
        /// <param name="city">The name of the city where the agent is located.</param>
        /// <param name="country">The name of the country where the agent is located.</param>
        public Agent(Guid id, string city, string country) : base(id)
        {
            Location = new Location(city, country);
        }
    }
}
