using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AssureNetServicesPOC.DAL
{
    public class GenericRepo<TEntity> where TEntity : class
    {
        internal DbSet<TEntity> dbSet;
        internal ReconciliationAccountsContext reconciliationAccountsContext;

        public GenericRepo(ReconciliationAccountsContext ctx)
        {
            this.reconciliationAccountsContext = ctx;
            this.dbSet = ctx.Set<TEntity>();
        }
        public virtual IQueryable<TEntity> Get()
        {
            IQueryable<TEntity> query = dbSet;
            return query;
        }
    }
}