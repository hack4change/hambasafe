using Hambasafe.DataAccess.Entities;
using Hambasafe.Server.Models.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hambasafe.Server.App_Start
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