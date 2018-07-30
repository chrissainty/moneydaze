using Blazored.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyDaze.Services
{
    public class AppState
    {
        private readonly string _incomeLocalStorageIdentifier = "incomes";
        private readonly string _outgoingLocalStorageIdentifier = "outgoings";

        private readonly ILocalStorage _localStorage;   

        private readonly List<Income> _incomes = new List<Income>();
        public IReadOnlyList<Income> Incomes => _incomes;

        private readonly List<Outgoing> _outgoings = new List<Outgoing>();
        public IReadOnlyList<Outgoing> Outgoings => _outgoings;

        public event Action OnChange;

        public AppState(ILocalStorage localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task LoadData()
        {
            var incomes = await _localStorage.GetItem<List<Income>>(_incomeLocalStorageIdentifier);
            var outgoings = await _localStorage.GetItem<List<Outgoing>>(_outgoingLocalStorageIdentifier);

            if (incomes != null)
                _incomes.AddRange(incomes);

            if (outgoings != null)
                _outgoings.AddRange(outgoings);

            NotifyStateChanged();
        }

        public async Task AddIncome(Income newIncome)
        {
            _incomes.Add(newIncome);
            await SaveToLocalStorage(_incomeLocalStorageIdentifier, _incomes);

            NotifyStateChanged();
        }

        public async Task AddOutgoing(Outgoing newOutgoing)
        {
            _outgoings.Add(newOutgoing);
            await SaveToLocalStorage(_outgoingLocalStorageIdentifier, _outgoings);

            NotifyStateChanged();
        }

        public async Task DeleteIncome(Guid id)
        {
            var income = _incomes.SingleOrDefault(x => x.Id == id);

            if (income != null)
            {
                _incomes.Remove(income);

                await _localStorage.SetItem(_incomeLocalStorageIdentifier, _incomes);

                NotifyStateChanged();
            }
        }

        public async Task DeleteOutgoing(Guid id)
        {
            var outgoing = _outgoings.SingleOrDefault(x => x.Id == id);

            if (outgoing != null)
            {
                _outgoings.Remove(outgoing);

                await _localStorage.SetItem(_outgoingLocalStorageIdentifier, _outgoings);

                NotifyStateChanged();
            }
        }

        private Task SaveToLocalStorage(string identifier, object data)
        {
            return _localStorage.SetItem(identifier, data);
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
