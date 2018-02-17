using System.Data.Entity;
using WebSuiteDDD.Repository.EF.DataModel;

namespace WebSuiteDDD.Repository.EF
{
    public class WebSuiteContext : DbContext
    {
        public WebSuiteContext() : base("WebSuiteContext") { }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<LoadTest> LoadTests { get; set; }
        public DbSet<LoadTestType> LoadTestTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Scenario> Scenarios { get; set; }
    }
}
