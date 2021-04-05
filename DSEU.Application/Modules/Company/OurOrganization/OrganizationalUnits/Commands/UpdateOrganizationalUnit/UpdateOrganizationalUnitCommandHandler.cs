using AutoMapper;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Commands.UpdateOrganizationalUnit
{
    public class UpdateOrganizationalUnitCommandHandler : AsyncRequestHandler<UpdateOrganizationalUnitCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public UpdateOrganizationalUnitCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(UpdateOrganizationalUnitCommand request, CancellationToken cancellationToken)
        {
            var organizationalUnit = await dbContext.FindByIdAsync<OrganizationalUnit>(request.Id, cancellationToken);
            mapper.Map(request, organizationalUnit);
            await dbContext.SaveChangesAsync();
        }
    }
}
