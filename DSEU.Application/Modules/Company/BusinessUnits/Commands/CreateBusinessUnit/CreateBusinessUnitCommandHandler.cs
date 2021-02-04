using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities.Company;
using DSEU.Domain.Events;

namespace DSEU.Application.Modules.Company.BusinessUnits.Commands.CreateBusinessUnit
{
    public class CreateBusinessUnitCommandHandler : AsyncRequestHandler<CreateBusinessUnitCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IRoleMemberService roleMemberService;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public CreateBusinessUnitCommandHandler(IApplicationDbContext dbContext,
            IRoleMemberService roleMemberService,
            IMapper mapper, IMediator mediator)
        {
            this.dbContext = dbContext;
            this.roleMemberService = roleMemberService;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        protected override async Task Handle(CreateBusinessUnitCommand request, CancellationToken cancellationToken)
        {
            await dbContext.InvokeTransactionAsync(async () =>
            {
                BusinessUnit businessUnit = mapper.Map<BusinessUnit>(request);
                businessUnit.Company = await CreateReadonlyCompany(businessUnit);
                if (request.HeadCompanyId.HasValue)
                    businessUnit.Parent = businessUnit.HeadCompany = await dbContext.Set<BusinessUnit>().FindAsync(request.HeadCompanyId);
                await dbContext.AddAsync(businessUnit);
                await dbContext.SaveChangesAsync();

                if (request.CEO.HasValue)
                {
                    await roleMemberService.GrantRoleIfNotExists(request.CEO.Value, SystemRoles.BusinessUnitHead);
                    await roleMemberService.GrantRoleIfNotExists(request.CEO.Value, SystemRoles.Signer);
                }

                await mediator.Publish(new ReevaluatePermissions());

            }, cancellationToken);
        }

        private async Task<Domain.Entities.Parties.Company> CreateReadonlyCompany(BusinessUnit businessUnit)
        {
            var company = mapper.Map<Domain.Entities.Parties.Company>(businessUnit);
            company.IsCardReadOnly = true;
            await dbContext.AddAsync(company);
            await dbContext.SaveChangesAsync();
            return company;
        }
    }
}
