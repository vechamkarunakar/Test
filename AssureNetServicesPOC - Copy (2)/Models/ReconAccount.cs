using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssureNetServicesPOC.Models
{
    public class ReconAccount
    {
        public long Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountDesc { get; set; }
        public string Status { get; set; }
        public string CompanyCode { get; set; }
        public DateTime FiscalMonth { get; set; }
        public Decimal EndingBalance { get; set; }
        public string Reconciler { get; set; }
        public string Reviewer { get; set; }
        public string Approver { get; set; }
        public string Attachment { get; set; }
    }
}