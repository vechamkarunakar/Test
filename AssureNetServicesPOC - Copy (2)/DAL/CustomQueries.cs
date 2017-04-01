using AssureNetServicesPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssureNetServicesPOC.DAL
{
    public class CustomQueries
    {
        public List<int> GetAccountsWithAttachments()
        {
            /*
             
             var result1 = (from u in context.User
                orderby u.LastName, u.FirstName
                join us in context.MetricBloodPreasure
                    on u.Id equals us.UserId into users
                from s in users
                select new
                {
                    UserName = s.User.LastName + ", " + s.User.FirstName,
                    Date = s.DateOfValue,
                }).ToList();
             */
            ReconciliationAccountsContext ctx = new ReconciliationAccountsContext();
            var res = from ra in ctx.view_ReconciliationResults
                      join fa in ctx.Reconciliations_Files
on ra.PKId equals fa.PKId
                      select new { ra.PKId };
            return (res as IQueryable<int>).ToList();
        }
    }
}