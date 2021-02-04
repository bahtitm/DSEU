using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos.CoreEntities;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Modules.CoreEntities.Logins.Queries.Handlers
{
    public class GetAllLoginsQueryHandler : IRequestHandler<GetAllLoginsQuery, IEnumerable<LoginDto>>,
        IRequestHandler<GetLoginsByIdQuery, LoginDto>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllLoginsQueryHandler(IReadOnlyApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<LoginDto>> Handle(GetAllLoginsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Query<Login>().ProjectTo<LoginDto>(mapper.ConfigurationProvider));
        }

        public async Task<LoginDto> Handle(GetLoginsByIdQuery request, CancellationToken cancellationToken)
        {
            var login = await dbContext.Query<Login>().FirstOrDefaultAsync(m => m.Id == request.Id);
            return mapper.Map<LoginDto>(login);
        }
    }
}
