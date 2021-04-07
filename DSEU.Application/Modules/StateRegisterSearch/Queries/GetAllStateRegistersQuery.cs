using DSEU.StateRegisterSearch.Interfaces.Dtos;
using DSEU.StateRegisterSearch.Interfaces.Enums;
using MediatR;
using System.Collections.Generic;

namespace DSEU.Application.Modules.StateRegisterSearch.Queries
{
    public class GetAllStateRegistersQuery : IRequest<IEnumerable<StateRegisterSearchModel>>
    {
        public string Query { get; set; }
        public List<int?> RegionId { get; set; }
        public List<int?> DistrictId { get; set; }
        public SearchField SearchField { get; set; }
    }
}
