using System;
using WebSuiteDDD.SharedKernel.Domain;

namespace WebSuiteDemo.Loadtesting.Domain
{
    /// <summary>
    /// The parameters for a loadTest, this is a ValueObject.
    /// </summary>
    public class LoadTestParameters : ValueObjectBase<LoadTestParameters>
    {
        /// <summary>
        /// A private emptyConstructor. Required by EntityFramework.
        /// </summary>
        private LoadTestParameters() { }

        /// <summary>
        /// The date for the start of the loadTest.
        /// </summary>
        public DateTime StartDateUtc { get; private set; }

        /// <summary>
        /// The number of user.
        /// </summary>
        public int UserCount { get; private set; }

        /// <summary>
        /// The total duration of the test, between 30s and 1h.
        /// </summary>
        public int DurationSec { get; private set; }

        /// <summary>
        /// The constructor for the parameters.
        /// </summary>
        /// <param name="startDateUtc">The date beginning the test.</param>
        /// <param name="userCount">The number of users.</param>
        /// <param name="durationSec">The duration of the test.</param>
        public LoadTestParameters(DateTime startDateUtc, int userCount, int durationSec)
        {
            if (userCount < 1) throw new ArgumentException("User count cannot be less than 1");
            if (durationSec < 30) throw new ArgumentException("Test duration cannot be less than 30 seconds");
            if (durationSec > 3600) throw new ArgumentException("Test duration cannot be more than 1 hour");
            if (startDateUtc < DateTime.UtcNow) startDateUtc = DateTime.UtcNow;

            StartDateUtc = startDateUtc;
            UserCount = userCount;
            DurationSec = durationSec;
        }

        /// <summary>
        /// Get the final date of the test.
        /// </summary>
        /// <returns>The final date time.</returns>
        public DateTime GetEndDateUtc()
        {
            return StartDateUtc.AddSeconds(DurationSec);
        }

        /// <summary>
        /// Change the startDate of the test.
        /// </summary>
        /// <param name="newStartDate">A new StartDate for the test.</param>
        /// <returns>The test with a new startDate.</returns>
        public LoadTestParameters WithStartDateUtc(DateTime newStartDate)
        {
            return new LoadTestParameters(newStartDate, this.UserCount, this.DurationSec);
        }

        /// <summary>
        /// Change the user count of the test.
        /// </summary>
        /// <param name="newUserCount">A new UserCount for the test.</param>
        /// <returns>The test with a new UserCount.</returns>
        public LoadTestParameters WithUserCount(int newUserCount)
        {
            return new LoadTestParameters(this.StartDateUtc, newUserCount, this.DurationSec);
        }

        /// <summary>
        /// Change the duration of the test.
        /// </summary>
        /// <param name="newDurationSec">The new duration in seconds for the test.</param>
        /// <returns>The test with a new Duration in seconds.</returns>
        public LoadTestParameters WithDurationSec(int newDurationSec)
        {
            return new LoadTestParameters(this.StartDateUtc, this.UserCount, newDurationSec);
        }

        /// <summary>
        /// Compare 2 loadTestParameters.
        /// </summary>
        /// <param name="other">The second LoadTestParameters</param>
        /// <returns>
        ///     <c>True</c> if it's the same parameters ; otherwise, <c>False</c>.
        /// </returns>
        public override bool Equals(LoadTestParameters other)
        {
            return other.UserCount == this.UserCount && other.StartDateUtc == this.StartDateUtc && other.DurationSec == this.DurationSec;
        }

        /// <summary>
        /// Compare an object with this parameters.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>
        ///     <c>True</c> if the object is a LoadTestParameters with the same parameters ; otherwise, <c>False</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is LoadTestParameters)) return false;
            return this.Equals((LoadTestParameters)obj);
        }

        /// <summary>
        /// The hashcode of the parameters.
        /// </summary>
        /// <returns>The int hashcode.</returns>
        public override int GetHashCode()
        {
            return this.DurationSec.GetHashCode() + this.StartDateUtc.GetHashCode() + this.UserCount.GetHashCode();
        }
    }
}
