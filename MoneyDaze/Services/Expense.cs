namespace MoneyDaze.Services
{
    public class Expense
    {
        public string Description { get; set; }
        public Category Category { get; set; }
        public decimal Amount { get; set; }
    }
}