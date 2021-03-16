using AutoMapper;
using AutoMapper.QueryableExtensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Company.OurOrganization.ForUser.Dtos;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.ForUser.Queries.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<UserDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllUserQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<UserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<User>().ProjectTo<UserDto>(mapper.ConfigurationProvider));
        }
    }
}
