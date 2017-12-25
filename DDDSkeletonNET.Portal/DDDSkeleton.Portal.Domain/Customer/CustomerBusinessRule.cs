using DDDSkeletonNET.Infrastructure.Common.Domain;

namespace DDDSkeleton.Portal.Domain.Customer
{
    public static class CustomerBusinessRule
    {
        public static readonly BusinessRule CustomerNameRequired = new BusinessRule("A customer must have a name.");
    }
}
