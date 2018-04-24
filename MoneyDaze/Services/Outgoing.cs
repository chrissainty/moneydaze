using System;

namespace MoneyDaze.Services
{
    public class Outgoing
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public string Amount { get; set; }

        public Outgoing()
        {
            Id = Guid.NewGuid();
        }

    }
}