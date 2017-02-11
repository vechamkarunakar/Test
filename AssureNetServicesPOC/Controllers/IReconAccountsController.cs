using System.Linq;
using System.Web.Http;
using System.Web.OData;
using AssureNetServicesPOC.Models;
using System.Web.OData.Query;

namespace AssureNetServicesPOC.Controllers
{
    public interface IReconAccountsRepository
    {
        IQueryable<ReconAccount> Get(ODataQueryOptions<ReconAccount> queryOptions);
        //SingleResult<ReconAccount> Get([FromODataUri] int key);
    }
}