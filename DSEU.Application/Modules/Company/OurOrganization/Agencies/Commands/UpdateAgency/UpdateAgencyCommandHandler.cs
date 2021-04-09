using AutoMapper;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Agencies.Commands.UpdateAgency
{
    public class UpdateAgencyCommandHandler : AsyncRequestHandler<UpdateAgencyCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public UpdateAgencyCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(UpdateAgencyCommand request, CancellationToken cancellationToken)
        {
            var agency = await dbContext.FindByIdAsync<Agency>(request.Id);
            mapper.Map(request, agency);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
