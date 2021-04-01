namespace DSEU.Application.Common.Enums
{
    public enum UserClaimTypes
    {
        //Claim-ы Для роли администратора
        /// <summary>
        /// Управление записями в книге данных
        /// </summary>
        ManipulateWithDataBookEntries,
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        UserRegistration,
        /// <summary>
        /// Регистрация роли пользователя
        /// </summary>
        UserClaimRoleRegistration,

        //Claim-ы для регистратора
        /// <summary>
        /// Регистрация заявления
        /// </summary>
        RegistrationOfStatement,
        /// <summary>
        /// Регистрация права
        /// </summary>
        RegistrationOfRight,
        /// <summary>
        /// Право на изменение
        /// </summary>
        RightToChange,
        /// <summary>
        /// Право на технические изменения
        /// </summary>
        RightToTechnicalChange,
        /// <summary>
        /// Регистрация ареста
        /// </summary>
        RegistrationOfArrest,
        /// <summary>
        /// Регистрация залога
        /// </summary>
        RegistrationOfBail,

        //Claim-ы для архиватора
        /// <summary>
        /// Принятие в архив
        /// </summary>
        AcceptanceToArchive
    }
}

