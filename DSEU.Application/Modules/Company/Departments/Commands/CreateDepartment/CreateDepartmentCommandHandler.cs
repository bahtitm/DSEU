using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities.Company;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Domain.Events;

namespace DSEU.Application.Modules.Company.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandHandler : AsyncRequestHandler<CreateDepartmentCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IRecipientLinkService recipientLinkService;
        private readonly IRoleMemberService roleMemberService;
        private readonly IMediator mediator;

        public CreateDepartmentCommandHandler(IApplicationDbContext dbContext, IMapper mapper,
            IRecipientLinkService recipientLinkService,
            IRoleMemberService roleMemberService, IMediator mediator)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.recipientLinkService = recipientLinkService;
            this.roleMemberService = roleMemberService;
            this.mediator = mediator;
        }

        protected override async Task Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            await dbContext.InvokeTransactionAsync(async () =>
            {
                Department department = mapper.Map<Department>(request);
                department.Parent = await GetParentGroup(request);
                var businessUnit = await dbContext.Query<BusinessUnit>().FirstOrDefaultAsync(p => p.Id == request.BusinessUnitId);
                department.Description = businessUnit.Name;
                await dbContext.AddAsync(department);
                await dbContext.SaveChangesAsync();

                if (request.ManagerId.HasValue)
                    await roleMemberService.GrantRoleIfNotExists(request.ManagerId.Value, SystemRoles.DepartmentManager);

                await mediator.Publish(new ReevaluatePermissions());

            }, cancellationToken);
        }

        private async Task<Group> GetParentGroup(CreateDepartmentCommand request)
        {
            if (request.HeadOfficeId.HasValue)
                return await dbContext.Set<Department>().FindAsync(request.HeadOfficeId);
            else
                return await dbContext.Set<BusinessUnit>().FindAsync(request.BusinessUnitId);
        }
    }
}
