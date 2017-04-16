using System;
using System.Collections.Generic;
using System.Web;
using AssureNetServicesPOC.Models;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;

namespace AssureNetServicesPOC.Controllers
{

    //TODO: Might not be used now but for later use
    /// <summary>
    /// 
    /// </summary>
    public class ReconAccountsController : GenericController<ReconAccount>,  IDisposable
    {
    }
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class ReconFilesController : GenericController<Reconciliations_Files>, IDisposable
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class ReconResultsController : GenericController<view_ReconciliationResults>, IDisposable
    {
    }

    
}

