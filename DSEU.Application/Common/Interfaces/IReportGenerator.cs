using System.Threading.Tasks;

namespace DSEU.Application.Common.Interfaces
{
    public interface IReportGenerator
    {
        Task<(string contentType, byte[] data)> Generate<TData>(IReport<TData> report) where TData : class;
    }
}
