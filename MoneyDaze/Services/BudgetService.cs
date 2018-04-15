using MoneyDaze.Infrastructure.LocalStorage;
using MoneyDaze.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyDaze.Services
{
    public class BudgetService : IBudgetService
    {
        const string IncomeLocalStorageIdentifier = "incomes";
        const string ExpensesLocalStorageIdentifier = "expenses";

        private List<Income> _incomes = new List<Income>();
        public List<Income> Incomes
        {
            get
            {
                // TODO: This isn't great. Must find a better way of loading initial data
                if (!_incomes.Any())
                    LoadData();

                return _incomes;
            }
        }

        public decimal TotalIncome { get => Math.Round(_incomes.Sum(i => i.Amount), 2); }

        private List<Expense> _expenses = new List<Expense>();
        public List<Expense> Expenses
        {
            get
            {
                // TODO: This isn't great. Must find a better way of loading initial data
                if (!_expenses.Any())
                    LoadData();

                return _expenses;
            }
        }

        public decimal TotalExpenses { get => Math.Round(_expenses.Sum(x => x.Amount), 2); }

        public void LoadData()
        {
            Console.WriteLine("Invoking get local storage data");

            _incomes = BlazoredLocalStorage.Get<List<Income>>(IncomeLocalStorageIdentifier);
            _expenses = BlazoredLocalStorage.Get<List<Expense>>(ExpensesLocalStorageIdentifier);

            if (_incomes == null)
                _incomes = new List<Income>();

            if (_expenses == null)
                _expenses = new List<Expense>();
        }

        public void AddIncome(Income newIncome)
        {
            _incomes.Add(newIncome);
            SaveToLocalStorage(IncomeLocalStorageIdentifier, _incomes);
        }

        public void AddExpense(Expense newExpense)
        {
            _expenses.Add(newExpense);
            SaveToLocalStorage(ExpensesLocalStorageIdentifier, _expenses);
        }

        private void SaveToLocalStorage(string identifier, object data)
        {
            Console.WriteLine("Invoking save to local storage");
            BlazoredLocalStorage.Save(identifier, data);
            Console.WriteLine("Save to local storage complete");
        }
    }
}
