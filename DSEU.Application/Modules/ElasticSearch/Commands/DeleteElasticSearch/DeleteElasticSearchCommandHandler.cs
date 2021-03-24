using DSEU.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.ElasticSearch.Commands.DeleteElasticSearch
{
    public class DeleteElasticSearchCommandHandler : AsyncRequestHandler<DeleteElasticSearchCommand>
    {
        private readonly IStateRegisterSearchService elastic;

        public DeleteElasticSearchCommandHandler(IStateRegisterSearchService elastic)
        {
            this.elastic = elastic;
        }

        protected override async Task Handle(DeleteElasticSearchCommand request, CancellationToken cancellationToken)
        {
            await elastic.DeleteAsync(request.id);
        }
    }
}
