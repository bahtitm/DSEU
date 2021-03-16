using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Company.OurOrganization.ForUser.Dtos;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.ForUser.Queries.GetUserDetail
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetUserDetailQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var emplooyee = await dbContext.Set<User>().FirstOrDefaultAsync(emp => emp.Id == request.id);
            return mapper.Map<UserDto>(emplooyee);
        }
    }
}
