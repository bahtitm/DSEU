namespace DSEU.Domain.Entities
{
    public enum SystemHistoryAction
    {
        /// <summary>
        /// Вход
        /// </summary>
        Login = 200,
        /// <summary>
        /// Неудачный вход
        /// </summary>
        LoginFailed = 300,
        /// <summary>
        /// Выход
        /// </summary>
        Logout = 400,
    }
}
