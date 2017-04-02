using AssureNetServicesPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AssureNetServicesPOC.Controllers
{
    [Authorize]
    public class ActiveUsersController : GenericController<ActiveUser>, IDisposable
    {
        [HttpPost]
        public IHttpActionResult GetUser(int key)
        {
            //string fileName = Convert.ToString(parameters["FileName"]);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}