using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Modules.Company.Employees.Commands.EditEmployee
{
    public class EditEmployeeCommandValidator : AbstractValidator<EditEmployeeCommand>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;

        public EditEmployeeCommandValidator(IReadOnlyApplicationDbContext dbContext,
            ILocalizationService localizationService)
        {
            this.dbContext = dbContext;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(user => user.Name).NotEmpty();

            RuleFor(user => user.Email)
               .EmailAddress()
               .MustAsync(UniqEmail)
               .WithMessage(localizationService[LocalizationKeys.EmployeeKeys.EmailMustBeUniq])
               .When(p => !string.IsNullOrEmpty(p.Email));

            WhenAsync(JobTitleIdWasModified, () =>
            {
                RuleFor(p => p.JobTitleId)
                    .MustAsync(async (jobTitleId, ct) => await dbContext.IsActiveAsync<JobTitle>(jobTitleId, ct))
                    .WithMessage(localizationService.StatusMustBeActive);
            });

            WhenAsync(DepartmentIdWasModified, () =>
            {
                RuleFor(p => p.DepartmentId)
                    .MustAsync(async (departmentId, ct) => await dbContext.IsActiveAsync<Department>(departmentId, ct))
                    .WithMessage(localizationService.StatusMustBeActive);
            });
        }

        private async Task<bool> UniqEmail(EditEmployeeCommand command, string email, CancellationToken ct)
        {
            return !await dbContext.Query<Employee>().AnyAsync(p => p.Email == email && p.Id != command.Id);
        }

        private async Task<bool> JobTitleIdWasModified(EditEmployeeCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Employee>().AnyAsync(p => p.Id == command.Id && p.JobTitleId != command.JobTitleId, cancellationToken);
        }

        private async Task<bool> DepartmentIdWasModified(EditEmployeeCommand command, CancellationToken cancellationToken)
        {
            return await dbContext.Query<Employee>().AnyAsync(p => p.Id == command.Id && p.DepartmentId != command.DepartmentId, cancellationToken);
        }
    }
}
