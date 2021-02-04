using System.Collections.Generic;
using System.Threading.Tasks;
using DSEU.Application.Dtos;

namespace DSEU.Application.Common.Interfaces
{
    public interface IActiveUserManager
    {
        /// <summary>
        /// Достигнут лимит пользователей
        /// </summary>
        bool LimitReached { get; }
        /// <summary>
        /// Пользователь соединился 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task UserConnected(string userId);
        /// <summary>
        /// Пользователь разединился
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        void UserDisconnected(string userId);
        /// <summary>
        /// Завершить сеанс пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task EndSession(string userId);
        /// <summary>
        /// Получить всех активных пользователей
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ActiveUser>> GetActiveUsersAsync();
    }
}
