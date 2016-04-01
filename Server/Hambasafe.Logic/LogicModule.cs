using Hambasafe.Logic.Services;
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
