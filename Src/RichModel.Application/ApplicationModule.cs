using Autofac;

namespace RichModel.Application
{
    public sealed class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<MediationModule>();
        }
    }
}