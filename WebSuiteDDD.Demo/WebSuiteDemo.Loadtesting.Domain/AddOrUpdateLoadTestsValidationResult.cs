using System.Collections.Generic;

namespace WebSuiteDemo.Loadtesting.Domain
{
    /// <summary>
    /// Actions for the result of a loadTest
    /// </summary>
    public class AddOrUpdateLoadTestsValidationResult
    {
        /// <summary>
        /// List of tests to insert.
        /// </summary>
        public List<LoadTest> ToBeInserted { get; private set; }

        /// <summary>
        /// List of tests to update.
        /// </summary>
        public List<LoadTest> ToBeUpdated { get; private set; }

        /// <summary>
        /// List of tests failed.
        /// </summary>
        public List<LoadTest> Failed { get; private set; }

        /// <summary>
        /// The summary of the whole operation.
        /// </summary>
        public string OperationResultSummary { get; private set; }

        /// <summary>
        /// The indicator if the validation was complete.
        /// </summary>
        public bool ValidationComplete { get; private set; }

        /// <summary>
        /// Constructor for the validation result.
        /// </summary>
        /// <param name="toBeInserted">Tests to insert.</param>
        /// <param name="toBeUpdated">Tests to update.</param>
        /// <param name="failed">Tests failed.</param>
        /// <param name="operationResultSummary">Summary of the operations.</param>
        public AddOrUpdateLoadTestsValidationResult(List<LoadTest> toBeInserted, List<LoadTest> toBeUpdated,
            List<LoadTest> failed, string operationResultSummary)
        {
            ToBeInserted = toBeInserted;
            ToBeUpdated = toBeUpdated;
            Failed = failed;
            OperationResultSummary = operationResultSummary;
            ValidationComplete = (toBeInserted != null && toBeUpdated != null && failed != null && !string.IsNullOrEmpty(operationResultSummary));
        }
    }
}
