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

namespace AssureNetServicesPOC.Controllers
{
    public class ReconAccountsController : GenericController<ReconAccount>,  IDisposable
    {
        
    }

    public class ReconFilesController : GenericController<Reconciliations_Files>, IDisposable
    {

    }

    public class ReconResultsController : GenericController<view_ReconciliationResults>, IDisposable
    {

    }


    public class GenericController<TEntity> : ODataController, IDisposable where TEntity : class
    {
        UnitOfWork<TEntity> uow = new UnitOfWork<TEntity>();

        public IQueryable<TEntity> Get(ODataQueryOptions<TEntity> queryOptions)
        {
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

