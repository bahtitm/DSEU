using DSEU.Application.Modules.ElasticSearch.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DSEU.Application.Common.Interfaces
{
    public interface IStateRegisterSearchService
    {
        Task<IEnumerable<StateRegisterSearchModel>> GetAsync(string query, List<int?> regionId, List<int?> districtId, SearchField searchField);
        Task AddSearchIndex<T>(T stateRegister) where T : class;
        Task DeleteAsync(int id);
        Task UpdateAsync<T>(int id, T stateRegister) where T : class;
    }
}