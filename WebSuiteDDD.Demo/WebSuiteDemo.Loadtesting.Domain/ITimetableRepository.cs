using System;
using System.Collections.Generic;

namespace WebSuiteDemo.Loadtesting.Domain
{
    /// <summary>
    /// A Repository describing all authorized operations on an aggregate root.
    /// </summary>
    public interface ITimetableRepository
    {
        /// <summary>
        /// Retrieve loadtests for a period of time. (Select operation).
        /// </summary>
        /// <param name="searchStartDateUtc">The start of the search time.</param>
        /// <param name="searchEndDateUtc">The end of the search time.</param>
        /// <returns>The loadTests where the dates overlap with this period.</returns>
        IList<LoadTest> GetLoadTestsForTimePeriod(DateTime searchStartDateUtc, DateTime searchEndDateUtc);

        /// <summary>
        /// The Add/Update operation.
        /// </summary>
        /// <param name="addOrUpdateLoadTestsValidationResult">The result of the validation at the end of the operation.</param>
        void AddOrUpdateLoadTests(AddOrUpdateLoadTestsValidationResult addOrUpdateLoadTestsValidationResult);

        /// <summary>
        /// The Detele operation.
        /// </summary>
        /// <param name="guid">The Guid of the Entity to delete.</param>
        void DeleteById(Guid guid);
    }
}
