using System;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace ExpenseManager.DataAccess
{
    public class ExpenseManagerDbConfiguration : DbConfiguration
    {
        public ExpenseManagerDbConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy(1, TimeSpan.FromSeconds(30)));
        }
    }
}