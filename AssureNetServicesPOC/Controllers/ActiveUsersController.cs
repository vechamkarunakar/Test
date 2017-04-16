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
        //TODO:Not used currently. Will check if this Action is required later
        [HttpPost]
        public IHttpActionResult GetUser(int key)
        {
            //string fileName = Convert.ToString(parameters["FileName"]);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}