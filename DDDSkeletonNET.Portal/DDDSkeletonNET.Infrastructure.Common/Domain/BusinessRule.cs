using System;

namespace DDDSkeletonNET.Infrastructure.Common.Domain
{
    public class BusinessRule
    {
        private string _ruleDescription;

        public BusinessRule(string ruleDescription)
        {
            _ruleDescription = ruleDescription;
        }

        public String RuleDescription
        {
            get
            {
                return _ruleDescription;
            }
        }
    }
}
