using System.Collections.Generic;
using System.Linq;
using System.Web.OData.Query;

namespace AssureNetServicesPOC.Controllers
{
    public interface IGenericController<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(ODataQueryOptions<TEntity> queryOptions);
    }
}