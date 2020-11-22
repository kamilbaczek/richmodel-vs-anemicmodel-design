using Autofac;
using Microsoft.EntityFrameworkCore;
using RichModel.Persistance.Database.Configurations;

namespace RichModel.Persistance
{
    public sealed class PersistanceModule : Module
    {
        private readonly string _connectionString;

        public PersistanceModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            RegisterOrdersContext(builder);
            builder.RegisterModule<RepositoriesModule>();
        }

        private void RegisterOrdersContext(ContainerBuilder builder)
        {
            builder
                .Register(c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<OrdersDbContext>();
                    dbContextOptionsBuilder.UseSqlServer(_connectionString);

                    return new OrdersDbContext(dbContextOptionsBuilder.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}