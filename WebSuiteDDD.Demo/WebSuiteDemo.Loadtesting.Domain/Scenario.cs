using System;
using System.Collections.Generic;
using System.Linq;
using WebSuiteDDD.SharedKernel.Domain;

namespace WebSuiteDemo.Loadtesting.Domain
{
    /// <summary>
    /// The Scenario Entity.
    /// </summary>
    public class Scenario : EntityBase<Guid>
    {
        /// <summary>
        /// The first Uri called during the Scenario.
        /// </summary>
        public string UriOne { get; private set; }

        /// <summary>
        /// The second Uri called during the Scenario.
        /// </summary>
        public string UriTwo { get; private set; }

        /// <summary>
        /// The third Uri called during the Scenario.
        /// </summary>
        public string UriThree { get; private set; }

        /// <summary>
        /// Private parameterless constructor required by EntityFramework.
        /// </summary>
        private Scenario() : base(Guid.NewGuid()) { }

        /// <summary>
        /// The constructor of the Senario Entity.
        /// </summary>
        /// <param name="guid">The <see cref="Guid"/> unique identifier of the entity.</param>
        /// <param name="loadtestSteps">The Uri that are called during the Scenario (onyl the first three steps are saved).</param>
        public Scenario(Guid guid, IEnumerable<Uri> loadtestSteps) : base(guid)
        {
            if (loadtestSteps == null || !loadtestSteps.Any())
                throw new ArgumentException("Loadtest scenario must have at least one valid URI.");

            Uri uriOne = loadtestSteps.ElementAt(0);
            if (uriOne == null) throw new ArgumentException("Loadtest scenario must have at least one valid URI.");
            UriOne = uriOne.AbsoluteUri;

            if (loadtestSteps.Count() == 2 && loadtestSteps.ElementAt(1) != null)
            {
                Uri uriTwo = loadtestSteps.ElementAt(1);
                UriTwo = uriTwo.AbsoluteUri;
            }

            if (loadtestSteps.Count() >= 3 && loadtestSteps.ElementAt(1) != null
                && loadtestSteps.ElementAt(2) != null)
            {
                Uri uriTwo = loadtestSteps.ElementAt(1);
                UriTwo = uriTwo.AbsoluteUri;

                Uri uriThree = loadtestSteps.ElementAt(2);
                UriThree = uriThree.AbsoluteUri;
            }
        }
    }
}
