using Autofac;
using RichModel.Persistance.Orders.Repositiories;

namespace RichModel.Persistance
{
    internal sealed class RepositoriesModule : Module
    {
        private const string Repository = "Repository";

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(OrdersRepository).Assembly)
                .Where(t => t.Name.EndsWith(Repository))
                .AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}