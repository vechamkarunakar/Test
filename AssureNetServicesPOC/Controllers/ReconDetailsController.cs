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
        UserRepo userRepo = null;
        IEffectiveDatesRepo effectiveDatesRepo = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iow"></param>
        public ReconDetailsController(IUnitOfWork<ReconDetail> iow, UserRepo userRepo, IEffectiveDatesRepo effectiveDatesRepo)
        {
            this.uow = iow;
            this.userRepo = userRepo;
            this.effectiveDatesRepo = effectiveDatesRepo;
        }

        /// <summary>
        /// 
        /// </summary>
        public ReconDetailsController()
        {
            this.uow = new UnitOfWork<ReconDetail>();
            this.userRepo = new UserRepo();
            this.effectiveDatesRepo = new EffectiveDatesRepo();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryOptions"></param>
        /// <returns></returns>
        [EnableQuery(PageSize =50)]
        public IEnumerable<ReconDetail> Get(ODataQueryOptions<ReconDetail> queryOptions)
        {
            var userAlias = UserProvider.GetUserAlias();
            var user = userRepo.GetUser(userAlias);
            DateTime dtFilter = effectiveDatesRepo.FilterForFBIS();

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