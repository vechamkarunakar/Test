using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AssureNetServicesPOC.Models;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData;

namespace AssureNetServicesPOC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            config.Filter();
            config.Filters.Add(new EnableQueryAttribute() { PageSize = 50});
            builder.EntitySet<ReconAccount>("ReconAccounts");
            var function = builder.Function("GetReconAccounts");
            function.Parameter<string>("CompanyCode");
            function.ReturnsCollectionFromEntitySet<ReconAccount>("ReconAccounts");


            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
        }
    }
}
