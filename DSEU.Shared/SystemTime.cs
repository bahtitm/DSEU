using System;

namespace DSEU.Shared
{
    public static class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.Now;
    }
}
