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
    //[AssurenetAuthorize]
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="ReconId"></param>
        /// <returns></returns>
        //[HttpGet]
        //[EnableQuery(AllowedQueryOptions=AllowedQueryOptions.None)]
        //public HttpResponseMessage DownloadFile([FromODataUri]string fileName, [FromODataUri]int ReconId)
        //{
        //    var res1 = DownloadFile(fileName);
        //    return res1;

        //    var userAlias = GetUserAlias();
        //    HttpResponseMessage res = null;
        //    UserRepo userRepo = new UserRepo();
        //    var user = userRepo.GetUser(userAlias);

        //    EffectiveDatesRepo edr = new EffectiveDatesRepo();
        //    DateTime dtFilter = edr.FilterForFBIS();

        //    IEnumerable<ReconDetail> rd = null;
        //    if (user.Role_ProgramAdmin)
        //    {
        //        Debug.WriteLine("Admin functionality");
        //        rd = uow.GetEntities.Get().Where(r => r.EffectiveDate > dtFilter && r.FileName == fileName && r.ReconId == ReconId);
        //    }
        //    else
        //    {
        //        Debug.WriteLine("Non Admin functionality");
        //        rd = uow.GetEntities.Get().Where((r => ((r.ReconcilerID == user.PKId && user.Role_Reconciler)
        //                || (r.ReviewerID == user.PKId && user.Role_Reviewer)
        //                || (r.ApproverID == user.PKId && user.Role_Approver)) && (r.EffectiveDate > dtFilter)
        //                    && (r.FileName == fileName)
        //                    && (r.ReconId == ReconId)
        //                    )
        //                );
        //    }
        //    if (rd != null && rd.Count() != 0)
        //    {
        //        Debug.WriteLine("Download stream");
        //        res = DownloadFile(fileName);
        //    }
        //    return res;
        //}

        
    }
}