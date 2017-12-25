namespace DDDSkeletonNET.Portal.Repository.Memory.Database
{
    public class LazySingletonObjectContextFactory : IObjectContextFactory
    {
        public InMemoryDatabaseObjectContext Create()
        {
            return InMemoryDatabaseObjectContext.Instance;
        }
    }
}
