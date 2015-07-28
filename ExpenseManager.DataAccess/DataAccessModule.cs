using Autofac;

namespace ExpenseManager.DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ExpenseManagerContext.Configure();

            builder.Register(x => new ExpenseManagerContext()).As<ExpenseManagerContext>();
        }
    }
}