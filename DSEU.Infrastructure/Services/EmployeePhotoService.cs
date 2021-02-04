using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Threading.Tasks;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Company;

namespace DSEU.Infrastructure.Services
{
    ///<inheritdoc/>
    public class EmployeePhotoService : IEmployeePhotoService
    {
        public const string employeeThumbnailDirectory = "PrivateStaticFiles/Employees/Thumbnails/";

        /// <inheritdoc/>
        public async Task<string> CreateThumbnail(Stream image)
        {
            var personalPhotoHash = Guid.NewGuid().ToString();
            var savePath = Path.Combine(employeeThumbnailDirectory, GenerateFileNameByHash(personalPhotoHash));

            if (!Directory.Exists(employeeThumbnailDirectory))
                Directory.CreateDirectory(employeeThumbnailDirectory);

            await using var stream = File.Create(savePath);
            using var imageProcessor = await Image.LoadAsync(image);
            imageProcessor.Mutate(x => x.Resize(36, 36));

            await imageProcessor.SaveAsync(stream, new PngEncoder());

            return personalPhotoHash;
        }

        private static string GenerateFileNameByHash(string personalPhotoHash)
        {
            return $"{personalPhotoHash}.png";
        }

        public void RemoveThumbnail(string personalPhotoHash)
        {
            var removePath = Path.Combine(employeeThumbnailDirectory, GenerateFileNameByHash(personalPhotoHash));
            if (File.Exists(removePath))
                File.Delete(removePath);
        }
    }
}
