using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.Company;
using DSEU.Domain.Events;

namespace DSEU.Application.Modules.Company.Employees.Commands.EditEmployee
{
    public class EditEmployeeCommandHandler : AsyncRequestHandler<EditEmployeeCommand>
    {
        private const int END_BLOCKING_DATE_IN_YEARS = 100;

        private readonly IApplicationDbContext dbContext;
        private readonly IIdentityService userManager;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly IRecipientLinkService recipientLinkService;
        private readonly IEmployeePhotoService employeePhotoService;

        public EditEmployeeCommandHandler(IApplicationDbContext dbContext,
            IIdentityService userManager,
            IMapper mapper,
            IMediator mediator,
            IRecipientLinkService recipientLinkService,
            IEmployeePhotoService employeePhotoService)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.mapper = mapper;
            this.mediator = mediator;
            this.recipientLinkService = recipientLinkService;
            this.employeePhotoService = employeePhotoService;
        }
        protected override async Task Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
        {
            await dbContext.InvokeTransactionAsync(async () =>
            {
                var employee = await dbContext.Set<Employee>().Include(p => p.Login).SingleAsync(p => p.Id == request.Id, cancellationToken);

                bool needReevaluatePermissions = employee.DepartmentId != request.DepartmentId || employee.Status != request.Status;

                if (employee.Login.LoginName != request.UserName)
                    await UpdateEmployeeLogin(employee, request.UserName);

                if (employee.DepartmentId != request.DepartmentId)
                {
                    await UpdateDepartmentRecipientLinks(employee.DepartmentId, request.DepartmentId, employee);
                }

                await HandleUserStatus(request, employee);

                await UpdateEmployeePersonalPhoto(request, employee);

                if (employee.Email != request.Email)
                    await userManager.SetConfirmedEmailAsync(employee.UserId, request.Email);

                mapper.Map(request, employee);

                var jobTitle = await dbContext.FindByIdAsync<JobTitle>(request.JobTitleId);
                employee.Description = jobTitle.Name;

                await dbContext.SaveChangesAsync(cancellationToken);

                if (needReevaluatePermissions)
                    await mediator.Publish(new ReevaluatePermissions());

            }, cancellationToken);

        }

        private async Task UpdateEmployeeLogin(Employee employee, string newUserName)
        {
            await userManager.UpdateUsernameAsync(employee.UserId, newUserName);
            employee.Login.LoginName = newUserName;
        }

        private async Task HandleUserStatus(EditEmployeeCommand request, Employee employee)
        {
            if (request.Status == Status.Active)
            {
                if (employee.Status == Status.Closed)
                    await userManager.UnlockUserAsync(employee.UserId);
            }
            else
            {
                await userManager.LockUserAsync(employee.UserId, SystemTime.Now().AddYears(END_BLOCKING_DATE_IN_YEARS));
            }
        }

        private async Task UpdateDepartmentRecipientLinks(int? oldDepartmentId, int newDepartmentId, Employee employee)
        {
            if (oldDepartmentId.HasValue)
            {
                await recipientLinkService.RemoveRecipientLink<DepartmentRecipientLinks>(oldDepartmentId.Value, employee.Id);
            }

            if (!await recipientLinkService.Exists<DepartmentRecipientLinks>(newDepartmentId, employee.Id))
                await recipientLinkService.CreateRecipientLink<DepartmentRecipientLinks>(newDepartmentId, employee.Id);
        }

        private async Task UpdateEmployeePersonalPhoto(EditEmployeeCommand request, Employee employee)
        {
            if (request.PersonalPhoto != null)
            {
                var photoStream = request.PersonalPhoto.OpenReadStream();

                var newPhotoHash = await employeePhotoService.CreateThumbnail(photoStream);

                if (employee.PersonalPhotoHash != null)
                {
                    employeePhotoService.RemoveThumbnail(employee.PersonalPhotoHash);
                }

                employee.PersonalPhotoHash = newPhotoHash;
                photoStream.Position = 0;
                using var ms = new MemoryStream();
                await photoStream.CopyToAsync(ms);
                employee.PersonalPhoto = ms.ToArray();
            }
        }
    }
}
