using Hambasafe.DataLayer.Entities;

namespace Hambasafe.Api.Models.v1
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        protected override void Configure()
        {
            CreateMap<Event, EventModel>();
            CreateMap<EventModel, Event>();

            CreateMap<EventLocation, EventLocationModel>();
            CreateMap<EventLocationModel, EventLocation>();

            CreateMap<EventType, EventTypeModel>();
            CreateMap<EventTypeModel, EventType>();

            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
        }
    }
}