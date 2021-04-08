using DSEU.StateRegisterSearch.Interfaces.Dtos;
using DSEU.StateRegisterSearch.Interfaces.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DSEU.StateRegisterSearch.Interfaces
{
    public interface IStateRegisterSearchService
    {
        Task<IEnumerable<StateRegisterSearchModel>> GetAsync(string query, List<int?> regionId, List<int?> districtId, SearchField searchField);
        Task AddSearchIndex(StateRegisterSearchModel stateRegister);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, StateRegisterSearchModel stateRegister);
    }
}
