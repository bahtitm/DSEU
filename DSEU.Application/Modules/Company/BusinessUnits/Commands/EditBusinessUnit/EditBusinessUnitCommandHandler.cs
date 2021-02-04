using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities.Company;
using DSEU.Domain.Events;

namespace DSEU.Application.Modules.Company.BusinessUnits.Commands.EditBusinessUnit
{
    public class EditBusinessUnitCommandHandler : AsyncRequestHandler<EditBusinessUnitCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IRoleMemberService roleMemberService;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        public EditBusinessUnitCommandHandler(IApplicationDbContext dbContext,
            IRoleMemberService roleMemberService,
            IMapper mapper, IMediator mediator)
        {
            this.dbContext = dbContext;
            this.roleMemberService = roleMemberService;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        protected override async Task Handle(EditBusinessUnitCommand request, CancellationToken cancellationToken)
        {
            await dbContext.InvokeTransactionAsync(async () =>
            {
                var businessUnit = await dbContext.Set<BusinessUnit>()
                                                  .Include(p => p.Company)
                                                  .Include(p => p.HeadCompany)
                                                  .Include(p => p.Departments)
                                                  .SingleAsync(p => p.Id == request.Id, cancellationToken);

                bool ceoWasChanged = businessUnit.CEO != request.CEO;

                if (ceoWasChanged && request.CEO.HasValue)
                {
                    await roleMemberService.GrantRoleIfNotExists(request.CEO.Value, SystemRoles.BusinessUnitHead);
                    await roleMemberService.GrantRoleIfNotExists(request.CEO.Value, SystemRoles.Signer);
                }

                bool headCompanyChanged = businessUnit.HeadCompanyId != request.HeadCompanyId;
                if (headCompanyChanged)
                {
                    if (businessUnit.HeadCompanyId.HasValue)
                    {
                        businessUnit.Parent = businessUnit.HeadCompany = await dbContext.Set<BusinessUnit>().FindAsync(request.HeadCompanyId);
                    }
                    else
                        businessUnit.Parent = businessUnit.HeadCompany = default;

                }

                mapper.Map(request, businessUnit);
                businessUnit.ReevaluateDepartmentsDescription();
                await dbContext.SaveChangesAsync(cancellationToken);

                await UpdateCounterParty(businessUnit, cancellationToken);

            }, cancellationToken);

            await mediator.Publish(new ReevaluatePermissions());
        }

        private async Task UpdateCounterParty(BusinessUnit businessUnit, CancellationToken cancellationToken)
        {
            var company = await dbContext.Set<Domain.Entities.Parties.Company>().FindAsync(businessUnit.Company.Id);
            mapper.Map(businessUnit, company);
            if (businessUnit.HeadCompanyId.HasValue)
            {
                var headCounterpartyCompany = await dbContext.Set<Domain.Entities.Parties.Company>().FindAsync(businessUnit.HeadCompanyId);
                company.HeadCompany = headCounterpartyCompany;
            }
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
