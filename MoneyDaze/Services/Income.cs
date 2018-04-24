using System;

namespace MoneyDaze.Services
{
    public class Income
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }

        public Income()
        {
            Id = Guid.NewGuid();
        }
    }
}