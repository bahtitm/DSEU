
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

        public const string Read = "ReadRealEstate";
        public const string Register = "RegisterRealEstate";

        public static IEnumerable<string> All
        {
            get
            {
                yield return UserClaimTypes.ManipulateWithDataBookEntries;
                yield return UserClaimTypes.UserRegistration;
                yield return UserClaimTypes.UserClaimRoleRegistration;
                yield return UserClaimTypes.RegistrationOfStatement;
                yield return UserClaimTypes.RegistrationOfRight;
                yield return UserClaimTypes.RightToChange;
                yield return UserClaimTypes.RightToTechnicalChange;
                yield return UserClaimTypes.RegistrationOfArrest;
                yield return UserClaimTypes.RegistrationOfBail;
                yield return UserClaimTypes.AcceptanceToArchive;
                yield return UserClaimTypes.Read;
                yield return UserClaimTypes.Register;
            }
        }
    }
}
