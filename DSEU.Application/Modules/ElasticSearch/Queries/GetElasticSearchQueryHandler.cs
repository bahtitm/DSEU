using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.ElasticSearch.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.ElasticSearch.Queries
{
    public class GetElasticSearchQueryHandler : IRequestHandler<GetElasticSearchQuery, IEnumerable<ElasticStateRegister>>
    {
        private readonly IStateRegisterSearchService elasticSearchService;
        private readonly IMapper mapper;

        public GetElasticSearchQueryHandler(IStateRegisterSearchService elasticSearchService, IMapper mapper)
        {
            this.elasticSearchService = elasticSearchService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ElasticStateRegister>> Handle(GetElasticSearchQuery request, CancellationToken cancellationToken)
        {
            var result = await elasticSearchService.GetAsync(request.Query, request.RegionId, request.DistrictId, request.SearchField);


            return result;
        }
    }
}
