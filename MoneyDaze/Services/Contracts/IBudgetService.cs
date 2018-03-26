using System.Collections.Generic;

namespace MoneyDaze.Services.Contracts
{
    public interface IBudgetService
    {
        List<Income> Incomes { get; }
        List<Expense> Expenses { get; }
        decimal TotalIncome { get; }
        decimal TotalExpenses { get; }

        void AddIncome(Income newIncome);
        void AddExpense(Expense newExpense);
    }
}