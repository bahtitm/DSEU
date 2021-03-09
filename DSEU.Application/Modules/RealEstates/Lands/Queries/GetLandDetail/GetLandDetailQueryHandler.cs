using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.RealEstates.Lands.Dtos;
using DSEU.Domain.Entities.RealEstates;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.RealEstates.Lands.Queries.GetLandDetail
{
    public class GetLandDetailQueryHandler : IRequestHandler<GetLandDetailQuery, LandDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetLandDetailQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<LandDto> Handle(GetLandDetailQuery request, CancellationToken cancellationToken)
        {
            var land = await dbContext.Set<Land>().FirstOrDefaultAsync(p => p.Id == request.Id);
            return mapper.Map<LandDto>(land);
        }
    }
}
