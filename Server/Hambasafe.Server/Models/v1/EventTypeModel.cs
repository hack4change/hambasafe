using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Entities = Hambasafe.DataAccess.Entities;

namespace Hambasafe.Server.Models.v1
{
    [RoutePrefix("v1")]
    public class EventTypeModel
    {
        

        public EventTypeModel()
        {

        }

        public int EventTypeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}