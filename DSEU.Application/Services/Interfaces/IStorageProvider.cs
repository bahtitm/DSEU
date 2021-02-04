using System.IO;
using System.Threading.Tasks;

namespace DSEU.Application.Services.Interfaces
{
    public interface IStorageProvider
    {
        Task Upload(Stream data, string objectName, string bucketName);
        Task<byte[]> Download(string objectName, string bucketName);
    }
}
