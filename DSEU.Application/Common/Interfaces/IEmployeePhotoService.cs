using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DSEU.Application.Common.Interfaces
{
    public interface IEmployeePhotoService
    {
        /// <summary>
        /// Создать миниатюру для фото сотрудника
        /// </summary>
        /// <param name="image"></param>
        /// <returns>Хэш картинки для поля PersonalPhotoHash</returns>
        Task<string> CreateThumbnail(Stream image);

        /// <summary>
        /// Удалить миниатюру для фото сотрудника
        /// </summary>
        /// <param name="personalPhotoHash"></param>
        /// <returns>Хэш картинки для поля PersonalPhotoHash</returns>
        void RemoveThumbnail(string personalPhotoHash);
    }
}
