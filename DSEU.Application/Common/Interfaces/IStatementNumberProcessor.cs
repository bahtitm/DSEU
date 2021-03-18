using System.Threading.Tasks;

namespace DSEU.Application.Common.Interfaces
{
    public interface IStatementNumberProcessor
    {
        /// <summary>
        /// Сгенерировать следующий порядковый номер
        /// </summary>
        /// <returns></returns>
        Task<int> GenerateIndex(int localityId);
    }
}
