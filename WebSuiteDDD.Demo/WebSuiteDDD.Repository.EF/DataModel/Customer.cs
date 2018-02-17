using System;

namespace WebSuiteDDD.Repository.EF.DataModel
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string MainContact { get; set; }
    }
}
