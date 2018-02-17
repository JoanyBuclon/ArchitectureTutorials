namespace WebSuiteDemo.Loadtesting.Domain
{
    /// <summary>
    /// The summary for a loadTest.
    /// </summary>
    public class LoadTestValidationSummary
    {
        /// <summary>
        /// Is it ok to modify or add?
        /// </summary>
        public bool OkToAddOrModify { get; set; }

        /// <summary>
        /// The description of the reason.
        /// </summary>
        public string ReasonForValidationFailure { get; set; }
    }
}
