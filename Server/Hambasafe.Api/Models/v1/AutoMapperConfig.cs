using Hambasafe.DataLayer.Entities;

namespace Hambasafe.Api.Models.v1
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        protected override void Configure()
        {
            CreateMap<Event, EventModel>();
            CreateMap<EventLocation, EventLocationModel>();
            CreateMap<EventType, EventTypeModel>();
            CreateMap<User, UserModel>();


        }
    }
}