using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.OData.Query;

namespace AssureNetServicesPOC.Models
{
    public class ReconAccountsRepository : IDisposable
    {
        private ReconciliationAccountsContext db = new ReconciliationAccountsContext();

        public IQueryable<ReconAccount> Get(ODataQueryOptions<ReconAccount> queryOptions)
        {
            return db.ReconAccounts;
        }

        public SingleResult<ReconAccount> Get(int key)
        {
            IQueryable<ReconAccount> result = db.ReconAccounts.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public IQueryable<ReconAccount> Get()
        {
            IQueryable<ReconAccount> result = db.ReconAccounts;
            return result;
        }

        public IQueryable<ReconAccount> GetReconAccounts(string CompanyCode)
        {
            IQueryable<ReconAccount> result = db.ReconAccounts.Where(p => p.CompanyCode == CompanyCode);
            return result;
        }


        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}