using Autofac;
using RichModel.Application;
using RichModel.Persistance;

namespace RichModel.Infrastructure
{
    public sealed class InfrastructureModule : Module
    {
        private readonly string _connectionString;

        public InfrastructureModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new PersistanceModule(_connectionString));
            builder.RegisterModule<ApplicationModule>();
        }
    }
}