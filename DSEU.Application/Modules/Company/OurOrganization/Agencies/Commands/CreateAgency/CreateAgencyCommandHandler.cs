using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Agencies.Commands.CreateAgency
{
    public class CreateAgencyCommandHandler : AsyncRequestHandler<CreateAgencyCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CreateAgencyCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateAgencyCommand request, CancellationToken cancellationToken)
        {
            var agency = mapper.Map<Agency>(request);
            await dbContext.AddAsync(agency, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
