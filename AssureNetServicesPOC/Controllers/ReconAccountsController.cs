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
    public class ReconAccountsController : ODataController, IReconAccountsRepository, IDisposable
    {
        ReconAccountsRepository _repo = new ReconAccountsRepository();


        public IQueryable<ReconAccount> Get(ODataQueryOptions<ReconAccount> queryOptions)
        {
            var settings = new ODataValidationSettings()
            {
                AllowedFunctions = AllowedFunctions.Contains
            };

            queryOptions.Validate(settings);

            var results = queryOptions.ApplyTo(_repo.Get()) as IQueryable<ReconAccount>;

            return results;
        }


        [EnableQuery]
        public SingleResult<ReconAccount> Get([FromODataUri] int key)
        {
            return _repo.Get(key);
        }

        //[HttpGet]
        //[EnableQuery]
        //public IHttpActionResult GetReconAccounts([FromODataUri]string CompanyCode)
        //{
        //    //return Ok(_repo.Get);
        //}

    }
}

