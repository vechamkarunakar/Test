using System.Linq;
using System.Web.OData.Query;

namespace AssureNetServicesPOC.Controllers
{
    public interface IGenericController<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get(ODataQueryOptions<TEntity> queryOptions);
    }
}