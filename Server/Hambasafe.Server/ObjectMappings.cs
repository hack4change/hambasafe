using AutoMapper;
using entities = Hambasafe.DataAccess.Entities;
using models = Hambasafe.Server.Models.v1;

namespace Hambasafe.Server
{
    public class ObjectMappings
    {
        // I'm not setting up DI at this stage!
        public static MapperConfiguration MapperConfiguration;
        public static void SetupMappings()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<models.UserModel, entities.User>();
                cfg.CreateMap<entities.User, models.UserModel>();
                cfg.CreateMap<models.EventModel, entities.Event>();
                cfg.CreateMap<entities.Event, models.EventModel>();
            });
        }
    }
}