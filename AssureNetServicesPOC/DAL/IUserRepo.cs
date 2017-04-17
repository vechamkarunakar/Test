using AssureNetServicesPOC.Models;
using System.Collections.Generic;

namespace AssureNetServicesPOC.DAL
{
    public interface IUserRepo
    {
        ActiveUser GetUser(string Alias);
        List<string> GetUserRoles(string Alias);


    }
}