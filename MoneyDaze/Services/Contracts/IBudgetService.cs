using System.Collections.Generic;

namespace MoneyDaze.Services.Contracts
{
    public interface IBudgetService
    {
        List<Income> Incomes { get; }
        List<Expense> Outgoings { get; }
        decimal TotalIncome { get; }
        decimal TotalOutgoings { get; }

        void LoadData();
        void AddIncome(Income newIncome);
        void AddExpense(Expense newExpense);
    }
}