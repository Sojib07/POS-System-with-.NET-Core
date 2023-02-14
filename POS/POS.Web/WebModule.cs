using Autofac;
using POS.Services;

namespace POS.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataUtility>().As<IDataUtility>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
