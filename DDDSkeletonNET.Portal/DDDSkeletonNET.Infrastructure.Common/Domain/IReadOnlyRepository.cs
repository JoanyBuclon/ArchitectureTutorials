using System.Collections.Generic;

namespace DDDSkeletonNET.Infrastructure.Common.Domain
{
    public interface IReadOnlyRepository<AggregateType, IdType> where AggregateType : IAggregateRoot
    {
        AggregateType FindBy(IdType id);
        IEnumerable<AggregateType> FindAll();
    }
}
