using MoneyDaze.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyDaze.Services
{
    public class BudgetService : IBudgetService
    {
        private List<Income> _incomes = new List<Income>();
        public List<Income> Incomes { get => _incomes; }

        public decimal TotalIncome { get => Math.Round(_incomes.Sum(i => i.Amount), 2); }

        private List<Expense> _expenses = new List<Expense>();
        public List<Expense> Expenses { get => _expenses; }

        public decimal TotalExpenses { get => Math.Round(_expenses.Sum(x => x.Amount), 2); }

        public void AddIncome(Income newIncome)
        {
            _incomes.Add(newIncome);
        }

        public void AddExpense(Expense newExpense)
        {
            _expenses.Add(newExpense);
        }
    }
}
