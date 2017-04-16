using AssureNetServicesPOC.DAL;
using AssureNetServicesPOC.Models;
using AssureNetServicesPOC.Pipeline;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.OData.Extensions;

namespace AssureNetServicesPOC.Controllers
{
    [AssurenetAuthorize]
    public class FileController : ApiController
    {
        public IFileProvider FileProvider { get; set; }
        private ActiveUser activeUser { get; set; }
        private IUnitOfWork<ReconDetail> uow;
        public UserRepo userRepo { get; set; }
        public EffectiveDatesRepo edr { get; set; }

        public FileController(IUnitOfWork<ReconDetail> iow)
        {
            this.uow = iow;
            FileProvider = new FileProvider();
            userRepo = new UserRepo();
            edr = new EffectiveDatesRepo();
        }

        /// <summary>
        /// 
        /// </summary>
        public FileController()
        {
            this.uow = new UnitOfWork<ReconDetail>();
            FileProvider = new FileProvider();
            userRepo = new UserRepo();
            edr = new EffectiveDatesRepo();
        }

        [HttpGet]
        public HttpResponseMessage GetFile([FromUri] string fileName, [FromUri]int ReconId)
        {
            var userAlias = UserProvider.GetUserAlias();
            HttpResponseMessage res = null;

            if (IsUserAuthorizedToDownloadFile(userAlias,fileName,ReconId))
            {
                Debug.WriteLine("Download stream");
                res = DownloadFile(fileName);
            }
            else
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            return res;
        }

        private HttpResponseMessage DownloadFile(string fileName)
        {
            if (!FileProvider.Exists(fileName))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            FileStream fileStream = FileProvider.Open(fileName);
            var response = new HttpResponseMessage();
            response.Content = new StreamContent(fileStream);
            response.Content.Headers.ContentDisposition
                = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = fileName;
            response.Content.Headers.ContentType
                = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentLength
                    = FileProvider.GetLength(fileName);
            return response;

        }

        private bool IsUserAuthorizedToDownloadFile(string userAlias, string fileName, int ReconId)
        {
            var user = userRepo.GetUser(userAlias);
            DateTime dtFilter = edr.FilterForFBIS();

            IEnumerable<ReconDetail> rd = null;
            if (user.Role_ProgramAdmin)
            {
                Debug.WriteLine("Admin functionality");
                rd = uow.GetEntities.Get().Where(r => r.EffectiveDate > dtFilter && r.FileName == fileName && r.ReconId == ReconId);
            }
            else
            {
                Debug.WriteLine("Non Admin functionality");
                rd = uow.GetEntities.Get().Where((r => ((r.ReconcilerID == user.PKId && user.Role_Reconciler)
                        || (r.ReviewerID == user.PKId && user.Role_Reviewer)
                        || (r.ApproverID == user.PKId && user.Role_Approver)) && (r.EffectiveDate > dtFilter)
                            && (r.FileName == fileName)
                            && (r.ReconId == ReconId)
                            )
                        );
            }
            return true;
        }

    }
}