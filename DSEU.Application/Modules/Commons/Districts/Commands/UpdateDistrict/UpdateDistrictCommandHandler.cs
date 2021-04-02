using AutoMapper;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.RealEstateRights.Cases;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Commons.Districts.Commands.UpdateDistrict
{
    public class UpdateDistrictCommandHandler : AsyncRequestHandler<UpdateDistrictCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public UpdateDistrictCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(UpdateDistrictCommand request, CancellationToken cancellationToken)
        {
            var district = await dbContext.FindByIdAsync<District>(request.Id);
            mapper.Map(request, district);
            await dbContext.SaveChangesAsync();
        }
    }
}
