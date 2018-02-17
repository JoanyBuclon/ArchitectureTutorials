using System;

namespace WebSuiteDDD.Repository.EF.DataModel
{
    public class Project
    {
        public Guid Id { get; set; }
        public Description Description { get; set; }
        public DateTime DateInsertedUtc { get; set; }
    }
}
