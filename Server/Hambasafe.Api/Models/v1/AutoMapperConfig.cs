using Hambasafe.DataLayer.Entities;

namespace Hambasafe.Api.Models.v1
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        protected override void Configure()
        {
            CreateMap<Event, EventModel>().ReverseMap();
            CreateMap<EventLocation, EventLocationModel>().ReverseMap();
            CreateMap<EventType, EventTypeModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}