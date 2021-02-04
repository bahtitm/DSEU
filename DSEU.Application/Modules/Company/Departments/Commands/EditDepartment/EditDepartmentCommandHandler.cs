using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities.Company;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Domain.Events;

namespace DSEU.Application.Modules.Company.Departments.Commands.EditDepartment
{
    public class EditDepartmentCommandHandler : AsyncRequestHandler<EditDepartmentCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IRoleMemberService roleMemberService;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public EditDepartmentCommandHandler(IApplicationDbContext dbContext,
                                            IRoleMemberService roleMemberService,
                                            IMapper mapper,
                                            IMediator mediator)
        {
            this.dbContext = dbContext;
            this.roleMemberService = roleMemberService;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        protected override async Task Handle(EditDepartmentCommand request, CancellationToken cancellationToken)
        {
            await dbContext.InvokeTransactionAsync(async () =>
            {
                var department = await dbContext.FindByIdAsync<Department>(request.Id, cancellationToken);
                
                bool managerChanged = department.ManagerId != request.ManagerId;
                if (managerChanged)
                {
                    await RemoveOldDepartmentManager(department.ManagerId);
                    await AppointNewDepartmentManager(request.ManagerId);
                }

                bool headOfficeChanged = department.HeadOfficeId != request.HeadOfficeId;
                if (headOfficeChanged)
                {
                    department.Parent = await GetDepartmentParent(request);
                }

                mapper.Map(request, department);
                
                var businessUnit = await dbContext.Query<BusinessUnit>().FirstOrDefaultAsync(p => p.Id == request.BusinessUnitId);
                department.Description = businessUnit.Name;
                await dbContext.SaveChangesAsync(cancellationToken);

                await mediator.Publish(new ReevaluatePermissions());

            }, cancellationToken);
        }

        private async Task RemoveOldDepartmentManager(int? managerId)
        {
            if (managerId.HasValue)
                await roleMemberService.RemoveFromRoleIfExists(managerId.Value, SystemRoles.DepartmentManager);
        }

        private async Task AppointNewDepartmentManager(int? managerId)
        {
            if (managerId.HasValue)
                await roleMemberService.GrantRoleIfNotExists(managerId.Value, SystemRoles.DepartmentManager);
        }

        private async Task<Group> GetDepartmentParent(EditDepartmentCommand request)
        {
            if (request.HeadOfficeId.HasValue)
                return await dbContext.Set<Department>().FindAsync(request.HeadOfficeId);
            else
                return await dbContext.Set<BusinessUnit>().FindAsync(request.BusinessUnitId);
        }
    }
}
