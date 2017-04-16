using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AssureNetServicesPOC.Controllers
{
    public interface IFileProvider
    {
        bool Exists(string name);
        FileStream Open(string name);
        long GetLength(string name);
    }
}