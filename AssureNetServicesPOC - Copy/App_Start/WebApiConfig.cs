﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AssureNetServicesPOC.Models;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData;
using Microsoft.Practices.Unity;

namespace AssureNetServicesPOC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var container = new UnityContainer();
            config.DependencyResolver = new UnityResolver(container);

            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            config.Filter();
            config.Filters.Add(new EnableQueryAttribute() { PageSize = 50});

            //builder.EntitySet<ReconAccount>("ReconAccounts");
            //builder.EntitySet<Reconciliations_Files>("ReconFiles");
            //builder.EntitySet<view_ReconciliationResults>("ReconResults");

            builder.EntitySet<ReconDetail>("ReconDetails");
            builder.EntitySet<ActiveUser>("ActiveUsers");
            
            config.Count().Filter(System.Web.OData.Query.QueryOptionSetting.Allowed).OrderBy().Expand().Select().MaxTop(null);

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
        }
    }
}
