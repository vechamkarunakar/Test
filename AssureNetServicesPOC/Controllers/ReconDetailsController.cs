using System;
using System.Collections.Generic;
using System.Web;
using AssureNetServicesPOC.Models;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using AssureNetServicesPOC.DAL;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using AssureNetServicesPOC.Pipeline;

namespace AssureNetServicesPOC.Controllers
{
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
            var userAlias = GetUserAlias();

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult GetFile(int key)
        {
            //string fileName = Convert.ToString(parameters["FileName"]);
            
            return StatusCode(HttpStatusCode.NoContent);
        }

        private string GetUserAlias()
        {
            var loginName = HttpContext.Current.Request.LogonUserIdentity.Name;
            if (string.IsNullOrEmpty(loginName)) return null;
            //Assuming that login name always have domain\\useralias

            var domainAlias = loginName.Split("\\".ToCharArray());
            string userAlias = domainAlias[1];
            
            return userAlias;
        }
    }
}