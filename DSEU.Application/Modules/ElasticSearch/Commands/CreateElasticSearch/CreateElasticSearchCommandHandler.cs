using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.ElasticSearch.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.ElasticSearch.Commands.CreateElasticSearch
{
    public class CreateElasticSearchCommandHandler : AsyncRequestHandler<CreateElasticSearchCommand>
    {
        private readonly IStateRegisterSearchService elasticSearchService;
        private readonly IMapper mapper;

        public CreateElasticSearchCommandHandler(IStateRegisterSearchService elasticSearchService, IMapper mapper)
        {
            this.elasticSearchService = elasticSearchService;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateElasticSearchCommand request, CancellationToken cancellationToken)
        {
            var elastic = mapper.Map<ElasticStateRegister>(request);
            await elasticSearchService.IndexDocumentAsync(elastic);
        }
    }
}
