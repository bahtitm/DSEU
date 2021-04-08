namespace DSEU.Application.Common.Enums
{
    public enum UserClaimTypes
    {
        //Claim-ы Для роли администратора

        /// <summary>
        /// Управление записями в справочниках
        /// </summary>
        ManipulateWithDataBookEntries,
        ManipulateWithDataBookEntriesRead,
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        UserRegistration,
        UserRegistrationRead,
        /// <summary>
        /// Регистрация роли пользователя
        /// </summary>
        UserClaimRoleRegistration,
        UserClaimRoleRegistrationRead,

        //Claim-ы для регистратора

        /// <summary>
        /// Регистрация заявления
        /// </summary>
        RegistrationOfStatement,
        RegistrationOfStatementRead,
        /// <summary>
        /// Регистрация права
        /// </summary>
        RegistrationOfRight,
        RegistrationOfRightRead,
        /// <summary>
        /// Право на изменение
        /// </summary>
        RightToChange,
        RightToChangeRead,
        /// <summary>
        /// Право на технические изменения
        /// </summary>
        RightToTechnicalChange,
        RightToTechnicalChangeRead,
        /// <summary>
        /// Регистрация ареста
        /// </summary>
        RegistrationOfArrest,
        RegistrationOfArrestRead,
        /// <summary>
        /// Регистрация залога
        /// </summary>
        RegistrationOfBail,
        RegistrationOfBailRead,

        //Claim-ы для архиватора

        /// <summary>
        /// Принятие в архив
        /// </summary>
        AcceptanceToArchive,
        AcceptanceToArchiveRead
    }
}

