using System.Linq;
using ExpenseManager.DataAccess.Models;

namespace ExpenseManager.DataAccess
{
    public partial class ExpenseManagerContext
    {
        public void RemoveExpense(int expenseId)
        {
            var expense = CrewExpenseses.Single(x => x.Id == expenseId);
            CrewExpenseses.Remove(expense);

            SaveChanges();
        }

        public void AddExpense(CrewExpense crewExpense)
        {
            CrewExpenseses.Add(crewExpense);

            SaveChanges();
        }

        public void UpdateExpense(int expenseId)
        {
            var expense = CrewExpenseses.Single(x => x.Id == expenseId);
            CrewExpenseses.Remove(expense);

            SaveChanges();
        }
    }
}