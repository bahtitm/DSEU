namespace DSEU.Domain.Entities
{
    public enum DocumentHistoryAction
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
        /// Создание версии
        /// </summary>
        CreateVersion = 40,
        /// <summary>
        /// Удаление версии
        /// </summary>
        RemoveVersion = 41,
        /// <summary>
        /// Удаление
        /// </summary>
        Delete = 50,
        /// <summary>
        /// Настройка прав
        /// </summary>
        Manage = 60,
        /// <summary>
        /// Регистрация
        /// </summary>
        Registration = 70,
        /// <summary>
        /// Отмена регистрации
        /// </summary>
        Deregistration = 80,
        /// <summary>
        /// Скачивание версии
        /// </summary>
        DownloadVersion = 90,
        /// <summary>
        /// Предпросмотр версии
        /// </summary>
        PreviewVersion = 100,
    }
}
