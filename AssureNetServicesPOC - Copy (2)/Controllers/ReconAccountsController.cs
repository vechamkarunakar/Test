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
using System.IO;
using System.Net.Http.Headers;
using System.Diagnostics;
using Microsoft.Owin;
using AssureNetServicesPOC.Pipeline;

namespace AssureNetServicesPOC.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ReconAccountsController : GenericController<ReconAccount>,  IDisposable
    {
    }
    [Authorize]
    public class ReconFilesController : GenericController<Reconciliations_Files>, IDisposable
    {
    }

    [Authorize]
    public class ActiveUsersController : GenericController<ActiveUser>, IDisposable
    {
    }

    [AssurenetAuthorize]
    public class ReconDetailsController : ODataController
    {
        public ActiveUser activeUser { get; set; }

        private IUnitOfWork<ReconDetail> uow;

        //public HttpResponseMessage Get(string filename)
        //{
        //    string ROOT = "";
        //    var path = Path.Combine(ROOT, filename);
        //    if (!File.Exists(path))
        //        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "File not exists!"));
        //    var result = new HttpResponseMessage(HttpStatusCode.OK);
        //    var stream = new FileStream(path, FileMode.Open);
        //    result.Content = new StreamContent(stream);
        //    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

        //    return result;
        //}

        public ReconDetailsController(IUnitOfWork<ReconDetail> iow)
        {
            this.uow = iow;
        }

        public ReconDetailsController()
        {
            var ctx = HttpContext.Current.GetOwinContext();
            //var user = HttpContext.Current.User;
            var name = this.User.Identity.Name;
            Debug.Write(name);
            //uow = new UnitOfWork<ReconDetail>();
            //ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            //string loginName = RequestContext.Principal.Identity.Name;

            ////var identity = User.Identity as ClaimsIdentity;
            ////Claim identityClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            ////var str = RequestContext.Principal.Identity.Name;
            ////var loginName = context.Users.FirstOrDefault(u => u.Id == identityClaim.Value);


            ////foreach (var item in identity.Claims)
            ////{
            ////    Debug.WriteLine(item.Issuer + "--" + item.Value);
            ////}

            ////var loginName = this.User.Identity.Name;
            //if (loginName == null) throw new Exception("Invalid User Exception");
            //string[] username = loginName.Split("\\".ToCharArray());
            //string userAlias = username[1];
            //UnitOfWork<ActiveUser> au = new UnitOfWork<ActiveUser>();
            //activeUser = au.GetEntities.Get().Where<ActiveUser>(un => un.UserName.ToLower() == userAlias).SingleOrDefault();
            
        }


        public IEnumerable<ReconDetail> Get(ODataQueryOptions<ReconDetail> queryOptions)
        {
            IEnumerable<ReconDetail> rd = null;
            if (activeUser.Role_ProgramAdmin)
            {
                rd = queryOptions.ApplyTo(uow.GetEntities.Get()) as IEnumerable<ReconDetail>;
            }
            else
            {
                rd = queryOptions.ApplyTo(uow.GetEntities.Get()) as IEnumerable<ReconDetail>;
                //rd = queryOptions.ApplyTo(uow.GetEntities.Get().Where(r => r.Approver.Contains(activeUser.UserName.ToLower())
                //        || r.Reconciler.Contains(activeUser.UserName.ToLower()) || r.Reviewer.Contains(activeUser.UserName.ToLower()))) 
                //        as IEnumerable<ReconDetail>;
            }

            return rd;
        }

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
        
        public IEnumerable<TEntity> Get(ODataQueryOptions<TEntity> queryOptions)
        {
            
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

