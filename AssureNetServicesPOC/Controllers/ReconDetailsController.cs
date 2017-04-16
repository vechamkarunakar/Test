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
using System.Web.OData.Routing;
using System.Diagnostics;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;
using System.Configuration;

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
            var userAlias = UserProvider.GetUserAlias();

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
}