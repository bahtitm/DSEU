using AutoMapper;
using MediatR;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities.Company;
using DSEU.Domain.Entities.CoreEntities;
//using DSEU.Domain.Entities.Docflow;
using DSEU.Domain.Events;

namespace DSEU.Application.Modules.Company.Employees.Commands.RegisterEmployee
{
    public class RegisterEmployeeCommandHandler : AsyncRequestHandler<RegisterEmployeeCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IIdentityService identityService;
        private readonly IMediator mediator;
        private readonly IRecipientLinkService recipientLinkService;
        private readonly IRoleMemberService roleMemberService;
        private readonly IEmployeePhotoService employeePhotoService;

        public RegisterEmployeeCommandHandler(IApplicationDbContext dbContext,
            IMapper mapper,
            IIdentityService identityService,
            IRecipientLinkService recipientLinkService,
            IRoleMemberService roleMemberService,
            IMediator mediator,
            IEmployeePhotoService employeePhotoService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.identityService = identityService;
            this.mediator = mediator;
            this.recipientLinkService = recipientLinkService;
            this.roleMemberService = roleMemberService;
            this.employeePhotoService = employeePhotoService;
        }

        protected override async Task Handle(RegisterEmployeeCommand request, CancellationToken cancellationToken)
        {
            await dbContext.InvokeTransactionAsync(async () =>
            {
                var jobTitle = await dbContext.FindByIdAsync<JobTitle>(request.JobTitleId);
                Employee employee = mapper.Map<Employee>(request);
                //todo history link
                //employee.PersonalSetting = new PersonalSetting();
                employee.UserId = await identityService.CreateUserAsync(request.UserName, request.Email, request.Password, request.NeedChangePassword, cancellationToken);
                employee.Login = new Login() { LoginName = request.UserName, AuthenticationType = AuthenticationType.Password };
                employee.Description = jobTitle.Name;
                await dbContext.AddAsync(employee);
                await dbContext.SaveChangesAsync();

                await roleMemberService.GrantRole(employee.Id, SystemRoles.User);
                await recipientLinkService.CreateRecipientLink<DepartmentRecipientLinks>(request.DepartmentId, employee.Id);
                await identityService.AddToClaimAsync(employee.UserId, EmployeeClaimTypes.UserIdentifier, employee.Id, cancellationToken);

                await UploadPersonalPhoto(request, employee);

                await mediator.Publish(new ReevaluatePermissions());

            }, cancellationToken);
        }

        private async Task UploadPersonalPhoto(RegisterEmployeeCommand request, Employee employee)
        {
            if (request.PersonalPhoto != null)
            {
                Stream photoStream = request.PersonalPhoto.OpenReadStream();
                employee.PersonalPhotoHash = await employeePhotoService.CreateThumbnail(photoStream);

                photoStream.Position = 0;
                using var ms = new MemoryStream();
                await photoStream.CopyToAsync(ms);
                employee.PersonalPhoto = ms.ToArray();

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
