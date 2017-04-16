using AssureNetServicesPOC.Models;
using System.Collections.Generic;
using System.Linq;

namespace AssureNetServicesPOC.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRepo
    {
        private ActiveUser activeUser { get; set; }
        private IUnitOfWork<ActiveUser> uow;

        public UserRepo()
        {
            uow = new UnitOfWork<ActiveUser>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Alias"></param>
        /// <returns></returns>
        public ActiveUser GetUser(string Alias)
        {
            var user = uow.GetEntities.Get().Where<ActiveUser>(un => un.UserName.ToLower() == Alias).SingleOrDefault();
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