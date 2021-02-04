using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos.Company;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Modules.Company.ManagersAssistants.Queries
{
    public class GetAllManagersAssistantsQueryHandler : IRequestHandler<GetAllManagersAssistantsQuery, IEnumerable<ManagersAssistantDto>>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllManagersAssistantsQueryHandler(IReadOnlyApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<ManagersAssistantDto>> Handle(GetAllManagersAssistantsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Query<ManagersAssistant>().Include(p => p.Manager).Include(p => p.Assistant).ProjectTo<ManagersAssistantDto>(mapper.ConfigurationProvider));
        }
    }
}
