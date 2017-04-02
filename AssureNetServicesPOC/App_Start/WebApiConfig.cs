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

            config.MapHttpAttributeRoutes();
            config.Filter();
            config.Filters.Add(new EnableQueryAttribute() { PageSize = 50 });
            config.Count().Filter(System.Web.OData.Query.QueryOptionSetting.Allowed).OrderBy().Expand().Select().MaxTop(null);

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

            //builder.EntitySet<ReconAccount>("ReconAccounts");
            //builder.EntitySet<Reconciliations_Files>("ReconFiles");
            //builder.EntitySet<view_ReconciliationResults>("ReconResults");

            /*
                ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
                builder.EntitySet<Product>("Products");
                builder.EntitySet<Supplier>("Suppliers");
                builder.EntitySet<ProductRating>("Ratings");

                // New code: Add an action to the EDM, and define the parameter and return type.
                ActionConfiguration rateProduct = builder.Entity>Product>().Action("RateProduct");
                rateProduct.Parameter<int>("Rating");
                rateProduct.Returns<double>();

             */

            builder.EntitySet<ReconDetail>("ReconDetails");
            builder.EntitySet<ActiveUser>("ActiveUsers");

            ActionConfiguration GetFileAction = builder.EntityType<ReconDetail>().Action("GetFile");
            GetFileAction.ReturnsFromEntitySet<ReconDetail>("ReconDetails");

            ActionConfiguration GetUserAction = builder.EntityType<ActiveUser>().Action("GetUser");
            GetUserAction.Returns<double>();

            builder.Namespace = typeof(ActiveUser).Namespace;

            return builder.GetEdmModel();
        }
    }
}
