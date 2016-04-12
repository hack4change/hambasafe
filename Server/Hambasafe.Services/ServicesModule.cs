using Autofac;
using Hambasafe.Services.Services;

namespace Hambasafe.Services
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventService>().As<IEventService>();
            builder.RegisterType<EventTypeService>().As<IEventTypeService>();
            builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}
