using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Hambasafe.Server.Models
{
    [RoutePrefix("v1")]
    public class EventTypeModel
    {
        private string _name;
        private string _description;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}