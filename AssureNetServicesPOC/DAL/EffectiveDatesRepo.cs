using AssureNetServicesPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssureNetServicesPOC.DAL
{
    public class EffectiveDatesRepo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime FilterForFBIS()
        {
            DateTime filter = DateTime.Now.AddYears(-1).AddMonths(-2);
            return( new UnitOfWork<EffectiveDate>().GetEntities.Get().Where<EffectiveDate>(x => x.EffectiveDate1 >= filter).Take(1).ToList()[0].EffectiveDate1);
        }
    }
}