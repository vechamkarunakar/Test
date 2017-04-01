using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.OData.Extensions;

namespace AssureNetServicesPOC.Controllers
{
    public class FileController : ApiController
    {
        
        public HttpResponseMessage File(string filename)
        {
            string ROOT = "";
            var path = Path.Combine(ROOT, filename);
            path = @"\\vecham\shares\inv.xslx";
            if (!System.IO.File.Exists(path))
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "File not exists!"));
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            
            return result;
        }

        //public HttpResponseMessage GetFile(string filename)
        //{
        //    string ROOT = "";
        //    throw new NotImplementedException();
        //}

        [Route("api/file")]
        public IHttpActionResult GetFile([FromUri] string imagePath)
        {
            var UserName = RequestContext.Principal.Identity.Name;
            string _rootPath = ConfigurationManager.AppSettings["FileSharePath"];
            var serverPath = Path.Combine(_rootPath, imagePath);
            var fileInfo = new FileInfo(serverPath);

            return !fileInfo.Exists
                ? (IHttpActionResult)NotFound()
                : new FileResult(fileInfo.FullName);
        }
    }
}