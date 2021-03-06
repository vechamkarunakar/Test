﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData;
using System.Web.OData.Query;

namespace AssureNetServicesPOC.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericController<TEntity> : ODataController, IDisposable, IGenericController<TEntity> where TEntity : class
    {
        private IUnitOfWork<TEntity> uow;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iow"></param>
        public GenericController(IUnitOfWork<TEntity> iow)
        {
            this.uow = iow;
        }

        /// <summary>
        /// 
        /// </summary>
        public GenericController()
        {
            uow = new UnitOfWork<TEntity>();
        }

        public IEnumerable<TEntity> Get(ODataQueryOptions<TEntity> queryOptions)
        {
            var loginName = HttpContext.Current.Request.LogonUserIdentity.Name;
            //var settings = new ODataValidationSettings()
            //{
            //    AllowedFunctions = AllowedFunctions.Contains,
            //    AllowedQueryOptions = AllowedQueryOptions.Filter
            //};
            //queryOptions.Validate(settings);
            var results = queryOptions.ApplyTo(uow.GetEntities.Get()) as IEnumerable<TEntity>;
            return results;
        }
    }
}