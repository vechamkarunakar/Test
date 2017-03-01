using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssureNetServicesPOC.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using System.Security.Claims;
using System.Net.Http;

namespace AssureNetServicesPOC.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ReconAccountsController : GenericController<ReconAccount>,  IDisposable
    {
        
    }

    public class ReconFilesController : GenericController<Reconciliations_Files>, IDisposable
    {

    }

    public class ReconResultsController : GenericController<view_ReconciliationResults>, IDisposable
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericController<TEntity> : ODataController, IDisposable, IGenericController<TEntity> where TEntity : class
    {
        private IUnitOfWork<TEntity> uow;

        public GenericController(IUnitOfWork<TEntity> iow)
        {
            this.uow = iow;
        }

        public GenericController()
        {
            uow = new UnitOfWork<TEntity>();
        }

        //UnitOfWork<TEntity> uow = new UnitOfWork<TEntity>();

        public IQueryable<TEntity> Get(ODataQueryOptions<TEntity> queryOptions)
        {
            var loginName = HttpContext.Current.Request.LogonUserIdentity.Name;
            var settings = new ODataValidationSettings()
            {
                AllowedFunctions = AllowedFunctions.Contains
            };
            queryOptions.Validate(settings);
            var results = queryOptions.ApplyTo(uow.GetEntities.Get()) as IQueryable<TEntity>;
            return results;
        }
    }
}

