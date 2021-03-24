using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.ElasticSearch.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.ElasticSearch.Commands.DeleteElasticSearch
{
    public class UpdateElasticSearchCommandHandler : AsyncRequestHandler<UpdateElasticSearchCommand>
    {
        private readonly IStateRegisterSearchService elastic;
        private readonly IMapper mapper;

        public UpdateElasticSearchCommandHandler(IStateRegisterSearchService elastic, IMapper mapper)
        {
            this.elastic = elastic;
            this.mapper = mapper;
        }

        protected override async Task Handle(UpdateElasticSearchCommand request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<ElasticStateRegister>(request);

            await elastic.UpdateAsync<ElasticStateRegister>(request.Id, result);
        }
    }
}
