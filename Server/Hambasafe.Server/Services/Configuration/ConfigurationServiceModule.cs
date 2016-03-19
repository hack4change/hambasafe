using Ninject.Modules;

namespace Hambasafe.Server.Services.Configuration
{
    public class ConfigurationServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfigurationService>().To<ConfigurationService>();
        }
    }
}