
using System.Collections.Generic;

namespace DSEU.Application.Common.Constants
{
    public static class UserClaimTypesConstants
    {
        public const string EmployeeId = "EmployeeId";
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
                yield return UserClaimTypesConstants.ManipulateWithDataBookEntries;
                yield return UserClaimTypesConstants.UserRegistration;
                yield return UserClaimTypesConstants.UserClaimRoleRegistration;
                yield return UserClaimTypesConstants.RegistrationOfStatement;
                yield return UserClaimTypesConstants.RegistrationOfRight;
                yield return UserClaimTypesConstants.RightToChange;
                yield return UserClaimTypesConstants.RightToTechnicalChange;
                yield return UserClaimTypesConstants.RegistrationOfArrest;
                yield return UserClaimTypesConstants.RegistrationOfBail;
                yield return UserClaimTypesConstants.AcceptanceToArchive;
                yield return UserClaimTypesConstants.Read;
                yield return UserClaimTypesConstants.Register;
            }
        }
    }
}
