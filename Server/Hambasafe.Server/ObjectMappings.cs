using AutoMapper;
using entities = Hambasafe.DataAccess.Entities;
using models = Hambasafe.Server.Models.v1;

namespace Hambasafe.Server
{
    public class ObjectMappings
    {
        public static void SetupMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<models.UserModel, entities.Event>();
                cfg.CreateMap<models.EventModel, entities.Event>();
            });
        }
    }
}