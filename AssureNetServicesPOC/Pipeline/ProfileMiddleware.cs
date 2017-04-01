using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AssureNetServicesPOC.Pipeline
{
    public class ProfileMiddleware 
    {
        Func<IDictionary<string, object>, Task> _next = null;
        public ProfileMiddleware(Func<IDictionary<string,object>, Task> next )
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {

            var context = new OwinContext(env);
            

            await _next(env);
        }
    }
}