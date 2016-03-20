using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Hambasafe.Server.Attributes
{
    public class GeneralExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent($"{context.Exception.Message} ({context.Exception.GetType()})"),
                ReasonPhrase = context.Exception.Message
            };

            throw new HttpResponseException(responseMessage);
        }
    }
}