using System.Data.Entity;
using ExpenseManager.DataAccess.Initialiation;
using ExpenseManager.DataAccess.Models;

namespace ExpenseManager.DataAccess
{
    [DbConfigurationType(typeof(ExpenseManagerDbConfiguration))] 
    public class ExpenseManagerContext : DbContext
    {
        public ExpenseManagerContext()
            : base("ExpenseManagerContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<CarCrew> CarCrews { get; set; }
        public DbSet<CrewExpense> CrewExpenseses { get; set; }

        public static void Configure()
        {
            Database.SetInitializer(new DbInitializer());
        }
    }
}