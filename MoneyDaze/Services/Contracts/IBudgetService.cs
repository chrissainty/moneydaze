using System.Collections.Generic;

namespace MoneyDaze.Services.Contracts
{
    public interface IBudgetService
    {
        List<Income> Incomes { get; }
        List<Outgoing> Outgoings { get; }
        decimal TotalIncome { get; }
        decimal TotalOutgoings { get; }

        void LoadData();
        void AddIncome(Income newIncome);
        void AddOutgoing(Outgoing newOutgoing);
    }
}