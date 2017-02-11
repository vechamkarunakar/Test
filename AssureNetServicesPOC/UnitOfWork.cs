﻿using AssureNetServicesPOC.DAL;
using AssureNetServicesPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssureNetServicesPOC
{
    public class UnitOfWork<TEntity> : IDisposable where TEntity: class
    {
        internal ReconciliationAccountsContext ctx;

        public UnitOfWork(ReconciliationAccountsContext ctx)
        {
            this.ctx = ctx;
        }

        public UnitOfWork()
        {
            ctx = new ReconciliationAccountsContext();
        }

        private GenericRepo<TEntity> reconAccountsRepo;

        public GenericRepo<TEntity> GetEntities
        {
            get
            {
                if (this.reconAccountsRepo == null)
                    this.reconAccountsRepo = new GenericRepo<TEntity>(ctx);
                return reconAccountsRepo;
            }
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ctx.Dispose();
                }
            }
            this.disposed = true;
        }

    }
}