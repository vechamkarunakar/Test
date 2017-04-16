using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssureNetServicesPOC.Controllers
{
    public class UserProvider
    {
        public UserProvider()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetUserAlias()
        {
            var loginName = HttpContext.Current.Request.LogonUserIdentity.Name;
            if (string.IsNullOrEmpty(loginName)) return null;
            //Assuming that login name always have domain\\useralias

            var domainAlias = loginName.Split("\\".ToCharArray());
            string userAlias = domainAlias[1];

            return userAlias;
        }
    }
}