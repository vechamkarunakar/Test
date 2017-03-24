using AssureNetServicesPOC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AssureNetServicesPOC.DAL
{
    public interface IReconciliationAccountsContext 
    {
        IDbSet<ReconAccount> ReconAccounts { get; set; }
        IDbSet<Reconciliations_Files> Reconciliations_Files { get; set; }
        IDbSet<view_ReconciliationResults> view_ReconciliationResults { get; set; }
        IDbSet<EffectiveDate> EffectiveDates { get; set; }
    }
}