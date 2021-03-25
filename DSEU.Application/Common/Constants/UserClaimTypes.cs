using System.Collections.Generic;

namespace DSEU.Application.Common.Constants
{
    public static class UserClaimTypes
    {
        //Claim-ы Для роли администратора
        public const string ManipulateWithDataBookEntries = "ManipulateWithDataBookEntries";
        public const string UserRegistration = "UserRegistration";
        public const string UserClaimRoleRegistration = "UserClaimRoleRegistration";
        //Claim-ы для регистратора
        public const string RegistrationOfStatement= "RegistrationOfStatement";
        public const string RegistrationOfRight = "RegistrationOfRight";
        public const string RightToChange = "RightToChange";
        public const string RightToTechnicalChange = "RightToTechnicalChange";
        public const string RegistrationOfArrest = "RegistrationOfArrest";
        public const string RegistrationOfBail = "RegistrationOfBail";
        //Claim-ы для архиватора
        public const string AcceptanceToArchive = "AcceptanceToArchive";
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
