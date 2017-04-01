using AssureNetServicesPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssureNetServicesPOC.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRepo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Alias"></param>
        /// <returns></returns>
        public ActiveUser GetUser(string Alias)
        {
            var user = new UnitOfWork<ActiveUser>().GetEntities.Get().Where<ActiveUser>(un => un.UserName.ToLower() == Alias).SingleOrDefault();
            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Alias"></param>
        /// <returns></returns>
        public List<string> GetUserRoles(string Alias)
        {
            List<string> roles = new List<string>();
            var user = new UnitOfWork<ActiveUser>().GetEntities.Get().Where<ActiveUser>(un => un.UserName.ToLower() == Alias).SingleOrDefault();
            if (user.Role_Approver) roles.Add("Approver");
            if (user.Role_Reconciler) roles.Add("Reconciler");
            if (user.Role_Reviewer) roles.Add("Reviewer");
            if (user.Role_ProgramAdmin) roles.Add("ProgramAdmin");
            return roles;
        }
    }
}