using System;

namespace WebSuiteDemo.Loadtesting.Domain.DomainEvents
{
    public class TimetableChangedEventArgs : EventArgs
    {
        private AddOrUpdateLoadTestsValidationResult _validationResult;

        public TimetableChangedEventArgs(AddOrUpdateLoadTestsValidationResult validationResult)
        {
            if (validationResult == null) throw new ArgumentNullException("validationResult");
            _validationResult = validationResult;
        }

        public AddOrUpdateLoadTestsValidationResult AddOrUpdateLoadtestsValidationResult
        {
            get
            {
                return _validationResult;
            }
        }
    }
}
