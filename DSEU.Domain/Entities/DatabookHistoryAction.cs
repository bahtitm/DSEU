namespace DSEU.Domain.Entities
{
    public enum DatabookHistoryAction
    {
        /// <summary>
        /// Создание
        /// </summary>
        Create = 10,
        /// <summary>
        /// Просмотр
        /// </summary>
        Read = 20,
        /// <summary>
        /// Изменение
        /// </summary>
        Update = 30,
        /// <summary>
        /// Удаление
        /// </summary>
        Delete = 50,
        /// <summary>
        /// Настройка прав
        /// </summary>
        Manage = 60,
    }
}
