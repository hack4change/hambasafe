using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Newtonsoft.Json;

namespace Hambasafe.Server.Attributes
{
    public class ClientTokenSecurityAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // Grab the current request headers
            var headers = actionContext.Request.Headers;

            IEnumerable<string> headerValues = new List<string>();

            headers.TryGetValues("ClientToken", out headerValues);

            var providerToken = headerValues?.FirstOrDefault();

            var isValid = !string.IsNullOrEmpty(providerToken);

            // Ensure that all of your properties are present in the current Request
            if (isValid)
            {
                var token = JsonConvert.DeserializeObject<string>(providerToken);

                isValid = UserTokenService.Instance.ValidateUserToken(token);
            }

            if (!isValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "This method is not allowed!");// StatusCode = HttpStatusCode.Forbidden;
            }

            // Additional Auditing-based Logic Here
            base.OnActionExecuting(actionContext);

        }
    }
}
