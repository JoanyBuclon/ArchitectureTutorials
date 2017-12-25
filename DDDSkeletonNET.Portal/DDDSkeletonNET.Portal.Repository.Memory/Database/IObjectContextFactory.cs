namespace DDDSkeletonNET.Portal.Repository.Memory.Database
{
    public interface IObjectContextFactory
    {
        InMemoryDatabaseObjectContext Create();
    }
}
