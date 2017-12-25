using DDDSkeleton.Portal.Domain.ValueObjects;
using DDDSkeletonNET.Infrastructure.Common.Domain;

namespace DDDSkeleton.Portal.Domain.Customer
{
    public class Customer : EntityBase<int>, IAggregateRoot
    {
        public string Name { get; set; }
        public Address CustomerAddress { get; set; }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                AddBrokenRule(CustomerBusinessRule.CustomerNameRequired);
            }

            CustomerAddress.ThrowExceptionIfInvalid();
        }
    }
}
