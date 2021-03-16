using System.Collections.Generic;

namespace DSEU.Application.Common.Constants
{
    public static class UserClaimTypes
    {
        public static class User
        {
            /// <summary>
            /// Идентификатор сотрудника
            /// </summary>
            public const string Id = "UserId";
            public const string Regions = "Regions";
        }
        public static class RealEstate
        {
            public const string Read = "ReadRealEstate";
            public const string Register = "RegisterRealEstate";
            public static IEnumerable<string> All
            {
                get
                {
                    yield return RealEstate.Read;
                    yield return RealEstate.Register;
                }
            }
        }

        public static IEnumerable<string> All
        {
            get
            {
                foreach (var item in RealEstate.All)
                    yield return item;
            }
        }
    }
}
