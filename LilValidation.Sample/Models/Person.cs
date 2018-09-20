using System;

namespace LilValidation.Sample.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public decimal NetWorth { get; set; }
    }
}
