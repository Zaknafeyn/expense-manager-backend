using Autofac;
using Autofac.Integration.WebApi;

namespace ExpenseManager
{
    public class ControllersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(typeof (ControllersModule).Assembly);
        }
    }
}