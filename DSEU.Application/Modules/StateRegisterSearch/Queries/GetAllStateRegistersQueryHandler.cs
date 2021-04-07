using AutoMapper;
using DSEU.StateRegisterSearch.Interfaces;
using DSEU.StateRegisterSearch.Interfaces.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.StateRegisterSearch.Queries
{
    public class GetAllStateRegistersQueryHandler : IRequestHandler<GetAllStateRegistersQuery, IEnumerable<StateRegisterSearchModel>>
    {
        private readonly IStateRegisterSearchService elasticSearchService;
        private readonly IMapper mapper;

        public GetAllStateRegistersQueryHandler(IStateRegisterSearchService elasticSearchService, IMapper mapper)
        {
            this.elasticSearchService = elasticSearchService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<StateRegisterSearchModel>> Handle(GetAllStateRegistersQuery request, CancellationToken cancellationToken)
        {
            var result = await elasticSearchService.GetAsync(request.Query, request.RegionId, request.DistrictId, request.SearchField);

            return result;
        }
    }
}
