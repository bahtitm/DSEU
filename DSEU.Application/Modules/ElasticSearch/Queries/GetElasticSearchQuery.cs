using DSEU.Application.Modules.ElasticSearch.Dtos;
using DSEU.Application.Modules.ElasticSearch.Entities;
using DSEU.Application.Modules.ElasticSearch.Enum;
using MediatR;
using System.Collections.Generic;

namespace DSEU.Application.Modules.ElasticSearch.Queries
{
    public class GetElasticSearchQuery : IRequest<IEnumerable<ElasticStateRegister>>
    {
        public string Query { get; set; }
        public List<int?> RegionId { get; set; }
        public List<int?> DistrictId { get; set; }
        public SearchField SearchField { get; set; }
    }
}
