using System.IO;
using System.Threading.Tasks;
using DSEU.Domain.Entities.Content;

namespace DSEU.Application.Services.Interfaces
{
    public interface IBinaryDataStorageProvider : IStorageProvider
    {
        Task Upload(Stream data, BinaryData binary);
        Task<byte[]> Download(BinaryData binary);
        Task Remove(BinaryData binaryData);
    }
}
