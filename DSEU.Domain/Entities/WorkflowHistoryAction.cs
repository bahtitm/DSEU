namespace DSEU.Domain.Entities
{
    public enum WorkflowHistoryAction
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
        /// <summary>
        /// Запущена задача
        /// </summary>
        Run = 500,
        /// <summary>
        /// Рестарт задачи
        /// </summary>
        Restart = 600,
        /// <summary>
        /// Прекращение задачи
        /// </summary>
        Abort = 700,
    }
}
