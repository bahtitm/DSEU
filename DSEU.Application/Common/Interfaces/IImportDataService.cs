using System.IO;
using System.Threading.Tasks;

namespace DSEU.Application.Common.Interfaces
{
    public interface IImportDataService
    {
        Task ImportJobTitles(Stream excellFileStream);
        Task ImportCompanies(Stream stream);
        Task ImportBanks(Stream stream);
        Task ImportPersons(Stream stream);
        Task ImportEmployees(Stream stream);
    }
}