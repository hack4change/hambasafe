using Ninject.Modules;

namespace Hambasafe.Server.Services.TableStorage
{
    public class TableStorageServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITableStorageService>().To<TableStorageService>();
        }
    }
}