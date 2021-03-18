using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.RealEstateRights;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Statements.Queries.GetAll
{
    public class StatementDto
    {

    }

    public class GetAllStatementsQuery : IRequest<IEnumerable<StatementDto>>
    {

    }

    public class GetAllStatementsQueryHandler : IRequestHandler<GetAllStatementsQuery, IEnumerable<StatementDto>>
    {
        private readonly ICurrentUserService currentUserService;
        private readonly IApplicationDbContext dbContext;

        public GetAllStatementsQueryHandler(ICurrentUserService currentUserService, IApplicationDbContext dbContext)
        {
            this.currentUserService = currentUserService;
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<StatementDto>> Handle(GetAllStatementsQuery request, CancellationToken cancellationToken)
        {
            var user = await currentUserService.GetUser();
            var localities = user.Localities.Select(p => p.LocalityId);
            var statements = dbContext.Set<Statement>().Where(p => localities.Contains(p.LocalityId));
            return null;
        }
    }

}
