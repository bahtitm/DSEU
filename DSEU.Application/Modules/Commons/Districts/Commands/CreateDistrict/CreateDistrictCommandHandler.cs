using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.RealEstateRights.Cases;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Commons.Districts.Commands.CreateDistrict
{
    public class CreateDistrictCommandHandler : AsyncRequestHandler<CreateDistrictCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateDistrictCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateDistrictCommand request, CancellationToken cancellationToken)
        {
            var district = mapper.Map<District>(request);
            await dbContext.AddAsync(district);
            await dbContext.SaveChangesAsync();
        }
    }
}
