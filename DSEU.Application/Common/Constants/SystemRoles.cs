namespace DSEU.Application.Common.Constants
{

    public static class SystemRoles
    {
        public static string[] All =
        {
            Admin,
            Auditor,
            User,
            DepartmentManager,
            BusinessUnitHead,
            ResponsibleForContracts,
            ResponsibleForTheFinancialArchive,
            ResponsibleForCounterparts,
            ResponsibleForRegistrationSettings,
            DocumentDeletion,
            Signer,
            Service
        };

        public const string Admin = "Admin";
        public const string Auditor = "Auditor";
        public const string Clerk = "Clerk";
        public const string User = "User";
        public const string DepartmentManager = "DepartmentManager";
        public const string BusinessUnitHead = "BusinessUnitHead";
        public const string ResponsibleForContracts = "ResponsibleForContracts";
        public const string ResponsibleForTheFinancialArchive = "ResponsibleForTheFinancialArchive";
        public const string ResponsibleForCounterparts = "ResponsibleForCounterparts";
        public const string ResponsibleForRegistrationSettings = "ResponsibleForRegistrationSettings";
        public const string DocumentDeletion = "DocumentDeletion";
        public const string Signer = "Signer";
        public const string Service = "Service";
    }
}
