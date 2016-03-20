using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Controllers;

namespace Hambasafe.Server.Attributes
{
    public class AuthenticateUserAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //retrieve controller action's authorization attributes
                var authorizeAttributes = actionContext.ActionDescriptor.GetCustomAttributes<AuthorizeVerifiedUsersAttribute>();

                //check controller and action BypassValidation value
                if (BypassValidation ||
                    actionAttributes.Count > 0 && actionAttributes.Any(x => x.BypassValidation))
                {
                    return true;
                }
                else
                {
                    //return false if user is unverified
                }

                return base.IsAuthorized(actionContext);
            }
        }
}