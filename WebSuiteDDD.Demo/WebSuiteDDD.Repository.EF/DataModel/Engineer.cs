using System;

namespace WebSuiteDDD.Repository.EF.DataModel
{
    public class Engineer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int YearJoinedCompany { get; set; }
    }
}
