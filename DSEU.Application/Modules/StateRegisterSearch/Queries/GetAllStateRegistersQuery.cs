using DSEU.StateRegisterSearch.Interfaces.Dtos;
using DSEU.StateRegisterSearch.Interfaces.Enums;
using MediatR;
using System.Collections.Generic;

namespace DSEU.Application.Modules.StateRegisterSearch.Queries
{
    public record GetAllStateRegistersQuery(string Query, List<int?> RegionId, List<int?> DistrictId, SearchField SearchField) : IRequest<IEnumerable<StateRegisterSearchModel>>;
}
