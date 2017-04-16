using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AssureNetServicesPOC.Models;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData;
using Microsoft.Practices.Unity;
using Microsoft.OData.Edm;
using System.IO;

namespace AssureNetServicesPOC
{
    /// <summary>
    /// 
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {

            var container = new UnityContainer();
            config.DependencyResolver = new UnityResolver(container);

            //config.MapHttpAttributeRoutes();
            //config.Filters.Add(new EnableQueryAttribute() { PageSize = 1 });
            //config.Count().Filter(System.Web.OData.Query.QueryOptionSetting.Allowed).OrderBy().Expand().Select().MaxTop(null);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: GetEdmModel(config));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        private static IEdmModel GetEdmModel(HttpConfiguration config)
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<ReconDetail>("ReconDetails");
            builder.EntityType<ReconDetail>().Filter("AccountNumber").OrderBy(System.Web.OData.Query.QueryOptionSetting.Allowed).Page(null,50).Filter(System.Web.OData.Query.QueryOptionSetting.Allowed);
            builder.EntitySet<ActiveUser>("ActiveUsers");
            builder.EntitySet<EffectiveDate>("EffectiveDates");

            return builder.GetEdmModel();
        }
    }
}
