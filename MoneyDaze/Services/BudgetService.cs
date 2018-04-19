using Blazored.Js;
using MoneyDaze.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyDaze.Services
{
    public class BudgetService : IBudgetService
    {
        const string IncomeLocalStorageIdentifier = "incomes";
        const string ExpensesLocalStorageIdentifier = "outgoings";

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

        public decimal TotalIncome { get => Math.Round(Incomes.Sum(i => i.Amount), 2); }

        private List<Outgoing> _outgoings = new List<Outgoing>();
        public List<Outgoing> Outgoings
        {
            get
            {
                // TODO: This isn't great. Must find a better way of loading initial data
                if (!_outgoings.Any())
                    LoadData();

                return _outgoings;
            }
        }

        public decimal TotalOutgoings { get => Math.Round(Outgoings.Sum(x => x.Amount), 2); }

        public void LoadData()
        {
            _incomes = LocalStorage.Get<List<Income>>(IncomeLocalStorageIdentifier);
            _outgoings = LocalStorage.Get<List<Outgoing>>(ExpensesLocalStorageIdentifier);

            if (_incomes == null)
                _incomes = new List<Income>();

            if (_outgoings == null)
                _outgoings = new List<Outgoing>();
        }

        public void AddIncome(Income newIncome)
        {
            _incomes.Add(newIncome);
            SaveToLocalStorage(IncomeLocalStorageIdentifier, _incomes);
        }

        public void AddOutgoing(Outgoing newOutgoing)
        {
            _outgoings.Add(newOutgoing);
            SaveToLocalStorage(ExpensesLocalStorageIdentifier, _outgoings);
        }

        private void SaveToLocalStorage(string identifier, object data)
        {
            LocalStorage.Save(identifier, data);
        }
    }
}
