using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Commands.CreateOrganizationalUnit
{
    public class CreateOrganizationalUnitCommandHandler : AsyncRequestHandler<CreateOrganizationalUnitCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CreateOrganizationalUnitCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateOrganizationalUnitCommand request, CancellationToken cancellationToken)
        {
            var organizationalUnit = mapper.Map<OrganizationalUnit>(request);
            await dbContext.AddAsync(organizationalUnit);
            await dbContext.SaveChangesAsync();
        }
    }
}
