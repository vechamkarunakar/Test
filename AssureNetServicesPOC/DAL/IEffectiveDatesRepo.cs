using System;

namespace AssureNetServicesPOC.DAL
{
    public interface IEffectiveDatesRepo
    {
        DateTime FilterForFBIS();
    }
}