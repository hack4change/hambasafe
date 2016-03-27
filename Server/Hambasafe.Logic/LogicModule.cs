using Hambasafe.DataAccess.Entities;
using Hambasafe.Logic.Services;
using Microsoft.Data.Entity;
using Ninject.Modules;

namespace Hambasafe.Logic
{
    public class LogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEventService>().To<EventService>();
        }
    }
}
