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
using AssureNetServicesPOC.Pipeline;
using AssureNetServicesPOC.DAL;

namespace AssureNetServicesPOC.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ReconAccountsController : GenericController<ReconAccount>,  IDisposable
    {
    }
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class ReconFilesController : GenericController<Reconciliations_Files>, IDisposable
    {
    }

    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class ActiveUsersController : GenericController<ActiveUser>, IDisposable
    {
    }

    /// <summary>
    /// 
    /// </summary>
    [AssurenetAuthorize]
    public class ReconDetailsController : ODataController
    {
        private ActiveUser activeUser { get; set; }
        private IUnitOfWork<ReconDetail> uow;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iow"></param>
        public ReconDetailsController(IUnitOfWork<ReconDetail> iow)
        {
            this.uow = iow;
        }

        /// <summary>
        /// 
        /// </summary>
        public ReconDetailsController()
        {
            this.uow = new UnitOfWork<ReconDetail>();
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryOptions"></param>
        /// <returns></returns>
        public IEnumerable<ReconDetail> Get(ODataQueryOptions<ReconDetail> queryOptions)
        {
            var loginName = HttpContext.Current.Request.LogonUserIdentity.Name;
            if (string.IsNullOrEmpty(loginName)) return null;
            //Assuming that login name always have domain\\useralias

            var domainAlias = loginName.Split("\\".ToCharArray());
            string userAlias = domainAlias[1];
            UserRepo userRepo = new UserRepo();
            var user = userRepo.GetUser(userAlias);

            EffectiveDatesRepo edr = new EffectiveDatesRepo();
            DateTime dtFilter = edr.FilterForFBIS();

            IEnumerable<ReconDetail> rd = null;
            if (user.Role_ProgramAdmin)
            {
                rd = queryOptions.ApplyTo(uow.GetEntities.Get().Where(r => r.EffectiveDate > dtFilter)) as IEnumerable<ReconDetail>;
            }
            else
            {
                rd = queryOptions.ApplyTo(uow.GetEntities.Get().Where(r => ((r.ReconcilerID == user.PKId && user.Role_Reconciler)
                        || (r.ReviewerID == user.PKId && user.Role_Reviewer)
                        || (r.ApproverID == user.PKId && user.Role_Approver)) && (r.EffectiveDate > dtFilter)))
                        as IEnumerable<ReconDetail>;
            }

            return rd;
        }
    }

    /// <summary>
    /// 
    /// </summary>
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

        //UnitOfWork<TEntity> uow = new UnitOfWork<TEntity>();
        
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

