using System.Data.Entity;
using System.Linq;
using ExpenseManager.DataAccess.Initialiation;
using ExpenseManager.DataAccess.Models;

namespace ExpenseManager.DataAccess
{
    [DbConfigurationType(typeof(ExpenseManagerDbConfiguration))] 
    public partial class ExpenseManagerContext : DbContext
    {
        public ExpenseManagerContext()
            : this("ExpenseManagerContext")
        {
        }

        public ExpenseManagerContext(string connectionString) : base(connectionString)
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Trips> Trips { get; set; }
        public DbSet<CarCrew> CarCrews { get; set; }
        public DbSet<CrewExpense> CrewExpenseses { get; set; }

        public static void Configure()
        {
            Database.SetInitializer(new DbInitializer());
        }

    }
}