using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace AssureNetServicesPOC.Pipeline
{
    /// <summary>
    /// 
    /// </summary>
    public class AssurenetAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var userAlias = actionContext.RequestContext.Principal.Identity.Name;

            return base.IsAuthorized(actionContext);
        }
    }
}