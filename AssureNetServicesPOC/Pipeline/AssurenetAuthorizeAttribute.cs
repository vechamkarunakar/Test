using AssureNetServicesPOC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
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
            IPrincipal genericPrincipal = null;
            var UserName = HttpContext.Current.Request.LogonUserIdentity.Name;
            if (string.IsNullOrEmpty(UserName)) return false;
            var domainAlias = UserName.Split("\\".ToCharArray());
            string userAlias = domainAlias[1];
            UserRepo userRepo = new UserRepo();
            var roles = userRepo.GetUserRoles(userAlias);
            if (roles.Count == 0) return false;

            genericPrincipal = new GenericPrincipal(actionContext.RequestContext.Principal.Identity, roles.ToArray());
            actionContext.RequestContext.Principal = genericPrincipal;
            return base.IsAuthorized(actionContext);
        }
    }
}