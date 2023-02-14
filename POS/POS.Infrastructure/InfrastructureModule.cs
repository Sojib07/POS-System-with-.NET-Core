using Autofac;
using POS.Infrastructure.Services;

namespace POS.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataUtility>().As<IDataUtility>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
