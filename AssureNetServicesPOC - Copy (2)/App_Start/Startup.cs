using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.ActiveDirectory;
using System.Configuration;
using System.Web.Http;
using System.IdentityModel.Tokens;
using Microsoft.Owin.Security.OAuth;
using AssureNetServicesPOC.Pipeline;

[assembly: OwinStartup(typeof(AssureNetServicesPOC.App_Start.Startup))]

namespace AssureNetServicesPOC.App_Start
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.Use(typeof(ProfileMiddleware));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
             new WindowsAzureActiveDirectoryBearerAuthenticationOptions
             {
                 Tenant = ConfigurationManager.AppSettings["ida:Tenant"],
                 TokenValidationParameters = new System.IdentityModel.Tokens.TokenValidationParameters()
                 {
                     ValidAudience = ConfigurationManager.AppSettings["ida:Audience"]
                 }
             });
        }
    }


}
